using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmHangHoa : Form
    {
        DataGridView grid;
        TextBox txtMaSP, txtTen, txtDVT, txtGiaNhap, txtGiaBan, txtTonMin, txtSearch;
        ComboBox cboDM, cboNCC;
        Button btnAdd, btnEdit, btnDel, btnNew, btnSearch;
        DateTimePicker dtpNSX, dtpHSD;
        int? selectedId = null;

        public frmHangHoa()
        {
            Text = "Quản lý hàng hóa";
            BackColor = Color.WhiteSmoke;

            var top = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
            top.Controls.Add(new Label { Text = "QUẢN LÝ HÀNG HÓA", Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15), AutoSize = true, ForeColor = Color.FromArgb(44, 62, 80) });
            txtSearch = new TextBox { Location = new Point(300, 15), Width = 220, Font = new Font("Segoe UI", 10) };
            btnSearch = new Button { Text = "🔍 Tìm", Location = new Point(530, 13), Size = new Size(80, 28) };
            btnSearch.Click += (s,e) => LoadGrid(txtSearch.Text);
            top.Controls.AddRange(new Control[] { txtSearch, btnSearch });

            var pnlForm = new GroupBox { Text = "Thông tin hàng hóa", Dock = DockStyle.Right, Width = 320,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), BackColor = Color.White };

            int yy = 30;
            pnlForm.Controls.Add(new Label { Text = "Mã SP:", Location = new Point(15, yy+3), AutoSize = true });
            txtMaSP = new TextBox { Location = new Point(110, yy), Width = 190 }; pnlForm.Controls.Add(txtMaSP); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Tên hàng:", Location = new Point(15, yy+3), AutoSize = true });
            txtTen = new TextBox { Location = new Point(110, yy), Width = 190 }; pnlForm.Controls.Add(txtTen); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Danh mục:", Location = new Point(15, yy+3), AutoSize = true });
            cboDM = new ComboBox { Location = new Point(110, yy), Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
            pnlForm.Controls.Add(cboDM); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Nhà cung cấp:", Location = new Point(15, yy+3), AutoSize = true });
            cboNCC = new ComboBox { Location = new Point(110, yy), Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
            pnlForm.Controls.Add(cboNCC); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "ĐVT:", Location = new Point(15, yy+3), AutoSize = true });
            txtDVT = new TextBox { Location = new Point(110, yy), Width = 190 }; pnlForm.Controls.Add(txtDVT); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Giá nhập:", Location = new Point(15, yy+3), AutoSize = true });
            txtGiaNhap = new TextBox { Location = new Point(110, yy), Width = 190, Text = "0" }; pnlForm.Controls.Add(txtGiaNhap); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Giá bán:", Location = new Point(15, yy+3), AutoSize = true });
            txtGiaBan = new TextBox { Location = new Point(110, yy), Width = 190, Text = "0" }; pnlForm.Controls.Add(txtGiaBan); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Tồn tối thiểu:", Location = new Point(15, yy+3), AutoSize = true });
            txtTonMin = new TextBox { Location = new Point(110, yy), Width = 190, Text = "10" }; pnlForm.Controls.Add(txtTonMin); yy += 40;
            pnlForm.Controls.Add(new Label { Text = "Ngày sản xuất:",   Location = new Point(15, yy+3), AutoSize = true });
            dtpNSX = new DateTimePicker { Location = new Point(110, yy), Width = 190, Format = DateTimePickerFormat.Short }; pnlForm.Controls.Add(dtpNSX); yy += 32;
            pnlForm.Controls.Add(new Label { Text = "Hạn sử dụng:", Location = new Point(15, yy+3), AutoSize = true });     
            dtpHSD = new DateTimePicker { Location = new Point(110, yy), Width = 190, Format = DateTimePickerFormat.Short }; pnlForm.Controls.Add(dtpHSD); yy += 32;

            btnNew = new Button { Text = "Mới", Location = new Point(15, yy), Size = new Size(70, 32) };
            btnAdd = new Button { Text = "Thêm", Location = new Point(90, yy), Size = new Size(70, 32),
                BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit = new Button { Text = "Sửa", Location = new Point(165, yy), Size = new Size(70, 32),
                BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDel = new Button { Text = "Xóa", Location = new Point(240, yy), Size = new Size(70, 32),
                BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            pnlForm.Controls.AddRange(new Control[] { btnNew, btnAdd, btnEdit, btnDel });

            grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White, RowHeadersVisible = false };
            grid.SelectionChanged += Grid_SelectionChanged;

            Controls.Add(grid);
            Controls.Add(pnlForm);
            Controls.Add(top);

            btnNew.Click += (s,e) => ClearForm();
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDel.Click += BtnDel_Click;

            Load += (s,e) => { LoadCombo(); LoadGrid(""); };
        }

        void LoadCombo()
        {
            cboDM.DataSource = DanhMucDAL.GetAll();
            cboDM.DisplayMember = "TenDM";
            cboDM.ValueMember = "MaDM";
            cboNCC.DataSource = NhaCungCapDAL.GetAll();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }
        void LoadGrid(string kw)
        {
            grid.DataSource = string.IsNullOrWhiteSpace(kw) ? HangHoaDAL.GetAll() : HangHoaDAL.Search(kw);
            if (grid.Columns.Contains("MaHH")) grid.Columns["MaHH"].Visible = false;
        }
        void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Cells["MaHH"].Value == null) return;
            selectedId = (int)grid.CurrentRow.Cells["MaHH"].Value;
            txtMaSP.Text = grid.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTen.Text = grid.CurrentRow.Cells["TenHH"].Value.ToString();
            txtDVT.Text = grid.CurrentRow.Cells["DonViTinh"].Value.ToString();
            txtGiaNhap.Text = grid.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = grid.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtTonMin.Text = grid.CurrentRow.Cells["TonToiThieu"].Value.ToString();
            cboDM.Text = grid.CurrentRow.Cells["TenDM"].Value.ToString();
            cboNCC.Text = grid.CurrentRow.Cells["TenNCC"].Value.ToString();
            dtpNSX.Value = grid.CurrentRow.Cells["NgaySanXuat"].Value == DBNull.Value ? DateTime.Now : Convert.ToDateTime(grid.CurrentRow.Cells["NgaySanXuat"].Value);
            dtpHSD.Value = grid.CurrentRow.Cells["HanSuDung"].Value == DBNull.Value ? DateTime.Now : Convert.ToDateTime(grid.CurrentRow.Cells["HanSuDung"].Value);
        }
        void ClearForm()
        {
            selectedId = null;
            txtMaSP.Clear(); txtTen.Clear(); txtDVT.Clear();
            txtGiaNhap.Text = "0"; txtGiaBan.Text = "0"; txtTonMin.Text = "10";
            if (cboDM.Items.Count > 0) cboDM.SelectedIndex = 0;
            if (cboNCC.Items.Count > 0) cboNCC.SelectedIndex = 0;
            dtpNSX.Value = DateTime.Now;
            dtpHSD.Value = DateTime.Now;
        }
        bool Validate(out int maDM, out int maNCC, out decimal gn, out decimal gb, out int tt, out DateTime ngaySX, out DateTime hanSD)
        {
            maDM = 0; maNCC = 0; gn = 0; gb = 0; tt = 0; ngaySX = dtpNSX.Value; hanSD = dtpHSD.Value;
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
            { MessageBox.Show("Nhập mã SP và tên hàng!"); return false; }
            if (cboDM.SelectedValue == null || cboNCC.SelectedValue == null)
            { MessageBox.Show("Chọn danh mục và nhà cung cấp!"); return false; }
            if(hanSD < ngaySX)
            { MessageBox.Show("Hạn sử dụng phải sau ngày sản xuất!"); return false; }

            maDM = (int)cboDM.SelectedValue;
            maNCC = (int)cboNCC.SelectedValue;

            decimal.TryParse(txtGiaNhap.Text, out gn);
            decimal.TryParse(txtGiaBan.Text, out gb);
            int.TryParse(txtTonMin.Text, out tt);
            return true;
        }
        void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Validate(out int dm, out int ncc, out decimal gn, out decimal gb, out int tt, out DateTime ngaySX, out DateTime hanSD)) return;
            try { HangHoaDAL.Insert(txtMaSP.Text, txtTen.Text, dm, ncc, txtDVT.Text, gn, gb, tt, ngaySX, hanSD);
                MessageBox.Show("Thêm thành công!"); LoadGrid(""); ClearForm(); }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        void BtnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Chọn dòng cần sửa!"); return; }
            if (!Validate(out int dm, out int ncc, out decimal gn, out decimal gb, out int tt, out DateTime ngaySX, out DateTime hanSD)) return;
            try { HangHoaDAL.Update(selectedId.Value, txtMaSP.Text, txtTen.Text, dm, ncc, txtDVT.Text, gn, gb, tt, ngaySX, hanSD);
                MessageBox.Show("Cập nhật thành công!"); LoadGrid(""); }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        void BtnDel_Click(object sender, EventArgs e)
        {
            if (selectedId == null) { MessageBox.Show("Chọn dòng cần xóa!"); return; }
            if (MessageBox.Show("Xóa hàng này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            HangHoaDAL.Delete(selectedId.Value);
            LoadGrid(""); ClearForm();
        }
    }
}