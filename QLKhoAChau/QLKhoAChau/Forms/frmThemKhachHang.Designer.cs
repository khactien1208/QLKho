namespace QLKhoAChau.Forms
{
    partial class frmThemKhachHang
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
            this.lblTenKH     = new System.Windows.Forms.Label();
            this.txtTenKH     = new System.Windows.Forms.TextBox();
            this.lblDiaChi    = new System.Windows.Forms.Label();
            this.txtDiaChi    = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail     = new System.Windows.Forms.Label();
            this.txtEmail     = new System.Windows.Forms.TextBox();
            this.btnOK        = new System.Windows.Forms.Button();
            this.btnCancel    = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Shared layout constants
            const int lx = 15, tx = 130, tw = 230, th = 23;

            // ------------------------------------------------------------------
            // lblTenKH / txtTenKH  (y=15)
            // ------------------------------------------------------------------
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(lx, 19);
            this.lblTenKH.Name     = "lblTenKH";
            this.lblTenKH.Text     = "Tên KH (*):";

            this.txtTenKH.Location = new System.Drawing.Point(tx, 15);
            this.txtTenKH.Name     = "txtTenKH";
            this.txtTenKH.Size     = new System.Drawing.Size(tw, th);
            this.txtTenKH.TabIndex = 0;

            // ------------------------------------------------------------------
            // lblDiaChi / txtDiaChi  (y=47)
            // ------------------------------------------------------------------
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(lx, 51);
            this.lblDiaChi.Name     = "lblDiaChi";
            this.lblDiaChi.Text     = "Địa chỉ:";

            this.txtDiaChi.Location = new System.Drawing.Point(tx, 47);
            this.txtDiaChi.Name     = "txtDiaChi";
            this.txtDiaChi.Size     = new System.Drawing.Size(tw, th);
            this.txtDiaChi.TabIndex = 1;

            // ------------------------------------------------------------------
            // lblDienThoai / txtDienThoai  (y=79)
            // ------------------------------------------------------------------
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(lx, 83);
            this.lblDienThoai.Name     = "lblDienThoai";
            this.lblDienThoai.Text     = "Số điện thoại:";

            this.txtDienThoai.Location = new System.Drawing.Point(tx, 79);
            this.txtDienThoai.Name     = "txtDienThoai";
            this.txtDienThoai.Size     = new System.Drawing.Size(tw, th);
            this.txtDienThoai.TabIndex = 2;

            // ------------------------------------------------------------------
            // lblEmail / txtEmail  (y=111)
            // ------------------------------------------------------------------
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(lx, 115);
            this.lblEmail.Name     = "lblEmail";
            this.lblEmail.Text     = "Email:";

            this.txtEmail.Location = new System.Drawing.Point(tx, 111);
            this.txtEmail.Name     = "txtEmail";
            this.txtEmail.Size     = new System.Drawing.Size(tw, th);
            this.txtEmail.TabIndex = 3;

            // ------------------------------------------------------------------
            // btnOK / btnCancel  (y=151)
            // ------------------------------------------------------------------
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location  = new System.Drawing.Point(tx, 151);
            this.btnOK.Name      = "btnOK";
            this.btnOK.Size      = new System.Drawing.Size(110, 32);
            this.btnOK.TabIndex  = 4;
            this.btnOK.Text      = "✓ Lưu";
            this.btnOK.Click    += new System.EventHandler(this.btnOK_Click);

            this.btnCancel.BackColor    = System.Drawing.Color.FromArgb(189, 195, 199);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle    = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location     = new System.Drawing.Point(250, 151);
            this.btnCancel.Name         = "btnCancel";
            this.btnCancel.Size         = new System.Drawing.Size(110, 32);
            this.btnCancel.TabIndex     = 5;
            this.btnCancel.Text         = "Hủy";

            // ------------------------------------------------------------------
            // frmThemKhachHang
            // ------------------------------------------------------------------
            this.AcceptButton        = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.CancelButton        = this.btnCancel;
            this.ClientSize          = new System.Drawing.Size(400, 200);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTenKH,    this.txtTenKH,
                this.lblDiaChi,   this.txtDiaChi,
                this.lblDienThoai, this.txtDienThoai,
                this.lblEmail,    this.txtEmail,
                this.btnOK,       this.btnCancel
            });
            this.Font            = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "frmThemKhachHang";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Thêm khách hàng mới";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label   lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label   lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button  btnOK;
        private System.Windows.Forms.Button  btnCancel;
    }
}
