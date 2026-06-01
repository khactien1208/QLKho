namespace QLKhoAChau.Forms
{
    partial class frmThemHangHoaNhanh
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
            lblDM = new Label();
            cboDM = new ComboBox();
            btnNewDM = new Button();
            lblNCC = new Label();
            cboNCC = new ComboBox();
            btnNewNCC = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblDM
            // 
            lblDM.AutoSize = true;
            lblDM.Location = new Point(24, 47);
            lblDM.Name = "lblDM";
            lblDM.Size = new Size(99, 20);
            lblDM.TabIndex = 2;
            lblDM.Text = "Danh mục (*):";
            // 
            // cboDM
            // 
            cboDM.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDM.Location = new Point(167, 41);
            cboDM.Margin = new Padding(3, 4, 3, 4);
            cboDM.Name = "cboDM";
            cboDM.Size = new Size(228, 28);
            cboDM.TabIndex = 2;
            // 
            // btnNewDM
            // 
            btnNewDM.BackColor = Color.FromArgb(52, 152, 219);
            btnNewDM.FlatStyle = FlatStyle.Flat;
            btnNewDM.ForeColor = Color.White;
            btnNewDM.Location = new Point(406, 40);
            btnNewDM.Margin = new Padding(3, 4, 3, 4);
            btnNewDM.Name = "btnNewDM";
            btnNewDM.Size = new Size(80, 35);
            btnNewDM.TabIndex = 3;
            btnNewDM.Text = "+ DM";
            btnNewDM.UseVisualStyleBackColor = false;
            btnNewDM.Click += btnNewDM_Click;
            // 
            // lblNCC
            // 
            lblNCC.AutoSize = true;
            lblNCC.Location = new Point(24, 89);
            lblNCC.Name = "lblNCC";
            lblNCC.Size = new Size(123, 20);
            lblNCC.TabIndex = 4;
            lblNCC.Text = "Nhà cung cấp (*):";
            // 
            // cboNCC
            // 
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.Location = new Point(167, 84);
            cboNCC.Margin = new Padding(3, 4, 3, 4);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(228, 28);
            cboNCC.TabIndex = 4;
            // 
            // btnNewNCC
            // 
            btnNewNCC.BackColor = Color.FromArgb(46, 204, 113);
            btnNewNCC.FlatStyle = FlatStyle.Flat;
            btnNewNCC.ForeColor = Color.White;
            btnNewNCC.Location = new Point(406, 83);
            btnNewNCC.Margin = new Padding(3, 4, 3, 4);
            btnNewNCC.Name = "btnNewNCC";
            btnNewNCC.Size = new Size(80, 35);
            btnNewNCC.TabIndex = 5;
            btnNewNCC.Text = "+ NCC";
            btnNewNCC.UseVisualStyleBackColor = false;
            btnNewNCC.Click += btnNewNCC_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(46, 204, 113);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(198, 148);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 45);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "OK";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmThemHangHoaNhanh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(526, 232);
            Controls.Add(lblDM);
            Controls.Add(cboDM);
            Controls.Add(btnNewDM);
            Controls.Add(lblNCC);
            Controls.Add(cboNCC);
            Controls.Add(btnNewNCC);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemHangHoaNhanh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm hàng hóa mới";
            Load += frmThemHangHoaNhanh_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label          lblDM;
        private System.Windows.Forms.ComboBox       cboDM;
        private System.Windows.Forms.Button         btnNewDM;
        private System.Windows.Forms.Label          lblNCC;
        private System.Windows.Forms.ComboBox       cboNCC;
        private System.Windows.Forms.Button         btnNewNCC;
        private System.Windows.Forms.Button         btnCancel;
    }
}
