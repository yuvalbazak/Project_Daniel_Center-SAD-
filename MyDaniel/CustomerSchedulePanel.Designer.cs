namespace MyDaniel
{
    partial class CustomerSchedulePanel
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
            this.label_note            = new System.Windows.Forms.Label();
            this.dataGridView_schedule = new System.Windows.Forms.DataGridView();
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
            // label_note
            //
            this.label_note.AutoSize  = true;
            this.label_note.Font      = new System.Drawing.Font("David", 11F);
            this.label_note.ForeColor = System.Drawing.Color.DimGray;
            this.label_note.Location  = new System.Drawing.Point(10, 57);
            this.label_note.Name      = "label_note";
            this.label_note.TabIndex  = 1;
            this.label_note.Text      = "הפעילויות שאתה רשום אליהן";
            //
            // dataGridView_schedule
            //
            this.dataGridView_schedule.AllowUserToAddRows          = false;
            this.dataGridView_schedule.AllowUserToDeleteRows       = false;
            this.dataGridView_schedule.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_schedule.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_schedule.Location                    = new System.Drawing.Point(10, 82);
            this.dataGridView_schedule.MultiSelect                 = false;
            this.dataGridView_schedule.Name                        = "dataGridView_schedule";
            this.dataGridView_schedule.ReadOnly                    = true;
            this.dataGridView_schedule.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_schedule.RowHeadersWidth             = 40;
            this.dataGridView_schedule.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_schedule.Size                        = new System.Drawing.Size(1040, 458);
            this.dataGridView_schedule.TabIndex                    = 2;
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(420, 552);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(165, 40);
            this.btn_back.TabIndex  = 3;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // CustomerSchedulePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.dataGridView_schedule);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.label_title);
            this.Name = "CustomerSchedulePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.Label        label_note;
        private System.Windows.Forms.DataGridView dataGridView_schedule;
        private System.Windows.Forms.Button       btn_back;
    }
}
