namespace MyDaniel
{
    partial class AdminActivitiesPanel
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
            this.label_title            = new System.Windows.Forms.Label();
            // Filter bar
            this.label_search           = new System.Windows.Forms.Label();
            this.txt_search             = new System.Windows.Forms.TextBox();
            this.label_filter_type      = new System.Windows.Forms.Label();
            this.combo_filter_type      = new System.Windows.Forms.ComboBox();
            this.label_filter_status    = new System.Windows.Forms.Label();
            this.combo_filter_status    = new System.Windows.Forms.ComboBox();
            this.btn_reset_filter       = new System.Windows.Forms.Button();
            // Grid
            this.dataGridView_activities = new System.Windows.Forms.DataGridView();
            // Bottom
            this.label_count            = new System.Windows.Forms.Label();
            this.btn_back               = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 24F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 10);
            this.label_title.Size      = new System.Drawing.Size(975, 44);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name      = "label_title";
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "כל הפעילויות";
            //
            // Filter bar (Y=48)
            //
            this.label_search.AutoSize = true;
            this.label_search.Font     = new System.Drawing.Font("David", 11F);
            this.label_search.Location = new System.Drawing.Point(860, 52);
            this.label_search.Name     = "label_search";
            this.label_search.TabIndex = 1;
            this.label_search.Text     = "חיפוש:";

            this.txt_search.Font     = new System.Drawing.Font("David", 11F);
            this.txt_search.Location = new System.Drawing.Point(640, 49);
            this.txt_search.Name     = "txt_search";
            this.txt_search.Size     = new System.Drawing.Size(210, 26);
            this.txt_search.TabIndex = 2;

            this.label_filter_type.AutoSize = true;
            this.label_filter_type.Font     = new System.Drawing.Font("David", 11F);
            this.label_filter_type.Location = new System.Drawing.Point(578, 52);
            this.label_filter_type.Name     = "label_filter_type";
            this.label_filter_type.TabIndex = 3;
            this.label_filter_type.Text     = "סוג:";

            this.combo_filter_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_filter_type.Font              = new System.Drawing.Font("David", 10F);
            this.combo_filter_type.FormattingEnabled = true;
            this.combo_filter_type.Location          = new System.Drawing.Point(375, 49);
            this.combo_filter_type.Name              = "combo_filter_type";
            this.combo_filter_type.Size              = new System.Drawing.Size(195, 25);
            this.combo_filter_type.TabIndex          = 4;

            this.label_filter_status.AutoSize = true;
            this.label_filter_status.Font     = new System.Drawing.Font("David", 11F);
            this.label_filter_status.Location = new System.Drawing.Point(318, 52);
            this.label_filter_status.Name     = "label_filter_status";
            this.label_filter_status.TabIndex = 5;
            this.label_filter_status.Text     = "סטטוס:";

            this.combo_filter_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_filter_status.Font              = new System.Drawing.Font("David", 10F);
            this.combo_filter_status.FormattingEnabled = true;
            this.combo_filter_status.Location          = new System.Drawing.Point(145, 49);
            this.combo_filter_status.Name              = "combo_filter_status";
            this.combo_filter_status.Size              = new System.Drawing.Size(165, 25);
            this.combo_filter_status.TabIndex          = 6;

            this.btn_reset_filter.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_reset_filter.Font      = new System.Drawing.Font("David", 10F);
            this.btn_reset_filter.Location  = new System.Drawing.Point(10, 47);
            this.btn_reset_filter.Name      = "btn_reset_filter";
            this.btn_reset_filter.Size      = new System.Drawing.Size(125, 28);
            this.btn_reset_filter.TabIndex  = 7;
            this.btn_reset_filter.Text      = "נקה סינון";
            this.btn_reset_filter.UseVisualStyleBackColor = true;
            this.btn_reset_filter.Click    += new System.EventHandler(this.btn_reset_filter_Click);
            //
            // Grid (Y=85, H=430)
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
            this.dataGridView_activities.Size                        = new System.Drawing.Size(1040, 430);
            this.dataGridView_activities.TabIndex                    = 8;
            //
            // label_count (Y=525)
            //
            this.label_count.AutoSize  = false;
            this.label_count.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_count.ForeColor = System.Drawing.Color.DimGray;
            this.label_count.Location  = new System.Drawing.Point(10, 525);
            this.label_count.Name      = "label_count";
            this.label_count.Size      = new System.Drawing.Size(400, 22);
            this.label_count.TabIndex  = 9;
            this.label_count.Text      = "סה\"כ: 0 פעילויות";
            //
            // btn_back (Y=558)
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(390, 555);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(220, 38);
            this.btn_back.TabIndex  = 10;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // AdminActivitiesPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.dataGridView_activities);
            this.Controls.Add(this.btn_reset_filter);
            this.Controls.Add(this.combo_filter_status);
            this.Controls.Add(this.label_filter_status);
            this.Controls.Add(this.combo_filter_type);
            this.Controls.Add(this.label_filter_type);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label_search);
            this.Controls.Add(this.label_title);
            this.Name = "AdminActivitiesPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_activities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.Label          label_search;
        private System.Windows.Forms.TextBox        txt_search;
        private System.Windows.Forms.Label          label_filter_type;
        private System.Windows.Forms.ComboBox       combo_filter_type;
        private System.Windows.Forms.Label          label_filter_status;
        private System.Windows.Forms.ComboBox       combo_filter_status;
        private System.Windows.Forms.Button         btn_reset_filter;
        private System.Windows.Forms.DataGridView   dataGridView_activities;
        private System.Windows.Forms.Label          label_count;
        private System.Windows.Forms.Button         btn_back;
    }
}
