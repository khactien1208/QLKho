namespace QLKhoAChau.Forms
{
    partial class frmPhieuNhap
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
            this.dtpTu          = new System.Windows.Forms.DateTimePicker();
            this.lblTu          = new System.Windows.Forms.Label();
            this.dtpDen         = new System.Windows.Forms.DateTimePicker();
            this.lblDen         = new System.Windows.Forms.Label();
            this.chkLoc         = new System.Windows.Forms.CheckBox();
            this.btnLoc         = new System.Windows.Forms.Button();
            this.btnReset       = new System.Windows.Forms.Button();
            this.btnExcel       = new System.Windows.Forms.Button();

            this.splitMain      = new System.Windows.Forms.SplitContainer();
            this.pnlGrid        = new System.Windows.Forms.Panel();
            this.gridPhieu      = new System.Windows.Forms.DataGridView();

            this.split2         = new System.Windows.Forms.SplitContainer();
            this.grpPhieu       = new System.Windows.Forms.GroupBox();

            // grpPhieu controls
            this.lblSoPhieu     = new System.Windows.Forms.Label();
            this.txtSoPhieu     = new System.Windows.Forms.TextBox();
            this.btnNew         = new System.Windows.Forms.Button();
            this.lblNCC         = new System.Windows.Forms.Label();
            this.cboNCC         = new System.Windows.Forms.ComboBox();
            this.lblGhiChu      = new System.Windows.Forms.Label();
            this.txtGhiChu      = new System.Windows.Forms.TextBox();
            this.lblSepHH       = new System.Windows.Forms.Label();
            this.lblHangHoa     = new System.Windows.Forms.Label();
            this.rdoSPCu        = new System.Windows.Forms.RadioButton();
            this.rdoSPMoi       = new System.Windows.Forms.RadioButton();

            // Panel SP cũ
            this.pnlSpCu        = new System.Windows.Forms.Panel();
            this.cboHH          = new System.Windows.Forms.ComboBox();
            this.btnNewHH       = new System.Windows.Forms.Button();

            // Panel SP mới
            this.pnlSpMoi       = new System.Windows.Forms.Panel();
            this.lblMaSPMoi     = new System.Windows.Forms.Label();
            this.txtMaSPMoi     = new System.Windows.Forms.TextBox();
            this.lblTenMoi      = new System.Windows.Forms.Label();
            this.txtTenMoi      = new System.Windows.Forms.TextBox();
            this.lblDMMoi       = new System.Windows.Forms.Label();
            this.cboDMMoi       = new System.Windows.Forms.ComboBox();
            this.lblDVTMoi      = new System.Windows.Forms.Label();
            this.txtDVTMoi      = new System.Windows.Forms.TextBox();
            this.lblNCCMoi      = new System.Windows.Forms.Label();
            this.cboNCCMoi      = new System.Windows.Forms.ComboBox();

            // Lô hàng fields
            this.lblSL          = new System.Windows.Forms.Label();
            this.txtSL          = new System.Windows.Forms.TextBox();
            this.lblDonGia      = new System.Windows.Forms.Label();
            this.txtDonGia      = new System.Windows.Forms.TextBox();
            this.lblGiaBanLo    = new System.Windows.Forms.Label();
            this.txtGiaBanLo    = new System.Windows.Forms.TextBox();
            this.lblNgaySX      = new System.Windows.Forms.Label();
            this.dtpNSX         = new System.Windows.Forms.DateTimePicker();
            this.lblHanSD       = new System.Windows.Forms.Label();
            this.dtpHSD         = new System.Windows.Forms.DateTimePicker();
            this.lblTonMin      = new System.Windows.Forms.Label();
            this.txtTonToiThieu = new System.Windows.Forms.TextBox();
            this.btnAddItem     = new System.Windows.Forms.Button();
            this.btnSave        = new System.Windows.Forms.Button();

            // Right-side grids
            this.splitRight     = new System.Windows.Forms.SplitContainer();
            this.lblGridTemp    = new System.Windows.Forms.Label();
            this.gridTemp       = new System.Windows.Forms.DataGridView();
            this.lblGridChiTiet = new System.Windows.Forms.Label();
            this.gridChiTiet    = new System.Windows.Forms.DataGridView();

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
            this.pnlSpCu.SuspendLayout();
            this.pnlSpMoi.SuspendLayout();
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
                this.chkLoc, this.btnLoc, this.btnReset, this.btnExcel
            });
            this.pnlTop.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height  = 110;
            this.pnlTop.Name    = "pnlTop";
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location  = new System.Drawing.Point(15, 10);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "PHIẾU NHẬP KHO";

            this.txtSearch.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location        = new System.Drawing.Point(15, 45);
            this.txtSearch.Name            = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm số phiếu, nhà cung cấp...";
            this.txtSearch.Size            = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex        = 1;
            this.txtSearch.KeyDown        += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

            this.btnSearch.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSearch.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor  = System.Drawing.Color.White;
            this.btnSearch.Location   = new System.Drawing.Point(243, 43);
            this.btnSearch.Name       = "btnSearch";
            this.btnSearch.Size       = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex   = 2;
            this.btnSearch.Text       = "🔍 Tìm";
            this.btnSearch.Click     += new System.EventHandler(this.btnSearch_Click);

            this.lblTu.AutoSize = true; this.lblTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTu.Location = new System.Drawing.Point(15, 80); this.lblTu.Name = "lblTu"; this.lblTu.Text = "Từ ngày:";

            this.dtpTu.Font   = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.Location = new System.Drawing.Point(70, 76);
            this.dtpTu.Name     = "dtpTu";
            this.dtpTu.Size     = new System.Drawing.Size(120, 23);
            this.dtpTu.TabIndex = 3;
            this.dtpTu.Value    = new System.DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);

            this.lblDen.AutoSize = true; this.lblDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDen.Location = new System.Drawing.Point(200, 80); this.lblDen.Name = "lblDen"; this.lblDen.Text = "Đến:";

            this.dtpDen.Font   = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.Location = new System.Drawing.Point(228, 76);
            this.dtpDen.Name     = "dtpDen";
            this.dtpDen.Size     = new System.Drawing.Size(120, 23);
            this.dtpDen.TabIndex = 4;
            this.dtpDen.Value    = System.DateTime.Today;

            this.chkLoc.AutoSize = true; this.chkLoc.Checked = false;
            this.chkLoc.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLoc.Location = new System.Drawing.Point(358, 78);
            this.chkLoc.Name     = "chkLoc"; this.chkLoc.TabIndex = 5; this.chkLoc.Text = "Lọc ngày";

            this.btnLoc.BackColor  = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnLoc.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor  = System.Drawing.Color.White;
            this.btnLoc.Location   = new System.Drawing.Point(440, 76);
            this.btnLoc.Name       = "btnLoc"; this.btnLoc.Size = new System.Drawing.Size(75, 26); this.btnLoc.TabIndex = 6;
            this.btnLoc.Text       = "⚙ Lọc";
            this.btnLoc.Click     += new System.EventHandler(this.btnLoc_Click);

            this.btnReset.BackColor  = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnReset.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.Location   = new System.Drawing.Point(523, 76);
            this.btnReset.Name       = "btnReset"; this.btnReset.Size = new System.Drawing.Size(85, 26); this.btnReset.TabIndex = 7;
            this.btnReset.Text       = "✕ Xóa lọc";
            this.btnReset.Click     += new System.EventHandler(this.btnReset_Click);

            this.btnExcel.BackColor  = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnExcel.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor  = System.Drawing.Color.White;
            this.btnExcel.Location   = new System.Drawing.Point(618, 76);
            this.btnExcel.Name       = "btnExcel"; this.btnExcel.Size = new System.Drawing.Size(110, 26); this.btnExcel.TabIndex = 8;
            this.btnExcel.Text       = "📥 Xuất Excel";
            this.btnExcel.Click     += new System.EventHandler(this.btnExcel_Click);

            // ------------------------------------------------------------------
            // splitMain
            // ------------------------------------------------------------------
            this.splitMain.Dock              = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Name              = "splitMain";
            this.splitMain.Orientation       = System.Windows.Forms.Orientation.Horizontal;
            this.splitMain.SplitterDistance  = 250;
            this.splitMain.TabIndex          = 1;

            // splitMain.Panel1 → pnlGrid → gridPhieu
            this.pnlGrid.BackColor  = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.Controls.Add(this.gridPhieu);
            this.pnlGrid.Dock       = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name       = "pnlGrid";
            this.pnlGrid.Padding    = new System.Windows.Forms.Padding(10);
            this.pnlGrid.TabIndex   = 0;
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
            // grpPhieu (split2.Panel1)
            // ------------------------------------------------------------------
            this.grpPhieu.BackColor = System.Drawing.Color.White;
            this.grpPhieu.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.grpPhieu.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPhieu.Name      = "grpPhieu";
            this.grpPhieu.TabIndex  = 0;
            this.grpPhieu.Text      = "Tạo phiếu nhập mới";
            this.grpPhieu.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSoPhieu, this.txtSoPhieu, this.btnNew,
                this.lblNCC, this.cboNCC,
                this.lblGhiChu, this.txtGhiChu,
                this.lblSepHH,
                this.lblHangHoa, this.rdoSPCu, this.rdoSPMoi,
                this.pnlSpCu, this.pnlSpMoi,
                this.lblSL, this.txtSL, this.lblDonGia, this.txtDonGia, this.lblGiaBanLo, this.txtGiaBanLo,
                this.lblNgaySX, this.dtpNSX, this.lblHanSD, this.dtpHSD, this.lblTonMin, this.txtTonToiThieu,
                this.btnAddItem, this.btnSave
            });
            this.split2.Panel1.Controls.Add(this.grpPhieu);

            // Row y=25: Số phiếu
            this.lblSoPhieu.AutoSize = true; this.lblSoPhieu.Location = new System.Drawing.Point(10, 28); this.lblSoPhieu.Name = "lblSoPhieu"; this.lblSoPhieu.Text = "Số phiếu:";
            this.txtSoPhieu.Location = new System.Drawing.Point(100, 25); this.txtSoPhieu.Name = "txtSoPhieu"; this.txtSoPhieu.ReadOnly = true; this.txtSoPhieu.Size = new System.Drawing.Size(150, 23); this.txtSoPhieu.TabIndex = 10;
            this.btnNew.Location     = new System.Drawing.Point(260, 24); this.btnNew.Name = "btnNew"; this.btnNew.Size = new System.Drawing.Size(70, 26); this.btnNew.TabIndex = 11; this.btnNew.Text = "Mới";
            this.btnNew.Click       += new System.EventHandler(this.btnNew_Click);

            // Row y=57: NCC
            this.lblNCC.AutoSize = true; this.lblNCC.Location = new System.Drawing.Point(10, 60); this.lblNCC.Name = "lblNCC"; this.lblNCC.Text = "NCC:";
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboNCC.Location = new System.Drawing.Point(100, 57); this.cboNCC.Name = "cboNCC"; this.cboNCC.Size = new System.Drawing.Size(330, 23); this.cboNCC.TabIndex = 12;

            // Row y=89: Ghi chú
            this.lblGhiChu.AutoSize = true; this.lblGhiChu.Location = new System.Drawing.Point(10, 92); this.lblGhiChu.Name = "lblGhiChu"; this.lblGhiChu.Text = "Ghi chú:";
            this.txtGhiChu.Location = new System.Drawing.Point(100, 89); this.txtGhiChu.Name = "txtGhiChu"; this.txtGhiChu.Size = new System.Drawing.Size(330, 23); this.txtGhiChu.TabIndex = 13;

            // Separator y=129
            this.lblSepHH.AutoSize  = true; this.lblSepHH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSepHH.ForeColor = System.Drawing.Color.Gray; this.lblSepHH.Location = new System.Drawing.Point(10, 129); this.lblSepHH.Name = "lblSepHH"; this.lblSepHH.Text = "─── Thêm sản phẩm ───";

            // Row y=154: Radio chọn chế độ SP
            this.lblHangHoa.AutoSize = true; this.lblHangHoa.Location = new System.Drawing.Point(10, 157); this.lblHangHoa.Name = "lblHangHoa"; this.lblHangHoa.Text = "Hàng hóa:";
            this.rdoSPCu.AutoSize    = true; this.rdoSPCu.Checked = true; this.rdoSPCu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoSPCu.Location    = new System.Drawing.Point(100, 154); this.rdoSPCu.Name = "rdoSPCu"; this.rdoSPCu.TabIndex = 14; this.rdoSPCu.Text = "SP có sẵn";
            this.rdoSPCu.CheckedChanged += new System.EventHandler(this.RdoSP_CheckedChanged);
            this.rdoSPMoi.AutoSize   = true; this.rdoSPMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoSPMoi.Location   = new System.Drawing.Point(210, 154); this.rdoSPMoi.Name = "rdoSPMoi"; this.rdoSPMoi.TabIndex = 15; this.rdoSPMoi.Text = "SP mới";
            this.rdoSPMoi.CheckedChanged += new System.EventHandler(this.RdoSP_CheckedChanged);

            // ------------------------------------------------------------------
            // pnlSpCu (y=182)
            // ------------------------------------------------------------------
            this.pnlSpCu.Location = new System.Drawing.Point(10, 182);
            this.pnlSpCu.Name     = "pnlSpCu";
            this.pnlSpCu.Size     = new System.Drawing.Size(440, 30);
            this.pnlSpCu.Visible  = true;
            this.pnlSpCu.Controls.AddRange(new System.Windows.Forms.Control[] { this.cboHH, this.btnNewHH });

            this.cboHH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHH.Location      = new System.Drawing.Point(0, 2);
            this.cboHH.Name          = "cboHH";
            this.cboHH.Size          = new System.Drawing.Size(360, 23);
            this.cboHH.TabIndex      = 16;
            this.cboHH.SelectedIndexChanged += new System.EventHandler(this.cboHH_SelectedIndexChanged);

            this.btnNewHH.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnNewHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewHH.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnNewHH.ForeColor = System.Drawing.Color.White;
            this.btnNewHH.Location  = new System.Drawing.Point(368, 1);
            this.btnNewHH.Name      = "btnNewHH";
            this.btnNewHH.Size      = new System.Drawing.Size(65, 26);
            this.btnNewHH.TabIndex  = 17;
            this.btnNewHH.Text      = "+ Mới";
            this.btnNewHH.Click    += new System.EventHandler(this.btnNewHH_Click);

            // ------------------------------------------------------------------
            // pnlSpMoi (y=182, height=70, hidden by default)
            // ------------------------------------------------------------------
            this.pnlSpMoi.Location = new System.Drawing.Point(10, 182);
            this.pnlSpMoi.Name     = "pnlSpMoi";
            this.pnlSpMoi.Size     = new System.Drawing.Size(440, 70);
            this.pnlSpMoi.Visible  = false;
            this.pnlSpMoi.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaSPMoi, this.txtMaSPMoi,
                this.lblTenMoi,  this.txtTenMoi,
                this.lblDMMoi,   this.cboDMMoi,
                this.lblDVTMoi,  this.txtDVTMoi,
                this.lblNCCMoi,  this.cboNCCMoi
            });

            this.lblMaSPMoi.AutoSize = true; this.lblMaSPMoi.Location = new System.Drawing.Point(0, 5);   this.lblMaSPMoi.Name = "lblMaSPMoi"; this.lblMaSPMoi.Text = "Mã SP (*):";
            this.txtMaSPMoi.Location = new System.Drawing.Point(65, 2);   this.txtMaSPMoi.Name = "txtMaSPMoi"; this.txtMaSPMoi.Size = new System.Drawing.Size(100, 23); this.txtMaSPMoi.TabIndex = 18;

            this.lblTenMoi.AutoSize  = true; this.lblTenMoi.Location  = new System.Drawing.Point(175, 5);  this.lblTenMoi.Name  = "lblTenMoi";  this.lblTenMoi.Text  = "Tên HH (*):";
            this.txtTenMoi.Location  = new System.Drawing.Point(240, 2);  this.txtTenMoi.Name  = "txtTenMoi";  this.txtTenMoi.Size  = new System.Drawing.Size(200, 23); this.txtTenMoi.TabIndex  = 19;

            this.lblDMMoi.AutoSize   = true; this.lblDMMoi.Location   = new System.Drawing.Point(0, 38);   this.lblDMMoi.Name   = "lblDMMoi";   this.lblDMMoi.Text   = "Danh mục:";
            this.cboDMMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboDMMoi.Location = new System.Drawing.Point(65, 35);  this.cboDMMoi.Name = "cboDMMoi"; this.cboDMMoi.Size = new System.Drawing.Size(160, 23); this.cboDMMoi.TabIndex = 20;

            this.lblDVTMoi.AutoSize  = true; this.lblDVTMoi.Location  = new System.Drawing.Point(238, 38); this.lblDVTMoi.Name  = "lblDVTMoi";  this.lblDVTMoi.Text  = "ĐVT:";
            this.txtDVTMoi.Location  = new System.Drawing.Point(265, 35); this.txtDVTMoi.Name  = "txtDVTMoi";  this.txtDVTMoi.Size  = new System.Drawing.Size(80, 23); this.txtDVTMoi.TabIndex  = 21; this.txtDVTMoi.Text = "Thùng";

            this.lblNCCMoi.AutoSize  = true; this.lblNCCMoi.Location  = new System.Drawing.Point(355, 38); this.lblNCCMoi.Name  = "lblNCCMoi";  this.lblNCCMoi.Text  = "NCC:";
            this.cboNCCMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboNCCMoi.Location = new System.Drawing.Point(380, 35); this.cboNCCMoi.Name = "cboNCCMoi"; this.cboNCCMoi.Size = new System.Drawing.Size(55, 23); this.cboNCCMoi.TabIndex = 22;

            // ------------------------------------------------------------------
            // Lô hàng fields (y=260)
            // ------------------------------------------------------------------
            this.lblSL.AutoSize      = true; this.lblSL.Location      = new System.Drawing.Point(10, 263);  this.lblSL.Name = "lblSL"; this.lblSL.Text = "Số lượng:";
            this.txtSL.Location      = new System.Drawing.Point(100, 260); this.txtSL.Name = "txtSL"; this.txtSL.Size = new System.Drawing.Size(80, 23); this.txtSL.TabIndex = 23; this.txtSL.Text = "1";

            this.lblDonGia.AutoSize  = true; this.lblDonGia.Location  = new System.Drawing.Point(195, 263); this.lblDonGia.Name = "lblDonGia"; this.lblDonGia.Text = "Đơn giá nhập:";
            this.txtDonGia.Location  = new System.Drawing.Point(295, 260); this.txtDonGia.Name = "txtDonGia"; this.txtDonGia.Size = new System.Drawing.Size(90, 23); this.txtDonGia.TabIndex = 24; this.txtDonGia.Text = "0";

            this.lblGiaBanLo.AutoSize = true; this.lblGiaBanLo.Location = new System.Drawing.Point(395, 263); this.lblGiaBanLo.Name = "lblGiaBanLo"; this.lblGiaBanLo.Text = "Giá bán:";
            this.txtGiaBanLo.Location = new System.Drawing.Point(445, 260); this.txtGiaBanLo.Name = "txtGiaBanLo"; this.txtGiaBanLo.Size = new System.Drawing.Size(90, 23); this.txtGiaBanLo.TabIndex = 25; this.txtGiaBanLo.Text = "0";

            this.lblNgaySX.AutoSize  = true; this.lblNgaySX.Location  = new System.Drawing.Point(10, 295);  this.lblNgaySX.Name = "lblNgaySX"; this.lblNgaySX.Text = "Ngày SX:";
            this.dtpNSX.Format       = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNSX.Location     = new System.Drawing.Point(100, 292); this.dtpNSX.Name = "dtpNSX"; this.dtpNSX.Size = new System.Drawing.Size(130, 23); this.dtpNSX.TabIndex = 26; this.dtpNSX.Value = System.DateTime.Today;

            this.lblHanSD.AutoSize   = true; this.lblHanSD.Location   = new System.Drawing.Point(245, 295); this.lblHanSD.Name = "lblHanSD"; this.lblHanSD.Text = "Hạn SD (*):";
            this.dtpHSD.Format       = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHSD.Location     = new System.Drawing.Point(320, 292); this.dtpHSD.Name = "dtpHSD"; this.dtpHSD.Size = new System.Drawing.Size(130, 23); this.dtpHSD.TabIndex = 27; this.dtpHSD.Value = System.DateTime.Today.AddYears(1);

            this.lblTonMin.AutoSize  = true; this.lblTonMin.Location  = new System.Drawing.Point(462, 295); this.lblTonMin.Name = "lblTonMin"; this.lblTonMin.Text = "Tồn tối thiểu:";
            this.txtTonToiThieu.Location = new System.Drawing.Point(550, 292); this.txtTonToiThieu.Name = "txtTonToiThieu"; this.txtTonToiThieu.Size = new System.Drawing.Size(60, 23); this.txtTonToiThieu.TabIndex = 28; this.txtTonToiThieu.Text = "10";

            // Row y=332: buttons
            this.btnAddItem.BackColor  = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnAddItem.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor  = System.Drawing.Color.White;
            this.btnAddItem.Location   = new System.Drawing.Point(100, 332);
            this.btnAddItem.Name       = "btnAddItem"; this.btnAddItem.Size = new System.Drawing.Size(150, 32); this.btnAddItem.TabIndex = 29;
            this.btnAddItem.Text       = "+ Thêm dòng";
            this.btnAddItem.Click     += new System.EventHandler(this.btnAddItem_Click);

            this.btnSave.BackColor  = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor  = System.Drawing.Color.White;
            this.btnSave.Location   = new System.Drawing.Point(260, 332);
            this.btnSave.Name       = "btnSave"; this.btnSave.Size = new System.Drawing.Size(170, 32); this.btnSave.TabIndex = 30;
            this.btnSave.Text       = "💾 LƯU PHIẾU";
            this.btnSave.Click     += new System.EventHandler(this.btnSave_Click);

            // ------------------------------------------------------------------
            // splitRight (split2.Panel2)
            // ------------------------------------------------------------------
            this.splitRight.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Name        = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitRight.TabIndex    = 0;
            this.split2.Panel2.Controls.Add(this.splitRight);

            // splitRight.Panel1: gridTemp
            this.lblGridTemp.BackColor  = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblGridTemp.Dock       = System.Windows.Forms.DockStyle.Top;
            this.lblGridTemp.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridTemp.Height     = 25;
            this.lblGridTemp.Name       = "lblGridTemp";
            this.lblGridTemp.Padding    = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblGridTemp.Text       = "Sản phẩm trong phiếu mới";
            this.lblGridTemp.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            ConfigureGrid(this.gridTemp, "gridTemp", 0);
            this.splitRight.Panel1.Controls.Add(this.gridTemp);
            this.splitRight.Panel1.Controls.Add(this.lblGridTemp);

            // splitRight.Panel2: gridChiTiet
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
            // frmPhieuNhap
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize         = new System.Drawing.Size(900, 550);
            this.Name                = "frmPhieuNhap";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Phiếu nhập";
            this.Load               += new System.EventHandler(this.frmPhieuNhap_Load);

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
            this.pnlSpCu.ResumeLayout(false);
            this.pnlSpMoi.ResumeLayout(false);
            this.pnlSpMoi.PerformLayout();
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Applies the shared DataGridView style used by all three grids.
        /// </summary>
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
            grid.DefaultCellStyle.Alignment        = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.Font             = new System.Drawing.Font("Segoe UI", 10F);
            grid.DefaultCellStyle.Padding          = new System.Windows.Forms.Padding(3);
            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            grid.Dock                  = System.Windows.Forms.DockStyle.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.Font                  = new System.Drawing.Font("Segoe UI", 10F);
            grid.GridColor             = System.Drawing.Color.FromArgb(230, 230, 230);
            grid.MultiSelect           = false;
            grid.Name                  = name;
            grid.ReadOnly              = true;
            grid.RowHeadersVisible     = false;
            grid.RowTemplate.Height    = 32;
            grid.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            grid.TabIndex              = tabIndex;
        }

        #endregion

        // Designer-managed fields
        private System.Windows.Forms.Panel              pnlTop;
        private System.Windows.Forms.Label              lblTitle;
        private System.Windows.Forms.TextBox            txtSearch;
        private System.Windows.Forms.Button             btnSearch;
        private System.Windows.Forms.Label              lblTu;
        private System.Windows.Forms.DateTimePicker     dtpTu;
        private System.Windows.Forms.Label              lblDen;
        private System.Windows.Forms.DateTimePicker     dtpDen;
        private System.Windows.Forms.CheckBox           chkLoc;
        private System.Windows.Forms.Button             btnLoc;
        private System.Windows.Forms.Button             btnReset;
        private System.Windows.Forms.Button             btnExcel;
        private System.Windows.Forms.SplitContainer     splitMain;
        private System.Windows.Forms.Panel              pnlGrid;
        private System.Windows.Forms.DataGridView       gridPhieu;
        private System.Windows.Forms.SplitContainer     split2;
        private System.Windows.Forms.GroupBox           grpPhieu;
        private System.Windows.Forms.Label              lblSoPhieu;
        private System.Windows.Forms.TextBox            txtSoPhieu;
        private System.Windows.Forms.Button             btnNew;
        private System.Windows.Forms.Label              lblNCC;
        private System.Windows.Forms.ComboBox           cboNCC;
        private System.Windows.Forms.Label              lblGhiChu;
        private System.Windows.Forms.TextBox            txtGhiChu;
        private System.Windows.Forms.Label              lblSepHH;
        private System.Windows.Forms.Label              lblHangHoa;
        private System.Windows.Forms.RadioButton        rdoSPCu;
        private System.Windows.Forms.RadioButton        rdoSPMoi;
        private System.Windows.Forms.Panel              pnlSpCu;
        private System.Windows.Forms.ComboBox           cboHH;
        private System.Windows.Forms.Button             btnNewHH;
        private System.Windows.Forms.Panel              pnlSpMoi;
        private System.Windows.Forms.Label              lblMaSPMoi;
        private System.Windows.Forms.TextBox            txtMaSPMoi;
        private System.Windows.Forms.Label              lblTenMoi;
        private System.Windows.Forms.TextBox            txtTenMoi;
        private System.Windows.Forms.Label              lblDMMoi;
        private System.Windows.Forms.ComboBox           cboDMMoi;
        private System.Windows.Forms.Label              lblDVTMoi;
        private System.Windows.Forms.TextBox            txtDVTMoi;
        private System.Windows.Forms.Label              lblNCCMoi;
        private System.Windows.Forms.ComboBox           cboNCCMoi;
        private System.Windows.Forms.Label              lblSL;
        private System.Windows.Forms.TextBox            txtSL;
        private System.Windows.Forms.Label              lblDonGia;
        private System.Windows.Forms.TextBox            txtDonGia;
        private System.Windows.Forms.Label              lblGiaBanLo;
        private System.Windows.Forms.TextBox            txtGiaBanLo;
        private System.Windows.Forms.Label              lblNgaySX;
        private System.Windows.Forms.DateTimePicker     dtpNSX;
        private System.Windows.Forms.Label              lblHanSD;
        private System.Windows.Forms.DateTimePicker     dtpHSD;
        private System.Windows.Forms.Label              lblTonMin;
        private System.Windows.Forms.TextBox            txtTonToiThieu;
        private System.Windows.Forms.Button             btnAddItem;
        private System.Windows.Forms.Button             btnSave;
        private System.Windows.Forms.SplitContainer     splitRight;
        private System.Windows.Forms.Label              lblGridTemp;
        private System.Windows.Forms.DataGridView       gridTemp;
        private System.Windows.Forms.Label              lblGridChiTiet;
        private System.Windows.Forms.DataGridView       gridChiTiet;
    }
}
