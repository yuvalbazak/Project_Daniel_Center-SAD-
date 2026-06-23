namespace MyDaniel
{
    partial class CreateEmployeePanel
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
            this.label_title         = new System.Windows.Forms.Label();
            this.label_id            = new System.Windows.Forms.Label();
            this.txt_id              = new System.Windows.Forms.TextBox();
            this.label_full_name     = new System.Windows.Forms.Label();
            this.txt_full_name       = new System.Windows.Forms.TextBox();
            this.label_role          = new System.Windows.Forms.Label();
            this.comboBox_role       = new System.Windows.Forms.ComboBox();
            this.label_start         = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label_phone         = new System.Windows.Forms.Label();
            this.txt_phone           = new System.Windows.Forms.TextBox();
            this.label_email         = new System.Windows.Forms.Label();
            this.txt_email           = new System.Windows.Forms.TextBox();
            this.btn_create          = new System.Windows.Forms.Button();
            this.btn_back            = new System.Windows.Forms.Button();
            this.label_error         = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize = false;
            this.label_title.Font = new System.Drawing.Font("David", 36F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location = new System.Drawing.Point(10, 18);
            this.label_title.Size = new System.Drawing.Size(975, 52);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name = "label_title";
            this.label_title.TabIndex = 0;
            this.label_title.Text = "הוספת עובד חדש";
            //
            // label_id
            //
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("David", 14F);
            this.label_id.Location = new System.Drawing.Point(660, 105);
            this.label_id.Name = "label_id";
            this.label_id.TabIndex = 1;
            this.label_id.Text = "מספר עובד";
            //
            // txt_id
            //
            this.txt_id.Font = new System.Drawing.Font("David", 12F);
            this.txt_id.Location = new System.Drawing.Point(430, 102);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(210, 27);
            this.txt_id.TabIndex = 2;
            //
            // label_full_name
            //
            this.label_full_name.AutoSize = true;
            this.label_full_name.Font = new System.Drawing.Font("David", 14F);
            this.label_full_name.Location = new System.Drawing.Point(660, 155);
            this.label_full_name.Name = "label_full_name";
            this.label_full_name.TabIndex = 3;
            this.label_full_name.Text = "שם מלא";
            //
            // txt_full_name
            //
            this.txt_full_name.Font = new System.Drawing.Font("David", 12F);
            this.txt_full_name.Location = new System.Drawing.Point(430, 152);
            this.txt_full_name.Name = "txt_full_name";
            this.txt_full_name.Size = new System.Drawing.Size(210, 27);
            this.txt_full_name.TabIndex = 4;
            //
            // label_role
            //
            this.label_role.AutoSize = true;
            this.label_role.Font = new System.Drawing.Font("David", 14F);
            this.label_role.Location = new System.Drawing.Point(660, 205);
            this.label_role.Name = "label_role";
            this.label_role.TabIndex = 5;
            this.label_role.Text = "תפקיד";
            //
            // comboBox_role
            //
            this.comboBox_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_role.Font = new System.Drawing.Font("David", 11F);
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(430, 205);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(210, 26);
            this.comboBox_role.TabIndex = 6;
            //
            // label_start
            //
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("David", 14F);
            this.label_start.Location = new System.Drawing.Point(660, 255);
            this.label_start.Name = "label_start";
            this.label_start.TabIndex = 7;
            this.label_start.Text = "תאריך התחלה";
            //
            // dateTimePicker_start
            //
            this.dateTimePicker_start.Font = new System.Drawing.Font("David", 11F);
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_start.Location = new System.Drawing.Point(430, 252);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(210, 26);
            this.dateTimePicker_start.TabIndex = 8;
            //
            // label_phone
            //
            this.label_phone.AutoSize = true;
            this.label_phone.Font = new System.Drawing.Font("David", 14F);
            this.label_phone.Location = new System.Drawing.Point(660, 305);
            this.label_phone.Name = "label_phone";
            this.label_phone.TabIndex = 9;
            this.label_phone.Text = "טלפון";
            //
            // txt_phone
            //
            this.txt_phone.Font = new System.Drawing.Font("David", 12F);
            this.txt_phone.Location = new System.Drawing.Point(430, 302);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(210, 27);
            this.txt_phone.TabIndex = 10;
            //
            // label_email
            //
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("David", 14F);
            this.label_email.Location = new System.Drawing.Point(660, 355);
            this.label_email.Name = "label_email";
            this.label_email.TabIndex = 11;
            this.label_email.Text = "אימייל";
            //
            // txt_email
            //
            this.txt_email.Font = new System.Drawing.Font("David", 12F);
            this.txt_email.Location = new System.Drawing.Point(430, 352);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(210, 27);
            this.txt_email.TabIndex = 12;
            //
            // label_error
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 11F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(200, 410);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(600, 24);
            this.label_error.TabIndex  = 20;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_error.Visible   = false;
            //
            // btn_create
            //
            this.btn_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_create.Font = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Bold);
            this.btn_create.Location = new System.Drawing.Point(100, 200);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(220, 100);
            this.btn_create.TabIndex = 13;
            this.btn_create.Text = "הוסף עובד";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(425, 530);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex = 14;
            this.btn_back.Text = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            //
            // CreateEmployeePanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.comboBox_role);
            this.Controls.Add(this.label_role);
            this.Controls.Add(this.txt_full_name);
            this.Controls.Add(this.label_full_name);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.label_title);
            this.Name = "CreateEmployeePanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           label_title;
        private System.Windows.Forms.Label           label_id;
        private System.Windows.Forms.TextBox         txt_id;
        private System.Windows.Forms.Label           label_full_name;
        private System.Windows.Forms.TextBox         txt_full_name;
        private System.Windows.Forms.Label           label_role;
        private System.Windows.Forms.ComboBox        comboBox_role;
        private System.Windows.Forms.Label           label_start;
        private System.Windows.Forms.DateTimePicker  dateTimePicker_start;
        private System.Windows.Forms.Label           label_phone;
        private System.Windows.Forms.TextBox         txt_phone;
        private System.Windows.Forms.Label           label_email;
        private System.Windows.Forms.TextBox         txt_email;
        private System.Windows.Forms.Button          btn_create;
        private System.Windows.Forms.Button          btn_back;
        private System.Windows.Forms.Label           label_error;
    }
}
