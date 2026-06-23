namespace MyDaniel
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain          = new System.Windows.Forms.Panel();
            this.panel_sidebar      = new System.Windows.Forms.Panel();
            this.label_brand        = new System.Windows.Forms.Label();
            this.label_brand_sub    = new System.Windows.Forms.Label();
            this.panel_sep          = new System.Windows.Forms.Panel();
            this.panel_nav          = new System.Windows.Forms.Panel();
            this.panel_bottom       = new System.Windows.Forms.Panel();
            this.label_sidebar_role = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Sidebar ───────────────────────────────────────────────────────
            this.panel_sidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.panel_sidebar.Width     = 220;
            this.panel_sidebar.BackColor = ThemeHelper.BG_SIDEBAR;
            this.panel_sidebar.Visible   = false;
            this.panel_sidebar.Controls.Add(this.panel_nav);
            this.panel_sidebar.Controls.Add(this.panel_sep);
            this.panel_sidebar.Controls.Add(this.label_brand_sub);
            this.panel_sidebar.Controls.Add(this.label_brand);
            this.panel_sidebar.Controls.Add(this.panel_bottom);

            // Brand title
            this.label_brand.Text      = "Daniel Center";
            this.label_brand.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label_brand.ForeColor = System.Drawing.Color.White;
            this.label_brand.Location  = new System.Drawing.Point(0, 22);
            this.label_brand.Size      = new System.Drawing.Size(220, 28);
            this.label_brand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_brand.BackColor = System.Drawing.Color.Transparent;

            // Brand subtitle
            this.label_brand_sub.Text      = "Management Portal";
            this.label_brand_sub.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label_brand_sub.ForeColor = ThemeHelper.SIDEBAR_MUTED;
            this.label_brand_sub.Location  = new System.Drawing.Point(0, 52);
            this.label_brand_sub.Size      = new System.Drawing.Size(220, 20);
            this.label_brand_sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_brand_sub.BackColor = System.Drawing.Color.Transparent;

            // Separator line
            this.panel_sep.Location  = new System.Drawing.Point(15, 82);
            this.panel_sep.Size      = new System.Drawing.Size(190, 1);
            this.panel_sep.BackColor = ThemeHelper.BORDER;

            // Nav buttons container
            this.panel_nav.Location  = new System.Drawing.Point(0, 90);
            this.panel_nav.Size      = new System.Drawing.Size(220, 600);
            this.panel_nav.BackColor = System.Drawing.Color.Transparent;

            // Bottom strip with role label
            this.panel_bottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Height    = 50;
            this.panel_bottom.BackColor = ThemeHelper.BG_SIDEBAR;
            this.panel_bottom.Controls.Add(this.label_sidebar_role);

            this.label_sidebar_role.Location  = new System.Drawing.Point(0, 14);
            this.label_sidebar_role.Size      = new System.Drawing.Size(220, 22);
            this.label_sidebar_role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_sidebar_role.ForeColor = ThemeHelper.SIDEBAR_MUTED;
            this.label_sidebar_role.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label_sidebar_role.BackColor = System.Drawing.Color.Transparent;

            // ── Content panel ─────────────────────────────────────────────────
            this.panelMain.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.BackColor = ThemeHelper.BG_CONTENT;

            // ── MainForm ──────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1280, 760);
            this.MinimumSize         = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.panelMain);       // Fill — docked last
            this.Controls.Add(this.panel_sidebar);   // Left — docked first
            this.Name = "MainForm";
            this.Text = "מרכז דניאל — מערכת ניהול";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel_sidebar;
        private System.Windows.Forms.Panel panel_nav;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Panel panel_sep;
        private System.Windows.Forms.Label label_brand;
        private System.Windows.Forms.Label label_brand_sub;
        private System.Windows.Forms.Label label_sidebar_role;
    }
}
