namespace MyDaniel
{
    partial class AdminStudentsPanel
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
            this.txt_search             = new System.Windows.Forms.TextBox();
            this.label_search           = new System.Windows.Forms.Label();
            this.btn_toggle_archive     = new System.Windows.Forms.Button();
            this.dataGridView_students  = new System.Windows.Forms.DataGridView();
            this.label_form_title       = new System.Windows.Forms.Label();
            // RIGHT col
            this.label_id               = new System.Windows.Forms.Label();
            this.txt_id                 = new System.Windows.Forms.TextBox();
            this.label_email            = new System.Windows.Forms.Label();
            this.txt_email              = new System.Windows.Forms.TextBox();
            this.label_status           = new System.Windows.Forms.Label();
            this.combo_status           = new System.Windows.Forms.ComboBox();
            this.label_password         = new System.Windows.Forms.Label();
            this.txt_password           = new System.Windows.Forms.TextBox();
            // LEFT col
            this.label_name             = new System.Windows.Forms.Label();
            this.txt_name               = new System.Windows.Forms.TextBox();
            this.label_phone            = new System.Windows.Forms.Label();
            this.txt_phone              = new System.Windows.Forms.TextBox();
            this.label_birth            = new System.Windows.Forms.Label();
            this.dtp_birth              = new System.Windows.Forms.DateTimePicker();
            this.label_emergency        = new System.Windows.Forms.Label();
            this.txt_emergency          = new System.Windows.Forms.TextBox();
            // Bottom
            this.label_error            = new System.Windows.Forms.Label();
            this.btn_new                = new System.Windows.Forms.Button();
            this.btn_save               = new System.Windows.Forms.Button();
            this.btn_update             = new System.Windows.Forms.Button();
            this.btn_archive            = new System.Windows.Forms.Button();
            this.btn_back               = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_students)).BeginInit();
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
            this.label_title.Text      = "ניהול תלמידים";
            //
            // Toolbar (Y=48)
            //
            this.label_search.AutoSize = true;
            this.label_search.Font     = new System.Drawing.Font("David", 11F);
            this.label_search.Location = new System.Drawing.Point(835, 52);
            this.label_search.Name     = "label_search";
            this.label_search.TabIndex = 1;
            this.label_search.Text     = "חיפוש:";

            this.txt_search.Font     = new System.Drawing.Font("David", 11F);
            this.txt_search.Location = new System.Drawing.Point(570, 49);
            this.txt_search.Name     = "txt_search";
            this.txt_search.Size     = new System.Drawing.Size(255, 26);
            this.txt_search.TabIndex = 2;

            this.btn_toggle_archive.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_toggle_archive.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.btn_toggle_archive.Location  = new System.Drawing.Point(10, 47);
            this.btn_toggle_archive.Name      = "btn_toggle_archive";
            this.btn_toggle_archive.Size      = new System.Drawing.Size(145, 30);
            this.btn_toggle_archive.TabIndex  = 3;
            this.btn_toggle_archive.Text      = "הצג ארכיון";
            this.btn_toggle_archive.UseVisualStyleBackColor = true;
            this.btn_toggle_archive.Click    += new System.EventHandler(this.btn_toggle_archive_Click);
            //
            // Grid (Y=85, H=175)
            //
            this.dataGridView_students.AllowUserToAddRows          = false;
            this.dataGridView_students.AllowUserToDeleteRows       = false;
            this.dataGridView_students.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_students.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_students.Location                    = new System.Drawing.Point(10, 85);
            this.dataGridView_students.MultiSelect                 = false;
            this.dataGridView_students.Name                        = "dataGridView_students";
            this.dataGridView_students.ReadOnly                    = true;
            this.dataGridView_students.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_students.RowHeadersWidth             = 40;
            this.dataGridView_students.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_students.Size                        = new System.Drawing.Size(1040, 175);
            this.dataGridView_students.TabIndex                    = 4;
            //
            // Form header (Y=268)
            //
            this.label_form_title.AutoSize  = true;
            this.label_form_title.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_form_title.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_title.Location  = new System.Drawing.Point(325, 268);
            this.label_form_title.Name      = "label_form_title";
            this.label_form_title.TabIndex  = 5;
            this.label_form_title.Text      = "הוספה / עריכת פרטי תלמיד";
            //
            // RIGHT col: lbl X=720, ctrl X=490 W=220 — Y=296,333,370,407
            //
            this.label_id.AutoSize = true;
            this.label_id.Font     = new System.Drawing.Font("David", 13F);
            this.label_id.Location = new System.Drawing.Point(720, 299);
            this.label_id.Name     = "label_id";
            this.label_id.TabIndex = 6;
            this.label_id.Text     = "מ.ז. תלמיד";
            this.txt_id.Font     = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(490, 296);
            this.txt_id.Name     = "txt_id";
            this.txt_id.Size     = new System.Drawing.Size(220, 27);
            this.txt_id.TabIndex = 7;

            this.label_email.AutoSize = true;
            this.label_email.Font     = new System.Drawing.Font("David", 13F);
            this.label_email.Location = new System.Drawing.Point(720, 336);
            this.label_email.Name     = "label_email";
            this.label_email.TabIndex = 8;
            this.label_email.Text     = "אימייל";
            this.txt_email.Font     = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(490, 333);
            this.txt_email.Name     = "txt_email";
            this.txt_email.Size     = new System.Drawing.Size(220, 27);
            this.txt_email.TabIndex = 9;

            this.label_status.AutoSize = true;
            this.label_status.Font     = new System.Drawing.Font("David", 13F);
            this.label_status.Location = new System.Drawing.Point(720, 373);
            this.label_status.Name     = "label_status";
            this.label_status.TabIndex = 10;
            this.label_status.Text     = "סטטוס";
            this.combo_status.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.Font              = new System.Drawing.Font("David", 11F);
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location          = new System.Drawing.Point(490, 370);
            this.combo_status.Name              = "combo_status";
            this.combo_status.Size              = new System.Drawing.Size(220, 26);
            this.combo_status.TabIndex          = 11;

            this.label_password.AutoSize = true;
            this.label_password.Font     = new System.Drawing.Font("David", 13F);
            this.label_password.Location = new System.Drawing.Point(720, 410);
            this.label_password.Name     = "label_password";
            this.label_password.TabIndex = 12;
            this.label_password.Text     = "סיסמה";
            this.txt_password.Font         = new System.Drawing.Font("David", 12F);
            this.txt_password.Location     = new System.Drawing.Point(490, 407);
            this.txt_password.Name         = "txt_password";
            this.txt_password.PasswordChar = '●';
            this.txt_password.Size         = new System.Drawing.Size(220, 27);
            this.txt_password.TabIndex     = 13;
            //
            // LEFT col: lbl X=375, ctrl X=120 W=245 — Y=296,333,370,407
            //
            this.label_name.AutoSize = true;
            this.label_name.Font     = new System.Drawing.Font("David", 13F);
            this.label_name.Location = new System.Drawing.Point(375, 299);
            this.label_name.Name     = "label_name";
            this.label_name.TabIndex = 14;
            this.label_name.Text     = "שם מלא";
            this.txt_name.Font     = new System.Drawing.Font("David", 12F);
            this.txt_name.Location = new System.Drawing.Point(120, 296);
            this.txt_name.Name     = "txt_name";
            this.txt_name.Size     = new System.Drawing.Size(245, 27);
            this.txt_name.TabIndex = 15;

            this.label_phone.AutoSize = true;
            this.label_phone.Font     = new System.Drawing.Font("David", 13F);
            this.label_phone.Location = new System.Drawing.Point(375, 336);
            this.label_phone.Name     = "label_phone";
            this.label_phone.TabIndex = 16;
            this.label_phone.Text     = "טלפון";
            this.txt_phone.Font     = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(120, 333);
            this.txt_phone.Name     = "txt_phone";
            this.txt_phone.Size     = new System.Drawing.Size(245, 27);
            this.txt_phone.TabIndex = 17;

            this.label_birth.AutoSize = true;
            this.label_birth.Font     = new System.Drawing.Font("David", 13F);
            this.label_birth.Location = new System.Drawing.Point(375, 373);
            this.label_birth.Name     = "label_birth";
            this.label_birth.TabIndex = 18;
            this.label_birth.Text     = "תאריך לידה";
            this.dtp_birth.Font     = new System.Drawing.Font("David", 11F);
            this.dtp_birth.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_birth.Location = new System.Drawing.Point(120, 370);
            this.dtp_birth.Name     = "dtp_birth";
            this.dtp_birth.Size     = new System.Drawing.Size(245, 26);
            this.dtp_birth.TabIndex = 19;

            this.label_emergency.AutoSize = true;
            this.label_emergency.Font     = new System.Drawing.Font("David", 13F);
            this.label_emergency.Location = new System.Drawing.Point(375, 410);
            this.label_emergency.Name     = "label_emergency";
            this.label_emergency.TabIndex = 20;
            this.label_emergency.Text     = "איש קשר חירום";
            this.txt_emergency.Font     = new System.Drawing.Font("David", 12F);
            this.txt_emergency.Location = new System.Drawing.Point(120, 407);
            this.txt_emergency.Name     = "txt_emergency";
            this.txt_emergency.Size     = new System.Drawing.Size(245, 27);
            this.txt_emergency.TabIndex = 21;
            //
            // label_error (Y=448)
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 448);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 30;
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // Buttons (Y=478)
            //
            this.btn_new.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_new.Location  = new System.Drawing.Point(10, 478);
            this.btn_new.Name      = "btn_new";
            this.btn_new.Size      = new System.Drawing.Size(120, 38);
            this.btn_new.TabIndex  = 31;
            this.btn_new.Text      = "חדש";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click    += new System.EventHandler(this.btn_new_Click);

            this.btn_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_save.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location  = new System.Drawing.Point(145, 478);
            this.btn_save.Name      = "btn_save";
            this.btn_save.Size      = new System.Drawing.Size(140, 38);
            this.btn_save.TabIndex  = 32;
            this.btn_save.Text      = "שמור חדש";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click    += new System.EventHandler(this.btn_save_Click);

            this.btn_update.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_update.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location  = new System.Drawing.Point(300, 478);
            this.btn_update.Name      = "btn_update";
            this.btn_update.Size      = new System.Drawing.Size(140, 38);
            this.btn_update.TabIndex  = 33;
            this.btn_update.Text      = "עדכן";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Visible   = false;
            this.btn_update.Click    += new System.EventHandler(this.btn_update_Click);

            this.btn_archive.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_archive.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.btn_archive.ForeColor = System.Drawing.Color.White;
            this.btn_archive.Location  = new System.Drawing.Point(455, 478);
            this.btn_archive.Name      = "btn_archive";
            this.btn_archive.Size      = new System.Drawing.Size(155, 38);
            this.btn_archive.TabIndex  = 34;
            this.btn_archive.Text      = "שלח לארכיון";
            this.btn_archive.UseVisualStyleBackColor = false;
            this.btn_archive.Visible   = false;
            this.btn_archive.Click    += new System.EventHandler(this.btn_archive_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(820, 478);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(165, 38);
            this.btn_back.TabIndex  = 35;
            this.btn_back.Text      = "חזרה לתפריט";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // AdminStudentsPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_archive);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.txt_emergency);
            this.Controls.Add(this.label_emergency);
            this.Controls.Add(this.dtp_birth);
            this.Controls.Add(this.label_birth);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.combo_status);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_form_title);
            this.Controls.Add(this.dataGridView_students);
            this.Controls.Add(this.btn_toggle_archive);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label_search);
            this.Controls.Add(this.label_title);
            this.Name = "AdminStudentsPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_students)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label          label_title;
        private System.Windows.Forms.TextBox        txt_search;
        private System.Windows.Forms.Label          label_search;
        private System.Windows.Forms.Button         btn_toggle_archive;
        private System.Windows.Forms.DataGridView   dataGridView_students;
        private System.Windows.Forms.Label          label_form_title;
        private System.Windows.Forms.Label          label_id;
        private System.Windows.Forms.TextBox        txt_id;
        private System.Windows.Forms.Label          label_email;
        private System.Windows.Forms.TextBox        txt_email;
        private System.Windows.Forms.Label          label_status;
        private System.Windows.Forms.ComboBox       combo_status;
        private System.Windows.Forms.Label          label_password;
        private System.Windows.Forms.TextBox        txt_password;
        private System.Windows.Forms.Label          label_name;
        private System.Windows.Forms.TextBox        txt_name;
        private System.Windows.Forms.Label          label_phone;
        private System.Windows.Forms.TextBox        txt_phone;
        private System.Windows.Forms.Label          label_birth;
        private System.Windows.Forms.DateTimePicker dtp_birth;
        private System.Windows.Forms.Label          label_emergency;
        private System.Windows.Forms.TextBox        txt_emergency;
        private System.Windows.Forms.Label          label_error;
        private System.Windows.Forms.Button         btn_new;
        private System.Windows.Forms.Button         btn_save;
        private System.Windows.Forms.Button         btn_update;
        private System.Windows.Forms.Button         btn_archive;
        private System.Windows.Forms.Button         btn_back;
    }
}
