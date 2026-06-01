using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public partial class frmHangHoa : Form
    {
        private int? selectedId = null;

        public frmHangHoa()
        {
            InitializeComponent();

            // Phân quyền: Nhân viên chỉ được xem, không sửa
            PhanQuyen.ApDungChiXem(
                btnEdit, btnDel,
                txtMaSP, txtTen, txtDVT, txtGiaNhap, txtGiaBan, txtTonMin,
                cboDM, cboNCC, dtpNSX, dtpHSD);
        }

        //  LOAD
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGrid(string.Empty);
        }

        private void LoadCombo()
        {
            cboDM.DataSource    = DanhMucDAL.GetAll();
            cboDM.DisplayMember = "TenDM";
            cboDM.ValueMember   = "MaDM";

            cboNCC.DataSource    = NhaCungCapDAL.GetAll();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember   = "MaNCC";
        }

        private void LoadGrid(string kw)
        {
            grid.DataSource = string.IsNullOrWhiteSpace(kw)
                ? HangHoaDAL.GetAll()
                : HangHoaDAL.Search(kw);

            // Ẩn cột kỹ thuật
            if (grid.Columns.Contains("MaHH"))        grid.Columns["MaHH"].Visible        = false;
            if (grid.Columns.Contains("TrangThaiLo")) grid.Columns["TrangThaiLo"].Visible  = false;

            // Đổi tên cột hiển thị
            if (grid.Columns.Contains("MaSP"))        grid.Columns["MaSP"].HeaderText        = "Mã SP";
            if (grid.Columns.Contains("TenHH"))       grid.Columns["TenHH"].HeaderText       = "Tên hàng hóa";
            if (grid.Columns.Contains("TenDM"))       grid.Columns["TenDM"].HeaderText       = "Danh mục";
            if (grid.Columns.Contains("DonViTinh"))   grid.Columns["DonViTinh"].HeaderText   = "ĐVT";
            if (grid.Columns.Contains("GiaNhap"))     grid.Columns["GiaNhap"].HeaderText     = "Giá nhập";
            if (grid.Columns.Contains("GiaBan"))      grid.Columns["GiaBan"].HeaderText      = "Giá bán";
            if (grid.Columns.Contains("TonKho"))      grid.Columns["TonKho"].HeaderText      = "Tồn kho";
            if (grid.Columns.Contains("TonToiThieu")) grid.Columns["TonToiThieu"].HeaderText = "Tồn tối thiểu";
            if (grid.Columns.Contains("NgaySanXuat")) grid.Columns["NgaySanXuat"].HeaderText = "Ngày SX";
            if (grid.Columns.Contains("HanSuDung"))   grid.Columns["HanSuDung"].HeaderText   = "Hạn SD";
            if (grid.Columns.Contains("NgayNhapLo"))  grid.Columns["NgayNhapLo"].HeaderText  = "Ngày nhập lô";
            if (grid.Columns.Contains("TenNCC"))      grid.Columns["TenNCC"].HeaderText      = "Nhà cung cấp";

            // Format ngày
            if (grid.Columns.Contains("NgaySanXuat"))
                grid.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (grid.Columns.Contains("HanSuDung"))
                grid.Columns["HanSuDung"].DefaultCellStyle.Format   = "dd/MM/yyyy";
            if (grid.Columns.Contains("NgayNhapLo"))
                grid.Columns["NgayNhapLo"].DefaultCellStyle.Format  = "dd/MM/yyyy HH:mm";

            // Cảnh báo lô hàng hết hạn
            int soLuongHetHan = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["HanSuDung"].Value != null &&
                    row.Cells["HanSuDung"].Value != DBNull.Value)
                {
                    if (Convert.ToDateTime(row.Cells["HanSuDung"].Value) < DateTime.Today)
                        soLuongHetHan++;
                }
            }

            if (soLuongHetHan > 0)
            {
                MessageBox.Show(
                    $"Có {soLuongHetHan} lô hàng đã hết hạn!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        //  GRID EVENTS
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || grid.Rows[e.RowIndex].IsNewRow) return;

            var row = grid.Rows[e.RowIndex];
            if (row.Cells["HanSuDung"].Value == null ||
                row.Cells["HanSuDung"].Value == DBNull.Value) return;

            DateTime hsd = Convert.ToDateTime(row.Cells["HanSuDung"].Value);

            if (hsd < DateTime.Today)
            {
                // Hết hạn: đỏ
                e.CellStyle.BackColor          = Color.Red;
                e.CellStyle.ForeColor          = Color.White;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
            else if ((hsd - DateTime.Today).TotalDays <= 7)
            {
                // Sắp hết hạn: vàng
                e.CellStyle.BackColor          = Color.Yellow;
                e.CellStyle.ForeColor          = Color.Black;
                e.CellStyle.SelectionBackColor = Color.Goldenrod;
            }
            else
            {
                // Bình thường: reset màu (tránh tồn màu cũ khi tìm kiếm)
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null ||
                grid.CurrentRow.Cells["MaHH"].Value == null) return;

            selectedId        = (int)grid.CurrentRow.Cells["MaHH"].Value;
            txtMaSP.Text      = grid.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTen.Text       = grid.CurrentRow.Cells["TenHH"].Value.ToString();
            txtDVT.Text       = grid.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtGiaNhap.Text   = grid.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text    = grid.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtTonMin.Text    = grid.CurrentRow.Cells["TonToiThieu"].Value.ToString();
            cboDM.Text        = grid.CurrentRow.Cells["TenDM"].Value.ToString();
            cboNCC.Text       = grid.CurrentRow.Cells["TenNCC"].Value.ToString();

            dtpNSX.Value = grid.CurrentRow.Cells["NgaySanXuat"].Value == DBNull.Value
                ? DateTime.Now
                : Convert.ToDateTime(grid.CurrentRow.Cells["NgaySanXuat"].Value);

            dtpHSD.Value = grid.CurrentRow.Cells["HanSuDung"].Value == DBNull.Value
                ? DateTime.Now
                : Convert.ToDateTime(grid.CurrentRow.Cells["HanSuDung"].Value);
        }

        //  BUTTON EVENTS
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Chọn dòng cần sửa!");
                return;
            }

            if (!ValidateForm(out int dm, out int ncc, out decimal gn,
                              out decimal gb, out int tt,
                              out DateTime ngaySX, out DateTime hanSD))
                return;

            try
            {
                HangHoaDAL.Update(selectedId.Value,
                    txtMaSP.Text, txtTen.Text, dm, ncc,
                    txtDVT.Text, gn, gb, tt, ngaySX, hanSD);

                MessageBox.Show("Cập nhật thành công!");
                LoadGrid(string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Xóa hàng này?", "Xác nhận",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            HangHoaDAL.Delete(selectedId.Value);
            LoadGrid(string.Empty);
            ClearForm();
        }

        //  HELPERS
        private void ClearForm()
        {
            selectedId = null;
            txtMaSP.Clear();
            txtTen.Clear();
            txtDVT.Clear();
            txtGiaNhap.Text = "0";
            txtGiaBan.Text  = "0";
            txtTonMin.Text  = "10";
            if (cboDM.Items.Count  > 0) cboDM.SelectedIndex  = 0;
            if (cboNCC.Items.Count > 0) cboNCC.SelectedIndex = 0;
            dtpNSX.Value = DateTime.Now;
            dtpHSD.Value = DateTime.Now;
        }

        private bool ValidateForm(out int maDM, out int maNCC,
            out decimal gn, out decimal gb, out int tt,
            out DateTime ngaySX, out DateTime hanSD)
        {
            maDM = 0; maNCC = 0; gn = 0; gb = 0; tt = 0;
            ngaySX = dtpNSX.Value;
            hanSD  = dtpHSD.Value;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Nhập mã SP và tên hàng!");
                return false;
            }

            if (cboDM.SelectedValue == null || cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Chọn danh mục và nhà cung cấp!");
                return false;
            }

            if (hanSD < ngaySX)
            {
                MessageBox.Show("Hạn sử dụng phải sau ngày sản xuất!");
                return false;
            }

            maDM = (int)cboDM.SelectedValue;
            maNCC = (int)cboNCC.SelectedValue;
            decimal.TryParse(txtGiaNhap.Text, out gn);
            decimal.TryParse(txtGiaBan.Text,  out gb);
            int.TryParse(txtTonMin.Text,       out tt);
            return true;
        }
    }
}
