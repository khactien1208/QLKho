using System;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmTonKho : Form
    {
        DataGridView grid;
        public frmTonKho()
        {
            Text = "Tồn kho"; BackColor = Color.WhiteSmoke;
            var top = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.White };
            top.Controls.Add(new Label { Text = "BẢNG TỒN KHO HIỆN TẠI", Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(15, 40), AutoSize = true, ForeColor = Color.FromArgb(44, 62, 80) });

            // ===== THANH TÌM KIẾM =====
            var txtSearch = new TextBox
            {
                Location = new Point(300, 48), Width = 220,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Tìm mã SP, tên hàng hóa..."
            };
            var btnSearch = new Button
            {
                Text = "🔍 Tìm", Location = new Point(528, 46), Size = new Size(80, 28),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            var btnReset = new Button
            {
                Text = "✕", Location = new Point(615, 46), Size = new Size(32, 28),
                BackColor = Color.FromArgb(189, 195, 199), FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnSearch.Click += (s, e) => LoadGrid(txtSearch.Text);
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadGrid(txtSearch.Text); };
            btnReset.Click += (s, e) => { txtSearch.Clear(); LoadGrid(""); };
            top.Controls.AddRange(new Control[] { txtSearch, btnSearch, btnReset });
            
            
            
            grid = new DataGridView { 
                Dock = DockStyle.Fill,

                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,

                MultiSelect = false,

                SelectionMode = DataGridViewSelectionMode.FullRowSelect,

                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,

                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,

                RowHeadersVisible = false,

                EnableHeadersVisualStyles = false,

                GridColor = Color.FromArgb(230, 230, 230),

                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,

                Font = new Font("Segoe UI", 10),

                RowTemplate = { Height = 32 },

                ColumnHeadersHeight = 40,
                ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            };
            // ===== HEADER =====

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 73, 94);

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            // ===== DÒNG =====

            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            grid.DefaultCellStyle.SelectionForeColor =
                Color.White;

            grid.DefaultCellStyle.Padding =
                new Padding(3);


            // ===== XEN KẼ MÀU =====

            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            grid.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlGrid.Controls.Add(grid);

            Controls.Add(pnlGrid); 
            Controls.Add(top);
            Load += (s, e) => LoadGrid("");
        }

        void LoadGrid(string kw = "")
        {
            grid.DataSource = string.IsNullOrWhiteSpace(kw)
                ? HangHoaDAL.GetTonKho()
                : HangHoaDAL.Search(kw);

            // Ẩn cột kỹ thuật
            if (grid.Columns.Contains("MaHH"))         grid.Columns["MaHH"].Visible         = false;
            if (grid.Columns.Contains("TrangThaiLo"))   grid.Columns["TrangThaiLo"].Visible   = false;
            if (grid.Columns.Contains("TrangThaiTon"))  grid.Columns["TrangThaiTon"].Visible  = false;

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
                grid.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (grid.Columns.Contains("NgayNhapLo"))
                grid.Columns["NgayNhapLo"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Tô màu theo TrangThaiTon
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["TrangThaiTon"].Value == null) continue;
                string st = row.Cells["TrangThaiTon"].Value.ToString();
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
