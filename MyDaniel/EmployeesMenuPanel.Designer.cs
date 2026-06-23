namespace MyDaniel
{
    partial class EmployeesMenuPanel
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
            this.label_title       = new System.Windows.Forms.Label();
            this.btn_create        = new System.Windows.Forms.Button();
            this.btn_update_delete = new System.Windows.Forms.Button();
            this.btn_watch         = new System.Windows.Forms.Button();
            this.btn_back          = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label_title
            //
            this.label_title.AutoSize = false;
            this.label_title.Font = new System.Drawing.Font("David", 36F, System.Drawing.FontStyle.Bold);
            this.label_title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_title.Location = new System.Drawing.Point(10, 20);
            this.label_title.Size = new System.Drawing.Size(975, 52);
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_title.Name = "label_title";
            this.label_title.TabIndex = 0;
            this.label_title.Text = "ניהול עובדים";
            //
            // btn_create
            //
            this.btn_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_create.Font = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Bold);
            this.btn_create.Location = new System.Drawing.Point(80, 170);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(270, 90);
            this.btn_create.TabIndex = 1;
            this.btn_create.Text = "הוספת עובד חדש";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            //
            // btn_update_delete
            //
            this.btn_update_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update_delete.Font = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Bold);
            this.btn_update_delete.Location = new System.Drawing.Point(80, 285);
            this.btn_update_delete.Name = "btn_update_delete";
            this.btn_update_delete.Size = new System.Drawing.Size(270, 90);
            this.btn_update_delete.TabIndex = 2;
            this.btn_update_delete.Text = "עדכון / מחיקת עובד";
            this.btn_update_delete.UseVisualStyleBackColor = true;
            this.btn_update_delete.Click += new System.EventHandler(this.btn_update_delete_Click);
            //
            // btn_watch
            //
            this.btn_watch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_watch.Font = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Bold);
            this.btn_watch.Location = new System.Drawing.Point(570, 225);
            this.btn_watch.Name = "btn_watch";
            this.btn_watch.Size = new System.Drawing.Size(270, 90);
            this.btn_watch.TabIndex = 3;
            this.btn_watch.Text = "צפייה בכל העובדים";
            this.btn_watch.UseVisualStyleBackColor = true;
            this.btn_watch.Click += new System.EventHandler(this.btn_watch_Click);
            //
            // btn_back
            //
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Font = new System.Drawing.Font("David", 14F, System.Drawing.FontStyle.Bold);
            this.btn_back.Location = new System.Drawing.Point(425, 510);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(150, 42);
            this.btn_back.TabIndex = 4;
            this.btn_back.Text = "חזרה";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            //
            // EmployeesMenuPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_watch);
            this.Controls.Add(this.btn_update_delete);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.label_title);
            this.Name = "EmployeesMenuPanel";
            this.Size = new System.Drawing.Size(1000, 620);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label  label_title;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_update_delete;
        private System.Windows.Forms.Button btn_watch;
        private System.Windows.Forms.Button btn_back;
    }
}
