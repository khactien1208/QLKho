namespace QLKhoAChau.Forms
{
    partial class frmPhieuXuat
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
            this.pnlTop          = new System.Windows.Forms.Panel();
            this.lblTitle        = new System.Windows.Forms.Label();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.btnSearch       = new System.Windows.Forms.Button();
            this.lblTu           = new System.Windows.Forms.Label();
            this.dtpTu           = new System.Windows.Forms.DateTimePicker();
            this.lblDen          = new System.Windows.Forms.Label();
            this.dtpDen          = new System.Windows.Forms.DateTimePicker();
            this.chkLoc          = new System.Windows.Forms.CheckBox();
            this.lblLoai         = new System.Windows.Forms.Label();
            this.cboLoai         = new System.Windows.Forms.ComboBox();
            this.btnLoc          = new System.Windows.Forms.Button();
            this.btnReset        = new System.Windows.Forms.Button();
            this.btnExcel        = new System.Windows.Forms.Button();

            this.splitMain       = new System.Windows.Forms.SplitContainer();
            this.pnlGrid         = new System.Windows.Forms.Panel();
            this.gridPhieu       = new System.Windows.Forms.DataGridView();

            this.split2          = new System.Windows.Forms.SplitContainer();
            this.grpPhieu        = new System.Windows.Forms.GroupBox();

            this.lblSoPhieu      = new System.Windows.Forms.Label();
            this.txtSoPhieu      = new System.Windows.Forms.TextBox();
            this.btnNew          = new System.Windows.Forms.Button();
            this.lblKH           = new System.Windows.Forms.Label();
            this.cboKH           = new System.Windows.Forms.ComboBox();
            this.btnNewKH        = new System.Windows.Forms.Button();
            this.lblGhiChu       = new System.Windows.Forms.Label();
            this.txtGhiChu       = new System.Windows.Forms.TextBox();
            this.lblSepSP        = new System.Windows.Forms.Label();
            this.lblHangHoa      = new System.Windows.Forms.Label();
            this.cboHH           = new System.Windows.Forms.ComboBox();
            this.lblFIFO         = new System.Windows.Forms.Label();
            this.lblSL           = new System.Windows.Forms.Label();
            this.txtSL           = new System.Windows.Forms.TextBox();
            this.lblDonGia       = new System.Windows.Forms.Label();
            this.txtDonGia       = new System.Windows.Forms.TextBox();
            this.btnAddItem      = new System.Windows.Forms.Button();
            this.btnSave         = new System.Windows.Forms.Button();
            this.btnXuatHuy      = new System.Windows.Forms.Button();

            this.splitRight      = new System.Windows.Forms.SplitContainer();
            this.lblGridTemp     = new System.Windows.Forms.Label();
            this.gridTemp        = new System.Windows.Forms.DataGridView();
            this.lblGridChiTiet  = new System.Windows.Forms.Label();
            this.gridChiTiet     = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split2)).BeginInit();
            this.split2.Panel1.SuspendLayout();
            this.split2.Panel2.SuspendLayout();
            this.split2.SuspendLayout();
            this.grpPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).BeginInit();
            this.SuspendLayout();

            // ------------------------------------------------------------------
            // pnlTop
            // ------------------------------------------------------------------
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.txtSearch, this.btnSearch,
                this.lblTu, this.dtpTu, this.lblDen, this.dtpDen,
                this.chkLoc, this.lblLoai, this.cboLoai,
                this.btnLoc, this.btnReset, this.btnExcel
            });
            this.pnlTop.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height  = 110;
            this.pnlTop.Name    = "pnlTop";
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location  = new System.Drawing.Point(15, 10);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "PHIẾU XUẤT KHO";

            // txtSearch
            this.txtSearch.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location        = new System.Drawing.Point(15, 45);
            this.txtSearch.Name            = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm số phiếu, khách hàng...";
            this.txtSearch.Size            = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex        = 1;
            this.txtSearch.KeyDown        += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location  = new System.Drawing.Point(243, 43);
            this.btnSearch.Name      = "btnSearch";
            this.btnSearch.Size      = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex  = 2;
            this.btnSearch.Text      = "🔍 Tìm";
            this.btnSearch.Click    += new System.EventHandler(this.btnSearch_Click);

            // lblTu
            this.lblTu.AutoSize = true;
            this.lblTu.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTu.Location = new System.Drawing.Point(15, 80);
            this.lblTu.Name     = "lblTu";
            this.lblTu.Text     = "Từ ngày:";

            // dtpTu
            this.dtpTu.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTu.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(70, 76);
            this.dtpTu.Name     = "dtpTu";
            this.dtpTu.Size     = new System.Drawing.Size(110, 23);
            this.dtpTu.TabIndex = 3;
            this.dtpTu.Value    = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);

            // lblDen
            this.lblDen.AutoSize = true;
            this.lblDen.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDen.Location = new System.Drawing.Point(188, 80);
            this.lblDen.Name     = "lblDen";
            this.lblDen.Text     = "Đến:";

            // dtpDen
            this.dtpDen.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDen.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(215, 76);
            this.dtpDen.Name     = "dtpDen";
            this.dtpDen.Size     = new System.Drawing.Size(110, 23);
            this.dtpDen.TabIndex = 4;
            this.dtpDen.Value    = System.DateTime.Today;

            // chkLoc
            this.chkLoc.AutoSize = true;
            this.chkLoc.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLoc.Location = new System.Drawing.Point(333, 78);
            this.chkLoc.Name     = "chkLoc";
            this.chkLoc.TabIndex = 5;
            this.chkLoc.Text     = "Lọc ngày";

            // lblLoai
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoai.Location = new System.Drawing.Point(420, 80);
            this.lblLoai.Name     = "lblLoai";
            this.lblLoai.Text     = "Loại:";

            // cboLoai
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLoai.Items.AddRange(new object[] { "Tất cả", "XuatBan", "XuatHuy" });
            this.cboLoai.Location      = new System.Drawing.Point(450, 76);
            this.cboLoai.Name          = "cboLoai";
            this.cboLoai.Size          = new System.Drawing.Size(100, 23);
            this.cboLoai.TabIndex      = 6;
            this.cboLoai.SelectedIndex = 0;

            // btnLoc
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location  = new System.Drawing.Point(558, 76);
            this.btnLoc.Name      = "btnLoc";
            this.btnLoc.Size      = new System.Drawing.Size(70, 26);
            this.btnLoc.TabIndex  = 7;
            this.btnLoc.Text      = "⚙ Lọc";
            this.btnLoc.Click    += new System.EventHandler(this.btnLoc_Click);

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.Location  = new System.Drawing.Point(635, 76);
            this.btnReset.Name      = "btnReset";
            this.btnReset.Size      = new System.Drawing.Size(85, 26);
            this.btnReset.TabIndex  = 8;
            this.btnReset.Text      = "✕ Xóa lọc";
            this.btnReset.Click    += new System.EventHandler(this.btnReset_Click);

            // btnExcel
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location  = new System.Drawing.Point(728, 76);
            this.btnExcel.Name      = "btnExcel";
            this.btnExcel.Size      = new System.Drawing.Size(110, 26);
            this.btnExcel.TabIndex  = 9;
            this.btnExcel.Text      = "📥 Xuất Excel";
            this.btnExcel.Click    += new System.EventHandler(this.btnExcel_Click);

            // ------------------------------------------------------------------
            // splitMain  (fill below pnlTop)
            // ------------------------------------------------------------------
            this.splitMain.Dock             = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Name             = "splitMain";
            this.splitMain.Orientation      = System.Windows.Forms.Orientation.Horizontal;
            this.splitMain.SplitterDistance = 250;
            this.splitMain.TabIndex         = 1;

            // splitMain.Panel1 → pnlGrid → gridPhieu
            this.pnlGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.Controls.Add(this.gridPhieu);
            this.pnlGrid.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name      = "pnlGrid";
            this.pnlGrid.Padding   = new System.Windows.Forms.Padding(10);
            this.pnlGrid.TabIndex  = 0;
            this.splitMain.Panel1.Controls.Add(this.pnlGrid);

            ConfigureGrid(this.gridPhieu, "gridPhieu", 0);
            this.gridPhieu.SelectionChanged += new System.EventHandler(this.gridPhieu_SelectionChanged);

            // splitMain.Panel2 → split2
            this.split2.Dock             = System.Windows.Forms.DockStyle.Fill;
            this.split2.Name             = "split2";
            this.split2.SplitterDistance = 480;
            this.split2.TabIndex         = 0;
            this.splitMain.Panel2.Controls.Add(this.split2);

            // ------------------------------------------------------------------
            // grpPhieu  (split2.Panel1)
            // ------------------------------------------------------------------
            this.grpPhieu.BackColor = System.Drawing.Color.White;
            this.grpPhieu.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSoPhieu, this.txtSoPhieu, this.btnNew,
                this.lblKH,      this.cboKH,      this.btnNewKH,
                this.lblGhiChu,  this.txtGhiChu,
                this.lblSepSP,
                this.lblHangHoa, this.cboHH,
                this.lblFIFO,
                this.lblSL,      this.txtSL,
                this.lblDonGia,  this.txtDonGia,
                this.btnAddItem, this.btnSave,    this.btnXuatHuy
            });
            this.grpPhieu.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.grpPhieu.Font    = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPhieu.Name    = "grpPhieu";
            this.grpPhieu.TabIndex = 0;
            this.grpPhieu.Text    = "Tạo phiếu xuất mới";
            this.split2.Panel1.Controls.Add(this.grpPhieu);

            // Row y=25: Số phiếu
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Location = new System.Drawing.Point(10, 28);
            this.lblSoPhieu.Name     = "lblSoPhieu";
            this.lblSoPhieu.Text     = "Số phiếu:";

            this.txtSoPhieu.Location = new System.Drawing.Point(100, 25);
            this.txtSoPhieu.Name     = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size     = new System.Drawing.Size(150, 23);
            this.txtSoPhieu.TabIndex = 10;

            this.btnNew.Location = new System.Drawing.Point(260, 24);
            this.btnNew.Name     = "btnNew";
            this.btnNew.Size     = new System.Drawing.Size(70, 26);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text     = "Mới";
            this.btnNew.Click   += new System.EventHandler(this.btnNew_Click);

            // Row y=57: Khách hàng
            this.lblKH.AutoSize = true;
            this.lblKH.Location = new System.Drawing.Point(10, 60);
            this.lblKH.Name     = "lblKH";
            this.lblKH.Text     = "Khách hàng:";

            this.cboKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKH.Location      = new System.Drawing.Point(100, 57);
            this.cboKH.Name          = "cboKH";
            this.cboKH.Size          = new System.Drawing.Size(280, 23);
            this.cboKH.TabIndex      = 12;

            this.btnNewKH.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnNewKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewKH.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNewKH.ForeColor = System.Drawing.Color.White;
            this.btnNewKH.Location  = new System.Drawing.Point(390, 56);
            this.btnNewKH.Name      = "btnNewKH";
            this.btnNewKH.Size      = new System.Drawing.Size(70, 26);
            this.btnNewKH.TabIndex  = 13;
            this.btnNewKH.Text      = "+ KH";
            this.btnNewKH.Click    += new System.EventHandler(this.btnNewKH_Click);

            // Row y=89: Ghi chú
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(10, 92);
            this.lblGhiChu.Name     = "lblGhiChu";
            this.lblGhiChu.Text     = "Ghi chú:";

            this.txtGhiChu.Location = new System.Drawing.Point(100, 89);
            this.txtGhiChu.Name     = "txtGhiChu";
            this.txtGhiChu.Size     = new System.Drawing.Size(330, 23);
            this.txtGhiChu.TabIndex = 14;

            // Separator y=129
            this.lblSepSP.AutoSize  = true;
            this.lblSepSP.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSepSP.ForeColor = System.Drawing.Color.Gray;
            this.lblSepSP.Location  = new System.Drawing.Point(10, 129);
            this.lblSepSP.Name      = "lblSepSP";
            this.lblSepSP.Text      = "─── Thêm sản phẩm ───";

            // Row y=154: cboHH
            this.lblHangHoa.AutoSize = true;
            this.lblHangHoa.Location = new System.Drawing.Point(10, 157);
            this.lblHangHoa.Name     = "lblHangHoa";
            this.lblHangHoa.Text     = "Hàng hóa:";

            this.cboHH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHH.Location      = new System.Drawing.Point(100, 154);
            this.cboHH.Name          = "cboHH";
            this.cboHH.Size          = new System.Drawing.Size(440, 23);
            this.cboHH.TabIndex      = 15;
            this.cboHH.SelectedIndexChanged += new System.EventHandler(this.cboHH_SelectedIndexChanged);

            // lblFIFO  y=184
            this.lblFIFO.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblFIFO.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.lblFIFO.Location  = new System.Drawing.Point(100, 184);
            this.lblFIFO.Name      = "lblFIFO";
            this.lblFIFO.Size      = new System.Drawing.Size(440, 20);
            this.lblFIFO.Text      = "";

            // Row y=212: SL + Đơn giá
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(10, 215);
            this.lblSL.Name     = "lblSL";
            this.lblSL.Text     = "Số lượng:";

            this.txtSL.Location = new System.Drawing.Point(100, 212);
            this.txtSL.Name     = "txtSL";
            this.txtSL.Size     = new System.Drawing.Size(100, 23);
            this.txtSL.TabIndex = 16;
            this.txtSL.Text     = "1";

            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(220, 215);
            this.lblDonGia.Name     = "lblDonGia";
            this.lblDonGia.Text     = "Đơn giá:";

            this.txtDonGia.Location = new System.Drawing.Point(290, 212);
            this.txtDonGia.Name     = "txtDonGia";
            this.txtDonGia.Size     = new System.Drawing.Size(140, 23);
            this.txtDonGia.TabIndex = 17;
            this.txtDonGia.Text     = "0";

            // Row y=252: buttons
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location  = new System.Drawing.Point(10, 252);
            this.btnAddItem.Name      = "btnAddItem";
            this.btnAddItem.Size      = new System.Drawing.Size(150, 32);
            this.btnAddItem.TabIndex  = 18;
            this.btnAddItem.Text      = "+ Thêm dòng";
            this.btnAddItem.Click    += new System.EventHandler(this.btnAddItem_Click);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location  = new System.Drawing.Point(170, 252);
            this.btnSave.Name      = "btnSave";
            this.btnSave.Size      = new System.Drawing.Size(160, 32);
            this.btnSave.TabIndex  = 19;
            this.btnSave.Text      = "💾 LƯU PHIẾU";
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            this.btnXuatHuy.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnXuatHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatHuy.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatHuy.ForeColor = System.Drawing.Color.White;
            this.btnXuatHuy.Location  = new System.Drawing.Point(340, 252);
            this.btnXuatHuy.Name      = "btnXuatHuy";
            this.btnXuatHuy.Size      = new System.Drawing.Size(140, 32);
            this.btnXuatHuy.TabIndex  = 20;
            this.btnXuatHuy.Text      = "🗑 XUẤT HỦY";
            this.btnXuatHuy.Visible   = false;
            this.btnXuatHuy.Click    += new System.EventHandler(this.btnXuatHuy_Click);

            // ------------------------------------------------------------------
            // splitRight  (split2.Panel2)
            // ------------------------------------------------------------------
            this.splitRight.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Name        = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitRight.TabIndex    = 0;
            this.split2.Panel2.Controls.Add(this.splitRight);

            // Panel1: gridTemp
            this.lblGridTemp.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblGridTemp.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblGridTemp.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridTemp.Height    = 25;
            this.lblGridTemp.Name      = "lblGridTemp";
            this.lblGridTemp.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblGridTemp.Text      = "Sản phẩm trong phiếu mới";
            this.lblGridTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            ConfigureGrid(this.gridTemp, "gridTemp", 0);
            this.splitRight.Panel1.Controls.Add(this.gridTemp);
            this.splitRight.Panel1.Controls.Add(this.lblGridTemp);

            // Panel2: gridChiTiet
            this.lblGridChiTiet.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.lblGridChiTiet.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblGridChiTiet.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridChiTiet.ForeColor = System.Drawing.Color.White;
            this.lblGridChiTiet.Height    = 25;
            this.lblGridChiTiet.Name      = "lblGridChiTiet";
            this.lblGridChiTiet.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblGridChiTiet.Text      = "Chi tiết phiếu đã chọn";
            this.lblGridChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            ConfigureGrid(this.gridChiTiet, "gridChiTiet", 0);
            this.splitRight.Panel2.Controls.Add(this.gridChiTiet);
            this.splitRight.Panel2.Controls.Add(this.lblGridChiTiet);

            // ------------------------------------------------------------------
            // frmPhieuXuat
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize         = new System.Drawing.Size(900, 550);
            this.Name                = "frmPhieuXuat";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Phiếu xuất";
            this.Load               += new System.EventHandler(this.frmPhieuXuat_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.split2)).EndInit();
            this.split2.Panel1.ResumeLayout(false);
            this.split2.Panel2.ResumeLayout(false);
            this.split2.ResumeLayout(false);
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).EndInit();
            this.ResumeLayout(false);
        }

        private static void ConfigureGrid(System.Windows.Forms.DataGridView grid, string name, int tabIndex)
        {
            grid.AllowUserToAddRows    = false;
            grid.AllowUserToDeleteRows = false;
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            grid.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor       = System.Drawing.Color.White;
            grid.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            grid.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            grid.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersHeight   = 40;
            grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.Font               = new System.Drawing.Font("Segoe UI", 10F);
            grid.DefaultCellStyle.Padding            = new System.Windows.Forms.Padding(3);
            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            grid.Dock                      = System.Windows.Forms.DockStyle.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.Font                      = new System.Drawing.Font("Segoe UI", 10F);
            grid.GridColor                 = System.Drawing.Color.FromArgb(230, 230, 230);
            grid.MultiSelect               = false;
            grid.Name                      = name;
            grid.ReadOnly                  = true;
            grid.RowHeadersVisible         = false;
            grid.RowTemplate.Height        = 32;
            grid.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.TabIndex                  = tabIndex;
        }

        #endregion

        private System.Windows.Forms.Panel          pnlTop;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.TextBox        txtSearch;
        private System.Windows.Forms.Button         btnSearch;
        private System.Windows.Forms.Label          lblTu;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Label          lblDen;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.CheckBox       chkLoc;
        private System.Windows.Forms.Label          lblLoai;
        private System.Windows.Forms.ComboBox       cboLoai;
        private System.Windows.Forms.Button         btnLoc;
        private System.Windows.Forms.Button         btnReset;
        private System.Windows.Forms.Button         btnExcel;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel          pnlGrid;
        private System.Windows.Forms.DataGridView   gridPhieu;
        private System.Windows.Forms.SplitContainer split2;
        private System.Windows.Forms.GroupBox       grpPhieu;
        private System.Windows.Forms.Label          lblSoPhieu;
        private System.Windows.Forms.TextBox        txtSoPhieu;
        private System.Windows.Forms.Button         btnNew;
        private System.Windows.Forms.Label          lblKH;
        private System.Windows.Forms.ComboBox       cboKH;
        private System.Windows.Forms.Button         btnNewKH;
        private System.Windows.Forms.Label          lblGhiChu;
        private System.Windows.Forms.TextBox        txtGhiChu;
        private System.Windows.Forms.Label          lblSepSP;
        private System.Windows.Forms.Label          lblHangHoa;
        private System.Windows.Forms.ComboBox       cboHH;
        private System.Windows.Forms.Label          lblFIFO;
        private System.Windows.Forms.Label          lblSL;
        private System.Windows.Forms.TextBox        txtSL;
        private System.Windows.Forms.Label          lblDonGia;
        private System.Windows.Forms.TextBox        txtDonGia;
        private System.Windows.Forms.Button         btnAddItem;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnXuatHuy;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.Label          lblGridTemp;
        private System.Windows.Forms.DataGridView   gridTemp;
        private System.Windows.Forms.Label          lblGridChiTiet;
        private System.Windows.Forms.DataGridView   gridChiTiet;
    }
}
