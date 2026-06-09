using System;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    /// <summary>
    /// Dialog thêm nhanh khách hàng mới ngay trong màn hình phiếu xuất.
    /// </summary>
    internal partial class frmThemKhachHang : Form
    {
        public int MaKHMoi { get; private set; }

        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Nhập tên khách hàng!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }

            try
            {
                MaKHMoi = PhieuXuatDAL.InsertKH(
                    txtTenKH.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    txtDienThoai.Text.Trim(),
                    txtEmail.Text.Trim());

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
