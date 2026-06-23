namespace MyDaniel
{
    partial class LoginPanel
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
            this.panel_card     = new System.Windows.Forms.Panel();
            this.label_title    = new System.Windows.Forms.Label();
            this.label_subtitle = new System.Windows.Forms.Label();
            this.panel_card_sep = new System.Windows.Forms.Panel();
            this.label_email    = new System.Windows.Forms.Label();
            this.txt_email      = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.txt_password   = new System.Windows.Forms.TextBox();
            this.btn_login      = new System.Windows.Forms.Button();
            this.btn_forgot     = new System.Windows.Forms.Button();
            this.btn_register   = new System.Windows.Forms.Button();
            this.label_error    = new System.Windows.Forms.Label();
            this.panel_card.SuspendLayout();
            this.SuspendLayout();

            // ── Card panel — white card centered on light-blue background ─────
            this.panel_card.BackColor = ThemeHelper.BG_CARD;      // white
            this.panel_card.Location  = new System.Drawing.Point(430, 110);
            this.panel_card.Size      = new System.Drawing.Size(420, 520);
            this.panel_card.Controls.Add(this.label_error);
            this.panel_card.Controls.Add(this.btn_register);
            this.panel_card.Controls.Add(this.btn_forgot);
            this.panel_card.Controls.Add(this.btn_login);
            this.panel_card.Controls.Add(this.txt_password);
            this.panel_card.Controls.Add(this.label_password);
            this.panel_card.Controls.Add(this.txt_email);
            this.panel_card.Controls.Add(this.label_email);
            this.panel_card.Controls.Add(this.panel_card_sep);
            this.panel_card.Controls.Add(this.label_subtitle);
            this.panel_card.Controls.Add(this.label_title);

            // ── Card contents (coordinates relative to panel_card) ────────────

            // Title — brand blue on white card
            this.label_title.Text      = "מרכז דניאל";
            this.label_title.Font      = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = ThemeHelper.PRIMARY;
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Location  = new System.Drawing.Point(0, 28);
            this.label_title.Size      = new System.Drawing.Size(420, 46);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_title.TabIndex  = 0;

            // Subtitle
            this.label_subtitle.Text      = "כניסה למערכת";
            this.label_subtitle.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.label_subtitle.ForeColor = ThemeHelper.TEXT_SECONDARY;
            this.label_subtitle.BackColor = System.Drawing.Color.Transparent;
            this.label_subtitle.Location  = new System.Drawing.Point(0, 80);
            this.label_subtitle.Size      = new System.Drawing.Size(420, 24);
            this.label_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_subtitle.TabIndex  = 1;

            // Separator under subtitle
            this.panel_card_sep.Location  = new System.Drawing.Point(20, 114);
            this.panel_card_sep.Size      = new System.Drawing.Size(380, 1);
            this.panel_card_sep.BackColor = ThemeHelper.BORDER;

            // Email label
            this.label_email.Text      = "אימייל / שם משתמש";
            this.label_email.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label_email.ForeColor = ThemeHelper.TEXT_SECONDARY;
            this.label_email.BackColor = System.Drawing.Color.Transparent;
            this.label_email.Location  = new System.Drawing.Point(20, 128);
            this.label_email.Size      = new System.Drawing.Size(380, 18);
            this.label_email.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_email.TabIndex  = 2;

            // Email input — white with dark text
            this.txt_email.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_email.BackColor   = ThemeHelper.BG_INPUT;
            this.txt_email.ForeColor   = ThemeHelper.TEXT_PRIMARY;
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.Location    = new System.Drawing.Point(20, 150);
            this.txt_email.Size        = new System.Drawing.Size(380, 28);
            this.txt_email.TabIndex    = 3;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            this.txt_email.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txt_email_KeyDown);

            // Password label
            this.label_password.Text      = "סיסמה";
            this.label_password.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.label_password.ForeColor = ThemeHelper.TEXT_SECONDARY;
            this.label_password.BackColor = System.Drawing.Color.Transparent;
            this.label_password.Location  = new System.Drawing.Point(20, 196);
            this.label_password.Size      = new System.Drawing.Size(380, 18);
            this.label_password.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_password.TabIndex  = 4;

            // Password input — white with dark text
            this.txt_password.Font                  = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_password.BackColor             = ThemeHelper.BG_INPUT;
            this.txt_password.ForeColor             = ThemeHelper.TEXT_PRIMARY;
            this.txt_password.BorderStyle           = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.Location              = new System.Drawing.Point(20, 218);
            this.txt_password.Size                  = new System.Drawing.Size(380, 28);
            this.txt_password.TabIndex              = 5;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            this.txt_password.KeyDown     += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);

            // Login button (Primary blue)
            this.btn_login.BackColor               = ThemeHelper.PRIMARY;
            this.btn_login.ForeColor               = System.Drawing.Color.White;
            this.btn_login.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.Font                    = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_login.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Location                = new System.Drawing.Point(20, 268);
            this.btn_login.Size                    = new System.Drawing.Size(380, 46);
            this.btn_login.TabIndex                = 6;
            this.btn_login.Text                    = "כניסה";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);

            // Forgot password (text-link style)
            this.btn_forgot.BackColor               = ThemeHelper.BG_CARD;
            this.btn_forgot.ForeColor               = ThemeHelper.PRIMARY;
            this.btn_forgot.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btn_forgot.FlatAppearance.BorderSize = 0;
            this.btn_forgot.Font                    = new System.Drawing.Font("Segoe UI", 10F);
            this.btn_forgot.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btn_forgot.Location                = new System.Drawing.Point(20, 328);
            this.btn_forgot.Size                    = new System.Drawing.Size(380, 34);
            this.btn_forgot.TabIndex                = 7;
            this.btn_forgot.Text                    = "שכחתי סיסמה?";
            this.btn_forgot.UseVisualStyleBackColor = false;
            this.btn_forgot.Click += new System.EventHandler(this.btn_forgot_Click);

            // Register button (Secondary — light gray, dark text)
            this.btn_register.BackColor               = ThemeHelper.SECONDARY;
            this.btn_register.ForeColor               = ThemeHelper.TEXT_PRIMARY;
            this.btn_register.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.FlatAppearance.BorderSize = 0;
            this.btn_register.Font                    = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_register.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Location                = new System.Drawing.Point(20, 370);
            this.btn_register.Size                    = new System.Drawing.Size(380, 44);
            this.btn_register.TabIndex                = 8;
            this.btn_register.Text                    = "הרשמה — לקוח חדש";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);

            // Error label
            this.label_error.Text      = "";
            this.label_error.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = ThemeHelper.DANGER;
            this.label_error.BackColor = System.Drawing.Color.Transparent;
            this.label_error.Location  = new System.Drawing.Point(20, 430);
            this.label_error.Size      = new System.Drawing.Size(380, 22);
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            this.label_error.TabIndex  = 9;

            // ── LoginPanel ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = ThemeHelper.BG_APP;          // light blue full screen
            this.Controls.Add(this.panel_card);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(1280, 760);
            this.panel_card.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel    panel_card;
        private System.Windows.Forms.Panel    panel_card_sep;
        private System.Windows.Forms.Label    label_title;
        private System.Windows.Forms.Label    label_subtitle;
        private System.Windows.Forms.Label    label_email;
        private System.Windows.Forms.TextBox  txt_email;
        private System.Windows.Forms.Label    label_password;
        private System.Windows.Forms.TextBox  txt_password;
        private System.Windows.Forms.Button   btn_login;
        private System.Windows.Forms.Button   btn_forgot;
        private System.Windows.Forms.Button   btn_register;
        private System.Windows.Forms.Label    label_error;
    }
}
