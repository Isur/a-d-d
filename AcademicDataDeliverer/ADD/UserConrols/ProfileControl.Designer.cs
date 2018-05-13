namespace ADD.UserConrols
{
    partial class ProfileControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserName = new System.Windows.Forms.Label();
            this.listBoxCollege = new System.Windows.Forms.ListBox();
            this.listBoxFaculty = new System.Windows.Forms.ListBox();
            this.listBoxSpecialization = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(0, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(90, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "IMIE NAZWISKO";
            // 
            // listBoxCollege
            // 
            this.listBoxCollege.FormattingEnabled = true;
            this.listBoxCollege.Location = new System.Drawing.Point(4, 43);
            this.listBoxCollege.Name = "listBoxCollege";
            this.listBoxCollege.Size = new System.Drawing.Size(120, 95);
            this.listBoxCollege.TabIndex = 1;
            // 
            // listBoxFaculty
            // 
            this.listBoxFaculty.FormattingEnabled = true;
            this.listBoxFaculty.Location = new System.Drawing.Point(4, 145);
            this.listBoxFaculty.Name = "listBoxFaculty";
            this.listBoxFaculty.Size = new System.Drawing.Size(120, 95);
            this.listBoxFaculty.TabIndex = 2;
            // 
            // listBoxSpecialization
            // 
            this.listBoxSpecialization.FormattingEnabled = true;
            this.listBoxSpecialization.Location = new System.Drawing.Point(4, 247);
            this.listBoxSpecialization.Name = "listBoxSpecialization";
            this.listBoxSpecialization.Size = new System.Drawing.Size(120, 95);
            this.listBoxSpecialization.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Subskrybuj Nowy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxSpecialization);
            this.Controls.Add(this.listBoxFaculty);
            this.Controls.Add(this.listBoxCollege);
            this.Controls.Add(this.labelUserName);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(136, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.ListBox listBoxCollege;
        private System.Windows.Forms.ListBox listBoxFaculty;
        private System.Windows.Forms.ListBox listBoxSpecialization;
        private System.Windows.Forms.Button button1;
    }
}
