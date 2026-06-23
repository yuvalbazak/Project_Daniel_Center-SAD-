namespace MyDaniel
{
    partial class AdminMenuPanel
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
            this.label_welcome        = new System.Windows.Forms.Label();
            this.label_title          = new System.Windows.Forms.Label();
            this.btn_employees        = new System.Windows.Forms.Button();
            this.btn_students         = new System.Windows.Forms.Button();
            this.btn_activities       = new System.Windows.Forms.Button();
            this.btn_assign           = new System.Windows.Forms.Button();
            this.btn_resource_update  = new System.Windows.Forms.Button();
            this.btn_maintenance      = new System.Windows.Forms.Button();
            this.btn_payroll          = new System.Windows.Forms.Button();
            this.btn_dashboard        = new System.Windows.Forms.Button();
            this.btn_payment          = new System.Windows.Forms.Button();
            this.btn_archive          = new System.Windows.Forms.Button();
            this.btn_logout           = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_welcome
            //
            this.label_welcome.AutoSize  = false;
            this.label_welcome.Font      = new System.Drawing.Font("David", 13F);
            this.label_welcome.ForeColor = System.Drawing.Color.DimGray;
            this.label_welcome.Location  = new System.Drawing.Point(0, 12);
            this.label_welcome.Name      = "label_welcome";
            this.label_welcome.Size      = new System.Drawing.Size(1000, 24);
            this.label_welcome.TabIndex  = 0;
            this.label_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 40);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 1;
            this.label_title.Text      = "תפריט ניהול מנהלה";
            //
            // Row 1 (Y=98)
            //
            this.btn_employees.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_employees.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_employees.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_employees.ForeColor = System.Drawing.Color.White;
            this.btn_employees.Location  = new System.Drawing.Point(25, 98);
            this.btn_employees.Name      = "btn_employees";
            this.btn_employees.Size      = new System.Drawing.Size(375, 65);
            this.btn_employees.TabIndex  = 2;
            this.btn_employees.Text      = "ניהול עובדים";
            this.btn_employees.UseVisualStyleBackColor = false;
            this.btn_employees.Click    += new System.EventHandler(this.btn_employees_Click);

            this.btn_students.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_students.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_students.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_students.ForeColor = System.Drawing.Color.White;
            this.btn_students.Location  = new System.Drawing.Point(415, 98);
            this.btn_students.Name      = "btn_students";
            this.btn_students.Size      = new System.Drawing.Size(375, 65);
            this.btn_students.TabIndex  = 3;
            this.btn_students.Text      = "ניהול תלמידים";
            this.btn_students.UseVisualStyleBackColor = false;
            this.btn_students.Click    += new System.EventHandler(this.btn_students_Click);
            //
            // Row 2 (Y=175)
            //
            this.btn_activities.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_activities.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_activities.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_activities.ForeColor = System.Drawing.Color.White;
            this.btn_activities.Location  = new System.Drawing.Point(25, 175);
            this.btn_activities.Name      = "btn_activities";
            this.btn_activities.Size      = new System.Drawing.Size(375, 65);
            this.btn_activities.TabIndex  = 4;
            this.btn_activities.Text      = "צפייה בכל הפעילויות";
            this.btn_activities.UseVisualStyleBackColor = false;
            this.btn_activities.Click    += new System.EventHandler(this.btn_activities_Click);

            this.btn_assign.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_assign.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_assign.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_assign.ForeColor = System.Drawing.Color.White;
            this.btn_assign.Location  = new System.Drawing.Point(415, 175);
            this.btn_assign.Name      = "btn_assign";
            this.btn_assign.Size      = new System.Drawing.Size(375, 65);
            this.btn_assign.TabIndex  = 5;
            this.btn_assign.Text      = "שיוך משאבים לפעילות";
            this.btn_assign.UseVisualStyleBackColor = false;
            this.btn_assign.Click    += new System.EventHandler(this.btn_assign_Click);
            //
            // Row 3 (Y=252)
            //
            this.btn_resource_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_resource_update.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_resource_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_resource_update.ForeColor = System.Drawing.Color.White;
            this.btn_resource_update.Location  = new System.Drawing.Point(25, 252);
            this.btn_resource_update.Name      = "btn_resource_update";
            this.btn_resource_update.Size      = new System.Drawing.Size(375, 65);
            this.btn_resource_update.TabIndex  = 6;
            this.btn_resource_update.Text      = "עדכון משאבי פעילות";
            this.btn_resource_update.UseVisualStyleBackColor = false;
            this.btn_resource_update.Click    += new System.EventHandler(this.btn_resource_update_Click);

            this.btn_maintenance.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_maintenance.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_maintenance.BackColor = System.Drawing.Color.Teal;
            this.btn_maintenance.ForeColor = System.Drawing.Color.White;
            this.btn_maintenance.Location  = new System.Drawing.Point(415, 252);
            this.btn_maintenance.Name      = "btn_maintenance";
            this.btn_maintenance.Size      = new System.Drawing.Size(375, 65);
            this.btn_maintenance.TabIndex  = 7;
            this.btn_maintenance.Text      = "ניהול תחזוקה";
            this.btn_maintenance.UseVisualStyleBackColor = false;
            this.btn_maintenance.Click    += new System.EventHandler(this.btn_maintenance_Click);
            //
            // Row 4 (Y=329)
            //
            this.btn_payroll.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_payroll.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_payroll.BackColor = System.Drawing.Color.DimGray;
            this.btn_payroll.ForeColor = System.Drawing.Color.White;
            this.btn_payroll.Location  = new System.Drawing.Point(25, 329);
            this.btn_payroll.Name      = "btn_payroll";
            this.btn_payroll.Size      = new System.Drawing.Size(375, 65);
            this.btn_payroll.TabIndex  = 8;
            this.btn_payroll.Text      = "סנכרון שכר ונוכחות";
            this.btn_payroll.UseVisualStyleBackColor = false;
            this.btn_payroll.Click    += new System.EventHandler(this.btn_payroll_Click);

            this.btn_dashboard.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_dashboard.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_dashboard.BackColor = System.Drawing.Color.DimGray;
            this.btn_dashboard.ForeColor = System.Drawing.Color.White;
            this.btn_dashboard.Location  = new System.Drawing.Point(415, 329);
            this.btn_dashboard.Name      = "btn_dashboard";
            this.btn_dashboard.Size      = new System.Drawing.Size(375, 65);
            this.btn_dashboard.TabIndex  = 9;
            this.btn_dashboard.Text      = "לוח מצב שבועי";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            this.btn_dashboard.Click    += new System.EventHandler(this.btn_dashboard_Click);
            //
            // Row 5 (Y=406)
            //
            this.btn_payment.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_payment.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_payment.BackColor = System.Drawing.Color.DimGray;
            this.btn_payment.ForeColor = System.Drawing.Color.White;
            this.btn_payment.Location  = new System.Drawing.Point(25, 406);
            this.btn_payment.Name      = "btn_payment";
            this.btn_payment.Size      = new System.Drawing.Size(375, 65);
            this.btn_payment.TabIndex  = 10;
            this.btn_payment.Text      = "ניהול תשלומים";
            this.btn_payment.UseVisualStyleBackColor = false;
            this.btn_payment.Click    += new System.EventHandler(this.btn_payment_Click);

            this.btn_archive.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_archive.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_archive.BackColor = System.Drawing.Color.DimGray;
            this.btn_archive.ForeColor = System.Drawing.Color.White;
            this.btn_archive.Location  = new System.Drawing.Point(415, 406);
            this.btn_archive.Name      = "btn_archive";
            this.btn_archive.Size      = new System.Drawing.Size(375, 65);
            this.btn_archive.TabIndex  = 11;
            this.btn_archive.Text      = "רשומות ארכיון";
            this.btn_archive.UseVisualStyleBackColor = false;
            this.btn_archive.Click    += new System.EventHandler(this.btn_archive_Click);
            //
            // Logout (centered, Y=485)
            //
            this.btn_logout.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_logout.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_logout.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location  = new System.Drawing.Point(312, 485);
            this.btn_logout.Name      = "btn_logout";
            this.btn_logout.Size      = new System.Drawing.Size(375, 55);
            this.btn_logout.TabIndex  = 12;
            this.btn_logout.Text      = "יציאה מהמערכת";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click    += new System.EventHandler(this.btn_logout_Click);
            //
            // AdminMenuPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_archive);
            this.Controls.Add(this.btn_payment);
            this.Controls.Add(this.btn_dashboard);
            this.Controls.Add(this.btn_payroll);
            this.Controls.Add(this.btn_maintenance);
            this.Controls.Add(this.btn_resource_update);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.btn_activities);
            this.Controls.Add(this.btn_students);
            this.Controls.Add(this.btn_employees);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_welcome);
            this.Name = "AdminMenuPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label  label_welcome;
        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Button btn_employees;
        private System.Windows.Forms.Button btn_students;
        private System.Windows.Forms.Button btn_activities;
        private System.Windows.Forms.Button btn_assign;
        private System.Windows.Forms.Button btn_resource_update;
        private System.Windows.Forms.Button btn_maintenance;
        private System.Windows.Forms.Button btn_payroll;
        private System.Windows.Forms.Button btn_dashboard;
        private System.Windows.Forms.Button btn_payment;
        private System.Windows.Forms.Button btn_archive;
        private System.Windows.Forms.Button btn_logout;
    }
}
