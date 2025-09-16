namespace PasswordManagerGUI4
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReveal;
        private System.Windows.Forms.DataGridView dgvAccounts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReveal = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();

            // labels + textboxes
            this.lblWebsite.AutoSize = true; this.lblWebsite.Location = new System.Drawing.Point(20, 20); this.lblWebsite.Text = "Website:";
            this.txtWebsite.Location = new System.Drawing.Point(100, 17); this.txtWebsite.Size = new System.Drawing.Size(200, 20);

            this.lblUsername.AutoSize = true; this.lblUsername.Location = new System.Drawing.Point(20, 50); this.lblUsername.Text = "Username:";
            this.txtUsername.Location = new System.Drawing.Point(100, 47); this.txtUsername.Size = new System.Drawing.Size(200, 20);

            this.lblPassword.AutoSize = true; this.lblPassword.Location = new System.Drawing.Point(20, 80); this.lblPassword.Text = "Password:";
            this.txtPassword.Location = new System.Drawing.Point(100, 77); this.txtPassword.Size = new System.Drawing.Size(200, 20); this.txtPassword.UseSystemPasswordChar = true;

            // buttons
            this.btnAdd.Location = new System.Drawing.Point(100, 115); this.btnAdd.Size = new System.Drawing.Size(80, 25); this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(190, 115); this.btnDelete.Size = new System.Drawing.Size(80, 25); this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnReveal.Location = new System.Drawing.Point(280, 115); this.btnReveal.Size = new System.Drawing.Size(80, 25); this.btnReveal.Text = "Reveal";
            this.btnReveal.Click += new System.EventHandler(this.btnReveal_Click);

            // grid
            this.dgvAccounts.Location = new System.Drawing.Point(20, 160);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.Size = new System.Drawing.Size(500, 250);

            // form
            this.ClientSize = new System.Drawing.Size(550, 430);
            this.Controls.Add(this.lblWebsite); this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.lblUsername); this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword); this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnAdd); this.Controls.Add(this.btnDelete); this.Controls.Add(this.btnReveal);
            this.Controls.Add(this.dgvAccounts);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager - Main";
            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
