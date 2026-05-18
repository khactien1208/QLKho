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
        Button btnNew, btnAddItem, btnSave, btnNewHH, btnNewDM, btnNewNCC;
        DataTable dtTemp;

        public frmPhieuNhap()
        {
            Text = "Phiếu nhập"; BackColor = Color.WhiteSmoke;

            var top = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.White };
            var lblTitle = new Label
            {
                Text = "PHIẾU NHẬP KHO",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(15, 40)
            };
            top.Controls.Add(lblTitle);

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
            // Thu hẹp combo để chừa chỗ cho nút "+ Mới"
            cboHH = new ComboBox { Location = new Point(100, y), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboHH.SelectedIndexChanged += (s, e) => {
                if (cboHH.SelectedItem is DataRowView drv) txtDonGia.Text = drv["GiaNhap"].ToString();
            };
            gb.Controls.Add(cboHH);

            // === NÚT THÊM HÀNG HÓA MỚI ===
            btnNewHH = new Button
            {
                Text = "+ Mới",
                Location = new Point(365, y - 1),
                Size = new Size(65, 26),
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Bold)
            };
            btnNewHH.Click += BtnNewHH_Click;
            gb.Controls.Add(btnNewHH);
            y += 32;

            gb.Controls.Add(new Label { Text = "Số lượng:", Location = new Point(10, y + 3), AutoSize = true });
            txtSL = new TextBox { Location = new Point(100, y), Width = 100, Text = "1" };
            gb.Controls.Add(txtSL);
            gb.Controls.Add(new Label { Text = "Đơn giá:", Location = new Point(220, y + 3), AutoSize = true });
            txtDonGia = new TextBox { Location = new Point(290, y), Width = 140, Text = "0" };
            gb.Controls.Add(txtDonGia); y += 40;

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

            Load += (s, e) => { LoadCombo(); LoadGrid(); NewPhieu(); };
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
            dtTemp.Rows.Add((int)cboHH.SelectedValue, drv["TenHienThi"], sl, dg, sl * dg);
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0) { MessageBox.Show("Phiếu rỗng!"); return; }
            try
            {
                PhieuNhapDAL.Insert(txtSoPhieu.Text, (int)cboNCC.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp);
                MessageBox.Show("Lưu phiếu nhập thành công!");
                LoadGrid(); LoadCombo(); NewPhieu();
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
                    // Reload combo
                    cboHH.DataSource = HangHoaDAL.GetForCombo();
                    cboHH.DisplayMember = "TenHienThi";
                    cboHH.ValueMember = "MaHH";
                    // cập nhật NCC form chính
                    cboNCC.DataSource = PhieuNhapDAL.GetNCC();
                    cboNCC.DisplayMember = "TenNCC";
                    cboNCC.ValueMember = "MaNCC";

                    // tự chọn NCC vừa thêm
                    if (dlg.MaNCCMoi > 0)
                    {
                        cboNCC.SelectedValue = dlg.MaNCCMoi;
                    }

                    // Tự chọn hàng vừa thêm theo MaSP
                    var dt = (DataTable)cboHH.DataSource;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ten = dt.Rows[i]["TenHienThi"].ToString();
                        if (ten.StartsWith(dlg.MaSPMoi + " - "))
                        {
                            cboHH.SelectedIndex = i;
                            break;
                        }
                    }
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
                HangHoaDAL.Insert(
                    txtMaSP.Text.Trim(), txtTen.Text.Trim(),
                    (int)cboDM.SelectedValue, (int)cboNCC.SelectedValue,
                    txtDVT.Text.Trim(), gn, gb, tm,
                    dtpNSX.Value, dtpHSD.Value);
                MaSPMoi = txtMaSP.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
