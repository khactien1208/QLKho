using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public class frmPhieuXuat : Form
    {
        DataGridView gridPhieu, gridChiTiet, gridTemp;
        TextBox txtSoPhieu, txtGhiChu, txtSL, txtDonGia;
        ComboBox cboKH, cboHH;
        Button btnNew, btnAddItem, btnSave;
        Button btnXuatHuy;   // THÊM MỚI: nút xuất hủy lô hết hạn
        Label lblFIFO;       // THÊM MỚI: gợi ý lô nên xuất trước
        DataTable dtTemp;

        public frmPhieuXuat()
        {
            Text = "Phiếu xuất"; BackColor = Color.WhiteSmoke;

            var top = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = Color.White };
            var lblTitle = new Label
            {
                Text = "PHIẾU XUẤT KHO",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(15, 10)
            };

            top.Controls.Add(lblTitle);

            // ===== HÀNG 1: TÌM KIẾM =====
            var txtSearch = new TextBox
            {
                Location = new Point(15, 45), Width = 220,
                Font = new Font("Segoe UI", 9),
                PlaceholderText = "Tìm số phiếu, khách hàng..."
            };
            var btnSearch = new Button
            {
                Text = "🔍 Tìm", Location = new Point(243, 43), Size = new Size(75, 26),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };

            // ===== HÀNG 2: LỌC NGÀY + LOẠI PHIẾU =====
            top.Controls.Add(new Label { Text = "Từ ngày:", Location = new Point(15, 80), AutoSize = true, Font = new Font("Segoe UI", 9) });
            var dtpTu = new DateTimePicker { Location = new Point(70, 76), Width = 110, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9) };
            top.Controls.Add(new Label { Text = "Đến:", Location = new Point(188, 80), AutoSize = true, Font = new Font("Segoe UI", 9) });
            var dtpDen = new DateTimePicker { Location = new Point(215, 76), Width = 110, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9) };

            dtpTu.Value  = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDen.Value = DateTime.Today;

            var chkLoc = new CheckBox { Text = "Lọc ngày", Location = new Point(333, 78), AutoSize = true, Font = new Font("Segoe UI", 9) };

            top.Controls.Add(new Label { Text = "Loại:", Location = new Point(420, 80), AutoSize = true, Font = new Font("Segoe UI", 9) });
            var cboLoai = new ComboBox
            {
                Location = new Point(450, 76), Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9)
            };
            cboLoai.Items.AddRange(new object[] { "Tất cả", "XuatBan", "XuatHuy" });
            cboLoai.SelectedIndex = 0;

            var btnLoc = new Button
            {
                Text = "⚙ Lọc", Location = new Point(558, 76), Size = new Size(70, 26),
                BackColor = Color.FromArgb(155, 89, 182), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            var btnReset = new Button
            {
                Text = "✕ Xóa lọc", Location = new Point(635, 76), Size = new Size(85, 26),
                BackColor = Color.FromArgb(189, 195, 199), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9)
            };
            var btnExcel = new Button
            {
                Text = "📥 Xuất Excel", Location = new Point(728, 76), Size = new Size(110, 26),
                BackColor = Color.FromArgb(39, 174, 96), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnSearch.Click += (s, e) => LoadGrid(txtSearch.Text, null, null, "");
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadGrid(txtSearch.Text, null, null, ""); };
            btnLoc.Click += (s, e) => LoadGrid(
                txtSearch.Text,
                chkLoc.Checked ? (DateTime?)dtpTu.Value  : null,
                chkLoc.Checked ? (DateTime?)dtpDen.Value : null,
                cboLoai.SelectedIndex == 0 ? "" : cboLoai.SelectedItem.ToString());
            btnReset.Click += (s, e) => { txtSearch.Clear(); chkLoc.Checked = false; cboLoai.SelectedIndex = 0; LoadGrid("", null, null, ""); };
            btnExcel.Click += (s, e) => XuatExcel(gridPhieu, "PhieuXuat");

            top.Controls.AddRange(new Control[] {
                txtSearch, btnSearch,
                dtpTu, dtpDen, chkLoc, cboLoai, btnLoc, btnReset, btnExcel
            });
            
            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 250 };
            Controls.Add(split);
            Controls.Add(top);
            top.BringToFront();

            gridPhieu = NewGrid();
            gridPhieu.SelectionChanged += (s,e) => {
                if (gridPhieu.CurrentRow == null || gridPhieu.CurrentRow.Cells["MaPX"].Value == null) return;
                int id = (int)gridPhieu.CurrentRow.Cells["MaPX"].Value;
                gridChiTiet.DataSource = PhieuXuatDAL.GetChiTiet(id);
            };
            split.Panel1.Controls.Add(gridPhieu);

            var split2 = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 480 };
            split.Panel2.Controls.Add(split2);

            var gb = new GroupBox { Text = "Tạo phiếu xuất mới", Dock = DockStyle.Fill,
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

            gb.Controls.Add(new Label { Text = "Khách hàng:", Location = new Point(10, y+3), AutoSize = true });
            cboKH = new ComboBox { Location = new Point(100, y), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
            gb.Controls.Add(cboKH);
            var btnNewKH = new Button
            {
                Text = "+ KH",
                Location = new Point(390, y - 1),
                Size = new Size(70, 26),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Bold)
            };
            btnNewKH.Click += BtnNewKH_Click;
            gb.Controls.Add(btnNewKH);
            y += 32;

            gb.Controls.Add(new Label { Text = "Ghi chú:", Location = new Point(10, y+3), AutoSize = true });
            txtGhiChu = new TextBox { Location = new Point(100, y), Width = 330 };
            gb.Controls.Add(txtGhiChu); y += 40;

            gb.Controls.Add(new Label { Text = "─── Thêm sản phẩm ───", Location = new Point(10, y), AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.Gray }); y += 25;

            gb.Controls.Add(new Label { Text = "Hàng hóa:", Location = new Point(10, y+3), AutoSize = true });
            // ComboBox lô: hiển thị "ID - MaSP - TenHH - HSD: dd/MM/yyyy"
            cboHH = new ComboBox { Location = new Point(100, y), Width = 440, DropDownStyle = ComboBoxStyle.DropDownList };
            cboHH.SelectedIndexChanged += CboHH_SelectedIndexChanged;
            gb.Controls.Add(cboHH); y += 30;

            // Label gợi ý FIFO
            lblFIFO = new Label { Location = new Point(100, y), Width = 440, Height = 20,
                Font = new Font("Segoe UI", 8, FontStyle.Italic), ForeColor = Color.FromArgb(230, 126, 34), Text = "" };
            gb.Controls.Add(lblFIFO); y += 28;

            gb.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(10, y+3), AutoSize = true });
            txtSL = new TextBox { Location = new Point(100, y), Width = 100, Text = "1" };
            gb.Controls.Add(txtSL);
            gb.Controls.Add(new Label { Text = "Đơn giá:", Location = new Point(220, y+3), AutoSize = true });
            txtDonGia = new TextBox { Location = new Point(290, y), Width = 140, Text = "0" };
            gb.Controls.Add(txtDonGia); y += 40;

            btnAddItem = new Button { Text = "+ Thêm dòng", Location = new Point(10, y), Size = new Size(150, 32),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAddItem.Click += BtnAddItem_Click;

            btnSave = new Button { Text = "💾 LƯU PHIẾU", Location = new Point(170, y), Size = new Size(160, 32),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            btnSave.Click += BtnSave_Click;

            // Nút xuất hủy — chỉ hiện khi chọn lô hết hạn
            btnXuatHuy = new Button { Text = "🗑 XUẤT HỦY", Location = new Point(340, y), Size = new Size(140, 32),
                BackColor = Color.FromArgb(192, 57, 43), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), Visible = false };
            btnXuatHuy.Click += BtnXuatHuy_Click;

            gb.Controls.AddRange(new Control[] { btnAddItem, btnSave, btnXuatHuy });
            PhanQuyen.ApDungChiXem(btnAddItem, btnSave, btnNew, btnXuatHuy);

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

            Load += (s,e) => { LoadCombo(); LoadGrid("", null, null, ""); NewPhieu(); };
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
            cboKH.DataSource = PhieuXuatDAL.GetKH();
            cboKH.DisplayMember = "TenKH"; cboKH.ValueMember = "MaKH";
            // Dùng GetLoForXuatCombo: chỉ lô TonKho>0, hiển thị "ID - MaSP - TenHH - HSD: dd/MM/yyyy"
            cboHH.DataSource = HangHoaDAL.GetLoForXuatCombo();
            cboHH.DisplayMember = "TenHienThi"; cboHH.ValueMember = "MaHH";
        }
        void LoadGrid(string kw = "", DateTime? tuNgay = null, DateTime? denNgay = null, string loaiPhieu = "")
        {
            bool coFilter = !string.IsNullOrWhiteSpace(kw) || tuNgay.HasValue || denNgay.HasValue || !string.IsNullOrWhiteSpace(loaiPhieu);
            gridPhieu.DataSource = coFilter
                ? PhieuXuatDAL.Filter(kw, tuNgay, denNgay, loaiPhieu)
                : PhieuXuatDAL.GetAll();
            if (gridPhieu.Columns.Contains("MaPX"))     gridPhieu.Columns["MaPX"].Visible = false;
            if (gridPhieu.Columns.Contains("TongTien"))  gridPhieu.Columns["TongTien"].DefaultCellStyle.Format  = "N0";
            if (gridPhieu.Columns.Contains("NgayXuat"))  gridPhieu.Columns["NgayXuat"].DefaultCellStyle.Format  = "dd/MM/yyyy HH:mm";
            // Tô màu dòng XuatHuy
            foreach (DataGridViewRow row in gridPhieu.Rows)
                if (row.Cells["LoaiPhieu"]?.Value?.ToString() == "XuatHuy")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
        }

        void XuatExcel(DataGridView dgv, string tenFile)
        {
            if (dgv.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }
            var dlg = new SaveFileDialog
            {
                Filter = "Excel CSV (*.csv)|*.csv",
                FileName = $"{tenFile}_{DateTime.Today:yyyyMMdd}.csv",
                Title = "Lưu file Excel"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                var sb = new System.Text.StringBuilder();
                var headers = new System.Collections.Generic.List<string>();
                foreach (DataGridViewColumn col in dgv.Columns)
                    if (col.Visible) headers.Add("\"" + col.HeaderText + "\"");
                sb.AppendLine(string.Join(",", headers));
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cells = new System.Collections.Generic.List<string>();
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Visible) continue;
                        string val = row.Cells[col.Index].FormattedValue?.ToString() ?? "";
                        cells.Add("\"" + val.Replace("\"", "\"\"") + "\"");
                    }
                    sb.AppendLine(string.Join(",", cells));
                }
                System.IO.File.WriteAllText(dlg.FileName, sb.ToString(), new System.Text.UTF8Encoding(true));
                if (MessageBox.Show("Xuất Excel thành công!\nMở file ngay?", "Thành công",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(dlg.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }
        void NewPhieu()
        {
            txtSoPhieu.Text = PhieuXuatDAL.SinhSoPhieu();
            txtGhiChu.Clear();
            lblFIFO.Text = "";
            btnXuatHuy.Visible = false;
            btnSave.Enabled = true;
            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaHH",      typeof(int));
            dtTemp.Columns.Add("TenHH");
            dtTemp.Columns.Add("HanSuDung", typeof(DateTime));
            dtTemp.Columns.Add("SoLuong",   typeof(int));
            dtTemp.Columns.Add("DonGia",    typeof(decimal));
            dtTemp.Columns.Add("ThanhTien", typeof(decimal));
            gridTemp.DataSource = dtTemp;
            if (gridTemp.Columns.Contains("MaHH"))
                gridTemp.Columns["MaHH"].Visible = false;
            if (gridTemp.Columns.Contains("HanSuDung"))
                gridTemp.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        // Khi chọn lô: điền giá bán, cập nhật label FIFO, hiện/ẩn nút Xuất Hủy
        void CboHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHH.SelectedItem == null) return;
            var drv = (DataRowView)cboHH.SelectedItem;

            // Điền giá bán
            txtDonGia.Text = drv["GiaBan"].ToString();

            // Kiểm tra hết hạn
            bool hetHan = false;
            DateTime hsd = DateTime.MaxValue;
            if (drv["HanSuDung"] != DBNull.Value)
            {
                hsd = Convert.ToDateTime(drv["HanSuDung"]);
                hetHan = hsd < DateTime.Today;
            }

            string maSP = drv["MaSP"].ToString();

            // Gợi ý lô FIFO cùng MaSP
            DataTable fifo = HangHoaDAL.GetLoFIFOByMaSP(maSP);
            if (fifo.Rows.Count > 0)
            {
                int fifoId = Convert.ToInt32(fifo.Rows[0]["MaHH"]);
                DateTime fifoHsd = fifo.Rows[0]["HanSuDung"] == DBNull.Value
                    ? DateTime.MaxValue
                    : Convert.ToDateTime(fifo.Rows[0]["HanSuDung"]);
                int selectedId = drv["MaHH"] == DBNull.Value ? 0 : Convert.ToInt32(drv["MaHH"]);

                if (selectedId != fifoId)
                {
                    lblFIFO.Text      = $"⚠ Nên xuất lô ID {fifoId} trước (HSD: {fifoHsd:dd/MM/yyyy})";
                    lblFIFO.ForeColor = Color.FromArgb(230, 126, 34);
                }
                else
                {
                    lblFIFO.Text      = "✔ Đây là lô nên xuất trước (HSD sớm nhất)";
                    lblFIFO.ForeColor = Color.FromArgb(39, 174, 96);
                }
            }
            else
            {
                lblFIFO.Text = "";
            }

            // Xử lý lô hết hạn
            if (hetHan)
            {
                btnXuatHuy.Visible = true;
                btnSave.Enabled    = false;
                lblFIFO.Text       = $"🚫 Lô này đã HẾT HẠN ({hsd:dd/MM/yyyy}) — chỉ được Xuất Hủy!";
                lblFIFO.ForeColor  = Color.Red;
            }
            else
            {
                btnXuatHuy.Visible = false;
                btnSave.Enabled    = true;
            }
        }

        void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cboHH.SelectedValue == null) { MessageBox.Show("Chọn lô hàng!"); return; }
            if (!int.TryParse(txtSL.Text, out int sl) || sl <= 0) { MessageBox.Show("SL không hợp lệ"); return; }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg < 0) { MessageBox.Show("Đơn giá không hợp lệ"); return; }

            var drv  = (DataRowView)cboHH.SelectedItem;
            int ton  = Convert.ToInt32(drv["TonKho"]);
            int maHH = Convert.ToInt32(drv["MaHH"]);

            if (sl > ton) { MessageBox.Show($"Tồn kho lô này chỉ còn {ton}!"); return; }

            DateTime hsd = drv["HanSuDung"] == DBNull.Value
                ? DateTime.MaxValue
                : Convert.ToDateTime(drv["HanSuDung"]);

            // Tách TenHH từ "ID - MaSP - TenHH - HSD: ..."
            string tenHienThi = drv["TenHienThi"].ToString();
            string tenHH = tenHienThi;
            var parts = tenHienThi.Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length >= 3) tenHH = parts[2];

            dtTemp.Rows.Add(maHH, tenHH, hsd, sl, dg, sl * dg);
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            LuuPhieu("XuatBan");
        }

        void BtnXuatHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Xác nhận XUẤT HỦY lô hàng hết hạn?\nTồn kho sẽ bị trừ và lô sẽ bị đánh dấu Hủy.",
                "Xác nhận xuất hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;

            // Cần thêm ít nhất 1 dòng vào dtTemp nếu chưa có
            if (dtTemp.Rows.Count == 0) BtnAddItem_Click(sender, e);
            if (dtTemp.Rows.Count == 0) return;

            txtSoPhieu.Text = PhieuXuatDAL.SinhSoPhieuHuy();
            LuuPhieu("XuatHuy");
        }

        void BtnNewKH_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmThemKhachHang())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && dlg.MaKHMoi > 0)
                {
                    // Reload combo KH
                    cboKH.DataSource = PhieuXuatDAL.GetKH();
                    cboKH.DisplayMember = "TenKH";
                    cboKH.ValueMember = "MaKH";
                    // Tự chọn KH vừa thêm
                    cboKH.SelectedValue = dlg.MaKHMoi;
                }
            }
        }
        void LuuPhieu(string loaiXuat)
        {
            if (dtTemp.Rows.Count == 0) { MessageBox.Show("Phiếu rỗng!"); return; }
            if (cboKH.SelectedValue == null) { MessageBox.Show("Chọn khách hàng!"); return; }
            try
            {
                PhieuXuatDAL.Insert(txtSoPhieu.Text, (int)cboKH.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp, loaiXuat);
                MessageBox.Show($"Lưu phiếu xuất {loaiXuat} thành công!");
                LoadGrid(); LoadCombo(); NewPhieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

    }

    // ================================================================
    //   DIALOG THÊM KHÁCH HÀNG MỚI
    // ================================================================
    internal class frmThemKhachHang : Form
    {
        public int MaKHMoi { get; private set; }

        TextBox txtTenKH, txtDiaChi, txtDienThoai, txtEmail;

        public frmThemKhachHang()
        {
            Text = "Thêm khách hàng mới";
            Size = new Size(400, 260);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9);

            int y = 15;
            void AddRow(string label, Control ctl)
            {
                Controls.Add(new Label { Text = label, Location = new Point(15, y + 4), AutoSize = true });
                ctl.Location = new Point(130, y);
                ctl.Width = 230;
                Controls.Add(ctl);
                y += 32;
            }

            txtTenKH    = new TextBox(); AddRow("Tên KH (*):",   txtTenKH);
            txtDiaChi   = new TextBox(); AddRow("Địa chỉ:",      txtDiaChi);
            txtDienThoai = new TextBox(); AddRow("Số điện thoại:", txtDienThoai);
            txtEmail    = new TextBox(); AddRow("Email:",         txtEmail);

            y += 8;
            var btnOK = new Button
            {
                Text = "✓ Lưu", Location = new Point(130, y), Size = new Size(110, 32),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnOK.Click += BtnOK_Click;

            var btnCancel = new Button
            {
                Text = "Hủy", Location = new Point(250, y), Size = new Size(110, 32),
                BackColor = Color.FromArgb(189, 195, 199), FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            AcceptButton = btnOK;
            CancelButton = btnCancel;
        }

        void BtnOK_Click(object sender, EventArgs e)
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
