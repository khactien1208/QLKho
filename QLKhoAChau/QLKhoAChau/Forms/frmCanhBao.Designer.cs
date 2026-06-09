namespace QLKhoAChau.Forms
{
    partial class frmCanhBao
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
            this.pnlTop  = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grid    = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // ------------------------------------------------------------------
            // pnlTop
            // ------------------------------------------------------------------
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblCount
            });
            this.pnlTop.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height  = 70;
            this.pnlTop.Name    = "pnlTop";
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(15, 10);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "⚠️  CẢNH BÁO TỒN KHO THẤP";

            // lblCount
            this.lblCount.AutoSize  = true;
            this.lblCount.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location  = new System.Drawing.Point(15, 45);
            this.lblCount.Name      = "lblCount";
            this.lblCount.Text      = "";
            this.lblCount.Visible   = false;

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

            // ------------------------------------------------------------------
            // pnlGrid
            // ------------------------------------------------------------------
            this.pnlGrid.BackColor   = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name        = "pnlGrid";
            this.pnlGrid.Padding     = new System.Windows.Forms.Padding(10);
            this.pnlGrid.TabIndex    = 1;

            // ------------------------------------------------------------------
            // frmCanhBao
            // ------------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize         = new System.Drawing.Size(600, 350);
            this.Name                = "frmCanhBao";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Cảnh báo tồn thấp";
            this.Load               += new System.EventHandler(this.frmCanhBao_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel        pnlTop;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblCount;
        private System.Windows.Forms.Panel        pnlGrid;
        private System.Windows.Forms.DataGridView grid;
    }
}
