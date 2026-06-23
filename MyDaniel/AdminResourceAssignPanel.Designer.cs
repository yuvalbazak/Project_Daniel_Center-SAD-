namespace MyDaniel
{
    partial class AdminResourceAssignPanel
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
            this.label_section           = new System.Windows.Forms.Label();
            // RIGHT col — instructor
            this.label_instructor        = new System.Windows.Forms.Label();
            this.combo_instructor        = new System.Windows.Forms.ComboBox();
            // LEFT col — boat
            this.label_boat              = new System.Windows.Forms.Label();
            this.combo_boat              = new System.Windows.Forms.ComboBox();
            // Status row
            this.label_status_lbl        = new System.Windows.Forms.Label();
            this.combo_status            = new System.Windows.Forms.ComboBox();
            // Info
            this.label_current           = new System.Windows.Forms.Label();
            // Bottom
            this.label_error             = new System.Windows.Forms.Label();
            this.btn_assign              = new System.Windows.Forms.Button();
            this.btn_back                = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 22F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 10);
            this.label_title.Size      = new System.Drawing.Size(975, 40);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "שיוך משאבים לפעילות";
            //
            // Grid (Y=45, H=190)
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
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 190);
            this.dataGridView_activities.TabIndex                    = 1;
            //
            // label_section (Y=245)
            //
            this.label_section.AutoSize  = true;
            this.label_section.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.label_section.ForeColor = System.Drawing.Color.DimGray;
            this.label_section.Location  = new System.Drawing.Point(280, 245);
            this.label_section.Name      = "label_section";
            this.label_section.TabIndex  = 2;
            this.label_section.Text      = "שיוך משאבים לפעילות הנבחרת";
            //
            // RIGHT col (lbl X=720, ctrl X=490 W=220) — Y=278 Instructor
            //
            this.label_instructor.AutoSize = true;
            this.label_instructor.Font     = new System.Drawing.Font("David", 13F);
            this.label_instructor.Location = new System.Drawing.Point(720, 281);
            this.label_instructor.Name     = "label_instructor";
            this.label_instructor.TabIndex = 3;
            this.label_instructor.Text     = "מדריך";

            this.combo_instructor.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_instructor.Font              = new System.Drawing.Font("David", 10F);
            this.combo_instructor.FormattingEnabled = true;
            this.combo_instructor.Location          = new System.Drawing.Point(490, 278);
            this.combo_instructor.Name              = "combo_instructor";
            this.combo_instructor.Size              = new System.Drawing.Size(220, 25);
            this.combo_instructor.TabIndex          = 4;
            //
            // LEFT col (lbl X=375, ctrl X=120 W=245) — Y=278 Boat
            //
            this.label_boat.AutoSize = true;
            this.label_boat.Font     = new System.Drawing.Font("David", 13F);
            this.label_boat.Location = new System.Drawing.Point(375, 281);
            this.label_boat.Name     = "label_boat";
            this.label_boat.TabIndex = 5;
            this.label_boat.Text     = "סירה";

            this.combo_boat.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_boat.Font              = new System.Drawing.Font("David", 10F);
            this.combo_boat.FormattingEnabled = true;
            this.combo_boat.Location          = new System.Drawing.Point(120, 278);
            this.combo_boat.Name              = "combo_boat";
            this.combo_boat.Size              = new System.Drawing.Size(245, 25);
            this.combo_boat.TabIndex          = 6;
            //
            // Status row (Y=315) — right side
            //
            this.label_status_lbl.AutoSize = true;
            this.label_status_lbl.Font     = new System.Drawing.Font("David", 13F);
            this.label_status_lbl.Location = new System.Drawing.Point(720, 318);
            this.label_status_lbl.Name     = "label_status_lbl";
            this.label_status_lbl.TabIndex = 7;
            this.label_status_lbl.Text     = "עדכון סטטוס";

            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 10F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(490, 315);
            this.combo_status.Name              = "combo_status";
            this.combo_status.Size              = new System.Drawing.Size(220, 25);
            this.combo_status.TabIndex          = 8;
            //
            // label_current (Y=350 — full width info)
            //
            this.label_current.AutoSize  = false;
            this.label_current.Font      = new System.Drawing.Font("David", 11F);
            this.label_current.ForeColor = System.Drawing.Color.DimGray;
            this.label_current.Location  = new System.Drawing.Point(10, 350);
            this.label_current.Name      = "label_current";
            this.label_current.Size      = new System.Drawing.Size(975, 22);
            this.label_current.TabIndex  = 9;
            this.label_current.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // label_error (Y=382)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 382);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 10;
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // Buttons (Y=415)
            //
            this.btn_assign.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_assign.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_assign.Enabled   = false;
            this.btn_assign.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_assign.ForeColor = System.Drawing.Color.White;
            this.btn_assign.Location  = new System.Drawing.Point(365, 415);
            this.btn_assign.Name      = "btn_assign";
            this.btn_assign.Size      = new System.Drawing.Size(270, 42);
            this.btn_assign.TabIndex  = 11;
            this.btn_assign.Text      = "שייך משאבים לפעילות";
            this.btn_assign.UseVisualStyleBackColor = false;
            this.btn_assign.Click    += new System.EventHandler(this.btn_assign_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(800, 415);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(185, 42);
            this.btn_back.TabIndex  = 12;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // AdminResourceAssignPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_assign);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label_current);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_status_lbl);
            this.Controls.Add(this.combo_boat);
            this.Controls.Add(this.label_boat);
            this.Controls.Add(this.combo_instructor);
            this.Controls.Add(this.label_instructor);
            this.Controls.Add(this.label_section);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.label_title);
            this.Name = "AdminResourceAssignPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.DataGridView   dataGridView_activities;
        private System.Windows.Forms.Label          label_section;
        private System.Windows.Forms.Label          label_instructor;
        private System.Windows.Forms.ComboBox       combo_instructor;
        private System.Windows.Forms.Label          label_boat;
        private System.Windows.Forms.ComboBox       combo_boat;
        private System.Windows.Forms.Label          label_status_lbl;
        private System.Windows.Forms.ComboBox       combo_status;
        private System.Windows.Forms.Label          label_current;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_assign;
        private System.Windows.Forms.Button         btn_back;
    }
}
