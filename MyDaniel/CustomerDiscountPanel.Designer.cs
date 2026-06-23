namespace MyDaniel
{
    partial class CustomerDiscountPanel
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
            this.dataGridView_requests = new System.Windows.Forms.DataGridView();
            this.label_detail          = new System.Windows.Forms.Label();
            this.label_new_form_title  = new System.Windows.Forms.Label();
            this.label_type            = new System.Windows.Forms.Label();
            this.combo_type            = new System.Windows.Forms.ComboBox();
            this.label_file            = new System.Windows.Forms.Label();
            this.txt_file              = new System.Windows.Forms.TextBox();
            this.label_error           = new System.Windows.Forms.Label();
            this.btn_submit            = new System.Windows.Forms.Button();
            this.btn_clear             = new System.Windows.Forms.Button();
            this.btn_back              = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requests)).BeginInit();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize  = false;
            this.label_title.Font      = new System.Drawing.Font("David", 28F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location  = new System.Drawing.Point(10, 12);
            this.label_title.Name      = "label_title";
            this.label_title.Size      = new System.Drawing.Size(1040, 44);
            this.label_title.TabIndex  = 0;
            this.label_title.Text      = "בקשות ההנחה שלי";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // label_note
            //
            this.label_note.AutoSize  = false;
            this.label_note.Font      = new System.Drawing.Font("David", 11F);
            this.label_note.ForeColor = System.Drawing.Color.DimGray;
            this.label_note.Location  = new System.Drawing.Point(10, 60);
            this.label_note.Name      = "label_note";
            this.label_note.Size      = new System.Drawing.Size(1040, 24);
            this.label_note.TabIndex  = 1;
            this.label_note.Text      = "הבקשות שלך — לחץ על שורה לצפייה בפרטים";
            this.label_note.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // dataGridView_requests
            //
            this.dataGridView_requests.AllowUserToAddRows          = false;
            this.dataGridView_requests.AllowUserToDeleteRows       = false;
            this.dataGridView_requests.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_requests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_requests.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_requests.Location                    = new System.Drawing.Point(10, 90);
            this.dataGridView_requests.MultiSelect                 = false;
            this.dataGridView_requests.Name                        = "dataGridView_requests";
            this.dataGridView_requests.ReadOnly                    = true;
            this.dataGridView_requests.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_requests.RowHeadersWidth             = 40;
            this.dataGridView_requests.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_requests.Size                        = new System.Drawing.Size(1040, 230);
            this.dataGridView_requests.TabIndex                    = 2;
            //
            // label_detail  (shown when a row is selected)
            //
            this.label_detail.AutoSize  = false;
            this.label_detail.Font      = new System.Drawing.Font("David", 11F);
            this.label_detail.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_detail.Location  = new System.Drawing.Point(10, 328);
            this.label_detail.Name      = "label_detail";
            this.label_detail.Size      = new System.Drawing.Size(1040, 30);
            this.label_detail.TabIndex  = 3;
            this.label_detail.Text      = "";
            this.label_detail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_detail.Visible   = false;
            //
            // label_new_form_title
            //
            this.label_new_form_title.AutoSize  = false;
            this.label_new_form_title.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.label_new_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_new_form_title.Location  = new System.Drawing.Point(10, 370);
            this.label_new_form_title.Name      = "label_new_form_title";
            this.label_new_form_title.Size      = new System.Drawing.Size(1040, 28);
            this.label_new_form_title.TabIndex  = 4;
            this.label_new_form_title.Text      = "הגשת בקשת הנחה חדשה";
            this.label_new_form_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // ── Form row (Y=408) ─────────────────────────────────────────────────
            //
            // label_type (right column — label to the RIGHT of its combo, Hebrew order)
            //
            this.label_type.AutoSize = true;
            this.label_type.Font     = new System.Drawing.Font("David", 13F);
            this.label_type.Location = new System.Drawing.Point(840, 411);
            this.label_type.Name     = "label_type";
            this.label_type.TabIndex = 5;
            this.label_type.Text     = "סוג הנחה";
            //
            // combo_type (right column)
            //
            this.combo_type.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_type.Font              = new System.Drawing.Font("David", 11F);
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Location          = new System.Drawing.Point(610, 408);
            this.combo_type.Name              = "combo_type";
            this.combo_type.RightToLeft       = System.Windows.Forms.RightToLeft.Yes;
            this.combo_type.Size              = new System.Drawing.Size(220, 26);
            this.combo_type.TabIndex          = 6;
            //
            // label_file (left column — label to the RIGHT of its textbox)
            //
            this.label_file.AutoSize = true;
            this.label_file.Font     = new System.Drawing.Font("David", 13F);
            this.label_file.Location = new System.Drawing.Point(428, 411);
            this.label_file.Name     = "label_file";
            this.label_file.TabIndex = 7;
            this.label_file.Text     = "נתיב מסמך";
            //
            // txt_file (left column)
            //
            this.txt_file.Font     = new System.Drawing.Font("David", 11F);
            this.txt_file.Location = new System.Drawing.Point(50, 408);
            this.txt_file.Name     = "txt_file";
            this.txt_file.Size     = new System.Drawing.Size(358, 27);
            this.txt_file.TabIndex = 8;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 448);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 20;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── Buttons (Y=480) ──────────────────────────────────────────────────
            //
            // btn_submit  (primary, blue)
            //
            this.btn_submit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_submit.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_submit.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location  = new System.Drawing.Point(20, 480);
            this.btn_submit.Name      = "btn_submit";
            this.btn_submit.Size      = new System.Drawing.Size(175, 42);
            this.btn_submit.TabIndex  = 30;
            this.btn_submit.Text      = "הגש בקשה";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click    += new System.EventHandler(this.btn_submit_Click);
            //
            // btn_clear
            //
            this.btn_clear.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_clear.Location  = new System.Drawing.Point(210, 480);
            this.btn_clear.Name      = "btn_clear";
            this.btn_clear.Size      = new System.Drawing.Size(130, 42);
            this.btn_clear.TabIndex  = 31;
            this.btn_clear.Text      = "נקה";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click    += new System.EventHandler(this.btn_clear_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 480);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex  = 32;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // CustomerDiscountPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.dataGridView_requests);
            this.Controls.Add(this.label_detail);
            this.Controls.Add(this.label_new_form_title);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_back);
            this.Name = "CustomerDiscountPanel";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_requests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.Label          label_note;
        private System.Windows.Forms.DataGridView   dataGridView_requests;
        private System.Windows.Forms.Label          label_detail;
        private System.Windows.Forms.Label          label_new_form_title;
        private System.Windows.Forms.Label          label_type;
        private System.Windows.Forms.ComboBox       combo_type;
        private System.Windows.Forms.Label          label_file;
        private System.Windows.Forms.TextBox        txt_file;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_submit;
        private System.Windows.Forms.Button         btn_clear;
        private System.Windows.Forms.Button         btn_back;
    }
}
