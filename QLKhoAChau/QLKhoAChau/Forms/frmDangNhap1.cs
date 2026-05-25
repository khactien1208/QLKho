using QLKhoAChau.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhoAChau.Forms
{
    public partial class frmDangNhap1 : Form
    {
        public frmDangNhap1()
        {
            InitializeComponent();
        }

        void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var nd = NguoiDungDAL.DangNhap(txtUser.Text.Trim(), txtPass.Text);

                if (nd == null)
                {
                    MessageBox.Show(
                        "Sai tên đăng nhập hoặc mật khẩu!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                Program.CurrentUser = nd;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không kết nối được CSDL:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
