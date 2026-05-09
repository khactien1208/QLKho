using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public class frmNguoiDung : Form
    {
        DataGridView grid;
        TextBox txtUser, txtHoTen, txtMatKhau;
        ComboBox cboVaiTro;
        CheckBox chkTrangThai;
        Button btnAdd, btnEdit, btnDel, btnNew, btnReset;
        int? selectedId = null;

        public frmNguoiDung()
        {
            Text = "Quản lý người dùng";
            BackColor = Color.WhiteSmoke;

            // Chặn truy cập nếu không phải Admin
            if (!PhanQuyen.IsAdmin)
            {
                Load += (s, e) =>
                {
                    MessageBox.Show("Chỉ Admin mới được phép truy cập chức năng này.",
                        "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                };
            }

            var top = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
            top.Controls.Add(new Label
            {
                Text = "QUẢN LÝ NGƯỜI DÙNG",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true,
                ForeColor = Color.FromArgb(44, 62, 80)
            });

            var pnlForm = new GroupBox
            {
                Text = "Thông tin tài khoản",
                Dock = DockStyle.Right,
                Width = 340,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.White
            };

            int yy = 30;
            pnlForm.Controls.Add(new Label { Text = "Tên đăng nhập:", Location = new Point(15, yy + 3), AutoSize = true });
            txtUser = new TextBox { Location = new Point(130, yy), Width = 190 };
            pnlForm.Controls.Add(txtUser); yy += 32;

            pnlForm.Controls.Add(new Label { Text = "Họ tên:", Location = new Point(15, yy + 3), AutoSize = true });
            txtHoTen = new TextBox { Location = new Point(130, yy), Width = 190 };
            pnlForm.Controls.Add(txtHoTen); yy += 32;

            pnlForm.Controls.Add(new Label { Text = "Vai trò:", Location = new Point(15, yy + 3), AutoSize = true });
            cboVaiTro = new ComboBox
            {
                Location = new Point(130, yy),
                Width = 190,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboVaiTro.Items.AddRange(new object[] { "Admin", "ThuKho", "NhanVien" });
            cboVaiTro.SelectedIndex = 2;
            pnlForm.Controls.Add(cboVaiTro); yy += 32;

            pnlForm.Controls.Add(new Label { Text = "Mật khẩu:", Location = new Point(15, yy + 3), AutoSize = true });
            txtMatKhau = new TextBox { Location = new Point(130, yy), Width = 190, UseSystemPasswordChar = true };
            pnlForm.Controls.Add(txtMatKhau); yy += 32;

            pnlForm.Controls.Add(new Label
            {
                Text = "(Khi sửa: để trống nếu\nkhông đổi mật khẩu)",
                Location = new Point(130, yy),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8, FontStyle.Italic)
            });
            yy += 36;

            chkTrangThai = new CheckBox
            {
                Text = "Đang hoạt động",
                Location = new Point(130, yy),
                AutoSize = true,
                Checked = true
            };
            pnlForm.Controls.Add(chkTrangThai); yy += 36;

            btnAdd = new Button { Text = "➕ Thêm", Location = new Point(15, yy), Size = new Size(95, 32), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnEdit = new Button { Text = "✏️ Sửa", Location = new Point(115, yy), Size = new Size(95, 32), BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDel = new Button { Text = "🗑 Khóa", Location = new Point(215, yy), Size = new Size(105, 32), BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            yy += 38;
            btnNew = new Button { Text = "🆕 Mới", Location = new Point(15, yy), Size = new Size(150, 32) };
            btnReset = new Button { Text = "🔑 Reset mật khẩu", Location = new Point(170, yy), Size = new Size(150, 32), BackColor = Color.FromArgb(243, 156, 18), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            pnlForm.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDel, btnNew, btnReset });

            grid = new DataGridView
            {
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
            Controls.Add(pnlForm);
            Controls.Add(top);

            btnAdd.Click += (s, e) => Them();
            btnEdit.Click += (s, e) => Sua();
            btnDel.Click += (s, e) => Khoa();
            btnNew.Click += (s, e) => ClearForm();
            btnReset.Click += (s, e) => ResetMatKhau();

            grid.SelectionChanged += (s, e) => GridSelected();

            // Nếu không phải admin -> disable mọi thao tác
            if (!PhanQuyen.IsAdmin)
            {
                foreach (Control c in new Control[] { txtUser, txtHoTen, txtMatKhau, cboVaiTro, chkTrangThai, btnAdd, btnEdit, btnDel, btnNew, btnReset })
                    c.Enabled = false;
            }

            Load += (s, e) => LoadGrid();
        }

        void LoadGrid()
        {
            try
            {
                grid.DataSource = NguoiDungDAL.GetAll();
                if (grid.Columns.Contains("MaND")) grid.Columns["MaND"].HeaderText = "Mã";
                if (grid.Columns.Contains("TenDangNhap")) grid.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                if (grid.Columns.Contains("HoTen")) grid.Columns["HoTen"].HeaderText = "Họ tên";
                if (grid.Columns.Contains("VaiTro")) grid.Columns["VaiTro"].HeaderText = "Vai trò";
                if (grid.Columns.Contains("TrangThai")) grid.Columns["TrangThai"].HeaderText = "Hoạt động";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        void GridSelected()
        {
            if (grid.CurrentRow == null || grid.CurrentRow.Index < 0) return;
            var r = grid.CurrentRow;
            try
            {
                selectedId = Convert.ToInt32(r.Cells["MaND"].Value);
                txtUser.Text = r.Cells["TenDangNhap"].Value?.ToString();
                txtUser.Enabled = false; // không cho đổi tên đăng nhập
                txtHoTen.Text = r.Cells["HoTen"].Value?.ToString();
                cboVaiTro.SelectedItem = r.Cells["VaiTro"].Value?.ToString();
                chkTrangThai.Checked = Convert.ToInt32(r.Cells["TrangThai"].Value) == 1;
                txtMatKhau.Text = string.Empty;
            }
            catch { }
        }

        void ClearForm()
        {
            selectedId = null;
            txtUser.Enabled = true;
            txtUser.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            cboVaiTro.SelectedIndex = 2;
            chkTrangThai.Checked = true;
            grid.ClearSelection();
        }

        void Them()
        {
            if (!PhanQuyen.IsAdmin) return;
            var user = txtUser.Text.Trim();
            var pass = txtMatKhau.Text;
            var hoTen = txtHoTen.Text.Trim();
            var vaiTro = cboVaiTro.SelectedItem?.ToString();

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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void Sua()
        {
            if (!PhanQuyen.IsAdmin) return;
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trong danh sách.");
                return;
            }
            var hoTen = txtHoTen.Text.Trim();
            var vaiTro = cboVaiTro.SelectedItem?.ToString();
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
                    {
                        MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự. Đã cập nhật thông tin nhưng KHÔNG đổi mật khẩu.");
                    }
                    else
                    {
                        NguoiDungDAL.DoiMatKhau(selectedId.Value, txtMatKhau.Text);
                    }
                }
                MessageBox.Show("Đã cập nhật.");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void Khoa()
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void ResetMatKhau()
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
