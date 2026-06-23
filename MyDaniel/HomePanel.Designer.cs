namespace MyDaniel
{
    partial class HomePanel
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
            this.label_title     = new System.Windows.Forms.Label();
            this.label_welcome   = new System.Windows.Forms.Label();
            this.panel_header_sep = new System.Windows.Forms.Panel();
            this.btn_employees   = new System.Windows.Forms.Button();
            this.btn_customers   = new System.Windows.Forms.Button();
            this.btn_my_profile  = new System.Windows.Forms.Button();
            this.btn_boats       = new System.Windows.Forms.Button();
            this.btn_activities  = new System.Windows.Forms.Button();
            this.btn_external    = new System.Windows.Forms.Button();
            this.btn_discount    = new System.Windows.Forms.Button();
            this.btn_maintenance = new System.Windows.Forms.Button();
            this.btn_workhours   = new System.Windows.Forms.Button();
            this.btn_attendance  = new System.Windows.Forms.Button();
            this.btn_my_schedule = new System.Windows.Forms.Button();
            this.btn_logout      = new System.Windows.Forms.Button();
            this.btn_exit        = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── Header ────────────────────────────────────────────────────────
            this.label_title.Text      = "מרכז דניאל — מערכת ניהול";
            this.label_title.Font      = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = ThemeHelper.TEXT_PRIMARY;
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Location  = new System.Drawing.Point(20, 18);
            this.label_title.Size      = new System.Drawing.Size(1020, 38);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.TabIndex  = 0;

            this.label_welcome.Text      = "";
            this.label_welcome.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.label_welcome.ForeColor = ThemeHelper.TEXT_SECONDARY;
            this.label_welcome.BackColor = System.Drawing.Color.Transparent;
            this.label_welcome.Location  = new System.Drawing.Point(20, 58);
            this.label_welcome.Size      = new System.Drawing.Size(1020, 22);
            this.label_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_welcome.TabIndex  = 20;

            this.panel_header_sep.Location  = new System.Drawing.Point(10, 90);
            this.panel_header_sep.Size      = new System.Drawing.Size(1040, 1);
            this.panel_header_sep.BackColor = ThemeHelper.BORDER;

            // ── Button grid helpers ───────────────────────────────────────────
            // Layout: 3 columns × up to 3 rows
            // Col X: 20, 370, 720    Width: 320    Height: 90    Gap: 10
            // Row Y: 108, 213, 318

            // Row 1
            StyleNavCard(this.btn_employees,  "👤  ניהול עובדים",       20,  108);
            this.btn_employees.Click += new System.EventHandler(this.btn_employees_Click);
            StyleNavCard(this.btn_customers,  "👥  ניהול לקוחות",      370,  108);
            this.btn_customers.Click += new System.EventHandler(this.btn_customers_Click);
            StyleNavCard(this.btn_my_profile, "👤  הפרופיל שלי",       370,  108);
            this.btn_my_profile.Click += new System.EventHandler(this.btn_my_profile_Click);
            StyleNavCard(this.btn_boats,      "⛵  ניהול סירות",       720,  108);
            this.btn_boats.Click += new System.EventHandler(this.btn_boats_Click);

            // Row 2
            StyleNavCard(this.btn_activities, "◉  ניהול פעילויות",     20,  213);
            this.btn_activities.Click += new System.EventHandler(this.btn_activities_Click);
            StyleNavCard(this.btn_external,   "⊠  מרכזים חיצוניים",  370,  213);
            this.btn_external.Click += new System.EventHandler(this.btn_external_Click);
            StyleNavCard(this.btn_my_schedule,"📅  לוח הפעילויות שלי",370,  213);
            this.btn_my_schedule.Click += new System.EventHandler(this.btn_my_schedule_Click);
            StyleNavCard(this.btn_discount,   "▣  בקשות הנחה",        720,  213);
            this.btn_discount.Click += new System.EventHandler(this.btn_discount_Click);

            // Row 3
            StyleNavCard(this.btn_maintenance,"⚙  תחזוקה",             20,  318);
            this.btn_maintenance.Click += new System.EventHandler(this.btn_maintenance_Click);
            StyleNavCard(this.btn_workhours,  "📊  שעות עבודה",       370,  318);
            this.btn_workhours.Click += new System.EventHandler(this.btn_workhours_Click);
            StyleNavCard(this.btn_attendance, "📋  דוחות נוכחות",     720,  318);
            this.btn_attendance.Click += new System.EventHandler(this.btn_attendance_Click);

            // ── Customer-only: identical positions as staff buttons they replace
            this.btn_my_profile.Visible  = false;
            this.btn_my_schedule.Visible = false;

            // ── Bottom row: logout / exit ─────────────────────────────────────
            this.btn_logout.BackColor               = ThemeHelper.DANGER;
            this.btn_logout.ForeColor               = System.Drawing.Color.White;
            this.btn_logout.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.Font                    = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_logout.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Location                = new System.Drawing.Point(720, 438);
            this.btn_logout.Name                    = "btn_logout";
            this.btn_logout.Size                    = new System.Drawing.Size(155, 40);
            this.btn_logout.Text                    = "↩  התנתקות";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.TabIndex                = 22;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);

            this.btn_exit.BackColor               = ThemeHelper.SECONDARY;
            this.btn_exit.ForeColor               = ThemeHelper.TEXT_SECONDARY;
            this.btn_exit.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.Font                    = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_exit.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Location                = new System.Drawing.Point(885, 438);
            this.btn_exit.Name                    = "btn_exit";
            this.btn_exit.Size                    = new System.Drawing.Size(155, 40);
            this.btn_exit.Text                    = "✕  יציאה";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.TabIndex                = 10;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);

            // ── HomePanel ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = ThemeHelper.BG_CONTENT;
            this.Controls.Add(this.panel_header_sep);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_attendance);
            this.Controls.Add(this.btn_workhours);
            this.Controls.Add(this.btn_maintenance);
            this.Controls.Add(this.btn_discount);
            this.Controls.Add(this.btn_my_schedule);
            this.Controls.Add(this.btn_my_profile);
            this.Controls.Add(this.btn_external);
            this.Controls.Add(this.btn_activities);
            this.Controls.Add(this.btn_boats);
            this.Controls.Add(this.btn_customers);
            this.Controls.Add(this.btn_employees);
            this.Name = "HomePanel";
            this.Size = new System.Drawing.Size(1060, 760);
            this.ResumeLayout(false);
        }

        // Shared card-button styler (avoids repetition)
        private void StyleNavCard(System.Windows.Forms.Button btn, string text, int x, int y)
        {
            btn.BackColor               = ThemeHelper.BG_CARD;
            btn.ForeColor               = ThemeHelper.TEXT_SECONDARY;
            btn.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = ThemeHelper.BORDER;
            btn.Font                    = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btn.Cursor                  = System.Windows.Forms.Cursors.Hand;
            btn.Location                = new System.Drawing.Point(x, y);
            btn.Size                    = new System.Drawing.Size(320, 90);
            btn.Text                    = text;
            btn.TextAlign               = System.Drawing.ContentAlignment.MiddleRight;
            btn.Padding                 = new System.Windows.Forms.Padding(0, 0, 20, 0);
            btn.UseVisualStyleBackColor = false;
            btn.Tag                     = "nav_card"; // prevents ThemeHelper.StyleButton from overriding

            btn.MouseEnter += (s, e) => {
                btn.BackColor = ThemeHelper.Hex("#EFF6FF"); // light blue hover
                btn.ForeColor = ThemeHelper.TEXT_PRIMARY;
                btn.FlatAppearance.BorderColor = ThemeHelper.PRIMARY;
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = ThemeHelper.BG_CARD;
                btn.ForeColor = ThemeHelper.TEXT_SECONDARY;
                btn.FlatAppearance.BorderColor = ThemeHelper.BORDER;
            };
        }

        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Label  label_welcome;
        private System.Windows.Forms.Panel  panel_header_sep;
        private System.Windows.Forms.Button btn_employees;
        private System.Windows.Forms.Button btn_customers;
        private System.Windows.Forms.Button btn_my_profile;
        private System.Windows.Forms.Button btn_boats;
        private System.Windows.Forms.Button btn_activities;
        private System.Windows.Forms.Button btn_external;
        private System.Windows.Forms.Button btn_discount;
        private System.Windows.Forms.Button btn_maintenance;
        private System.Windows.Forms.Button btn_workhours;
        private System.Windows.Forms.Button btn_attendance;
        private System.Windows.Forms.Button btn_my_schedule;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_exit;
    }
}
