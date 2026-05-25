namespace QLKhoAChau.Forms
{
    partial class frmMain
    {
        private Panel pnlSide;
        private Panel pnlContent;

        private Label lblUser;
        private Label lblWarning;
        private Label lblBrand;

        private void InitializeComponent()
        {
            pnlSide = new Panel();
            lblUser = new Label();
            lblBrand = new Label();
            pnlContent = new Panel();
            lblWarning = new Label();
            pnlSide.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSide
            // 
            pnlSide.BackColor = Color.FromArgb(44, 62, 80);
            pnlSide.Controls.Add(lblUser);
            pnlSide.Controls.Add(lblBrand);
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Name = "pnlSide";
            pnlSide.Size = new Size(220, 253);
            pnlSide.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Top;
            lblUser.Font = new Font("Segoe UI", 9F);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(0, 60);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(220, 50);
            lblUser.TabIndex = 0;
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrand
            // 
            lblBrand.BackColor = Color.FromArgb(192, 57, 43);
            lblBrand.Dock = DockStyle.Top;
            lblBrand.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(0, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(220, 60);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "BÁNH KẸO Á CHÂU";
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Controls.Add(lblWarning);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(62, 253);
            pnlContent.TabIndex = 0;
            // 
            // lblWarning
            // 
            lblWarning.BackColor = Color.FromArgb(255, 243, 205);
            lblWarning.Cursor = Cursors.Hand;
            lblWarning.Dock = DockStyle.Top;
            lblWarning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(133, 100, 4);
            lblWarning.Location = new Point(0, 0);
            lblWarning.Name = "lblWarning";
            lblWarning.Padding = new Padding(5);
            lblWarning.Size = new Size(62, 40);
            lblWarning.TabIndex = 0;
            lblWarning.TextAlign = ContentAlignment.MiddleCenter;
            lblWarning.Click += lblWarning_Click;
            // 
            // frmMain
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(282, 253);
            Controls.Add(pnlContent);
            Controls.Add(pnlSide);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý kho - Bánh kẹo Á Châu";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            pnlSide.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}