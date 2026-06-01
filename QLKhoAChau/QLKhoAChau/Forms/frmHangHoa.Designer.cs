namespace QLKhoAChau.Forms
{
    partial class frmHangHoa
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
            this.pnlTop         = new System.Windows.Forms.Panel();
            this.lblTitle       = new System.Windows.Forms.Label();
            this.txtSearch      = new System.Windows.Forms.TextBox();
            this.btnSearch      = new System.Windows.Forms.Button();
            this.grpForm        = new System.Windows.Forms.GroupBox();
            this.lblMaSP        = new System.Windows.Forms.Label();
            this.txtMaSP        = new System.Windows.Forms.TextBox();
            this.lblTen         = new System.Windows.Forms.Label();
            this.txtTen         = new System.Windows.Forms.TextBox();
            this.lblDanhMuc     = new System.Windows.Forms.Label();
            this.cboDM          = new System.Windows.Forms.ComboBox();
            this.lblNCC         = new System.Windows.Forms.Label();
            this.cboNCC         = new System.Windows.Forms.ComboBox();
            this.lblDVT         = new System.Windows.Forms.Label();
            this.txtDVT         = new System.Windows.Forms.TextBox();
            this.lblGiaNhap     = new System.Windows.Forms.Label();
            this.txtGiaNhap     = new System.Windows.Forms.TextBox();
            this.lblGiaBan      = new System.Windows.Forms.Label();
            this.txtGiaBan      = new System.Windows.Forms.TextBox();
            this.lblTonMin      = new System.Windows.Forms.Label();
            this.txtTonMin      = new System.Windows.Forms.TextBox();
            this.lblNSX         = new System.Windows.Forms.Label();
            this.dtpNSX         = new System.Windows.Forms.DateTimePicker();
            this.lblHSD         = new System.Windows.Forms.Label();
            this.dtpHSD         = new System.Windows.Forms.DateTimePicker();
            this.btnEdit        = new System.Windows.Forms.Button();
            this.btnDel         = new System.Windows.Forms.Button();
            this.pnlGrid        = new System.Windows.Forms.Panel();
            this.grid           = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.grpForm.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height    = 100;
            this.pnlTop.Name      = "pnlTop";
            this.pnlTop.Padding   = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.pnlTop.TabIndex  = 0;

            // lblTitle
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location  = new System.Drawing.Point(15, 50);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "QUẢN LÝ HÀNG HÓA";

            // txtSearch
            this.txtSearch.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(300, 50);
            this.txtSearch.Name     = "txtSearch";
            this.txtSearch.Size     = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 1;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(530, 48);
            this.btnSearch.Name     = "btnSearch";
            this.btnSearch.Size     = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text     = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click   += new System.EventHandler(this.btnSearch_Click);

            // grpForm
            this.grpForm.BackColor = System.Drawing.Color.White;
            this.grpForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaSP,    this.txtMaSP,
                this.lblTen,     this.txtTen,
                this.lblDanhMuc, this.cboDM,
                this.lblNCC,     this.cboNCC,
                this.lblDVT,     this.txtDVT,
                this.lblGiaNhap, this.txtGiaNhap,
                this.lblGiaBan,  this.txtGiaBan,
                this.lblTonMin,  this.txtTonMin,
                this.lblNSX,     this.dtpNSX,
                this.lblHSD,     this.dtpHSD,
                this.btnEdit,    this.btnDel
            });
            this.grpForm.Dock     = System.Windows.Forms.DockStyle.Right;
            this.grpForm.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpForm.Name     = "grpForm";
            this.grpForm.TabIndex = 1;
            this.grpForm.Text     = "Thông tin hàng hóa";
            this.grpForm.Width    = 320;

            // Label + TextBox helpers  (y starts at 30, step = 32)
            int lx = 15, tx = 110, tw = 190;

            // Mã SP  (y = 30)
            this.lblMaSP.AutoSize = true; this.lblMaSP.Location = new System.Drawing.Point(lx, 33);  this.lblMaSP.Name = "lblMaSP"; this.lblMaSP.Text = "Mã SP:";
            this.txtMaSP.Location = new System.Drawing.Point(tx, 30);  this.txtMaSP.Name = "txtMaSP"; this.txtMaSP.Size = new System.Drawing.Size(tw, 23); this.txtMaSP.TabIndex = 3;

            // Tên hàng  (y = 62)
            this.lblTen.AutoSize = true; this.lblTen.Location = new System.Drawing.Point(lx, 65);   this.lblTen.Name = "lblTen"; this.lblTen.Text = "Tên hàng:";
            this.txtTen.Location = new System.Drawing.Point(tx, 62);   this.txtTen.Name = "txtTen"; this.txtTen.Size = new System.Drawing.Size(tw, 23); this.txtTen.TabIndex = 4;

            // Danh mục  (y = 94)
            this.lblDanhMuc.AutoSize = true; this.lblDanhMuc.Location = new System.Drawing.Point(lx, 97);   this.lblDanhMuc.Name = "lblDanhMuc"; this.lblDanhMuc.Text = "Danh mục:";
            this.cboDM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboDM.Location = new System.Drawing.Point(tx, 94); this.cboDM.Name = "cboDM"; this.cboDM.Size = new System.Drawing.Size(tw, 23); this.cboDM.TabIndex = 5;

            // Nhà cung cấp  (y = 126)
            this.lblNCC.AutoSize = true; this.lblNCC.Location = new System.Drawing.Point(lx, 129);  this.lblNCC.Name = "lblNCC"; this.lblNCC.Text = "Nhà cung cấp:";
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboNCC.Location = new System.Drawing.Point(tx, 126); this.cboNCC.Name = "cboNCC"; this.cboNCC.Size = new System.Drawing.Size(tw, 23); this.cboNCC.TabIndex = 6;

            // ĐVT  (y = 158)
            this.lblDVT.AutoSize = true; this.lblDVT.Location = new System.Drawing.Point(lx, 161);  this.lblDVT.Name = "lblDVT"; this.lblDVT.Text = "ĐVT:";
            this.txtDVT.Location = new System.Drawing.Point(tx, 158);  this.txtDVT.Name = "txtDVT"; this.txtDVT.Size = new System.Drawing.Size(tw, 23); this.txtDVT.TabIndex = 7;

            // Giá nhập  (y = 190)
            this.lblGiaNhap.AutoSize = true; this.lblGiaNhap.Location = new System.Drawing.Point(lx, 193);  this.lblGiaNhap.Name = "lblGiaNhap"; this.lblGiaNhap.Text = "Giá nhập:";
            this.txtGiaNhap.Location = new System.Drawing.Point(tx, 190);  this.txtGiaNhap.Name = "txtGiaNhap"; this.txtGiaNhap.Size = new System.Drawing.Size(tw, 23); this.txtGiaNhap.TabIndex = 8; this.txtGiaNhap.Text = "0";

            // Giá bán  (y = 222)
            this.lblGiaBan.AutoSize = true; this.lblGiaBan.Location = new System.Drawing.Point(lx, 225);  this.lblGiaBan.Name = "lblGiaBan"; this.lblGiaBan.Text = "Giá bán:";
            this.txtGiaBan.Location = new System.Drawing.Point(tx, 222);  this.txtGiaBan.Name = "txtGiaBan"; this.txtGiaBan.Size = new System.Drawing.Size(tw, 23); this.txtGiaBan.TabIndex = 9; this.txtGiaBan.Text = "0";

            // Tồn tối thiểu  (y = 254)
            this.lblTonMin.AutoSize = true; this.lblTonMin.Location = new System.Drawing.Point(lx, 257);  this.lblTonMin.Name = "lblTonMin"; this.lblTonMin.Text = "Tồn tối thiểu:";
            this.txtTonMin.Location = new System.Drawing.Point(tx, 254);  this.txtTonMin.Name = "txtTonMin"; this.txtTonMin.Size = new System.Drawing.Size(tw, 23); this.txtTonMin.TabIndex = 10; this.txtTonMin.Text = "10";

            // Ngày sản xuất  (y = 294 — extra gap)
            this.lblNSX.AutoSize = true; this.lblNSX.Location = new System.Drawing.Point(lx, 297);  this.lblNSX.Name = "lblNSX"; this.lblNSX.Text = "Ngày sản xuất:";
            this.dtpNSX.Format   = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNSX.Location = new System.Drawing.Point(tx, 294);  this.dtpNSX.Name = "dtpNSX"; this.dtpNSX.Size = new System.Drawing.Size(tw, 23); this.dtpNSX.TabIndex = 11;

            // Hạn sử dụng  (y = 326)
            this.lblHSD.AutoSize = true; this.lblHSD.Location = new System.Drawing.Point(lx, 329);  this.lblHSD.Name = "lblHSD"; this.lblHSD.Text = "Hạn sử dụng:";
            this.dtpHSD.Format   = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpHSD.Location = new System.Drawing.Point(tx, 326);  this.dtpHSD.Name = "dtpHSD"; this.dtpHSD.Size = new System.Drawing.Size(tw, 23); this.dtpHSD.TabIndex = 12;

            // btnEdit  (y = 368)
            this.btnEdit.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor  = System.Drawing.Color.White;
            this.btnEdit.Location   = new System.Drawing.Point(165, 368);
            this.btnEdit.Name       = "btnEdit";
            this.btnEdit.Size       = new System.Drawing.Size(70, 32);
            this.btnEdit.TabIndex   = 13;
            this.btnEdit.Text       = "Sửa";
            this.btnEdit.Click     += new System.EventHandler(this.btnEdit_Click);

            // btnDel
            this.btnDel.BackColor  = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDel.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor  = System.Drawing.Color.White;
            this.btnDel.Location   = new System.Drawing.Point(240, 368);
            this.btnDel.Name       = "btnDel";
            this.btnDel.Size       = new System.Drawing.Size(70, 32);
            this.btnDel.TabIndex   = 14;
            this.btnDel.Text       = "Xóa";
            this.btnDel.Click     += new System.EventHandler(this.btnDel_Click);

            // grid (DataGridView)
            this.grid.AllowUserToAddRows    = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.grid.BackgroundColor       = System.Drawing.Color.White;
            this.grid.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.grid.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersHeight   = 40;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DefaultCellStyle.Alignment        = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.DefaultCellStyle.Font             = new System.Drawing.Font("Segoe UI", 10F);
            this.grid.DefaultCellStyle.Padding          = new System.Windows.Forms.Padding(3);
            this.grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.grid.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.Font                  = new System.Drawing.Font("Segoe UI", 10F);
            this.grid.GridColor             = System.Drawing.Color.FromArgb(230, 230, 230);
            this.grid.MultiSelect           = false;
            this.grid.Name                  = "grid";
            this.grid.ReadOnly              = true;
            this.grid.RowHeadersVisible     = false;
            this.grid.RowTemplate.Height    = 32;
            this.grid.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.TabIndex              = 0;
            this.grid.CellFormatting       += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.SelectionChanged     += new System.EventHandler(this.grid_SelectionChanged);

            // pnlGrid
            this.pnlGrid.BackColor   = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name        = "pnlGrid";
            this.pnlGrid.Padding     = new System.Windows.Forms.Padding(10);
            this.pnlGrid.TabIndex    = 2;

            // frmHangHoa
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.grpForm);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize         = new System.Drawing.Size(800, 500);
            this.Name                = "frmHangHoa";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Quản lý hàng hóa";
            this.Load               += new System.EventHandler(this.frmHangHoa_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpForm.ResumeLayout(false);
            this.grpForm.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Designer-managed fields
        private System.Windows.Forms.Panel          pnlTop;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.TextBox        txtSearch;
        private System.Windows.Forms.Button         btnSearch;
        private System.Windows.Forms.GroupBox       grpForm;
        private System.Windows.Forms.Label          lblMaSP;
        private System.Windows.Forms.TextBox        txtMaSP;
        private System.Windows.Forms.Label          lblTen;
        private System.Windows.Forms.TextBox        txtTen;
        private System.Windows.Forms.Label          lblDanhMuc;
        private System.Windows.Forms.ComboBox       cboDM;
        private System.Windows.Forms.Label          lblNCC;
        private System.Windows.Forms.ComboBox       cboNCC;
        private System.Windows.Forms.Label          lblDVT;
        private System.Windows.Forms.TextBox        txtDVT;
        private System.Windows.Forms.Label          lblGiaNhap;
        private System.Windows.Forms.TextBox        txtGiaNhap;
        private System.Windows.Forms.Label          lblGiaBan;
        private System.Windows.Forms.TextBox        txtGiaBan;
        private System.Windows.Forms.Label          lblTonMin;
        private System.Windows.Forms.TextBox        txtTonMin;
        private System.Windows.Forms.Label          lblNSX;
        private System.Windows.Forms.DateTimePicker dtpNSX;
        private System.Windows.Forms.Label          lblHSD;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.Button         btnEdit;
        private System.Windows.Forms.Button         btnDel;
        private System.Windows.Forms.Panel          pnlGrid;
        private System.Windows.Forms.DataGridView   grid;
    }
}
