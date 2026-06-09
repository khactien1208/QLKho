using System;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  LOAD
        // =====================================================================

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            LoadGrid(string.Empty);
        }

        // =====================================================================
        //  TOOLBAR EVENTS
        // =====================================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadGrid(txtSearch.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadGrid(string.Empty);
        }

        // =====================================================================
        //  LOAD GRID
        // =====================================================================

        private void LoadGrid(string kw = "")
        {
            grid.DataSource = string.IsNullOrWhiteSpace(kw)
                ? HangHoaDAL.GetTonKho()
                : HangHoaDAL.Search(kw);

            // Ẩn cột kỹ thuật
            if (grid.Columns.Contains("MaHH"))        grid.Columns["MaHH"].Visible        = false;
            if (grid.Columns.Contains("TrangThaiLo")) grid.Columns["TrangThaiLo"].Visible  = false;
            if (grid.Columns.Contains("TrangThaiTon")) grid.Columns["TrangThaiTon"].Visible = false;

            // Đổi tên cột hiển thị
            if (grid.Columns.Contains("MaSP"))        grid.Columns["MaSP"].HeaderText        = "Mã SP";
            if (grid.Columns.Contains("TenHH"))       grid.Columns["TenHH"].HeaderText       = "Tên hàng hóa";
            if (grid.Columns.Contains("TenDM"))       grid.Columns["TenDM"].HeaderText       = "Danh mục";
            if (grid.Columns.Contains("DonViTinh"))   grid.Columns["DonViTinh"].HeaderText   = "ĐVT";
            if (grid.Columns.Contains("TenNCC"))      grid.Columns["TenNCC"].HeaderText      = "Nhà cung cấp";
            if (grid.Columns.Contains("NgayNhapLo"))  grid.Columns["NgayNhapLo"].HeaderText  = "Ngày nhập lô";
            if (grid.Columns.Contains("NgaySanXuat")) grid.Columns["NgaySanXuat"].HeaderText = "Ngày SX";
            if (grid.Columns.Contains("HanSuDung"))   grid.Columns["HanSuDung"].HeaderText   = "Hạn SD";
            if (grid.Columns.Contains("TongNhap"))    grid.Columns["TongNhap"].HeaderText    = "Tổng nhập";
            if (grid.Columns.Contains("TongXuat"))    grid.Columns["TongXuat"].HeaderText    = "Tổng xuất";
            if (grid.Columns.Contains("TonKho"))      grid.Columns["TonKho"].HeaderText      = "Tồn kho";
            if (grid.Columns.Contains("TonToiThieu")) grid.Columns["TonToiThieu"].HeaderText = "Tồn tối thiểu";

            // Format ngày
            if (grid.Columns.Contains("NgaySanXuat"))
                grid.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (grid.Columns.Contains("HanSuDung"))
                grid.Columns["HanSuDung"].DefaultCellStyle.Format   = "dd/MM/yyyy";
            if (grid.Columns.Contains("NgayNhapLo"))
                grid.Columns["NgayNhapLo"].DefaultCellStyle.Format  = "dd/MM/yyyy HH:mm";

            // Tô màu theo TrangThaiTon
            if (grid.Columns.Contains("TrangThaiTon"))
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    var cell = row.Cells["TrangThaiTon"];
                    if (cell == null) continue;

                    var val = cell.Value;
                    if (val == null || val == DBNull.Value) continue;

                    string st = val.ToString();

                    if (st == "HetHan")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (st == "SapHetHan")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (st == "TonThap")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}
