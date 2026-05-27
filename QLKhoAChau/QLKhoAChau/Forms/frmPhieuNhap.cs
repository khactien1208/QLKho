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
        TextBox txtGiaBanLo, txtTonToiThieu;           // THÊM MỚI: thông tin lô
        ComboBox cboNCC, cboHH;                        // cboHH = combo chọn SP cũ
        ComboBox cboDMMoi, cboNCCMoi;                  // THÊM MỚI: cho SP mới
        TextBox txtMaSPMoi, txtTenMoi, txtDVTMoi;      // THÊM MỚI: nhập SP mới
        DateTimePicker dtpNSX, dtpHSD;                 // THÊM MỚI: hạn sử dụng
        RadioButton rdoSPCu, rdoSPMoi;                 // THÊM MỚI: chọn chế độ
        Panel pnlSpCu, pnlSpMoi;                       // THÊM MỚI: 2 panel ẩn/hiện
        Button btnNew, btnAddItem, btnSave, btnNewHH, btnNewDM, btnNewNCC;
        DataTable dtTemp;

        public frmPhieuNhap()
        {
            Text = "Phiếu nhập"; BackColor = Color.WhiteSmoke;

            var top = new Panel { Dock = DockStyle.Top, Height = 110, BackColor = Color.White };
            var lblTitle = new Label
            {
                Text = "PHIẾU NHẬP KHO",
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
                PlaceholderText = "Tìm số phiếu, nhà cung cấp..."
            };
            var btnSearch = new Button
            {
                Text = "🔍 Tìm", Location = new Point(243, 43), Size = new Size(75, 26),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };

            // ===== HÀNG 2: LỌC NGÀY =====
            top.Controls.Add(new Label { Text = "Từ ngày:", Location = new Point(15, 80), AutoSize = true, Font = new Font("Segoe UI", 9) });
            var dtpTu = new DateTimePicker { Location = new Point(70, 76), Width = 120, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9) };
            top.Controls.Add(new Label { Text = "Đến:", Location = new Point(200, 80), AutoSize = true, Font = new Font("Segoe UI", 9) });
            var dtpDen = new DateTimePicker { Location = new Point(228, 76), Width = 120, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9) };

            // Mặc định: đầu tháng → hôm nay
            dtpTu.Value  = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDen.Value = DateTime.Today;

            var chkLoc = new CheckBox
            {
                Text = "Lọc ngày", Location = new Point(358, 78), AutoSize = true,
                Font = new Font("Segoe UI", 9), Checked = false
            };

            var btnLoc = new Button
            {
                Text = "⚙ Lọc", Location = new Point(440, 76), Size = new Size(75, 26),
                BackColor = Color.FromArgb(155, 89, 182), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            var btnReset = new Button
            {
                Text = "✕ Xóa lọc", Location = new Point(523, 76), Size = new Size(85, 26),
                BackColor = Color.FromArgb(189, 195, 199), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9)
            };
            var btnExcel = new Button
            {
                Text = "📥 Xuất Excel", Location = new Point(618, 76), Size = new Size(110, 26),
                BackColor = Color.FromArgb(39, 174, 96), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            // Kích hoạt lọc
            btnSearch.Click += (s, e) => LoadGrid(txtSearch.Text, null, null);
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadGrid(txtSearch.Text, null, null); };
            btnLoc.Click += (s, e) => LoadGrid(
                txtSearch.Text,
                chkLoc.Checked ? (DateTime?)dtpTu.Value  : null,
                chkLoc.Checked ? (DateTime?)dtpDen.Value : null);
            btnReset.Click += (s, e) => { txtSearch.Clear(); chkLoc.Checked = false; LoadGrid("", null, null); };
            btnExcel.Click += (s, e) => XuatExcel(gridPhieu, "PhieuNhap");

            top.Controls.AddRange(new Control[] {
                txtSearch, btnSearch,
                dtpTu, dtpDen, chkLoc, btnLoc, btnReset, btnExcel
            });

            var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 250 };
            Controls.Add(split);
            Controls.Add(top);
            top.BringToFront();

            gridPhieu = NewGrid();
            gridPhieu.SelectionChanged += (s, e) => {
                if (gridPhieu.CurrentRow == null) return;
                if (gridPhieu.CurrentRow.Cells["MaPN"].Value == null) return;
                int id = (int)gridPhieu.CurrentRow.Cells["MaPN"].Value;
                gridChiTiet.DataSource = PhieuNhapDAL.GetChiTiet(id);
            };
            split.Panel1.Controls.Add(gridPhieu);

            var split2 = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 480 };
            split.Panel2.Controls.Add(split2);

            var gb = new GroupBox
            {
                Text = "Tạo phiếu nhập mới", Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), BackColor = Color.White
            };
            split2.Panel1.Controls.Add(gb);

            int y = 25;
            gb.Controls.Add(new Label { Text = "Số phiếu:", Location = new Point(10, y + 3), AutoSize = true });
            txtSoPhieu = new TextBox { Location = new Point(100, y), Width = 150, ReadOnly = true };
            gb.Controls.Add(txtSoPhieu);
            btnNew = new Button { Text = "Mới", Location = new Point(260, y - 1), Size = new Size(70, 26) };
            btnNew.Click += (s, e) => NewPhieu();
            gb.Controls.Add(btnNew);
            y += 32;

            gb.Controls.Add(new Label { Text = "NCC:", Location = new Point(10, y + 3), AutoSize = true });
            cboNCC = new ComboBox { Location = new Point(100, y), Width = 330, DropDownStyle = ComboBoxStyle.DropDownList };
            gb.Controls.Add(cboNCC); y += 32;

            gb.Controls.Add(new Label { Text = "Ghi chú:", Location = new Point(10, y + 3), AutoSize = true });
            txtGhiChu = new TextBox { Location = new Point(100, y), Width = 330 };
            gb.Controls.Add(txtGhiChu); y += 40;

            gb.Controls.Add(new Label
            {
                Text = "─── Thêm sản phẩm ───", Location = new Point(10, y), AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.Gray
            }); y += 25;

            gb.Controls.Add(new Label { Text = "Hàng hóa:", Location = new Point(10, y + 3), AutoSize = true });

            // ===== RADIO CHỌN CHẾ ĐỘ SP =====
            rdoSPCu = new RadioButton { Text = "SP có sẵn", Location = new Point(100, y), AutoSize = true, Checked = true, Font = new Font("Segoe UI", 9) };
            rdoSPMoi = new RadioButton { Text = "SP mới", Location = new Point(210, y), AutoSize = true, Font = new Font("Segoe UI", 9) };
            rdoSPCu.CheckedChanged += RdoSP_CheckedChanged;
            rdoSPMoi.CheckedChanged += RdoSP_CheckedChanged;
            gb.Controls.AddRange(new Control[] { rdoSPCu, rdoSPMoi });
            y += 28;

            // ===== PANEL SP CŨ =====
            pnlSpCu = new Panel { Location = new Point(10, y), Width = 440, Height = 30, Visible = true };
            cboHH = new ComboBox { Location = new Point(0, 2), Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
            cboHH.SelectedIndexChanged += (s, e) => {
                if (cboHH.SelectedItem is DataRowView drv)
                {
                    var tbl = drv.Row.Table;
                    if (tbl.Columns.Contains("GiaNhap") && drv["GiaNhap"] != DBNull.Value)
                    {
                        txtDonGia.Text = drv["GiaNhap"].ToString();
                    }
                    else if (tbl.Columns.Contains("DonGia") && drv["DonGia"] != DBNull.Value)
                    {
                        txtDonGia.Text = drv["DonGia"].ToString();
                    }
                    else
                    {
                        txtDonGia.Text = "0";
                    }
                }
            };
            btnNewHH = new Button
            {
                Text = "+ Mới", Location = new Point(368, 1), Size = new Size(65, 26),
                BackColor = Color.FromArgb(155, 89, 182), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 8, FontStyle.Bold)
            };
            btnNewHH.Click += BtnNewHH_Click;
            pnlSpCu.Controls.AddRange(new Control[] { cboHH, btnNewHH });
            gb.Controls.Add(pnlSpCu);

            // ===== PANEL SP MỚI =====
            pnlSpMoi = new Panel { Location = new Point(10, y), Width = 440, Height = 70, Visible = false };
            pnlSpMoi.Controls.Add(new Label { Text = "Mã SP (*):", Location = new Point(0, 5), AutoSize = true });
            txtMaSPMoi = new TextBox { Location = new Point(65, 2), Width = 100 };
            pnlSpMoi.Controls.Add(txtMaSPMoi);
            pnlSpMoi.Controls.Add(new Label { Text = "Tên HH (*):", Location = new Point(175, 5), AutoSize = true });
            txtTenMoi = new TextBox { Location = new Point(240, 2), Width = 200 };
            pnlSpMoi.Controls.Add(txtTenMoi);
            pnlSpMoi.Controls.Add(new Label { Text = "Danh mục:", Location = new Point(0, 38), AutoSize = true });
            cboDMMoi = new ComboBox { Location = new Point(65, 35), Width = 160, DropDownStyle = ComboBoxStyle.DropDownList };
            pnlSpMoi.Controls.Add(cboDMMoi);
            pnlSpMoi.Controls.Add(new Label { Text = "ĐVT:", Location = new Point(238, 38), AutoSize = true });
            txtDVTMoi = new TextBox { Location = new Point(265, 35), Width = 80, Text = "Thùng" };
            pnlSpMoi.Controls.Add(txtDVTMoi);
            pnlSpMoi.Controls.Add(new Label { Text = "NCC:", Location = new Point(355, 38), AutoSize = true });
            cboNCCMoi = new ComboBox { Location = new Point(380, 35), Width = 55, DropDownStyle = ComboBoxStyle.DropDownList };
            pnlSpMoi.Controls.Add(cboNCCMoi);
            gb.Controls.Add(pnlSpMoi);
            y += 78;

            // ===== CÁC FIELD THÔNG TIN LÔ (dùng chung 2 chế độ) =====
            gb.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(10, y + 3), AutoSize = true });
            txtSL = new TextBox { Location = new Point(100, y), Width = 80, Text = "1" };
            gb.Controls.Add(txtSL);
            gb.Controls.Add(new Label { Text = "Đơn giá nhập:", Location = new Point(195, y + 3), AutoSize = true });
            txtDonGia = new TextBox { Location = new Point(295, y), Width = 90, Text = "0" };
            gb.Controls.Add(txtDonGia);
            gb.Controls.Add(new Label { Text = "Giá bán:", Location = new Point(395, y + 3), AutoSize = true });
            txtGiaBanLo = new TextBox { Location = new Point(445, y), Width = 90, Text = "0" };
            gb.Controls.Add(txtGiaBanLo);
            y += 32;

            gb.Controls.Add(new Label { Text = "Ngày SX:", Location = new Point(10, y + 3), AutoSize = true });
            dtpNSX = new DateTimePicker { Location = new Point(100, y), Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            gb.Controls.Add(dtpNSX);
            gb.Controls.Add(new Label { Text = "Hạn SD (*):", Location = new Point(245, y + 3), AutoSize = true });
            dtpHSD = new DateTimePicker { Location = new Point(320, y), Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddYears(1) };
            gb.Controls.Add(dtpHSD);
            gb.Controls.Add(new Label { Text = "Tồn tối thiểu:", Location = new Point(462, y + 3), AutoSize = true });
            txtTonToiThieu = new TextBox { Location = new Point(550, y), Width = 60, Text = "10" };
            gb.Controls.Add(txtTonToiThieu);
            y += 40;

            btnAddItem = new Button
            {
                Text = "+ Thêm dòng", Location = new Point(100, y), Size = new Size(150, 32),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat
            };
            btnAddItem.Click += BtnAddItem_Click;
            btnSave = new Button
            {
                Text = "💾 LƯU PHIẾU", Location = new Point(260, y), Size = new Size(170, 32),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnSave.Click += BtnSave_Click;
            gb.Controls.AddRange(new Control[] { btnAddItem, btnSave });
            PhanQuyen.ApDungChiXem(btnAddItem, btnSave, btnNew, btnNewHH);

            var splitRight = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal };
            split2.Panel2.Controls.Add(splitRight);

            gridTemp = NewGrid();
            var lbl1 = new Label
            {
                Text = "Sản phẩm trong phiếu mới", Dock = DockStyle.Top, Height = 25,
                BackColor = Color.FromArgb(241, 196, 15), Font = new Font("Segoe UI", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8, 0, 0, 0)
            };
            splitRight.Panel1.Controls.Add(gridTemp);
            splitRight.Panel1.Controls.Add(lbl1);

            gridChiTiet = NewGrid();
            var lbl2 = new Label
            {
                Text = "Chi tiết phiếu đã chọn", Dock = DockStyle.Top, Height = 25,
                BackColor = Color.FromArgb(149, 165, 166), ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8, 0, 0, 0)
            };
            splitRight.Panel2.Controls.Add(gridChiTiet);
            splitRight.Panel2.Controls.Add(lbl2);

            Load += (s, e) => { LoadCombo(); LoadGrid("", null, null); NewPhieu(); RdoSP_CheckedChanged(null, null); };
        }

        DataGridView NewGrid()
        {
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true,
                AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
                RowHeadersVisible = false, EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(230, 230, 230),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                Font = new Font("Segoe UI", 10),
                RowTemplate = { Height = 32 },
                ColumnHeadersHeight = 40,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Padding = new Padding(3);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return grid;
        }

        void LoadCombo()
        {
            cboNCC.DataSource = PhieuNhapDAL.GetNCC();
            cboNCC.DisplayMember = "TenNCC"; cboNCC.ValueMember = "MaNCC";

            // Combo SP có sẵn: hiển thị "MaSP - TenHH"
            cboHH.DataSource = HangHoaDAL.GetDanhSachSP();
            cboHH.DisplayMember = "TenHienThi"; cboHH.ValueMember = "MaSP";

            // Combo danh mục cho SP mới
            cboDMMoi.DataSource = DanhMucDAL.GetAll();
            cboDMMoi.DisplayMember = "TenDM"; cboDMMoi.ValueMember = "MaDM";

            // Combo NCC cho SP mới (dùng chung nguồn)
            cboNCCMoi.DataSource = NhaCungCapDAL.GetAll();
            cboNCCMoi.DisplayMember = "TenNCC"; cboNCCMoi.ValueMember = "MaNCC";
        }

        void LoadGrid(string kw = "", DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            bool coFilter = !string.IsNullOrWhiteSpace(kw) || tuNgay.HasValue || denNgay.HasValue;
            gridPhieu.DataSource = coFilter
                ? PhieuNhapDAL.Filter(kw, tuNgay, denNgay)
                : PhieuNhapDAL.GetAll();
            if (gridPhieu.Columns.Contains("MaPN"))    gridPhieu.Columns["MaPN"].Visible = false;
            if (gridPhieu.Columns.Contains("TongTien")) gridPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            if (gridPhieu.Columns.Contains("NgayNhap")) gridPhieu.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // Xuất DataGridView hiện tại ra Excel (CSV UTF-8 mở được bằng Excel)
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

                // Header
                var headers = new System.Collections.Generic.List<string>();
                foreach (DataGridViewColumn col in dgv.Columns)
                    if (col.Visible) headers.Add("\"" + col.HeaderText + "\"");
                sb.AppendLine(string.Join(",", headers));

                // Rows
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

                // Ghi file UTF-8 BOM để Excel nhận đúng tiếng Việt
                System.IO.File.WriteAllText(dlg.FileName, sb.ToString(),
                    new System.Text.UTF8Encoding(true));

                if (MessageBox.Show("Xuất Excel thành công!\nMở file ngay?", "Thành công",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(dlg.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }

        void NewPhieu()
        {
            txtSoPhieu.Text = PhieuNhapDAL.SinhSoPhieu();
            txtGhiChu.Clear();

            // dtTemp cần đủ cột để PhieuNhapDAL.Insert() tạo lô HangHoa mới
            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaSP",       typeof(string));
            dtTemp.Columns.Add("TenHH",       typeof(string));
            dtTemp.Columns.Add("MaDM",        typeof(int));
            dtTemp.Columns.Add("MaNCC",       typeof(int));
            dtTemp.Columns.Add("DonViTinh",   typeof(string));
            dtTemp.Columns.Add("GiaNhap",     typeof(decimal));
            dtTemp.Columns.Add("GiaBan",      typeof(decimal));
            dtTemp.Columns.Add("TonToiThieu", typeof(int));
            dtTemp.Columns.Add("NgaySanXuat", typeof(DateTime));
            dtTemp.Columns.Add("HanSuDung",   typeof(DateTime));
            dtTemp.Columns.Add("SoLuong",     typeof(int));
            dtTemp.Columns.Add("DonGia",      typeof(decimal));
            dtTemp.Columns.Add("ThanhTien",   typeof(decimal));

            gridTemp.DataSource = dtTemp;

            // Ẩn cột kỹ thuật
            string[] hide = { "MaDM", "MaNCC", "GiaNhap", "GiaBan", "TonToiThieu" };
            foreach (string col in hide)
                if (gridTemp.Columns.Contains(col)) gridTemp.Columns[col].Visible = false;

            if (gridTemp.Columns.Contains("NgaySanXuat"))
                gridTemp.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (gridTemp.Columns.Contains("HanSuDung"))
                gridTemp.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        // Ẩn/hiện panel theo chế độ chọn SP
        void RdoSP_CheckedChanged(object sender, EventArgs e)
        {
            if (pnlSpCu == null || pnlSpMoi == null) return;
            pnlSpCu.Visible  = rdoSPCu.Checked;
            pnlSpMoi.Visible = rdoSPMoi.Checked;
        }

        void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSL.Text, out int sl) || sl <= 0)
            { MessageBox.Show("Số lượng không hợp lệ!"); return; }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg < 0)
            { MessageBox.Show("Đơn giá không hợp lệ!"); return; }
            if (!decimal.TryParse(txtGiaBanLo.Text, out decimal gb)) gb = 0;
            if (!int.TryParse(txtTonToiThieu.Text, out int ton)) ton = 0;
            if (dtpHSD.Value < dtpNSX.Value)
            { MessageBox.Show("Hạn SD phải sau Ngày SX!"); return; }

            string maSP, tenHH, dvt;
            int maDM, maNCC;

            if (rdoSPCu.Checked)
            {
                // Lấy thông tin từ SP có sẵn
                if (cboHH.SelectedItem == null) { MessageBox.Show("Chọn sản phẩm!"); return; }
                var drv = (DataRowView)cboHH.SelectedItem;
                maSP  = drv["MaSP"].ToString();
                // TenHienThi = "MaSP - TenHH" → tách TenHH
                string tenHienThi = drv["TenHienThi"].ToString();
                int idx = tenHienThi.IndexOf(" - ");
                tenHH = idx >= 0 ? tenHienThi.Substring(idx + 3) : tenHienThi;
                maDM  = drv["MaDM"] == DBNull.Value ? 1 : Convert.ToInt32(drv["MaDM"]);
                maNCC = drv["MaNCC"] == DBNull.Value ? (int)cboNCC.SelectedValue
                                                      : Convert.ToInt32(drv["MaNCC"]);
                dvt   = drv["DonViTinh"].ToString();
            }
            else
            {
                // SP mới — kiểm tra bắt buộc
                if (string.IsNullOrWhiteSpace(txtMaSPMoi.Text)) { MessageBox.Show("Nhập Mã SP!"); return; }
                if (string.IsNullOrWhiteSpace(txtTenMoi.Text))  { MessageBox.Show("Nhập Tên hàng hóa!"); return; }
                if (cboDMMoi.SelectedValue == null)              { MessageBox.Show("Chọn danh mục!"); return; }
                maSP  = txtMaSPMoi.Text.Trim();
                tenHH = txtTenMoi.Text.Trim();
                maDM  = (int)cboDMMoi.SelectedValue;
                maNCC = cboNCCMoi.SelectedValue != null ? (int)cboNCCMoi.SelectedValue
                                                        : (int)cboNCC.SelectedValue;
                dvt   = string.IsNullOrWhiteSpace(txtDVTMoi.Text) ? "Thùng" : txtDVTMoi.Text.Trim();
            }

            dtTemp.Rows.Add(
                maSP, tenHH, maDM, maNCC, dvt,
                dg, gb, ton,
                dtpNSX.Value, dtpHSD.Value,
                sl, dg, sl * dg);

            // Reset field cho dòng tiếp theo
            txtSL.Text          = "1";
            txtDonGia.Text      = "0";
            txtGiaBanLo.Text    = "0";
            txtTonToiThieu.Text = "10";
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0) { MessageBox.Show("Phiếu rỗng!"); return; }
            if (cboNCC.SelectedValue == null) { MessageBox.Show("Chọn nhà cung cấp!"); return; }
            try
            {
                // PhieuNhapDAL.Insert() mới nhận dtTemp đầy đủ cột lô
                PhieuNhapDAL.Insert(txtSoPhieu.Text, (int)cboNCC.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp);
                MessageBox.Show("Lưu phiếu nhập thành công!");
                LoadGrid("", null, null); LoadCombo(); NewPhieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ============================================================
        //   THÊM HÀNG HÓA MỚI NGAY TRONG PHIẾU NHẬP
        // ============================================================
        void BtnNewHH_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmThemHangHoaNhanh())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(dlg.MaSPMoi))
                {
                    // Reload combo SP cũ với method mới
                    cboHH.DataSource = HangHoaDAL.GetDanhSachSP();
                    cboHH.DisplayMember = "TenHienThi";
                    cboHH.ValueMember = "MaSP";

                    cboNCC.DataSource = PhieuNhapDAL.GetNCC();
                    cboNCC.DisplayMember = "TenNCC";
                    cboNCC.ValueMember = "MaNCC";

                    if (dlg.MaNCCMoi > 0) cboNCC.SelectedValue = dlg.MaNCCMoi;

                    // Tự chọn SP vừa thêm
                    var dt = (DataTable)cboHH.DataSource;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MaSP"].ToString() == dlg.MaSPMoi)
                        { cboHH.SelectedIndex = i; break; }
                    }
                    // Chuyển về chế độ SP cũ
                    rdoSPCu.Checked = true;
                }
            }
        }
    }

    // ================================================================
    //   DIALOG NHẬP NHANH HÀNG HÓA MỚI
    // ================================================================
    internal class frmThemHangHoaNhanh : Form
    {
        public string MaSPMoi { get; private set; }
        public int MaNCCMoi { get; private set; }

        TextBox txtMaSP, txtTen, txtDVT, txtGiaNhap, txtGiaBan, txtTonMin;
        ComboBox cboDM, cboNCC;
        DateTimePicker dtpNSX, dtpHSD;

        Button btnNewDM, btnNewNCC;
        public frmThemHangHoaNhanh()
        {
            Text = "Thêm hàng hóa mới";
            Size = new Size(460, 480);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9);

            int y = 15;
            void AddRow(string label, Control ctl)
            {
                Controls.Add(new Label { Text = label, Location = new Point(15, y + 4), AutoSize = true });
                ctl.Location = new Point(140, y);
                ctl.Width = 280;
                Controls.Add(ctl);
                y += 32;
            }

            txtMaSP = new TextBox(); AddRow("Mã SP (*):", txtMaSP);
            txtTen = new TextBox(); AddRow("Tên hàng (*):", txtTen);

            Controls.Add(new Label
            {
                Text = "Danh mục (*):",
                Location = new Point(15, y + 4),
                AutoSize = true
            });

            cboDM = new ComboBox
            {
                Location = new Point(140, y),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cboDM.DataSource = DanhMucDAL.GetAll();
            cboDM.DisplayMember = "TenDM";
            cboDM.ValueMember = "MaDM";

            Controls.Add(cboDM);

            btnNewDM = new Button
            {
                Text = "+ DM",
                Location = new Point(350, y - 1),
                Size = new Size(70, 26),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnNewDM.Click += BtnNewDM_Click;

            Controls.Add(btnNewDM);

            y += 32;

            Controls.Add(new Label
            {
                Text = "Nhà cung cấp (*):",
                Location = new Point(15, y + 4),
                AutoSize = true
            });

            cboNCC = new ComboBox
            {
                Location = new Point(140, y),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cboNCC.DataSource = NhaCungCapDAL.GetAll();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";

            Controls.Add(cboNCC);

            btnNewNCC = new Button
            {
                Text = "+ NCC",
                Location = new Point(350, y - 1),
                Size = new Size(70, 26),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnNewNCC.Click += BtnNewNCC_Click;

            Controls.Add(btnNewNCC);

            y += 32;

            txtDVT = new TextBox { Text = "Thùng" }; AddRow("Đơn vị tính:", txtDVT);
            txtGiaNhap = new TextBox { Text = "0" }; AddRow("Giá nhập:", txtGiaNhap);
            txtGiaBan = new TextBox { Text = "0" }; AddRow("Giá bán:", txtGiaBan);
            txtTonMin = new TextBox { Text = "0" }; AddRow("Tồn tối thiểu:", txtTonMin);

            dtpNSX = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            AddRow("Ngày SX:", dtpNSX);
            dtpHSD = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddYears(1) };
            AddRow("Hạn SD:", dtpHSD);

            y += 10;
            var btnOK = new Button
            {
                Text = "✓ Lưu", Location = new Point(140, y), Size = new Size(130, 34),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnOK.Click += BtnOK_Click;
            var btnCancel = new Button
            {
                Text = "Hủy", Location = new Point(280, y), Size = new Size(100, 34),
                BackColor = Color.FromArgb(189, 195, 199), FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };
            Controls.Add(btnOK); Controls.Add(btnCancel);
            AcceptButton = btnOK; CancelButton = btnCancel;
        }
        void BtnNewDM_Click(object sender, EventArgs e)
        {
            string tenDM = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên danh mục mới:",
                "Thêm danh mục");

            if (string.IsNullOrWhiteSpace(tenDM))
                return;

            try
            {
                // thêm DB
                DanhMucDAL.Insert(tenDM);

                // load lại datasource
                DataTable dt = DanhMucDAL.GetAll();

                cboDM.DataSource = dt;
                cboDM.DisplayMember = "TenDM";
                cboDM.ValueMember = "MaDM";

                // tự chọn item vừa thêm
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TenDM"].ToString() == tenDM)
                    {
                        cboDM.SelectedValue = row["MaDM"];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
                void BtnNewNCC_Click(object sender, EventArgs e)
            {
                string tenNCC = Microsoft.VisualBasic.Interaction.InputBox(
                    "Nhập tên nhà cung cấp mới:",
                    "Thêm nhà cung cấp");

                if (string.IsNullOrWhiteSpace(tenNCC))
                    return;

                try
                {
                    // thêm NCC vào database
                    NhaCungCapDAL.Insert(
                        tenNCC,
                        "",
                        "",
                        ""
                    );

                    // load lại datasource
                    DataTable dt = NhaCungCapDAL.GetAll();

                    cboNCC.DataSource = dt;
                    cboNCC.DisplayMember = "TenNCC";
                    cboNCC.ValueMember = "MaNCC";

                    // tìm NCC vừa thêm
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TenNCC"].ToString() == tenNCC)
                        {
                            // lưu mã NCC mới
                            MaNCCMoi = Convert.ToInt32(row["MaNCC"]);

                            // chọn luôn trong combobox popup
                            cboNCC.SelectedValue = MaNCCMoi;

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text)) { MessageBox.Show("Nhập Mã SP"); return; }
            if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageBox.Show("Nhập tên hàng"); return; }
            if (cboDM.SelectedValue == null) { MessageBox.Show("Chọn danh mục"); return; }
            if (cboNCC.SelectedValue == null) { MessageBox.Show("Chọn nhà cung cấp"); return; }
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal gn) || gn < 0) { MessageBox.Show("Giá nhập không hợp lệ"); return; }
            if (!decimal.TryParse(txtGiaBan.Text, out decimal gb) || gb < 0) { MessageBox.Show("Giá bán không hợp lệ"); return; }
            if (!int.TryParse(txtTonMin.Text, out int tm) || tm < 0) tm = 0;

            try
            {
                // Insert signature mới: thêm soLuong=0, ngayNhapLo=now
                // SoLuong=0 vì lô thực sự sẽ tạo khi lưu phiếu nhập
                HangHoaDAL.Insert(
                    txtMaSP.Text.Trim(), txtTen.Text.Trim(),
                    (int)cboDM.SelectedValue, (int)cboNCC.SelectedValue,
                    txtDVT.Text.Trim(), gn, gb, tm,
                    dtpNSX.Value, dtpHSD.Value,
                    0, DateTime.Now);
                MaSPMoi = txtMaSP.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
