namespace MyDaniel
{
    partial class ManageRosterPanel
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
            this.label_activity_info = new System.Windows.Forms.Label();
            this.dataGridView_roster = new System.Windows.Forms.DataGridView();
            this.label_capacity      = new System.Windows.Forms.Label();
            this.label_form_header   = new System.Windows.Forms.Label();
            // Row 1: customer (RIGHT) + boat (LEFT)
            this.label_customer_lbl  = new System.Windows.Forms.Label();
            this.combo_customer      = new System.Windows.Forms.ComboBox();
            this.label_boat_lbl      = new System.Windows.Forms.Label();
            this.combo_boat          = new System.Windows.Forms.ComboBox();
            // Row 2: notes (spanning most of width)
            this.label_notes_lbl     = new System.Windows.Forms.Label();
            this.txt_notes           = new System.Windows.Forms.TextBox();
            // Error + buttons
            this.label_error               = new System.Windows.Forms.Label();
            this.btn_add                   = new System.Windows.Forms.Button();
            this.btn_assign_boat           = new System.Windows.Forms.Button();
            this.btn_assign_external_boat  = new System.Windows.Forms.Button();
            this.btn_remove                = new System.Windows.Forms.Button();
            this.btn_notify                = new System.Windows.Forms.Button();
            this.btn_back                  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_roster)).BeginInit();
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
            this.label_title.Text      = "ניהול משתתפים וסירות";
            //
            // label_activity_info
            //
            this.label_activity_info.AutoSize  = false;
            this.label_activity_info.Font      = new System.Drawing.Font("David", 11F);
            this.label_activity_info.ForeColor = System.Drawing.Color.DimGray;
            this.label_activity_info.Location  = new System.Drawing.Point(0, 52);
            this.label_activity_info.Name      = "label_activity_info";
            this.label_activity_info.Size      = new System.Drawing.Size(1000, 22);
            this.label_activity_info.TabIndex  = 1;
            this.label_activity_info.Text      = "";
            this.label_activity_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dataGridView_roster
            //
            this.dataGridView_roster.AllowUserToAddRows          = false;
            this.dataGridView_roster.AllowUserToDeleteRows       = false;
            this.dataGridView_roster.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_roster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_roster.Font                        = new System.Drawing.Font("David", 10F);
            this.dataGridView_roster.Location                    = new System.Drawing.Point(10, 80);
            this.dataGridView_roster.MultiSelect                 = false;
            this.dataGridView_roster.Name                        = "dataGridView_roster";
            this.dataGridView_roster.ReadOnly                    = true;
            this.dataGridView_roster.RightToLeft                 = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_roster.RowHeadersWidth             = 40;
            this.dataGridView_roster.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_roster.Size                        = new System.Drawing.Size(1040, 220);
            this.dataGridView_roster.TabIndex                    = 2;
            //
            // label_capacity
            //
            this.label_capacity.AutoSize  = true;
            this.label_capacity.Font      = new System.Drawing.Font("David", 11F);
            this.label_capacity.ForeColor = System.Drawing.Color.DimGray;
            this.label_capacity.Location  = new System.Drawing.Point(10, 298);
            this.label_capacity.Name      = "label_capacity";
            this.label_capacity.TabIndex  = 3;
            this.label_capacity.Text      = "רשומים: 0 / 10 משתתפים";
            //
            // label_form_header
            //
            this.label_form_header.AutoSize  = true;
            this.label_form_header.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label_form_header.ForeColor = System.Drawing.Color.DimGray;
            this.label_form_header.Location  = new System.Drawing.Point(10, 322);
            this.label_form_header.Name      = "label_form_header";
            this.label_form_header.TabIndex  = 4;
            this.label_form_header.Text      = "הוספת / עדכון משתתף:";
            //
            // Row 1 Y=350: customer (RIGHT col) + boat (LEFT col)
            //
            // label_customer_lbl  RIGHT: label X=740, ctrl X=490 W=240
            this.label_customer_lbl.AutoSize  = true;
            this.label_customer_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_customer_lbl.Location  = new System.Drawing.Point(740, 353);
            this.label_customer_lbl.Name      = "label_customer_lbl";
            this.label_customer_lbl.TabIndex  = 10;
            this.label_customer_lbl.Text      = "תלמיד:";

            this.combo_customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_customer.Font          = new System.Drawing.Font("David", 11F);
            this.combo_customer.Location      = new System.Drawing.Point(490, 350);
            this.combo_customer.Name          = "combo_customer";
            this.combo_customer.Size          = new System.Drawing.Size(240, 26);
            this.combo_customer.TabIndex      = 11;

            // label_boat_lbl  LEFT: label X=375, ctrl X=100 W=265
            this.label_boat_lbl.AutoSize  = true;
            this.label_boat_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_boat_lbl.Location  = new System.Drawing.Point(375, 353);
            this.label_boat_lbl.Name      = "label_boat_lbl";
            this.label_boat_lbl.TabIndex  = 12;
            this.label_boat_lbl.Text      = "סירה:";

            this.combo_boat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_boat.Font          = new System.Drawing.Font("David", 11F);
            this.combo_boat.Location      = new System.Drawing.Point(100, 350);
            this.combo_boat.Name          = "combo_boat";
            this.combo_boat.Size          = new System.Drawing.Size(265, 26);
            this.combo_boat.TabIndex      = 13;
            //
            // Row 2 Y=385: notes (spanning right side to left)
            //
            this.label_notes_lbl.AutoSize  = true;
            this.label_notes_lbl.Font      = new System.Drawing.Font("David", 11F);
            this.label_notes_lbl.Location  = new System.Drawing.Point(740, 388);
            this.label_notes_lbl.Name      = "label_notes_lbl";
            this.label_notes_lbl.TabIndex  = 14;
            this.label_notes_lbl.Text      = "הערות:";

            this.txt_notes.Font     = new System.Drawing.Font("David", 11F);
            this.txt_notes.Location = new System.Drawing.Point(100, 385);
            this.txt_notes.Name     = "txt_notes";
            this.txt_notes.Size     = new System.Drawing.Size(630, 24);
            this.txt_notes.TabIndex = 15;
            //
            // label_error  Y=418
            //
            this.label_error.AutoSize  = false;
            this.label_error.Font      = new System.Drawing.Font("David", 10F, System.Drawing.FontStyle.Bold);
            this.label_error.ForeColor = System.Drawing.Color.Crimson;
            this.label_error.Location  = new System.Drawing.Point(100, 418);
            this.label_error.Name      = "label_error";
            this.label_error.Size      = new System.Drawing.Size(800, 22);
            this.label_error.TabIndex  = 20;
            this.label_error.Text      = "";
            this.label_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_error.Visible   = false;
            //
            // Buttons Y=448
            //
            // Buttons Y=448 — 6 buttons across ~990px
            this.btn_add.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_add.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location  = new System.Drawing.Point(10, 448);
            this.btn_add.Name      = "btn_add";
            this.btn_add.Size      = new System.Drawing.Size(140, 40);
            this.btn_add.TabIndex  = 30;
            this.btn_add.Text      = "הוסף משתתף";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click    += new System.EventHandler(this.btn_add_Click);

            this.btn_assign_boat.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_assign_boat.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_assign_boat.Enabled   = false;
            this.btn_assign_boat.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_assign_boat.ForeColor = System.Drawing.Color.White;
            this.btn_assign_boat.Location  = new System.Drawing.Point(155, 448);
            this.btn_assign_boat.Name      = "btn_assign_boat";
            this.btn_assign_boat.Size      = new System.Drawing.Size(165, 40);
            this.btn_assign_boat.TabIndex  = 31;
            this.btn_assign_boat.Text      = "עדכן סירה למשתתף";
            this.btn_assign_boat.UseVisualStyleBackColor = false;
            this.btn_assign_boat.Click    += new System.EventHandler(this.btn_assign_boat_Click);

            this.btn_assign_external_boat.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_assign_external_boat.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_assign_external_boat.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_assign_external_boat.ForeColor = System.Drawing.Color.White;
            this.btn_assign_external_boat.Location  = new System.Drawing.Point(325, 448);
            this.btn_assign_external_boat.Name      = "btn_assign_external_boat";
            this.btn_assign_external_boat.Size      = new System.Drawing.Size(160, 40);
            this.btn_assign_external_boat.TabIndex  = 32;
            this.btn_assign_external_boat.Text      = "שייך סירה חיצונית";
            this.btn_assign_external_boat.UseVisualStyleBackColor = false;
            this.btn_assign_external_boat.Click    += new System.EventHandler(this.btn_assign_external_boat_Click);

            this.btn_remove.BackColor = System.Drawing.Color.DarkRed;
            this.btn_remove.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_remove.Enabled   = false;
            this.btn_remove.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_remove.ForeColor = System.Drawing.Color.White;
            this.btn_remove.Location  = new System.Drawing.Point(490, 448);
            this.btn_remove.Name      = "btn_remove";
            this.btn_remove.Size      = new System.Drawing.Size(140, 40);
            this.btn_remove.TabIndex  = 33;
            this.btn_remove.Text      = "הסר משתתף";
            this.btn_remove.UseVisualStyleBackColor = false;
            this.btn_remove.Click    += new System.EventHandler(this.btn_remove_Click);

            this.btn_notify.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_notify.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_notify.Enabled   = false;
            this.btn_notify.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_notify.ForeColor = System.Drawing.Color.White;
            this.btn_notify.Location  = new System.Drawing.Point(635, 448);
            this.btn_notify.Name      = "btn_notify";
            this.btn_notify.Size      = new System.Drawing.Size(150, 40);
            this.btn_notify.TabIndex  = 34;
            this.btn_notify.Text      = "שלח הודעה";
            this.btn_notify.UseVisualStyleBackColor = false;
            this.btn_notify.Click    += new System.EventHandler(this.btn_notify_Click);

            this.btn_back.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font      = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location  = new System.Drawing.Point(870, 510);
            this.btn_back.Name      = "btn_back";
            this.btn_back.Size      = new System.Drawing.Size(185, 40);
            this.btn_back.TabIndex  = 35;
            this.btn_back.Text      = "חזרה לפעילויות";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click    += new System.EventHandler(this.btn_back_Click);
            //
            // ManageRosterPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = ThemeHelper.BG_CONTENT;
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_activity_info);
            this.Controls.Add(this.dataGridView_roster);
            this.Controls.Add(this.label_capacity);
            this.Controls.Add(this.label_form_header);
            this.Controls.Add(this.label_customer_lbl);
            this.Controls.Add(this.combo_customer);
            this.Controls.Add(this.label_boat_lbl);
            this.Controls.Add(this.combo_boat);
            this.Controls.Add(this.label_notes_lbl);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_assign_boat);
            this.Controls.Add(this.btn_assign_external_boat);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_notify);
            this.Controls.Add(this.btn_back);
            this.Name = "ManageRosterPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_roster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           label_title;
        private System.Windows.Forms.Label           label_activity_info;
        private System.Windows.Forms.DataGridView    dataGridView_roster;
        private System.Windows.Forms.Label           label_capacity;
        private System.Windows.Forms.Label           label_form_header;
        private System.Windows.Forms.Label           label_customer_lbl;
        private System.Windows.Forms.ComboBox        combo_customer;
        private System.Windows.Forms.Label           label_boat_lbl;
        private System.Windows.Forms.ComboBox        combo_boat;
        private System.Windows.Forms.Label           label_notes_lbl;
        private System.Windows.Forms.TextBox         txt_notes;
        private System.Windows.Forms.Label           label_error;
        private System.Windows.Forms.Button          btn_add;
        private System.Windows.Forms.Button          btn_assign_boat;
        private System.Windows.Forms.Button          btn_assign_external_boat;
        private System.Windows.Forms.Button          btn_remove;
        private System.Windows.Forms.Button          btn_notify;
        private System.Windows.Forms.Button          btn_back;
    }
}
