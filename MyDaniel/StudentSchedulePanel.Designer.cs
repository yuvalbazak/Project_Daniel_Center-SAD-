namespace MyDaniel
{
    partial class StudentSchedulePanel
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
            // Navigation bar
            this.btn_monthly           = new System.Windows.Forms.Button();
            this.btn_weekly            = new System.Windows.Forms.Button();
            this.label_period          = new System.Windows.Forms.Label();
            this.btn_next              = new System.Windows.Forms.Button();
            this.btn_prev              = new System.Windows.Forms.Button();
            // Grid
            this.dataGridView_schedule = new System.Windows.Forms.DataGridView();
            // Footer
            this.label_note            = new System.Windows.Forms.Label();
            this.btn_back              = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).BeginInit();
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
            this.label_title.Text      = "לוח הפעילויות שלי";
            //
            // ── Navigation bar (Y=50) ─────────────────────────────────────────
            //
            // btn_monthly  (far right)
            //
            this.btn_monthly.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_monthly.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.btn_monthly.Location  = new System.Drawing.Point(845, 50);
            this.btn_monthly.Name      = "btn_monthly";
            this.btn_monthly.Size      = new System.Drawing.Size(120, 30);
            this.btn_monthly.TabIndex  = 1;
            this.btn_monthly.Text      = "תצוגה חודשית";
            this.btn_monthly.UseVisualStyleBackColor = false;
            this.btn_monthly.Click    += new System.EventHandler(this.btn_monthly_Click);
            //
            // btn_weekly  (right, next to monthly)
            //
            this.btn_weekly.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_weekly.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.btn_weekly.Location  = new System.Drawing.Point(715, 50);
            this.btn_weekly.Name      = "btn_weekly";
            this.btn_weekly.Size      = new System.Drawing.Size(120, 30);
            this.btn_weekly.TabIndex  = 2;
            this.btn_weekly.Text      = "תצוגה שבועית";
            this.btn_weekly.UseVisualStyleBackColor = false;
            this.btn_weekly.Click    += new System.EventHandler(this.btn_weekly_Click);
            //
            // label_period  (center)
            //
            this.label_period.AutoSize  = false;
            this.label_period.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_period.ForeColor = System.Drawing.Color.DimGray;
            this.label_period.Location  = new System.Drawing.Point(348, 53);
            this.label_period.Name      = "label_period";
            this.label_period.Size      = new System.Drawing.Size(355, 24);
            this.label_period.TabIndex  = 3;
            this.label_period.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btn_next  "הבא ►"  (moves forward in time)
            //
            this.btn_next.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_next.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.btn_next.Location  = new System.Drawing.Point(195, 50);
            this.btn_next.Name      = "btn_next";
            this.btn_next.Size      = new System.Drawing.Size(143, 30);
            this.btn_next.TabIndex  = 4;
            this.btn_next.Text      = "הבא ►";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click    += new System.EventHandler(this.btn_next_Click);
            //
            // btn_prev  "◄ הקודם"  (moves back in time)
            //
            this.btn_prev.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_prev.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.btn_prev.Location  = new System.Drawing.Point(37, 50);
            this.btn_prev.Name      = "btn_prev";
            this.btn_prev.Size      = new System.Drawing.Size(148, 30);
            this.btn_prev.TabIndex  = 5;
            this.btn_prev.Text      = "◄ הקודם";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click    += new System.EventHandler(this.btn_prev_Click);
            //
            // ── Grid (Y=90) ───────────────────────────────────────────────────
            //
            this.dataGridView_schedule.AllowUserToAddRows          = false;
            this.dataGridView_schedule.AllowUserToDeleteRows       = false;
            this.dataGridView_schedule.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_schedule.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_schedule.Location                    = new System.Drawing.Point(10, 90);
            this.dataGridView_schedule.MultiSelect                 = false;
            this.dataGridView_schedule.Name                        = "dataGridView_schedule";
            this.dataGridView_schedule.ReadOnly                    = true;
            this.dataGridView_schedule.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_schedule.RowHeadersWidth             = 40;
            this.dataGridView_schedule.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_schedule.Size                        = new System.Drawing.Size(1040, 408);
            this.dataGridView_schedule.TabIndex                    = 6;
            //
            // label_note
            //
            this.label_note.AutoSize  = false;
            this.label_note.Font      = new System.Drawing.Font("David", 11F);
            this.label_note.ForeColor = System.Drawing.Color.DimGray;
            this.label_note.Location  = new System.Drawing.Point(10, 506);
            this.label_note.Name      = "label_note";
            this.label_note.Size      = new System.Drawing.Size(1040, 24);
            this.label_note.TabIndex  = 7;
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(397, 548);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(205, 42);
            this.btn_back.TabIndex  = 8;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // StudentSchedulePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.dataGridView_schedule);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.label_period);
            this.Controls.Add(this.btn_weekly);
            this.Controls.Add(this.btn_monthly);
            this.Controls.Add(this.label_title);
            this.Name = "StudentSchedulePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.Button       btn_monthly;
        private System.Windows.Forms.Button       btn_weekly;
        private System.Windows.Forms.Label        label_period;
        private System.Windows.Forms.Button       btn_next;
        private System.Windows.Forms.Button       btn_prev;
        private System.Windows.Forms.DataGridView dataGridView_schedule;
        private System.Windows.Forms.Label        label_note;
        private System.Windows.Forms.Button       btn_back;
    }
}
