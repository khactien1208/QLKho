using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public class frmPhieuNhap : Form
    {
        DataGridView gridPhieu, gridChiTiet, gridTemp;
        TextBox txtSoPhieu, txtGhiChu, txtSL, txtDonGia;
        ComboBox cboNCC, cboHH;
        Button btnNew, btnAddItem, btnSave;
        DataTable dtTemp;

        public frmPhieuNhap()
        {
            Text = "Phiếu nhập"; BackColor = Color.WhiteSmoke;

            var top = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
    
            top.Controls.Add(new Label { Text = "PHIẾU NHẬP KHO", Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15), AutoSize = true, ForeColor = Color.FromArgb(44, 62, 80) });
            

            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 250 };
            Controls.Add(split);
            Controls.Add(top);

            // ----- Trên: danh sách phiếu -----
            gridPhieu = NewGrid();
            gridPhieu.SelectionChanged += (s,e) => {
                if (gridPhieu.CurrentRow == null) return;
                if (gridPhieu.CurrentRow.Cells["MaPN"].Value == null) return;
                int id = (int)gridPhieu.CurrentRow.Cells["MaPN"].Value;
                gridChiTiet.DataSource = PhieuNhapDAL.GetChiTiet(id);
            };
            split.Panel1.Controls.Add(gridPhieu);

            // ----- Dưới: 2 cột (form tạo + chi tiết) -----
            var split2 = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 480 };
            split.Panel2.Controls.Add(split2);

            // Form tạo phiếu mới
            var gb = new GroupBox { Text = "Tạo phiếu nhập mới", Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), BackColor = Color.White };
            split2.Panel1.Controls.Add(gb);

            int y = 25;
            gb.Controls.Add(new Label { Text = "Số phiếu:", Location = new Point(10, y+3), AutoSize = true });
            txtSoPhieu = new TextBox { Location = new Point(100, y), Width = 150, ReadOnly = true };
            gb.Controls.Add(txtSoPhieu);
            btnNew = new Button { Text = "Mới", Location = new Point(260, y-1), Size = new Size(70, 26) };
            btnNew.Click += (s,e) => NewPhieu();
            gb.Controls.Add(btnNew);
            y += 32;

            gb.Controls.Add(new Label { Text = "NCC:", Location = new Point(10, y+3), AutoSize = true });
            cboNCC = new ComboBox { Location = new Point(100, y), Width = 330, DropDownStyle = ComboBoxStyle.DropDownList };
            gb.Controls.Add(cboNCC); y += 32;

            gb.Controls.Add(new Label { Text = "Ghi chú:", Location = new Point(10, y+3), AutoSize = true });
            txtGhiChu = new TextBox { Location = new Point(100, y), Width = 330 };
            gb.Controls.Add(txtGhiChu); y += 40;

            gb.Controls.Add(new Label { Text = "─── Thêm sản phẩm ───", Location = new Point(10, y), AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.Gray }); y += 25;

            gb.Controls.Add(new Label { Text = "Hàng hóa:", Location = new Point(10, y+3), AutoSize = true });
            cboHH = new ComboBox { Location = new Point(100, y), Width = 330, DropDownStyle = ComboBoxStyle.DropDownList };
            cboHH.SelectedIndexChanged += (s,e) => {
                if (cboHH.SelectedItem is DataRowView drv) txtDonGia.Text = drv["GiaNhap"].ToString();
            };
            gb.Controls.Add(cboHH); y += 32;

            gb.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(10, y+3), AutoSize = true });
            txtSL = new TextBox { Location = new Point(100, y), Width = 100, Text = "1" };
            gb.Controls.Add(txtSL);
            gb.Controls.Add(new Label { Text = "Đơn giá:", Location = new Point(220, y+3), AutoSize = true });
            txtDonGia = new TextBox { Location = new Point(290, y), Width = 140, Text = "0" };
            gb.Controls.Add(txtDonGia); y += 40;

            btnAddItem = new Button { Text = "+ Thêm dòng", Location = new Point(100, y), Size = new Size(150, 32),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAddItem.Click += BtnAddItem_Click;
            btnSave = new Button { Text = "💾 LƯU PHIẾU", Location = new Point(260, y), Size = new Size(170, 32),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            btnSave.Click += BtnSave_Click;
            gb.Controls.AddRange(new Control[] { btnAddItem, btnSave });
            PhanQuyen.ApDungChiXem(btnAddItem, btnSave, btnNew);

            // Right: Hai grid xếp dọc
            var splitRight = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal };
            split2.Panel2.Controls.Add(splitRight);

            gridTemp = NewGrid();
            var lbl1 = new Label { Text = "Sản phẩm trong phiếu mới", Dock = DockStyle.Top, Height = 25,
                BackColor = Color.FromArgb(241, 196, 15), Font = new Font("Segoe UI", 9, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8,0,0,0) };
            splitRight.Panel1.Controls.Add(gridTemp);
            splitRight.Panel1.Controls.Add(lbl1);

            gridChiTiet = NewGrid();
            var lbl2 = new Label { Text = "Chi tiết phiếu đã chọn", Dock = DockStyle.Top, Height = 25,
                BackColor = Color.FromArgb(149, 165, 166), ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8,0,0,0) };
            splitRight.Panel2.Controls.Add(gridChiTiet);
            splitRight.Panel2.Controls.Add(lbl2);

            Load += (s,e) => { LoadCombo(); LoadGrid(); NewPhieu(); };
        }

        DataGridView NewGrid() {
            var grid = new DataGridView {
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
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };
            // ===== HEADER =====
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            // ===== DÒNG =====
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Padding = new Padding(3);
            // ===== XEN KẼ MÀU =====
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlGrid.Controls.Add(grid);

            return grid;
        }


        void LoadCombo()
        {
            cboNCC.DataSource = PhieuNhapDAL.GetNCC();
            cboNCC.DisplayMember = "TenNCC"; cboNCC.ValueMember = "MaNCC";
            cboHH.DataSource = HangHoaDAL.GetForCombo();
            cboHH.DisplayMember = "TenHienThi"; cboHH.ValueMember = "MaHH";
        }
        void LoadGrid()
        {
            gridPhieu.DataSource = PhieuNhapDAL.GetAll();
            if (gridPhieu.Columns.Contains("MaPN")) gridPhieu.Columns["MaPN"].Visible = false;
        }
        void NewPhieu()
        {
            txtSoPhieu.Text = PhieuNhapDAL.SinhSoPhieu();
            txtGhiChu.Clear();
            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaHH", typeof(int));
            dtTemp.Columns.Add("TenHH"); dtTemp.Columns.Add("SoLuong", typeof(int));
            dtTemp.Columns.Add("DonGia", typeof(decimal));
            dtTemp.Columns.Add("ThanhTien", typeof(decimal));
            gridTemp.DataSource = dtTemp;
            if (gridTemp.Columns.Contains("MaHH")) gridTemp.Columns["MaHH"].Visible = false;
        }
        void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cboHH.SelectedValue == null) return;
            if (!int.TryParse(txtSL.Text, out int sl) || sl <= 0) { MessageBox.Show("SL không hợp lệ"); return; }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg < 0) { MessageBox.Show("Đơn giá không hợp lệ"); return; }
            var drv = (DataRowView)cboHH.SelectedItem;
            dtTemp.Rows.Add((int)cboHH.SelectedValue, drv["TenHienThi"], sl, dg, sl*dg);
        }
        void BtnSave_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0) { MessageBox.Show("Phiếu rỗng!"); return; }
            try {
                PhieuNhapDAL.Insert(txtSoPhieu.Text, (int)cboNCC.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp);
                MessageBox.Show("Lưu phiếu nhập thành công!");
                LoadGrid(); LoadCombo(); NewPhieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
