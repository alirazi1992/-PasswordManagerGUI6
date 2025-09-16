namespace PasswordManagerGUI4
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSet;
        private System.Windows.Forms.Label lblSet1;
        private System.Windows.Forms.TextBox txtSet1;
        private System.Windows.Forms.Label lblSet2;
        private System.Windows.Forms.TextBox txtSet2;
        private System.Windows.Forms.Button btnSet;

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.Label lblMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSet = new System.Windows.Forms.Panel();
            this.lblSet1 = new System.Windows.Forms.Label();
            this.txtSet1 = new System.Windows.Forms.TextBox();
            this.lblSet2 = new System.Windows.Forms.Label();
            this.txtSet2 = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();

            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();

            this.lblMessage = new System.Windows.Forms.Label();

            // pnlSet
            this.pnlSet.Location = new System.Drawing.Point(12, 12);
            this.pnlSet.Size = new System.Drawing.Size(360, 120);
            this.pnlSet.Controls.Add(this.lblSet1);
            this.pnlSet.Controls.Add(this.txtSet1);
            this.pnlSet.Controls.Add(this.lblSet2);
            this.pnlSet.Controls.Add(this.txtSet2);
            this.pnlSet.Controls.Add(this.btnSet);

            this.lblSet1.Location = new System.Drawing.Point(10, 10);
            this.lblSet1.Size = new System.Drawing.Size(150, 20);
            this.lblSet1.Text = "Set master password:";

            this.txtSet1.Location = new System.Drawing.Point(170, 10);
            this.txtSet1.Size = new System.Drawing.Size(170, 20);
            this.txtSet1.UseSystemPasswordChar = true;

            this.lblSet2.Location = new System.Drawing.Point(10, 45);
            this.lblSet2.Size = new System.Drawing.Size(150, 20);
            this.lblSet2.Text = "Confirm password:";

            this.txtSet2.Location = new System.Drawing.Point(170, 45);
            this.txtSet2.Size = new System.Drawing.Size(170, 20);
            this.txtSet2.UseSystemPasswordChar = true;

            this.btnSet.Location = new System.Drawing.Point(235, 80);
            this.btnSet.Size = new System.Drawing.Size(105, 25);
            this.btnSet.Text = "Set & Continue";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);

            // pnlLogin
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Size = new System.Drawing.Size(360, 120);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.btnLogin);

            this.lblLogin.Location = new System.Drawing.Point(10, 20);
            this.lblLogin.Size = new System.Drawing.Size(150, 20);
            this.lblLogin.Text = "Master password:";

            this.txtPassword.Location = new System.Drawing.Point(170, 20);
            this.txtPassword.Size = new System.Drawing.Size(170, 20);
            this.txtPassword.UseSystemPasswordChar = true;

            this.btnLogin.Location = new System.Drawing.Point(235, 55);
            this.btnLogin.Size = new System.Drawing.Size(105, 25);
            this.btnLogin.Text = "Unlock";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // lblMessage
            this.lblMessage.Location = new System.Drawing.Point(12, 140);
            this.lblMessage.Size = new System.Drawing.Size(360, 30);
            this.lblMessage.Text = "";
            this.lblMessage.ForeColor = System.Drawing.Color.Firebrick;

            // Form
            this.ClientSize = new System.Drawing.Size(384, 176);
            this.Controls.Add(this.pnlSet);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vault Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
        }
    }
}
