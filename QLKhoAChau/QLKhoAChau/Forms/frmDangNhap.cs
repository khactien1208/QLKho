using System;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmDangNhap : Form
    {
        TextBox txtUser, txtPass;
        Button btnLogin, btnExit;

        public frmDangNhap()
        {
            Text = "Đăng nhập - Quản lý kho Á Châu";
            Size = new Size(420, 280);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;

            var lblTitle = new Label {
                Text = "BÁNH KẸO Á CHÂU",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 57, 43),
                Location = new Point(20, 15), Size = new Size(380, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            var lblSub = new Label {
                Text = "Hệ thống quản lý nhập - xuất - tồn kho",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                Location = new Point(20, 45), Size = new Size(380, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblU = new Label { Text = "Tên đăng nhập:", Location = new Point(40, 90), AutoSize = true };
            txtUser = new TextBox { Location = new Point(150, 87), Size = new Size(220, 25), Text = "admin" };
            var lblP = new Label { Text = "Mật khẩu:", Location = new Point(40, 125), AutoSize = true };
            txtPass = new TextBox { Location = new Point(150, 122), Size = new Size(220, 25), UseSystemPasswordChar = true, Text = "admin123" };

            btnLogin = new Button {
                Text = "Đăng nhập", Location = new Point(150, 170), Size = new Size(110, 35),
                BackColor = Color.FromArgb(192, 57, 43), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnExit = new Button { Text = "Thoát", Location = new Point(270, 170), Size = new Size(100, 35) };

            btnLogin.Click += BtnLogin_Click;
            btnExit.Click += (s,e) => { DialogResult = DialogResult.Cancel; Close(); };
            AcceptButton = btnLogin;

            Controls.AddRange(new Control[] { lblTitle, lblSub, lblU, txtUser, lblP, txtPass, btnLogin, btnExit });
        }

        void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var nd = NguoiDungDAL.DangNhap(txtUser.Text.Trim(), txtPass.Text);
                if (nd == null)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Program.CurrentUser = nd;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
