namespace MyDaniel
{
    partial class MyActivitiesPanel
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
            this.label_note               = new System.Windows.Forms.Label();
            this.dataGridView_activities  = new System.Windows.Forms.DataGridView();
            this.label_detail_header      = new System.Windows.Forms.Label();
            this.label_detail_info        = new System.Windows.Forms.Label();
            this.dataGridView_participants = new System.Windows.Forms.DataGridView();
            this.btn_back                 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_participants)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "הפעילויות שלי";
            //
            // label_note
            //
            this.label_note.AutoSize  = true;
            this.label_note.Font      = new System.Drawing.Font("David", 11F);
            this.label_note.ForeColor = System.Drawing.Color.DimGray;
            this.label_note.Location  = new System.Drawing.Point(10, 60);
            this.label_note.Name      = "label_note";
            this.label_note.TabIndex  = 1;
            this.label_note.Text      = "הפעילויות שלך — לחץ על שורה לצפיה בפרטים ומשתתפים";
            //
            // dataGridView_activities  (upper half)
            //
            this.dataGridView_activities.AllowUserToAddRows          = false;
            this.dataGridView_activities.AllowUserToDeleteRows       = false;
            this.dataGridView_activities.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_activities.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_activities.Location                    = new System.Drawing.Point(10, 85);
            this.dataGridView_activities.MultiSelect                 = false;
            this.dataGridView_activities.Name                        = "dataGridView_activities";
            this.dataGridView_activities.ReadOnly                    = true;
            this.dataGridView_activities.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_activities.RowHeadersWidth             = 40;
            this.dataGridView_activities.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 195);
            this.dataGridView_activities.TabIndex                    = 2;
            //
            // label_detail_header
            //
            this.label_detail_header.AutoSize  = true;
            this.label_detail_header.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_detail_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_detail_header.Location  = new System.Drawing.Point(10, 290);
            this.label_detail_header.Name      = "label_detail_header";
            this.label_detail_header.TabIndex  = 3;
            this.label_detail_header.Text      = "פרטי הפעילות הנבחרת:";
            this.label_detail_header.Visible   = false;
            //
            // label_detail_info
            //
            this.label_detail_info.AutoSize  = false;
            this.label_detail_info.Font      = new System.Drawing.Font("David", 10F);
            this.label_detail_info.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_detail_info.Location  = new System.Drawing.Point(10, 315);
            this.label_detail_info.Name      = "label_detail_info";
            this.label_detail_info.Size      = new System.Drawing.Size(1040, 40);
            this.label_detail_info.TabIndex  = 4;
            this.label_detail_info.Text      = "";
            this.label_detail_info.Visible   = false;
            //
            // dataGridView_participants  (lower half — participants + boats)
            //
            this.dataGridView_participants.AllowUserToAddRows          = false;
            this.dataGridView_participants.AllowUserToDeleteRows       = false;
            this.dataGridView_participants.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_participants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_participants.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_participants.Location                    = new System.Drawing.Point(10, 360);
            this.dataGridView_participants.MultiSelect                 = false;
            this.dataGridView_participants.Name                        = "dataGridView_participants";
            this.dataGridView_participants.ReadOnly                    = true;
            this.dataGridView_participants.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_participants.RowHeadersWidth             = 40;
            this.dataGridView_participants.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_participants.Size                        = new System.Drawing.Size(1040, 195);
            this.dataGridView_participants.TabIndex                    = 5;
            this.dataGridView_participants.Visible                     = false;
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(420, 568);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(165, 38);
            this.btn_back.TabIndex  = 6;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // MyActivitiesPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.dataGridView_participants);
            this.Controls.Add(this.label_detail_info);
            this.Controls.Add(this.label_detail_header);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.label_title);
            this.Name = "MyActivitiesPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_participants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.Label        label_note;
        private System.Windows.Forms.DataGridView dataGridView_activities;
        private System.Windows.Forms.Label        label_detail_header;
        private System.Windows.Forms.Label        label_detail_info;
        private System.Windows.Forms.DataGridView dataGridView_participants;
        private System.Windows.Forms.Button       btn_back;
    }
}
