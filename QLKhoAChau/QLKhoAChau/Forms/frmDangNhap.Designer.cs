using System.Drawing;
using System.Windows.Forms;

namespace QLKhoAChau.Forms
{
    partial class frmDangNhap
    {
        private TextBox txtUser;
        private TextBox txtPass;

        private Button btnLogin;
        private Button btnExit;

        private Label lblTitle;
        private Label lblSub;
        private Label lblU;
        private Label lblP;

        private void InitializeComponent()
        {
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblTitle = new Label();
            lblSub = new Label();
            lblU = new Label();
            lblP = new Label();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Location = new Point(150, 87);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(220, 23);
            txtUser.TabIndex = 3;
            txtUser.Text = "admin";
            // 
            // txtPass
            // 
            txtPass.Location = new Point(150, 122);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(220, 23);
            txtPass.TabIndex = 5;
            txtPass.Text = "admin123";
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(192, 57, 43);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(150, 170);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(110, 35);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(270, 170);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 35);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.Click += BtnExit_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(192, 57, 43);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(380, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁNH KẸO Á CHÂU";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSub.Location = new Point(20, 45);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(380, 20);
            lblSub.TabIndex = 1;
            lblSub.Text = "Hệ thống quản lý nhập - xuất - tồn kho";
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblU
            // 
            lblU.AutoSize = true;
            lblU.Location = new Point(40, 90);
            lblU.Name = "lblU";
            lblU.Size = new Size(89, 15);
            lblU.TabIndex = 2;
            lblU.Text = "Tên đăng nhập:";
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(40, 125);
            lblP.Name = "lblP";
            lblP.Size = new Size(60, 15);
            lblP.TabIndex = 4;
            lblP.Text = "Mật khẩu:";
            // 
            // frmDangNhap
            // 
            AcceptButton = btnLogin;
            BackColor = Color.White;
            ClientSize = new Size(404, 241);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(lblU);
            Controls.Add(txtUser);
            Controls.Add(lblP);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Quản lý kho Á Châu";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}