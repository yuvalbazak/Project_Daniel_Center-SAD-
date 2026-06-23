namespace MyDaniel
{
    partial class InstructorMenuPanel
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
            this.label_welcome       = new System.Windows.Forms.Label();
            this.label_title         = new System.Windows.Forms.Label();
            this.btn_attendance      = new System.Windows.Forms.Button();
            this.btn_resources       = new System.Windows.Forms.Button();
            this.btn_events          = new System.Windows.Forms.Button();
            this.btn_my_activities   = new System.Windows.Forms.Button();
            this.btn_my_students     = new System.Windows.Forms.Button();
            this.btn_logout          = new System.Windows.Forms.Button();
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
            this.label_title.Text      = "תפריט מדריך";
            //
            // btn_attendance  (left col, row 1)
            //
            this.btn_attendance.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_attendance.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_attendance.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_attendance.ForeColor = System.Drawing.Color.White;
            this.btn_attendance.Location  = new System.Drawing.Point(80, 155);
            this.btn_attendance.Name      = "btn_attendance";
            this.btn_attendance.Size      = new System.Drawing.Size(360, 75);
            this.btn_attendance.TabIndex  = 2;
            this.btn_attendance.Text      = "דוח נוכחות תלמידים";
            this.btn_attendance.UseVisualStyleBackColor = false;
            this.btn_attendance.Click    += new System.EventHandler(this.btn_attendance_Click);
            //
            // btn_resources  (right col, row 1)
            //
            this.btn_resources.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_resources.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_resources.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_resources.ForeColor = System.Drawing.Color.White;
            this.btn_resources.Location  = new System.Drawing.Point(530, 155);
            this.btn_resources.Name      = "btn_resources";
            this.btn_resources.Size      = new System.Drawing.Size(360, 75);
            this.btn_resources.TabIndex  = 3;
            this.btn_resources.Text      = "עדכון משאבי פעילות";
            this.btn_resources.UseVisualStyleBackColor = false;
            this.btn_resources.Click    += new System.EventHandler(this.btn_resources_Click);
            //
            // btn_events  (left col, row 2)
            //
            this.btn_events.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_events.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_events.BackColor = System.Drawing.Color.Tomato;
            this.btn_events.ForeColor = System.Drawing.Color.White;
            this.btn_events.Location  = new System.Drawing.Point(80, 255);
            this.btn_events.Name      = "btn_events";
            this.btn_events.Size      = new System.Drawing.Size(360, 75);
            this.btn_events.TabIndex  = 4;
            this.btn_events.Text      = "דוח אירועים חריגים";
            this.btn_events.UseVisualStyleBackColor = false;
            this.btn_events.Click    += new System.EventHandler(this.btn_events_Click);
            //
            // btn_my_activities  (right col, row 2)
            //
            this.btn_my_activities.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_my_activities.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_my_activities.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_my_activities.ForeColor = System.Drawing.Color.White;
            this.btn_my_activities.Location  = new System.Drawing.Point(530, 255);
            this.btn_my_activities.Name      = "btn_my_activities";
            this.btn_my_activities.Size      = new System.Drawing.Size(360, 75);
            this.btn_my_activities.TabIndex  = 5;
            this.btn_my_activities.Text      = "הפעילויות שלי";
            this.btn_my_activities.UseVisualStyleBackColor = false;
            this.btn_my_activities.Click    += new System.EventHandler(this.btn_my_activities_Click);
            //
            // btn_my_students  (left col, row 3)
            //
            this.btn_my_students.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_my_students.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_my_students.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_my_students.ForeColor = System.Drawing.Color.White;
            this.btn_my_students.Location  = new System.Drawing.Point(80, 355);
            this.btn_my_students.Name      = "btn_my_students";
            this.btn_my_students.Size      = new System.Drawing.Size(360, 75);
            this.btn_my_students.TabIndex  = 6;
            this.btn_my_students.Text      = "התלמידים שלי";
            this.btn_my_students.UseVisualStyleBackColor = false;
            this.btn_my_students.Click    += new System.EventHandler(this.btn_my_students_Click);
            //
            // btn_logout  (right col, row 3)
            //
            this.btn_logout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Font      = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_logout.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location  = new System.Drawing.Point(530, 355);
            this.btn_logout.Name      = "btn_logout";
            this.btn_logout.Size      = new System.Drawing.Size(360, 75);
            this.btn_logout.TabIndex  = 7;
            this.btn_logout.Text      = "יציאה מהמערכת";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click    += new System.EventHandler(this.btn_logout_Click);
            //
            // InstructorMenuPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_my_students);
            this.Controls.Add(this.btn_my_activities);
            this.Controls.Add(this.btn_events);
            this.Controls.Add(this.btn_resources);
            this.Controls.Add(this.btn_attendance);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_welcome);
            this.Name = "InstructorMenuPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label  label_welcome;
        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Button btn_attendance;
        private System.Windows.Forms.Button btn_resources;
        private System.Windows.Forms.Button btn_events;
        private System.Windows.Forms.Button btn_my_activities;
        private System.Windows.Forms.Button btn_my_students;
        private System.Windows.Forms.Button btn_logout;
    }
}
