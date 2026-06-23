namespace MyDaniel
{
    partial class ManageActivitiesPanel
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
            this.label_title           = new System.Windows.Forms.Label();
            this.dataGridView_activities = new System.Windows.Forms.DataGridView();
            this.label_form_header     = new System.Windows.Forms.Label();
            // RIGHT column controls
            this.label_id_lbl          = new System.Windows.Forms.Label();
            this.txt_id                = new System.Windows.Forms.TextBox();
            this.label_type_lbl        = new System.Windows.Forms.Label();
            this.combo_type            = new System.Windows.Forms.ComboBox();
            this.label_instructor_lbl  = new System.Windows.Forms.Label();
            this.combo_instructor      = new System.Windows.Forms.ComboBox();
            this.label_status_lbl      = new System.Windows.Forms.Label();
            this.combo_status          = new System.Windows.Forms.ComboBox();
            this.label_max_lbl         = new System.Windows.Forms.Label();
            this.txt_max               = new System.Windows.Forms.TextBox();
            // LEFT column controls
            this.label_dt_lbl          = new System.Windows.Forms.Label();
            this.dtp_datetime          = new System.Windows.Forms.DateTimePicker();
            this.label_location_lbl    = new System.Windows.Forms.Label();
            this.txt_location          = new System.Windows.Forms.TextBox();
            this.label_agegroup_lbl    = new System.Windows.Forms.Label();
            this.combo_age_group       = new System.Windows.Forms.ComboBox();
            this.label_roster_count    = new System.Windows.Forms.Label();
            // Cancel reason row
            this.label_cancel_lbl      = new System.Windows.Forms.Label();
            this.txt_cancel_reason     = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error           = new System.Windows.Forms.Label();
            this.btn_new               = new System.Windows.Forms.Button();
            this.btn_save              = new System.Windows.Forms.Button();
            this.btn_update            = new System.Windows.Forms.Button();
            this.btn_delete            = new System.Windows.Forms.Button();
            this.btn_roster            = new System.Windows.Forms.Button();
            this.btn_cancel_activity   = new System.Windows.Forms.Button();
            this.btn_back              = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 26F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(1040, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "ניהול פעילויות";
            //
            // dataGridView_activities
            //
            this.dataGridView_activities.AllowUserToAddRows          = false;
            this.dataGridView_activities.AllowUserToDeleteRows       = false;
            this.dataGridView_activities.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_activities.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_activities.Location                    = new System.Drawing.Point(10, 55);
            this.dataGridView_activities.MultiSelect                 = false;
            this.dataGridView_activities.Name                        = "dataGridView_activities";
            this.dataGridView_activities.ReadOnly                    = true;
            this.dataGridView_activities.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_activities.RowHeadersWidth             = 40;
            this.dataGridView_activities.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 180);
            this.dataGridView_activities.TabIndex                    = 1;
            //
            // label_form_header
            //
            this.label_form_header.AutoSize  = true;
            this.label_form_header.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_form_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_header.Location  = new System.Drawing.Point(10, 220);
            this.label_form_header.Name      = "label_form_header";
            this.label_form_header.TabIndex  = 2;
            this.label_form_header.Text      = "פרטי הפעילות:";
            //
            // RIGHT column  (labels at X=740, controls at X=490 W=235)
            //
            this.label_id_lbl.AutoSize  = true;
            this.label_id_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_id_lbl.Location  = new System.Drawing.Point(740, 248);
            this.label_id_lbl.Name      = "label_id_lbl";
            this.label_id_lbl.TabIndex  = 10;
            this.label_id_lbl.Text      = "מספר פעילות:";

            this.txt_id.Font      = new System.Drawing.Font("David", 11F);
            this.txt_id.Location  = new System.Drawing.Point(490, 245);
            this.txt_id.Name      = "txt_id";
            this.txt_id.ReadOnly  = true;
            this.txt_id.Size      = new System.Drawing.Size(235, 24);
            this.txt_id.TabIndex  = 11;
            this.txt_id.BackColor = System.Drawing.SystemColors.Control;

            this.label_type_lbl.AutoSize  = true;
            this.label_type_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_type_lbl.Location  = new System.Drawing.Point(740, 288);
            this.label_type_lbl.Name      = "label_type_lbl";
            this.label_type_lbl.TabIndex  = 12;
            this.label_type_lbl.Text      = "סוג פעילות:";

            this.combo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_type.Font          = new System.Drawing.Font("David", 11F);
            this.combo_type.Location      = new System.Drawing.Point(490, 285);
            this.combo_type.Name          = "combo_type";
            this.combo_type.Size          = new System.Drawing.Size(235, 26);
            this.combo_type.TabIndex      = 13;

            this.label_instructor_lbl.AutoSize  = true;
            this.label_instructor_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_instructor_lbl.Location  = new System.Drawing.Point(740, 328);
            this.label_instructor_lbl.Name      = "label_instructor_lbl";
            this.label_instructor_lbl.TabIndex  = 14;
            this.label_instructor_lbl.Text      = "מדריך:";

            this.combo_instructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_instructor.Font          = new System.Drawing.Font("David", 11F);
            this.combo_instructor.Location      = new System.Drawing.Point(490, 325);
            this.combo_instructor.Name          = "combo_instructor";
            this.combo_instructor.Size          = new System.Drawing.Size(235, 26);
            this.combo_instructor.TabIndex      = 15;

            this.label_status_lbl.AutoSize  = true;
            this.label_status_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_status_lbl.Location  = new System.Drawing.Point(740, 368);
            this.label_status_lbl.Name      = "label_status_lbl";
            this.label_status_lbl.TabIndex  = 16;
            this.label_status_lbl.Text      = "סטטוס:";

            this.combo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font          = new System.Drawing.Font("David", 11F);
            this.combo_status.Location      = new System.Drawing.Point(490, 365);
            this.combo_status.Name          = "combo_status";
            this.combo_status.Size          = new System.Drawing.Size(235, 26);
            this.combo_status.TabIndex      = 17;

            this.label_max_lbl.AutoSize  = true;
            this.label_max_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_max_lbl.Location  = new System.Drawing.Point(740, 408);
            this.label_max_lbl.Name      = "label_max_lbl";
            this.label_max_lbl.TabIndex  = 18;
            this.label_max_lbl.Text      = "מקס. משתתפים:";

            this.txt_max.Font     = new System.Drawing.Font("David", 11F);
            this.txt_max.Location = new System.Drawing.Point(610, 405);
            this.txt_max.Name     = "txt_max";
            this.txt_max.Size     = new System.Drawing.Size(115, 24);
            this.txt_max.TabIndex = 19;
            this.txt_max.Text     = "10";
            //
            // LEFT column  (labels at X=385, controls at X=130 W=245)
            //
            this.label_dt_lbl.AutoSize  = true;
            this.label_dt_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_dt_lbl.Location  = new System.Drawing.Point(385, 248);
            this.label_dt_lbl.Name      = "label_dt_lbl";
            this.label_dt_lbl.TabIndex  = 20;
            this.label_dt_lbl.Text      = "תאריך ושעה:";

            this.dtp_datetime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_datetime.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_datetime.Font         = new System.Drawing.Font("David", 11F);
            this.dtp_datetime.Location     = new System.Drawing.Point(130, 245);
            this.dtp_datetime.Name         = "dtp_datetime";
            this.dtp_datetime.ShowUpDown   = true;
            this.dtp_datetime.Size         = new System.Drawing.Size(245, 24);
            this.dtp_datetime.TabIndex     = 21;

            this.label_location_lbl.AutoSize  = true;
            this.label_location_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_location_lbl.Location  = new System.Drawing.Point(385, 288);
            this.label_location_lbl.Name      = "label_location_lbl";
            this.label_location_lbl.TabIndex  = 22;
            this.label_location_lbl.Text      = "מיקום:";

            this.txt_location.Font     = new System.Drawing.Font("David", 11F);
            this.txt_location.Location = new System.Drawing.Point(130, 285);
            this.txt_location.Name     = "txt_location";
            this.txt_location.Size     = new System.Drawing.Size(245, 24);
            this.txt_location.TabIndex = 23;

            this.label_agegroup_lbl.AutoSize  = true;
            this.label_agegroup_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_agegroup_lbl.Location  = new System.Drawing.Point(385, 328);
            this.label_agegroup_lbl.Name      = "label_agegroup_lbl";
            this.label_agegroup_lbl.TabIndex  = 24;
            this.label_agegroup_lbl.Text      = "קבוצת גיל:";

            this.combo_age_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_age_group.Font          = new System.Drawing.Font("David", 11F);
            this.combo_age_group.Location      = new System.Drawing.Point(130, 325);
            this.combo_age_group.Name          = "combo_age_group";
            this.combo_age_group.Size          = new System.Drawing.Size(245, 26);
            this.combo_age_group.TabIndex      = 25;

            // label_roster_count — moved up to Y=368 (boat row removed)
            this.label_roster_count.AutoSize  = true;
            this.label_roster_count.Font      = new System.Drawing.Font("David", 11F);
            this.label_roster_count.ForeColor = System.Drawing.Color.DimGray;
            this.label_roster_count.Location  = new System.Drawing.Point(130, 368);
            this.label_roster_count.Name      = "label_roster_count";
            this.label_roster_count.TabIndex  = 26;
            this.label_roster_count.Text      = "רשומים: 0";
            //
            // Cancel reason row (hidden by default)
            //
            this.label_cancel_lbl.AutoSize  = true;
            this.label_cancel_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_cancel_lbl.Location  = new System.Drawing.Point(875, 444);
            this.label_cancel_lbl.Name      = "label_cancel_lbl";
            this.label_cancel_lbl.TabIndex  = 30;
            this.label_cancel_lbl.Text      = "סיבת ביטול:";
            this.label_cancel_lbl.Visible   = false;

            this.txt_cancel_reason.Font      = new System.Drawing.Font("David", 11F);
            this.txt_cancel_reason.Location  = new System.Drawing.Point(100, 441);
            this.txt_cancel_reason.Name      = "txt_cancel_reason";
            this.txt_cancel_reason.Size      = new System.Drawing.Size(765, 24);
            this.txt_cancel_reason.TabIndex  = 31;
            this.txt_cancel_reason.Visible   = false;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 475);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 40;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_error.Visible   = false;
            //
            // Buttons at Y=505
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 505);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(150, 40);
            this.btn_new.TabIndex  = 50;
            this.btn_new.Text      = "פעילות חדשה";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(180, 505);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(150, 40);
            this.btn_save.TabIndex  = 51;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);

            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(180, 505);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(150, 40);
            this.btn_update.TabIndex  = 52;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);

            this.btn_delete.BackColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location  = new System.Drawing.Point(340, 505);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(150, 40);
            this.btn_delete.TabIndex  = 53;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);

            this.btn_roster.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_roster.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_roster.Enabled   = false;
            this.btn_roster.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_roster.ForeColor = System.Drawing.Color.White;
            this.btn_roster.Location  = new System.Drawing.Point(500, 505);
            this.btn_roster.Name      = "btn_roster";
            this.btn_roster.Size      = new System.Drawing.Size(200, 40);
            this.btn_roster.TabIndex  = 54;
            this.btn_roster.Text      = "ניהול משתתפים וסירות";
            this.btn_roster.UseVisualStyleBackColor = false;
            this.btn_roster.Click    += new System.EventHandler(this.btn_roster_Click);

            this.btn_cancel_activity.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_cancel_activity.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel_activity.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel_activity.ForeColor = System.Drawing.Color.White;
            this.btn_cancel_activity.Location  = new System.Drawing.Point(710, 505);
            this.btn_cancel_activity.Name      = "btn_cancel_activity";
            this.btn_cancel_activity.Size      = new System.Drawing.Size(100, 40);
            this.btn_cancel_activity.TabIndex  = 55;
            this.btn_cancel_activity.Text      = "ביטול פעילות";
            this.btn_cancel_activity.UseVisualStyleBackColor = false;
            this.btn_cancel_activity.Visible   = false;
            this.btn_cancel_activity.Click    += new System.EventHandler(this.btn_cancel_activity_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(895, 555);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 40);
            this.btn_back.TabIndex  = 56;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // ManageActivitiesPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = ThemeHelper.BG_CONTENT;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.label_form_header);
            this.Controls.Add(this.label_id_lbl);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_type_lbl);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.label_instructor_lbl);
            this.Controls.Add(this.combo_instructor);
            this.Controls.Add(this.label_status_lbl);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_max_lbl);
            this.Controls.Add(this.txt_max);
            this.Controls.Add(this.label_dt_lbl);
            this.Controls.Add(this.dtp_datetime);
            this.Controls.Add(this.label_location_lbl);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.label_agegroup_lbl);
            this.Controls.Add(this.combo_age_group);
            this.Controls.Add(this.label_roster_count);
            this.Controls.Add(this.label_cancel_lbl);
            this.Controls.Add(this.txt_cancel_reason);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_roster);
            this.Controls.Add(this.btn_cancel_activity);
            this.Controls.Add(this.btn_back);
            this.Name = "ManageActivitiesPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           label_title;
        private System.Windows.Forms.DataGridView    dataGridView_activities;
        private System.Windows.Forms.Label           label_form_header;
        private System.Windows.Forms.Label           label_id_lbl;
        private System.Windows.Forms.TextBox         txt_id;
        private System.Windows.Forms.Label           label_type_lbl;
        private System.Windows.Forms.ComboBox        combo_type;
        private System.Windows.Forms.Label           label_instructor_lbl;
        private System.Windows.Forms.ComboBox        combo_instructor;
        private System.Windows.Forms.Label           label_status_lbl;
        private System.Windows.Forms.ComboBox        combo_status;
        private System.Windows.Forms.Label           label_max_lbl;
        private System.Windows.Forms.TextBox         txt_max;
        private System.Windows.Forms.Label           label_dt_lbl;
        private System.Windows.Forms.DateTimePicker  dtp_datetime;
        private System.Windows.Forms.Label           label_location_lbl;
        private System.Windows.Forms.TextBox         txt_location;
        private System.Windows.Forms.Label           label_agegroup_lbl;
        private System.Windows.Forms.ComboBox        combo_age_group;
        private System.Windows.Forms.Label           label_roster_count;
        private System.Windows.Forms.Label           label_cancel_lbl;
        private System.Windows.Forms.TextBox         txt_cancel_reason;
        private System.Windows.Forms.Label           label_error;
        private System.Windows.Forms.Button          btn_new;
        private System.Windows.Forms.Button          btn_save;
        private System.Windows.Forms.Button          btn_update;
        private System.Windows.Forms.Button          btn_delete;
        private System.Windows.Forms.Button          btn_roster;
        private System.Windows.Forms.Button          btn_cancel_activity;
        private System.Windows.Forms.Button          btn_back;
    }
}
