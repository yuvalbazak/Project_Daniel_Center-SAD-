namespace MyDaniel
{
    partial class StudentMenuPanel
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
            this.label_welcome    = new System.Windows.Forms.Label();
            this.label_title      = new System.Windows.Forms.Label();
            this.btn_schedule     = new System.Windows.Forms.Button();
            this.btn_profile      = new System.Windows.Forms.Button();
            this.btn_discount     = new System.Windows.Forms.Button();
            this.btn_register     = new System.Windows.Forms.Button();
            this.btn_logout       = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_welcome
            //
            this.label_welcome.AutoSize  = false;
            this.label_welcome.Font      = new System.Drawing.Font("David", 14F);
            this.label_welcome.ForeColor = System.Drawing.Color.DimGray;
            this.label_welcome.Location  = new System.Drawing.Point(0, 15);
            this.label_welcome.Name      = "label_welcome";
            this.label_welcome.Size      = new System.Drawing.Size(1000, 28);
            this.label_welcome.TabIndex  = 0;
            this.label_welcome.Text      = "";
            this.label_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 34F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 52);
            this.label_title.Size      = new System.Drawing.Size(975, 50);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 1;
            this.label_title.Text      = "פורטל תלמיד";
            //
            // btn_schedule  (left col, row 1)  — לוח פעילויות
            //
            this.btn_schedule.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_schedule.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_schedule.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_schedule.ForeColor = System.Drawing.Color.White;
            this.btn_schedule.Location  = new System.Drawing.Point(80, 148);
            this.btn_schedule.Name      = "btn_schedule";
            this.btn_schedule.Size      = new System.Drawing.Size(360, 75);
            this.btn_schedule.TabIndex  = 2;
            this.btn_schedule.Text      = "לוח הפעילויות שלי";
            this.btn_schedule.UseVisualStyleBackColor = false;
            this.btn_schedule.Click    += new System.EventHandler(this.btn_schedule_Click);
            //
            // btn_profile  (right col, row 1) — פרטים אישיים
            //
            this.btn_profile.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_profile.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_profile.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_profile.ForeColor = System.Drawing.Color.White;
            this.btn_profile.Location  = new System.Drawing.Point(530, 148);
            this.btn_profile.Name      = "btn_profile";
            this.btn_profile.Size      = new System.Drawing.Size(360, 75);
            this.btn_profile.TabIndex  = 3;
            this.btn_profile.Text      = "הפרטים האישיים שלי";
            this.btn_profile.UseVisualStyleBackColor = false;
            this.btn_profile.Click    += new System.EventHandler(this.btn_profile_Click);
            //
            // btn_discount  (left col, row 2) — העלאת מסמכי הנחה
            //
            this.btn_discount.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_discount.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_discount.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_discount.ForeColor = System.Drawing.Color.White;
            this.btn_discount.Location  = new System.Drawing.Point(80, 255);
            this.btn_discount.Name      = "btn_discount";
            this.btn_discount.Size      = new System.Drawing.Size(360, 75);
            this.btn_discount.TabIndex  = 4;
            this.btn_discount.Text      = "העלאת מסמכי בקשת הנחה";
            this.btn_discount.UseVisualStyleBackColor = false;
            this.btn_discount.Click    += new System.EventHandler(this.btn_discount_Click);
            //
            // btn_register  (right col, row 2) — הרשמה לפעילות
            //
            this.btn_register.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_register.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_register.ForeColor = System.Drawing.Color.White;
            this.btn_register.Location  = new System.Drawing.Point(530, 255);
            this.btn_register.Name      = "btn_register";
            this.btn_register.Size      = new System.Drawing.Size(360, 75);
            this.btn_register.TabIndex  = 5;
            this.btn_register.Text      = "הרשמה לפעילות";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click    += new System.EventHandler(this.btn_register_Click);
            //
            // btn_logout  (row 3, centered)
            //
            this.btn_logout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_logout.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location  = new System.Drawing.Point(320, 362);
            this.btn_logout.Name      = "btn_logout";
            this.btn_logout.Size      = new System.Drawing.Size(360, 65);
            this.btn_logout.TabIndex  = 6;
            this.btn_logout.Text      = "יציאה מהמערכת";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click    += new System.EventHandler(this.btn_logout_Click);
            //
            // StudentMenuPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.btn_discount);
            this.Controls.Add(this.btn_profile);
            this.Controls.Add(this.btn_schedule);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_welcome);
            this.Name = "StudentMenuPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label  label_welcome;
        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Button btn_schedule;
        private System.Windows.Forms.Button btn_profile;
        private System.Windows.Forms.Button btn_discount;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_logout;
    }
}
