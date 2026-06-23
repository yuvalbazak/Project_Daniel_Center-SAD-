namespace MyDaniel
{
    partial class ExternalCenterPanel
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
            this.label_title          = new System.Windows.Forms.Label();
            this.dataGridView_centers = new System.Windows.Forms.DataGridView();
            this.label_form_title     = new System.Windows.Forms.Label();
            // RIGHT column
            this.label_id             = new System.Windows.Forms.Label();
            this.txt_id               = new System.Windows.Forms.TextBox();
            this.label_name           = new System.Windows.Forms.Label();
            this.txt_name             = new System.Windows.Forms.TextBox();
            // LEFT column
            this.label_contact        = new System.Windows.Forms.Label();
            this.txt_contact          = new System.Windows.Forms.TextBox();
            this.label_phone          = new System.Windows.Forms.Label();
            this.txt_phone            = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error          = new System.Windows.Forms.Label();
            this.btn_new              = new System.Windows.Forms.Button();
            this.btn_save             = new System.Windows.Forms.Button();
            this.btn_update           = new System.Windows.Forms.Button();
            this.btn_delete           = new System.Windows.Forms.Button();
            this.btn_back             = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_centers)).BeginInit();
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
            this.label_title.Text      = "ניהול מרכזים חיצוניים";
            //
            // dataGridView_centers
            //
            this.dataGridView_centers.AllowUserToAddRows          = false;
            this.dataGridView_centers.AllowUserToDeleteRows       = false;
            this.dataGridView_centers.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_centers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_centers.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_centers.Location                    = new System.Drawing.Point(10, 55);
            this.dataGridView_centers.MultiSelect                 = false;
            this.dataGridView_centers.Name                        = "dataGridView_centers";
            this.dataGridView_centers.ReadOnly                    = true;
            this.dataGridView_centers.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_centers.RowHeadersWidth             = 40;
            this.dataGridView_centers.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_centers.Size                        = new System.Drawing.Size(1040, 170);
            this.dataGridView_centers.TabIndex                    = 1;
            //
            // label_form_title
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(260, 235);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 2;
            this.label_form_title.Text      = "פרטי מרכז חיצוני — הוספה / עריכה";
            //
            // ── RIGHT COLUMN  (label X=725, ctrl X=505 W=210)
            // ── Rows at Y: 254, 294
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(725, 254);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 10;
            this.label_id.Text     = "מספר מרכז";

            this.txt_id.Font      = new System.Drawing.Font("David", 12F);
            this.txt_id.Location  = new System.Drawing.Point(505, 251);
            this.txt_id.Name      = "txt_id";
            this.txt_id.ReadOnly  = true;
            this.txt_id.Size      = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex  = 11;
            this.txt_id.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            this.label_name.AutoSize = true;
            this.label_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_name.Location = new System.Drawing.Point(725, 294);
            this.label_name.Name     = "label_name";
            this.label_name.TabIndex = 12;
            this.label_name.Text     = "שם המרכז";

            this.txt_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_name.Location = new System.Drawing.Point(505, 291);
            this.txt_name.Name     = "txt_name";
            this.txt_name.Size     = new System.Drawing.Size(210, 27);
            this.txt_name.TabIndex = 13;
            //
            // ── LEFT COLUMN  (label X=385, ctrl X=150 W=220)
            // ── Rows at Y: 254, 294
            //
            this.label_contact.AutoSize = true;
            this.label_contact.Font     = new System.Drawing.Font("David", 13F);
            this.label_contact.Location = new System.Drawing.Point(385, 254);
            this.label_contact.Name     = "label_contact";
            this.label_contact.TabIndex = 20;
            this.label_contact.Text     = "איש קשר";

            this.txt_contact.Font     = new System.Drawing.Font("David", 12F);
            this.txt_contact.Location = new System.Drawing.Point(150, 251);
            this.txt_contact.Name     = "txt_contact";
            this.txt_contact.Size     = new System.Drawing.Size(220, 27);
            this.txt_contact.TabIndex = 21;

            this.label_phone.AutoSize = true;
            this.label_phone.Font     = new System.Drawing.Font("David", 13F);
            this.label_phone.Location = new System.Drawing.Point(385, 294);
            this.label_phone.Name     = "label_phone";
            this.label_phone.TabIndex = 22;
            this.label_phone.Text     = "טלפון";

            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(150, 291);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(220, 27);
            this.txt_phone.TabIndex = 23;
            //
            // label_error (Y=338)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 338);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // ── BUTTONS (Y=366)
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(20, 366);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(145, 42);
            this.btn_new.TabIndex  = 40;
            this.btn_new.Text      = "מרכז חדש";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(180, 366);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(145, 42);
            this.btn_save.TabIndex  = 41;
            this.btn_save.Text      = "שמור";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);

            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(180, 366);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(145, 42);
            this.btn_update.TabIndex  = 42;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);

            this.btn_delete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location  = new System.Drawing.Point(350, 366);
            this.btn_delete.Name      = "btn_delete";
            this.btn_delete.Size      = new System.Drawing.Size(145, 42);
            this.btn_delete.TabIndex  = 43;
            this.btn_delete.Text      = "מחק";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible   = false;
            this.btn_delete.Click    += new System.EventHandler(this.btn_delete_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 13F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 366);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(155, 42);
            this.btn_back.TabIndex  = 44;
            this.btn_back.Text      = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // ExternalCenterPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.dataGridView_centers);
            this.Controls.Add(this.label_form_title);
            // RIGHT
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.txt_name);
            // LEFT
            this.Controls.Add(this.label_contact);
            this.Controls.Add(this.txt_contact);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.txt_phone);
            // Error + buttons
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_back);
            this.Name = "ExternalCenterPanel";
            this.Size = new System.Drawing.Size(1000, 430);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_centers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        label_title;
        private System.Windows.Forms.DataGridView dataGridView_centers;
        private System.Windows.Forms.Label        label_form_title;
        private System.Windows.Forms.Label        label_id;
        private System.Windows.Forms.TextBox      txt_id;
        private System.Windows.Forms.Label        label_name;
        private System.Windows.Forms.TextBox      txt_name;
        private System.Windows.Forms.Label        label_contact;
        private System.Windows.Forms.TextBox      txt_contact;
        private System.Windows.Forms.Label        label_phone;
        private System.Windows.Forms.TextBox      txt_phone;
        private System.Windows.Forms.Label        label_error;
        private System.Windows.Forms.Button       btn_new;
        private System.Windows.Forms.Button       btn_save;
        private System.Windows.Forms.Button       btn_update;
        private System.Windows.Forms.Button       btn_delete;
        private System.Windows.Forms.Button       btn_back;
    }
}
