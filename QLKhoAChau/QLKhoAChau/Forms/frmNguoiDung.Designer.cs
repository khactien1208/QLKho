namespace QLKhoAChau.Forms
{
    partial class frmNguoiDung
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop        = new System.Windows.Forms.Panel();
            this.lblTitle      = new System.Windows.Forms.Label();
            this.grpForm       = new System.Windows.Forms.GroupBox();
            this.lblUser       = new System.Windows.Forms.Label();
            this.txtUser       = new System.Windows.Forms.TextBox();
            this.lblHoTen      = new System.Windows.Forms.Label();
            this.txtHoTen      = new System.Windows.Forms.TextBox();
            this.lblVaiTro     = new System.Windows.Forms.Label();
            this.cboVaiTro     = new System.Windows.Forms.ComboBox();
            this.lblMatKhau    = new System.Windows.Forms.Label();
            this.txtMatKhau    = new System.Windows.Forms.TextBox();
            this.lblHintMK     = new System.Windows.Forms.Label();
            this.chkTrangThai  = new System.Windows.Forms.CheckBox();
            this.btnAdd        = new System.Windows.Forms.Button();
            this.btnEdit       = new System.Windows.Forms.Button();
            this.btnDel        = new System.Windows.Forms.Button();
            this.btnNew        = new System.Windows.Forms.Button();
            this.btnReset      = new System.Windows.Forms.Button();
            this.pnlGrid       = new System.Windows.Forms.Panel();
            this.grid          = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.grpForm.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // ------------------------------------------------------------------
            // pnlTop
            // ------------------------------------------------------------------
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height  = 70;
            this.pnlTop.Name    = "pnlTop";
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location  = new System.Drawing.Point(15, 40);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "QUẢN LÝ NGƯỜI DÙNG";

            // ------------------------------------------------------------------
            // grpForm  (right panel)
            // ------------------------------------------------------------------
            this.grpForm.BackColor = System.Drawing.Color.White;
            this.grpForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUser,    this.txtUser,
                this.lblHoTen,   this.txtHoTen,
                this.lblVaiTro,  this.cboVaiTro,
                this.lblMatKhau, this.txtMatKhau,
                this.lblHintMK,
                this.chkTrangThai,
                this.btnAdd,  this.btnEdit, this.btnDel,
                this.btnNew,  this.btnReset
            });
            this.grpForm.Dock    = System.Windows.Forms.DockStyle.Right;
            this.grpForm.Font    = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpForm.Name    = "grpForm";
            this.grpForm.TabIndex = 1;
            this.grpForm.Text    = "Thông tin tài khoản";
            this.grpForm.Width   = 340;

            // Row helpers: lx=15, tx=130, tw=190, step=32
            // y=30: Tên đăng nhập
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 33);
            this.lblUser.Name     = "lblUser";
            this.lblUser.Text     = "Tên đăng nhập:";

            this.txtUser.Location = new System.Drawing.Point(130, 30);
            this.txtUser.Name     = "txtUser";
            this.txtUser.Size     = new System.Drawing.Size(190, 23);
            this.txtUser.TabIndex = 0;

            // y=62: Họ tên
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 65);
            this.lblHoTen.Name     = "lblHoTen";
            this.lblHoTen.Text     = "Họ tên:";

            this.txtHoTen.Location = new System.Drawing.Point(130, 62);
            this.txtHoTen.Name     = "txtHoTen";
            this.txtHoTen.Size     = new System.Drawing.Size(190, 23);
            this.txtHoTen.TabIndex = 1;

            // y=94: Vai trò
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(15, 97);
            this.lblVaiTro.Name     = "lblVaiTro";
            this.lblVaiTro.Text     = "Vai trò:";

            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Items.AddRange(new object[] { "Admin", "ThuKho", "NhanVien" });
            this.cboVaiTro.Location      = new System.Drawing.Point(130, 94);
            this.cboVaiTro.Name          = "cboVaiTro";
            this.cboVaiTro.Size          = new System.Drawing.Size(190, 23);
            this.cboVaiTro.TabIndex      = 2;
            this.cboVaiTro.SelectedIndex = 2;

            // y=126: Mật khẩu
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(15, 129);
            this.lblMatKhau.Name     = "lblMatKhau";
            this.lblMatKhau.Text     = "Mật khẩu:";

            this.txtMatKhau.Location             = new System.Drawing.Point(130, 126);
            this.txtMatKhau.Name                 = "txtMatKhau";
            this.txtMatKhau.Size                 = new System.Drawing.Size(190, 23);
            this.txtMatKhau.TabIndex             = 3;
            this.txtMatKhau.UseSystemPasswordChar = true;

            // y=154: hint label
            this.lblHintMK.AutoSize  = true;
            this.lblHintMK.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHintMK.ForeColor = System.Drawing.Color.Gray;
            this.lblHintMK.Location  = new System.Drawing.Point(130, 154);
            this.lblHintMK.Name      = "lblHintMK";
            this.lblHintMK.Text      = "(Khi sửa: để trống nếu\nkhông đổi mật khẩu)";

            // y=190: CheckBox trạng thái
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked  = true;
            this.chkTrangThai.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTrangThai.Location = new System.Drawing.Point(130, 190);
            this.chkTrangThai.Name     = "chkTrangThai";
            this.chkTrangThai.TabIndex = 4;
            this.chkTrangThai.Text     = "Đang hoạt động";

            // y=226: btnAdd / btnEdit / btnDel
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location  = new System.Drawing.Point(15, 226);
            this.btnAdd.Name      = "btnAdd";
            this.btnAdd.Size      = new System.Drawing.Size(95, 32);
            this.btnAdd.TabIndex  = 5;
            this.btnAdd.Text      = "➕ Thêm";
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location  = new System.Drawing.Point(115, 226);
            this.btnEdit.Name      = "btnEdit";
            this.btnEdit.Size      = new System.Drawing.Size(95, 32);
            this.btnEdit.TabIndex  = 6;
            this.btnEdit.Text      = "✏️ Sửa";
            this.btnEdit.Click    += new System.EventHandler(this.btnEdit_Click);

            this.btnDel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location  = new System.Drawing.Point(215, 226);
            this.btnDel.Name      = "btnDel";
            this.btnDel.Size      = new System.Drawing.Size(105, 32);
            this.btnDel.TabIndex  = 7;
            this.btnDel.Text      = "🗑 Khóa";
            this.btnDel.Click    += new System.EventHandler(this.btnDel_Click);

            // y=264: btnNew / btnReset
            this.btnNew.Location = new System.Drawing.Point(15, 264);
            this.btnNew.Name     = "btnNew";
            this.btnNew.Size     = new System.Drawing.Size(150, 32);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text     = "🆕 Mới";
            this.btnNew.Click   += new System.EventHandler(this.btnNew_Click);

            this.btnReset.BackColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location  = new System.Drawing.Point(170, 264);
            this.btnReset.Name      = "btnReset";
            this.btnReset.Size      = new System.Drawing.Size(150, 32);
            this.btnReset.TabIndex  = 9;
            this.btnReset.Text      = "🔑 Reset mật khẩu";
            this.btnReset.Click    += new System.EventHandler(this.btnReset_Click);

            // ------------------------------------------------------------------
            // grid
            // ------------------------------------------------------------------
            this.grid.AllowUserToAddRows    = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.grid.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor       = System.Drawing.Color.White;
            this.grid.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grid.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersHeight   = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DefaultCellStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.DefaultCellStyle.Font               = new System.Drawing.Font("Segoe UI", 10F);
            this.grid.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(3);
            this.grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.grid.Dock                      = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.Font                      = new System.Drawing.Font("Segoe UI", 10F);
            this.grid.GridColor                 = System.Drawing.Color.FromArgb(230, 230, 230);
            this.grid.MultiSelect               = false;
            this.grid.Name                      = "grid";
            this.grid.ReadOnly                  = true;
            this.grid.RowHeadersVisible         = false;
            this.grid.RowTemplate.Height        = 32;
            this.grid.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.TabIndex                  = 0;
            this.grid.SelectionChanged         += new System.EventHandler(this.grid_SelectionChanged);

            // ------------------------------------------------------------------
            // pnlGrid
            // ------------------------------------------------------------------
            this.pnlGrid.BackColor   = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name        = "pnlGrid";
            this.pnlGrid.Padding     = new System.Windows.Forms.Padding(10);
            this.pnlGrid.TabIndex    = 2;

            // ------------------------------------------------------------------
            // frmNguoiDung
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpForm);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize         = new System.Drawing.Size(700, 450);
            this.Name                = "frmNguoiDung";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Quản lý người dùng";
            this.Load               += new System.EventHandler(this.frmNguoiDung_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpForm.ResumeLayout(false);
            this.grpForm.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel        pnlTop;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.GroupBox     grpForm;
        private System.Windows.Forms.Label        lblUser;
        private System.Windows.Forms.TextBox      txtUser;
        private System.Windows.Forms.Label        lblHoTen;
        private System.Windows.Forms.TextBox      txtHoTen;
        private System.Windows.Forms.Label        lblVaiTro;
        private System.Windows.Forms.ComboBox     cboVaiTro;
        private System.Windows.Forms.Label        lblMatKhau;
        private System.Windows.Forms.TextBox      txtMatKhau;
        private System.Windows.Forms.Label        lblHintMK;
        private System.Windows.Forms.CheckBox     chkTrangThai;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnEdit;
        private System.Windows.Forms.Button       btnDel;
        private System.Windows.Forms.Button       btnNew;
        private System.Windows.Forms.Button       btnReset;
        private System.Windows.Forms.Panel        pnlGrid;
        private System.Windows.Forms.DataGridView grid;
    }
}
