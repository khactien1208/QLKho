using System;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public partial class frmNguoiDung : Form
    {
        private int? selectedId = null;

        public frmNguoiDung()
        {
            InitializeComponent();

            // Nếu không phải Admin → disable mọi thao tác nhập liệu
            if (!PhanQuyen.IsAdmin)
            {
                foreach (Control c in new Control[] {
                    txtUser, txtHoTen, txtMatKhau, cboVaiTro,
                    chkTrangThai, btnAdd, btnEdit, btnDel, btnNew, btnReset })
                    c.Enabled = false;
            }
        }

        // =====================================================================
        //  LOAD
        // =====================================================================

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            if (!PhanQuyen.IsAdmin)
                MessageBox.Show("Chỉ Admin mới được phép truy cập chức năng này.",
                    "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadGrid();
        }

        // =====================================================================
        //  GRID
        // =====================================================================

        private void LoadGrid()
        {
            try
            {
                grid.DataSource = NguoiDungDAL.GetAll();
                if (grid.Columns.Contains("MaND"))         grid.Columns["MaND"].HeaderText         = "Mã";
                if (grid.Columns.Contains("TenDangNhap"))  grid.Columns["TenDangNhap"].HeaderText  = "Tên đăng nhập";
                if (grid.Columns.Contains("HoTen"))        grid.Columns["HoTen"].HeaderText        = "Họ tên";
                if (grid.Columns.Contains("VaiTro"))       grid.Columns["VaiTro"].HeaderText       = "Vai trò";
                if (grid.Columns.Contains("TrangThai"))    grid.Columns["TrangThai"].HeaderText    = "Hoạt động";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Index < 0) return;
            var r = grid.CurrentRow;
            try
            {
                selectedId          = Convert.ToInt32(r.Cells["MaND"].Value);
                txtUser.Text        = r.Cells["TenDangNhap"].Value?.ToString();
                txtUser.Enabled     = false; // không cho đổi tên đăng nhập
                txtHoTen.Text       = r.Cells["HoTen"].Value?.ToString();
                cboVaiTro.SelectedItem = r.Cells["VaiTro"].Value?.ToString();
                chkTrangThai.Checked = Convert.ToInt32(r.Cells["TrangThai"].Value) == 1;
                txtMatKhau.Text     = string.Empty;
            }
            catch { }
        }

        // =====================================================================
        //  BUTTON EVENTS
        // =====================================================================

        private void btnAdd_Click(object sender, EventArgs e)   => Them();
        private void btnEdit_Click(object sender, EventArgs e)  => Sua();
        private void btnDel_Click(object sender, EventArgs e)   => Khoa();
        private void btnNew_Click(object sender, EventArgs e)   => ClearForm();
        private void btnReset_Click(object sender, EventArgs e) => ResetMatKhau();

        // =====================================================================
        //  BUSINESS LOGIC
        // =====================================================================

        private void ClearForm()
        {
            selectedId          = null;
            txtUser.Enabled     = true;
            txtUser.Text        = string.Empty;
            txtHoTen.Text       = string.Empty;
            txtMatKhau.Text     = string.Empty;
            cboVaiTro.SelectedIndex = 2;
            chkTrangThai.Checked = true;
            grid.ClearSelection();
        }

        private void Them()
        {
            if (!PhanQuyen.IsAdmin) return;

            string user  = txtUser.Text.Trim();
            string pass  = txtMatKhau.Text;
            string hoTen = txtHoTen.Text.Trim();
            string vaiTro = cboVaiTro.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(vaiTro))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập, Mật khẩu, Họ tên, Vai trò.");
                return;
            }
            if (pass.Length < 4)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 4 ký tự.");
                return;
            }
            try
            {
                if (NguoiDungDAL.TonTai(user))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                    return;
                }
                NguoiDungDAL.Them(user, pass, hoTen, vaiTro);
                MessageBox.Show("Đã thêm tài khoản.");
                LoadGrid();
                ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void Sua()
        {
            if (!PhanQuyen.IsAdmin) return;
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trong danh sách.");
                return;
            }

            string hoTen  = txtHoTen.Text.Trim();
            string vaiTro = cboVaiTro.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(vaiTro))
            {
                MessageBox.Show("Họ tên và vai trò không được để trống.");
                return;
            }
            try
            {
                NguoiDungDAL.CapNhat(selectedId.Value, hoTen, vaiTro, chkTrangThai.Checked);

                if (!string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    if (txtMatKhau.Text.Length < 4)
                        MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự. " +
                            "Đã cập nhật thông tin nhưng KHÔNG đổi mật khẩu.");
                    else
                        NguoiDungDAL.DoiMatKhau(selectedId.Value, txtMatKhau.Text);
                }

                MessageBox.Show("Đã cập nhật.");
                LoadGrid();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void Khoa()
        {
            if (!PhanQuyen.IsAdmin) return;
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản.");
                return;
            }
            if (Program.CurrentUser != null && selectedId.Value == Program.CurrentUser.MaND)
            {
                MessageBox.Show("Không thể tự khóa tài khoản đang đăng nhập.");
                return;
            }
            if (MessageBox.Show("Khóa (vô hiệu hóa) tài khoản này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                NguoiDungDAL.Xoa(selectedId.Value);
                MessageBox.Show("Đã khóa tài khoản.");
                LoadGrid();
                ClearForm();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void ResetMatKhau()
        {
            if (!PhanQuyen.IsAdmin) return;
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản.");
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text) || txtMatKhau.Text.Length < 4)
            {
                MessageBox.Show("Nhập mật khẩu mới (≥ 4 ký tự) vào ô Mật khẩu trước khi reset.");
                return;
            }
            if (MessageBox.Show("Đặt lại mật khẩu cho tài khoản đã chọn?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                NguoiDungDAL.DoiMatKhau(selectedId.Value, txtMatKhau.Text);
                MessageBox.Show("Đã đặt lại mật khẩu.");
                txtMatKhau.Text = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
    }
}
