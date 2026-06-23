namespace MyDaniel
{
    partial class ActivityResourceUpdatePanel
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
            this.label_title             = new System.Windows.Forms.Label();
            this.dataGridView_activities = new System.Windows.Forms.DataGridView();
            // Section 1 — Activity update
            this.label_form_title        = new System.Windows.Forms.Label();
            this.label_act_type          = new System.Windows.Forms.Label();
            this.combo_act_type          = new System.Windows.Forms.ComboBox();
            this.label_age_group         = new System.Windows.Forms.Label();
            this.combo_age_group         = new System.Windows.Forms.ComboBox();
            this.label_instructor        = new System.Windows.Forms.Label();
            this.combo_instructor        = new System.Windows.Forms.ComboBox();
            this.label_location          = new System.Windows.Forms.Label();
            this.txt_location            = new System.Windows.Forms.TextBox();
            this.label_datetime          = new System.Windows.Forms.Label();
            this.dtp_act_datetime        = new System.Windows.Forms.DateTimePicker();
            this.label_assign_boat       = new System.Windows.Forms.Label();
            this.combo_assign_boat       = new System.Windows.Forms.ComboBox();
            this.btn_update_activity     = new System.Windows.Forms.Button();
            // Section 2 — Boat status
            this.label_boat_section      = new System.Windows.Forms.Label();
            this.label_boat_lbl          = new System.Windows.Forms.Label();
            this.combo_boat              = new System.Windows.Forms.ComboBox();
            this.label_boat_status_lbl   = new System.Windows.Forms.Label();
            this.combo_boat_new_status   = new System.Windows.Forms.ComboBox();
            this.btn_update_boat         = new System.Windows.Forms.Button();
            // Shared
            this.label_error             = new System.Windows.Forms.Label();
            this.btn_back                = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 26F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "עדכון משאבי פעילות";
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
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 150);
            this.dataGridView_activities.TabIndex                    = 1;
            this.dataGridView_activities.SelectionChanged           += new System.EventHandler(this.onActivitySelected);
            //
            // ── Section 1: Activity update form (Y=215–370) ──────────────────────
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(295, 215);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "עריכת פרטי פעילות — לחץ על פעילות מהרשימה";
            //
            // ── Row 1 (Y=240): RIGHT=סוג פעילות  LEFT=מיקום ─────────────────────
            //
            // label_act_type
            //
            this.label_act_type.AutoSize = true;
            this.label_act_type.Font     = new System.Drawing.Font("David", 13F);
            this.label_act_type.Location = new System.Drawing.Point(720, 240);
            this.label_act_type.Name     = "label_act_type";
            this.label_act_type.TabIndex = 3;
            this.label_act_type.Text     = "סוג פעילות";
            //
            // combo_act_type
            //
            this.combo_act_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.combo_act_type.Font              = new System.Drawing.Font("David", 11F);
            this.combo_act_type.FormattingEnabled = true;
            this.combo_act_type.Location          = new System.Drawing.Point(490, 237);
            this.combo_act_type.Name              = "combo_act_type";
            this.combo_act_type.Size              = new System.Drawing.Size(220, 26);
            this.combo_act_type.TabIndex          = 4;
            this.combo_act_type.Enabled           = false;
            //
            // label_location
            //
            this.label_location.AutoSize = true;
            this.label_location.Font     = new System.Drawing.Font("David", 13F);
            this.label_location.Location = new System.Drawing.Point(375, 240);
            this.label_location.Name     = "label_location";
            this.label_location.TabIndex = 5;
            this.label_location.Text     = "מיקום";
            //
            // txt_location
            //
            this.txt_location.Font     = new System.Drawing.Font("David", 12F);
            this.txt_location.Location = new System.Drawing.Point(120, 237);
            this.txt_location.Name     = "txt_location";
            this.txt_location.Size     = new System.Drawing.Size(240, 27);
            this.txt_location.TabIndex = 6;
            this.txt_location.Enabled  = false;
            //
            // ── Row 2 (Y=277): RIGHT=קבוצת גיל  LEFT=תאריך ושעה ─────────────────
            //
            // label_age_group
            //
            this.label_age_group.AutoSize = true;
            this.label_age_group.Font     = new System.Drawing.Font("David", 13F);
            this.label_age_group.Location = new System.Drawing.Point(720, 277);
            this.label_age_group.Name     = "label_age_group";
            this.label_age_group.TabIndex = 7;
            this.label_age_group.Text     = "קבוצת גיל";
            //
            // combo_age_group
            //
            this.combo_age_group.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_age_group.Font              = new System.Drawing.Font("David", 11F);
            this.combo_age_group.FormattingEnabled = true;
            this.combo_age_group.Location          = new System.Drawing.Point(490, 274);
            this.combo_age_group.Name              = "combo_age_group";
            this.combo_age_group.Size              = new System.Drawing.Size(220, 26);
            this.combo_age_group.TabIndex          = 8;
            this.combo_age_group.Enabled           = false;
            //
            // label_datetime
            //
            this.label_datetime.AutoSize = true;
            this.label_datetime.Font     = new System.Drawing.Font("David", 13F);
            this.label_datetime.Location = new System.Drawing.Point(375, 277);
            this.label_datetime.Name     = "label_datetime";
            this.label_datetime.TabIndex = 9;
            this.label_datetime.Text     = "תאריך ושעה";
            //
            // dtp_act_datetime
            //
            this.dtp_act_datetime.Font         = new System.Drawing.Font("David", 11F);
            this.dtp_act_datetime.Format       = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_act_datetime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtp_act_datetime.ShowUpDown   = true;
            this.dtp_act_datetime.Location     = new System.Drawing.Point(120, 274);
            this.dtp_act_datetime.Name         = "dtp_act_datetime";
            this.dtp_act_datetime.Size         = new System.Drawing.Size(240, 26);
            this.dtp_act_datetime.TabIndex     = 10;
            this.dtp_act_datetime.Enabled      = false;
            //
            // ── Row 3 (Y=314): RIGHT=מדריך  LEFT=סירה לפעילות ────────────────────
            //
            // label_instructor
            //
            this.label_instructor.AutoSize = true;
            this.label_instructor.Font     = new System.Drawing.Font("David", 13F);
            this.label_instructor.Location = new System.Drawing.Point(720, 317);
            this.label_instructor.Name     = "label_instructor";
            this.label_instructor.TabIndex = 11;
            this.label_instructor.Text     = "מדריך";
            //
            // combo_instructor
            //
            this.combo_instructor.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_instructor.Font              = new System.Drawing.Font("David", 11F);
            this.combo_instructor.FormattingEnabled = true;
            this.combo_instructor.Location          = new System.Drawing.Point(490, 314);
            this.combo_instructor.Name              = "combo_instructor";
            this.combo_instructor.Size              = new System.Drawing.Size(220, 26);
            this.combo_instructor.TabIndex          = 12;
            this.combo_instructor.Enabled           = false;
            //
            // label_assign_boat
            //
            this.label_assign_boat.AutoSize = true;
            this.label_assign_boat.Font     = new System.Drawing.Font("David", 13F);
            this.label_assign_boat.Location = new System.Drawing.Point(375, 317);
            this.label_assign_boat.Name     = "label_assign_boat";
            this.label_assign_boat.TabIndex = 13;
            this.label_assign_boat.Text     = "סירה לפעילות";
            //
            // combo_assign_boat
            //
            this.combo_assign_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_assign_boat.Font              = new System.Drawing.Font("David", 11F);
            this.combo_assign_boat.FormattingEnabled = true;
            this.combo_assign_boat.Location          = new System.Drawing.Point(120, 314);
            this.combo_assign_boat.Name              = "combo_assign_boat";
            this.combo_assign_boat.Size              = new System.Drawing.Size(240, 26);
            this.combo_assign_boat.TabIndex          = 14;
            this.combo_assign_boat.Enabled           = false;
            //
            // btn_update_activity (moved to Y=355)
            //
            this.btn_update_activity.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update_activity.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update_activity.Enabled   = false;
            this.btn_update_activity.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_update_activity.ForeColor = System.Drawing.Color.White;
            this.btn_update_activity.Location  = new System.Drawing.Point(380, 355);
            this.btn_update_activity.Name      = "btn_update_activity";
            this.btn_update_activity.Size      = new System.Drawing.Size(210, 36);
            this.btn_update_activity.TabIndex  = 15;
            this.btn_update_activity.Text      = "עדכן פרטי פעילות";
            this.btn_update_activity.UseVisualStyleBackColor = false;
            this.btn_update_activity.Click    += new System.EventHandler(this.btn_update_activity_Click);
            //
            // ── Section 2: Boat status update (Y=402–440) ────────────────────────
            //
            // label_boat_section
            //
            this.label_boat_section.AutoSize  = true;
            this.label_boat_section.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_boat_section.ForeColor = System.Drawing.Color.DimGray;
            this.label_boat_section.Location  = new System.Drawing.Point(20, 402);
            this.label_boat_section.Name      = "label_boat_section";
            this.label_boat_section.TabIndex  = 16;
            this.label_boat_section.Text      = "עדכון סטטוס סירה | דיווח אי-זמינות";
            //
            // label_boat_lbl
            //
            this.label_boat_lbl.AutoSize = true;
            this.label_boat_lbl.Font     = new System.Drawing.Font("David", 13F);
            this.label_boat_lbl.Location = new System.Drawing.Point(785, 430);
            this.label_boat_lbl.Name     = "label_boat_lbl";
            this.label_boat_lbl.TabIndex = 17;
            this.label_boat_lbl.Text     = "סירה";
            //
            // combo_boat
            //
            this.combo_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_boat.Font              = new System.Drawing.Font("David", 11F);
            this.combo_boat.FormattingEnabled = true;
            this.combo_boat.Location          = new System.Drawing.Point(540, 427);
            this.combo_boat.Name              = "combo_boat";
            this.combo_boat.Size              = new System.Drawing.Size(235, 26);
            this.combo_boat.TabIndex          = 18;
            //
            // label_boat_status_lbl
            //
            this.label_boat_status_lbl.AutoSize = true;
            this.label_boat_status_lbl.Font     = new System.Drawing.Font("David", 13F);
            this.label_boat_status_lbl.Location = new System.Drawing.Point(450, 430);
            this.label_boat_status_lbl.Name     = "label_boat_status_lbl";
            this.label_boat_status_lbl.TabIndex = 19;
            this.label_boat_status_lbl.Text     = "סטטוס חדש";
            //
            // combo_boat_new_status
            //
            this.combo_boat_new_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_boat_new_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_boat_new_status.FormattingEnabled = true;
            this.combo_boat_new_status.Location          = new System.Drawing.Point(215, 427);
            this.combo_boat_new_status.Name              = "combo_boat_new_status";
            this.combo_boat_new_status.Size              = new System.Drawing.Size(225, 26);
            this.combo_boat_new_status.TabIndex          = 20;
            //
            // btn_update_boat
            //
            this.btn_update_boat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_update_boat.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update_boat.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_update_boat.ForeColor = System.Drawing.Color.White;
            this.btn_update_boat.Location  = new System.Drawing.Point(20, 425);
            this.btn_update_boat.Name      = "btn_update_boat";
            this.btn_update_boat.Size      = new System.Drawing.Size(185, 30);
            this.btn_update_boat.TabIndex  = 21;
            this.btn_update_boat.Text      = "עדכן סטטוס סירה";
            this.btn_update_boat.UseVisualStyleBackColor = false;
            this.btn_update_boat.Click    += new System.EventHandler(this.btn_update_boat_Click);
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 468);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 500);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 31;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // ActivityResourceUpdatePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_update_boat);
            this.Controls.Add(this.combo_boat_new_status);
            this.Controls.Add(this.label_boat_status_lbl);
            this.Controls.Add(this.combo_boat);
            this.Controls.Add(this.label_boat_lbl);
            this.Controls.Add(this.label_boat_section);
            this.Controls.Add(this.btn_update_activity);
            this.Controls.Add(this.combo_assign_boat);
            this.Controls.Add(this.label_assign_boat);
            this.Controls.Add(this.combo_instructor);
            this.Controls.Add(this.label_instructor);
            this.Controls.Add(this.dtp_act_datetime);
            this.Controls.Add(this.label_datetime);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.label_location);
            this.Controls.Add(this.combo_age_group);
            this.Controls.Add(this.label_age_group);
            this.Controls.Add(this.combo_act_type);
            this.Controls.Add(this.label_act_type);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.label_title);
            this.Name = "ActivityResourceUpdatePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label            label_title;
        private System.Windows.Forms.DataGridView     dataGridView_activities;
        private System.Windows.Forms.Label            label_form_title;
        private System.Windows.Forms.Label            label_act_type;
        private System.Windows.Forms.ComboBox         combo_act_type;
        private System.Windows.Forms.Label            label_age_group;
        private System.Windows.Forms.ComboBox         combo_age_group;
        private System.Windows.Forms.Label            label_instructor;
        private System.Windows.Forms.ComboBox         combo_instructor;
        private System.Windows.Forms.Label            label_location;
        private System.Windows.Forms.TextBox          txt_location;
        private System.Windows.Forms.Label            label_datetime;
        private System.Windows.Forms.DateTimePicker   dtp_act_datetime;
        private System.Windows.Forms.Label            label_assign_boat;
        private System.Windows.Forms.ComboBox         combo_assign_boat;
        private System.Windows.Forms.Button           btn_update_activity;
        private System.Windows.Forms.Label            label_boat_section;
        private System.Windows.Forms.Label            label_boat_lbl;
        private System.Windows.Forms.ComboBox         combo_boat;
        private System.Windows.Forms.Label            label_boat_status_lbl;
        private System.Windows.Forms.ComboBox         combo_boat_new_status;
        private System.Windows.Forms.Button           btn_update_boat;
        private System.Windows.Forms.Label            label_error;
        private System.Windows.Forms.Button           btn_back;
    }
}
