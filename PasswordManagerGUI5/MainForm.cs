using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace PasswordManagerGUI4
{
    public partial class MainForm : Form
    {
        private readonly string _dbPath;
        private readonly string _connStr;

        public MainForm()
        {
            InitializeComponent();
            _dbPath = Path.Combine(AppContext.BaseDirectory, "passwords.db");
            _connStr = "Data Source=" + _dbPath;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_dbPath))
            {
                MessageBox.Show("Database not found. Set master password first.", "Missing DB",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadGrid();
        }

        private void LoadGrid()
        {
            using (var conn = new SqliteConnection(_connStr))
            {
                conn.Open();
                using (var cmd = new SqliteCommand("SELECT Id, Website, Username, Password FROM Accounts ORDER BY Id DESC", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    dgvAccounts.DataSource = table;
                }
            }
        }

        private bool ValidateInputs(out string website, out string username, out string password)
        {
            website = (txtWebsite.Text ?? "").Trim();
            username = (txtUsername.Text ?? "").Trim();
            password = (txtPassword.Text ?? "").Trim();
            if (website.Length == 0) { MessageBox.Show("Website is required."); return false; }
            if (username.Length == 0) { MessageBox.Show("Username is required."); return false; }
            if (password.Length == 0) { MessageBox.Show("Password is required."); return false; }
            return true;
        }

        private int? GetSelectedId()
        {
            if (dgvAccounts.CurrentRow == null || dgvAccounts.CurrentRow.DataBoundItem == null) return null;
            var row = (dgvAccounts.CurrentRow.DataBoundItem as DataRowView)?.Row;
            if (row == null) return null;
            int id;
            return int.TryParse(row["Id"].ToString(), out id) ? (int?)id : null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string w, u, p;
            if (!ValidateInputs(out w, out u, out p)) return;

            try
            {
                using (var conn = new SqliteConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand("INSERT INTO Accounts (Website, Username, Password) VALUES ($w,$u,$p)", conn))
                    {
                        cmd.Parameters.AddWithValue("$w", w);
                        cmd.Parameters.AddWithValue("$u", u);
                        cmd.Parameters.AddWithValue("$p", p); // plaintext for learning demo
                        cmd.ExecuteNonQuery();
                    }
                }
                txtWebsite.Clear(); txtUsername.Clear(); txtPassword.Clear();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedId();
            if (id == null) { MessageBox.Show("Select a row to delete."); return; }

            if (MessageBox.Show("Delete selected account?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var conn = new SqliteConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand("DELETE FROM Accounts WHERE Id=$id", conn))
                    {
                        cmd.Parameters.AddWithValue("$id", id.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null || dgvAccounts.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Select a row first."); return;
            }

            var row = (dgvAccounts.CurrentRow.DataBoundItem as DataRowView)?.Row;
            if (row == null) { MessageBox.Show("Invalid selection."); return; }

            string site = Convert.ToString(row["Website"]);
            string user = Convert.ToString(row["Username"]);
            string pass = Convert.ToString(row["Password"]);

            MessageBox.Show(
                "Website: " + site + Environment.NewLine +
                "Username: " + user + Environment.NewLine +
                "Password: " + pass,
                "Reveal Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
