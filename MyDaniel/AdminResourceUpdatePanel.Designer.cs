namespace MyDaniel
{
    partial class AdminResourceUpdatePanel
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
            this.label_title              = new System.Windows.Forms.Label();
            this.dataGridView_activities  = new System.Windows.Forms.DataGridView();
            // Section 1 — Replace Instructor
            this.label_section1           = new System.Windows.Forms.Label();
            this.label_new_instructor     = new System.Windows.Forms.Label();
            this.combo_new_instructor     = new System.Windows.Forms.ComboBox();
            this.label_instructor_reason  = new System.Windows.Forms.Label();
            this.txt_instructor_reason    = new System.Windows.Forms.TextBox();
            this.btn_replace_instructor   = new System.Windows.Forms.Button();
            // Section 2 — Replace Boat
            this.label_section2           = new System.Windows.Forms.Label();
            this.label_new_boat           = new System.Windows.Forms.Label();
            this.combo_new_boat           = new System.Windows.Forms.ComboBox();
            this.label_boat_reason        = new System.Windows.Forms.Label();
            this.txt_boat_reason          = new System.Windows.Forms.TextBox();
            this.btn_replace_boat         = new System.Windows.Forms.Button();
            this.btn_report_unavailable   = new System.Windows.Forms.Button();
            // Bottom
            this.label_error              = new System.Windows.Forms.Label();
            this.btn_back                 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 20F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 10);
            this.label_title.Size      = new System.Drawing.Size(975, 38);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "עדכון משאבי פעילות — החלפת סירה / מדריך";
            //
            // Grid (Y=45, H=155)
            //
            this.dataGridView_activities.AllowUserToAddRows          = false;
            this.dataGridView_activities.AllowUserToDeleteRows       = false;
            this.dataGridView_activities.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_activities.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_activities.Location                    = new System.Drawing.Point(10, 45);
            this.dataGridView_activities.MultiSelect                 = false;
            this.dataGridView_activities.Name                        = "dataGridView_activities";
            this.dataGridView_activities.ReadOnly                    = true;
            this.dataGridView_activities.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_activities.RowHeadersWidth             = 40;
            this.dataGridView_activities.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 155);
            this.dataGridView_activities.TabIndex                    = 1;
            //
            // === Section 1 — Replace Instructor (Y=208-272) ===
            //
            this.label_section1.AutoSize  = true;
            this.label_section1.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_section1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label_section1.Location  = new System.Drawing.Point(320, 208);
            this.label_section1.Name      = "label_section1";
            this.label_section1.TabIndex  = 2;
            this.label_section1.Text      = "החלפת מדריך לפעילות הנבחרת";

            // RIGHT col (lbl X=720, ctrl X=490 W=220)
            this.label_new_instructor.AutoSize = true;
            this.label_new_instructor.Font     = new System.Drawing.Font("David", 12F);
            this.label_new_instructor.Location = new System.Drawing.Point(720, 236);
            this.label_new_instructor.Name     = "label_new_instructor";
            this.label_new_instructor.TabIndex = 3;
            this.label_new_instructor.Text     = "מדריך חלופי";

            this.combo_new_instructor.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_new_instructor.Font              = new System.Drawing.Font("David", 10F);
            this.combo_new_instructor.FormattingEnabled = true;
            this.combo_new_instructor.Location          = new System.Drawing.Point(490, 233);
            this.combo_new_instructor.Name              = "combo_new_instructor";
            this.combo_new_instructor.Size              = new System.Drawing.Size(220, 25);
            this.combo_new_instructor.TabIndex          = 4;

            // LEFT col (lbl X=375, ctrl X=120 W=245)
            this.label_instructor_reason.AutoSize = true;
            this.label_instructor_reason.Font     = new System.Drawing.Font("David", 12F);
            this.label_instructor_reason.Location = new System.Drawing.Point(375, 236);
            this.label_instructor_reason.Name     = "label_instructor_reason";
            this.label_instructor_reason.TabIndex = 5;
            this.label_instructor_reason.Text     = "סיבת ההחלפה";

            this.txt_instructor_reason.Font        = new System.Drawing.Font("David", 11F);
            this.txt_instructor_reason.Location    = new System.Drawing.Point(120, 233);
            this.txt_instructor_reason.Name        = "txt_instructor_reason";
            this.txt_instructor_reason.Size        = new System.Drawing.Size(245, 26);
            this.txt_instructor_reason.TabIndex    = 6;

            this.btn_replace_instructor.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_replace_instructor.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_replace_instructor.Enabled   = false;
            this.btn_replace_instructor.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_replace_instructor.ForeColor = System.Drawing.Color.White;
            this.btn_replace_instructor.Location  = new System.Drawing.Point(345, 268);
            this.btn_replace_instructor.Name      = "btn_replace_instructor";
            this.btn_replace_instructor.Size      = new System.Drawing.Size(305, 36);
            this.btn_replace_instructor.TabIndex  = 7;
            this.btn_replace_instructor.Text      = "החלף מדריך לפעילות";
            this.btn_replace_instructor.UseVisualStyleBackColor = false;
            this.btn_replace_instructor.Click    += new System.EventHandler(this.btn_replace_instructor_Click);
            //
            // === Section 2 — Replace Boat (Y=315-385) ===
            //
            this.label_section2.AutoSize  = true;
            this.label_section2.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_section2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label_section2.Location  = new System.Drawing.Point(320, 315);
            this.label_section2.Name      = "label_section2";
            this.label_section2.TabIndex  = 8;
            this.label_section2.Text      = "החלפת סירה לפעילות הנבחרת";

            // RIGHT col
            this.label_new_boat.AutoSize = true;
            this.label_new_boat.Font     = new System.Drawing.Font("David", 12F);
            this.label_new_boat.Location = new System.Drawing.Point(720, 343);
            this.label_new_boat.Name     = "label_new_boat";
            this.label_new_boat.TabIndex = 9;
            this.label_new_boat.Text     = "סירה חלופית";

            this.combo_new_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_new_boat.Font              = new System.Drawing.Font("David", 10F);
            this.combo_new_boat.FormattingEnabled = true;
            this.combo_new_boat.Location          = new System.Drawing.Point(490, 340);
            this.combo_new_boat.Name              = "combo_new_boat";
            this.combo_new_boat.Size              = new System.Drawing.Size(220, 25);
            this.combo_new_boat.TabIndex          = 10;

            // LEFT col
            this.label_boat_reason.AutoSize = true;
            this.label_boat_reason.Font     = new System.Drawing.Font("David", 12F);
            this.label_boat_reason.Location = new System.Drawing.Point(375, 343);
            this.label_boat_reason.Name     = "label_boat_reason";
            this.label_boat_reason.TabIndex = 11;
            this.label_boat_reason.Text     = "סיבת ההחלפה";

            this.txt_boat_reason.Font     = new System.Drawing.Font("David", 11F);
            this.txt_boat_reason.Location = new System.Drawing.Point(120, 340);
            this.txt_boat_reason.Name     = "txt_boat_reason";
            this.txt_boat_reason.Size     = new System.Drawing.Size(245, 26);
            this.txt_boat_reason.TabIndex = 12;

            this.btn_replace_boat.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_replace_boat.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_replace_boat.Enabled   = false;
            this.btn_replace_boat.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_replace_boat.ForeColor = System.Drawing.Color.White;
            this.btn_replace_boat.Location  = new System.Drawing.Point(345, 378);
            this.btn_replace_boat.Name      = "btn_replace_boat";
            this.btn_replace_boat.Size      = new System.Drawing.Size(200, 36);
            this.btn_replace_boat.TabIndex  = 13;
            this.btn_replace_boat.Text      = "החלף סירה";
            this.btn_replace_boat.UseVisualStyleBackColor = false;
            this.btn_replace_boat.Click    += new System.EventHandler(this.btn_replace_boat_Click);

            this.btn_report_unavailable.BackColor = System.Drawing.Color.Peru;
            this.btn_report_unavailable.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_report_unavailable.Enabled   = false;
            this.btn_report_unavailable.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_report_unavailable.ForeColor = System.Drawing.Color.White;
            this.btn_report_unavailable.Location  = new System.Drawing.Point(560, 378);
            this.btn_report_unavailable.Name      = "btn_report_unavailable";
            this.btn_report_unavailable.Size      = new System.Drawing.Size(220, 36);
            this.btn_report_unavailable.TabIndex  = 14;
            this.btn_report_unavailable.Text      = "דווח סירה כלא זמינה";
            this.btn_report_unavailable.UseVisualStyleBackColor = false;
            this.btn_report_unavailable.Click    += new System.EventHandler(this.btn_report_unavailable_Click);
            //
            // label_error (Y=428)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 428);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 20;
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_back (Y=465)
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(390, 462);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(220, 38);
            this.btn_back.TabIndex  = 21;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // AdminResourceUpdatePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_report_unavailable);
            this.Controls.Add(this.btn_replace_boat);
            this.Controls.Add(this.txt_boat_reason);
            this.Controls.Add(this.label_boat_reason);
            this.Controls.Add(this.combo_new_boat);
            this.Controls.Add(this.label_new_boat);
            this.Controls.Add(this.label_section2);
            this.Controls.Add(this.btn_replace_instructor);
            this.Controls.Add(this.txt_instructor_reason);
            this.Controls.Add(this.label_instructor_reason);
            this.Controls.Add(this.combo_new_instructor);
            this.Controls.Add(this.label_new_instructor);
            this.Controls.Add(this.label_section1);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.label_title);
            this.Name = "AdminResourceUpdatePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.DataGridView   dataGridView_activities;
        private System.Windows.Forms.Label          label_section1;
        private System.Windows.Forms.Label          label_new_instructor;
        private System.Windows.Forms.ComboBox       combo_new_instructor;
        private System.Windows.Forms.Label          label_instructor_reason;
        private System.Windows.Forms.TextBox        txt_instructor_reason;
        private System.Windows.Forms.Button         btn_replace_instructor;
        private System.Windows.Forms.Label          label_section2;
        private System.Windows.Forms.Label          label_new_boat;
        private System.Windows.Forms.ComboBox       combo_new_boat;
        private System.Windows.Forms.Label          label_boat_reason;
        private System.Windows.Forms.TextBox        txt_boat_reason;
        private System.Windows.Forms.Button         btn_replace_boat;
        private System.Windows.Forms.Button         btn_report_unavailable;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_back;
    }
}
