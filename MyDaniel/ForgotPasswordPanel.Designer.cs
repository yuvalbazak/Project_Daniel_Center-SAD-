namespace MyDaniel
{
    partial class ForgotPasswordPanel
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
            this.label_title    = new System.Windows.Forms.Label();
            this.label_hint     = new System.Windows.Forms.Label();
            this.label_email    = new System.Windows.Forms.Label();
            this.txt_email      = new System.Windows.Forms.TextBox();
            this.label_id       = new System.Windows.Forms.Label();
            this.txt_id         = new System.Windows.Forms.TextBox();
            this.btn_verify     = new System.Windows.Forms.Button();
            this.label_phase2   = new System.Windows.Forms.Label();
            this.label_new_pass = new System.Windows.Forms.Label();
            this.txt_new_pass   = new System.Windows.Forms.TextBox();
            this.label_confirm  = new System.Windows.Forms.Label();
            this.txt_confirm    = new System.Windows.Forms.TextBox();
            this.btn_reset      = new System.Windows.Forms.Button();
            this.label_message  = new System.Windows.Forms.Label();
            this.btn_back       = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 32F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 28);
            this.label_title.Size      = new System.Drawing.Size(975, 48);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "שחזור סיסמה";
            //
            // label_hint
            //
            this.label_hint.AutoSize  = true;
            this.label_hint.Font      = new System.Drawing.Font("David", 11F);
            this.label_hint.ForeColor = System.Drawing.Color.DimGray;
            this.label_hint.Location  = new System.Drawing.Point(290, 88);
            this.label_hint.Name      = "label_hint";
            this.label_hint.TabIndex  = 1;
            this.label_hint.Text      = "הזינו את האימייל ומספר הזהות / עובד שבו נרשמתם";
            //
            // label_email
            //
            this.label_email.AutoSize = true;
            this.label_email.Font     = new System.Drawing.Font("David", 14F);
            this.label_email.Location = new System.Drawing.Point(660, 148);
            this.label_email.Name     = "label_email";
            this.label_email.TabIndex = 2;
            this.label_email.Text     = "אימייל";
            //
            // txt_email
            //
            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(430, 145);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(215, 27);
            this.txt_email.TabIndex = 3;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            //
            // label_id
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 14F);
            this.label_id.Location = new System.Drawing.Point(660, 200);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 4;
            this.label_id.Text     = "מספר זהות / עובד";
            //
            // txt_id
            //
            this.txt_id.Font     = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(430, 197);
            this.txt_id.Name     = "txt_id";
            this.txt_id.Size     = new System.Drawing.Size(215, 27);
            this.txt_id.TabIndex = 5;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            //
            // btn_verify
            //
            this.btn_verify.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_verify.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_verify.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_verify.ForeColor = System.Drawing.Color.White;
            this.btn_verify.Location  = new System.Drawing.Point(430, 246);
            this.btn_verify.Name      = "btn_verify";
            this.btn_verify.Size      = new System.Drawing.Size(215, 46);
            this.btn_verify.TabIndex  = 6;
            this.btn_verify.Text      = "אמת זהות";
            this.btn_verify.UseVisualStyleBackColor = false;
            this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
            //
            // label_phase2
            //
            this.label_phase2.AutoSize  = true;
            this.label_phase2.Font      = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Bold);
            this.label_phase2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_phase2.Location  = new System.Drawing.Point(340, 318);
            this.label_phase2.Name      = "label_phase2";
            this.label_phase2.TabIndex  = 7;
            this.label_phase2.Text      = "הגדרת סיסמה חדשה";
            this.label_phase2.Visible   = false;
            //
            // label_new_pass
            //
            this.label_new_pass.AutoSize = true;
            this.label_new_pass.Font     = new System.Drawing.Font("David", 14F);
            this.label_new_pass.Location = new System.Drawing.Point(660, 362);
            this.label_new_pass.Name     = "label_new_pass";
            this.label_new_pass.TabIndex = 8;
            this.label_new_pass.Text     = "סיסמה חדשה";
            this.label_new_pass.Visible  = false;
            //
            // txt_new_pass
            //
            this.txt_new_pass.Font                  = new System.Drawing.Font("David", 12F);
            this.txt_new_pass.Location              = new System.Drawing.Point(430, 359);
            this.txt_new_pass.Name                  = "txt_new_pass";
            this.txt_new_pass.Size                  = new System.Drawing.Size(215, 27);
            this.txt_new_pass.TabIndex              = 9;
            this.txt_new_pass.UseSystemPasswordChar = false;
            this.txt_new_pass.Visible               = false;
            this.txt_new_pass.TextChanged += new System.EventHandler(this.txt_new_pass_TextChanged);
            //
            // label_confirm
            //
            this.label_confirm.AutoSize = true;
            this.label_confirm.Font     = new System.Drawing.Font("David", 14F);
            this.label_confirm.Location = new System.Drawing.Point(660, 410);
            this.label_confirm.Name     = "label_confirm";
            this.label_confirm.TabIndex = 10;
            this.label_confirm.Text     = "אשר סיסמה";
            this.label_confirm.Visible  = false;
            //
            // txt_confirm
            //
            this.txt_confirm.Font                  = new System.Drawing.Font("David", 12F);
            this.txt_confirm.Location              = new System.Drawing.Point(430, 407);
            this.txt_confirm.Name                  = "txt_confirm";
            this.txt_confirm.Size                  = new System.Drawing.Size(215, 27);
            this.txt_confirm.TabIndex              = 11;
            this.txt_confirm.UseSystemPasswordChar = false;
            this.txt_confirm.Visible               = false;
            this.txt_confirm.TextChanged += new System.EventHandler(this.txt_confirm_TextChanged);
            //
            // btn_reset
            //
            this.btn_reset.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_reset.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_reset.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_reset.ForeColor = System.Drawing.Color.White;
            this.btn_reset.Location  = new System.Drawing.Point(430, 453);
            this.btn_reset.Name      = "btn_reset";
            this.btn_reset.Size      = new System.Drawing.Size(215, 46);
            this.btn_reset.TabIndex  = 12;
            this.btn_reset.Text      = "שמור סיסמה חדשה";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Visible   = false;
            this.btn_reset.Click    += new System.EventHandler(this.btn_reset_Click);
            //
            // label_message
            //
            this.label_message.AutoSize  = false;
            this.label_message.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_message.Location  = new System.Drawing.Point(220, 516);
            this.label_message.Name      = "label_message";
            this.label_message.Size      = new System.Drawing.Size(560, 24);
            this.label_message.TabIndex  = 13;
            this.label_message.Text      = "";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_message.Visible   = false;
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(425, 553);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex  = 14;
            this.btn_back.Text      = "חזרה לכניסה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            //
            // ForgotPasswordPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.txt_confirm);
            this.Controls.Add(this.label_confirm);
            this.Controls.Add(this.txt_new_pass);
            this.Controls.Add(this.label_new_pass);
            this.Controls.Add(this.label_phase2);
            this.Controls.Add(this.btn_verify);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_hint);
            this.Controls.Add(this.label_title);
            this.Name = "ForgotPasswordPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   label_title;
        private System.Windows.Forms.Label   label_hint;
        private System.Windows.Forms.Label   label_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label   label_id;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button  btn_verify;
        private System.Windows.Forms.Label   label_phase2;
        private System.Windows.Forms.Label   label_new_pass;
        private System.Windows.Forms.TextBox txt_new_pass;
        private System.Windows.Forms.Label   label_confirm;
        private System.Windows.Forms.TextBox txt_confirm;
        private System.Windows.Forms.Button  btn_reset;
        private System.Windows.Forms.Label   label_message;
        private System.Windows.Forms.Button  btn_back;
    }
}
