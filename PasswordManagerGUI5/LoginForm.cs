using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace PasswordManagerGUI4
{
    public partial class LoginForm : Form
    {
        private readonly string _dbPath;
        private readonly string _connStr;

        public LoginForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(AppContext.BaseDirectory, "passwords.db");
            _connStr = "Data Source=" + _dbPath;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureDatabase();
                bool hasMaster = HasMasterPassword();
                pnlSet.Visible = !hasMaster;
                pnlLogin.Visible = hasMaster;
                lblMessage.Text = "";
                if (hasMaster) txtPassword.Focus(); else txtSet1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup error:\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void EnsureDatabase()
        {
            if (!File.Exists(_dbPath))
                using (File.Create(_dbPath)) { }

            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();

                const string sqlSettings = @"
CREATE TABLE IF NOT EXISTS Settings (
    Id INTEGER PRIMARY KEY CHECK (Id=1),
    MasterHash TEXT NOT NULL
);";
                using (var cmd = new SqliteCommand(sqlSettings, conn)) cmd.ExecuteNonQuery();

                const string sqlAccounts = @"
CREATE TABLE IF NOT EXISTS Accounts (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Website TEXT NOT NULL,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL
);";
                using (var cmd = new SqliteCommand(sqlAccounts, conn)) cmd.ExecuteNonQuery();
            }
        }

        private bool HasMasterPassword()
        {
            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new SqliteCommand("SELECT COUNT(1) FROM Settings WHERE Id=1", conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string p1 = (txtSet1.Text ?? "").Trim();
            string p2 = (txtSet2.Text ?? "").Trim();

            if (p1.Length < 6) { ShowMsg("Use at least 6 characters."); return; }
            if (p1 != p2) { ShowMsg("Passwords do not match."); return; }

            string hash = HashPassword(p1);

            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new SqliteCommand("INSERT INTO Settings (Id, MasterHash) VALUES (1, $h)", conn))
                {
                    cmd.Parameters.AddWithValue("$h", hash);
                    cmd.ExecuteNonQuery();
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pw = (txtPassword.Text ?? "").Trim();
            if (pw.Length == 0) { ShowMsg("Enter master password."); return; }

            string stored;
            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new SqliteCommand("SELECT MasterHash FROM Settings WHERE Id=1", conn))
                {
                    stored = cmd.ExecuteScalar() as string;
                }
            }

            if (string.IsNullOrEmpty(stored)) { ShowMsg("No master password found. Restart app."); return; }

            if (VerifyPassword(pw, stored))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                ShowMsg("Wrong master password.");
            }
        }

        private void ShowMsg(string text) => lblMessage.Text = text;

        private string HashPassword(string password)
        {
            using (var kdf = new Rfc2898DeriveBytes(password, 16, 10000, HashAlgorithmName.SHA256))
            {
                byte[] salt = kdf.Salt;
                byte[] key = kdf.GetBytes(32);
                byte[] blob = new byte[48];
                Buffer.BlockCopy(salt, 0, blob, 0, 16);
                Buffer.BlockCopy(key, 0, blob, 16, 32);
                return Convert.ToBase64String(blob);
            }
        }

        private bool VerifyPassword(string password, string stored)
        {
            try
            {
                byte[] blob = Convert.FromBase64String(stored);
                if (blob.Length != 48) return false;

                byte[] salt = new byte[16];
                byte[] key = new byte[32];
                Buffer.BlockCopy(blob, 0, salt, 0, 16);
                Buffer.BlockCopy(blob, 16, key, 0, 32);

                using (var kdf = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
                {
                    byte[] test = kdf.GetBytes(32);
                    return SlowEquals(key, test);
                }
            }
            catch { return false; }
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}
