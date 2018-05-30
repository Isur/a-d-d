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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Colleges");
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonAddSubscribe = new System.Windows.Forms.Button();
            this.labelUserMail = new System.Windows.Forms.Label();
            this.labelUserPhone = new System.Windows.Forms.Label();
            this.buttonBackToNote = new System.Windows.Forms.Button();
            this.treeViewSubscribed = new System.Windows.Forms.TreeView();
            this.buttonDeleteSubscribe = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelUserLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(17, 40);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(90, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "IMIE NAZWISKO";
            // 
            // buttonAddSubscribe
            // 
            this.buttonAddSubscribe.Location = new System.Drawing.Point(15, 426);
            this.buttonAddSubscribe.Name = "buttonAddSubscribe";
            this.buttonAddSubscribe.Size = new System.Drawing.Size(209, 23);
            this.buttonAddSubscribe.TabIndex = 4;
            this.buttonAddSubscribe.Text = "Subskrybuj Nowy";
            this.buttonAddSubscribe.UseVisualStyleBackColor = true;
            // 
            // labelUserMail
            // 
            this.labelUserMail.AutoSize = true;
            this.labelUserMail.Location = new System.Drawing.Point(17, 83);
            this.labelUserMail.Name = "labelUserMail";
            this.labelUserMail.Size = new System.Drawing.Size(32, 13);
            this.labelUserMail.TabIndex = 5;
            this.labelUserMail.Text = "MAIL";
            // 
            // labelUserPhone
            // 
            this.labelUserPhone.AutoSize = true;
            this.labelUserPhone.Location = new System.Drawing.Point(17, 104);
            this.labelUserPhone.Name = "labelUserPhone";
            this.labelUserPhone.Size = new System.Drawing.Size(95, 13);
            this.labelUserPhone.TabIndex = 6;
            this.labelUserPhone.Text = "PHONE NUMBER";
            // 
            // buttonBackToNote
            // 
            this.buttonBackToNote.Location = new System.Drawing.Point(15, 456);
            this.buttonBackToNote.Name = "buttonBackToNote";
            this.buttonBackToNote.Size = new System.Drawing.Size(209, 23);
            this.buttonBackToNote.TabIndex = 7;
            this.buttonBackToNote.Text = "Powrót do notatek";
            this.buttonBackToNote.UseVisualStyleBackColor = true;
            this.buttonBackToNote.Click += new System.EventHandler(this.buttonBackToNote_Click);
            // 
            // treeViewSubscribed
            // 
            this.treeViewSubscribed.Location = new System.Drawing.Point(15, 132);
            this.treeViewSubscribed.Name = "treeViewSubscribed";
            treeNode2.Name = "NodeColleges";
            treeNode2.Text = "Colleges";
            this.treeViewSubscribed.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeViewSubscribed.Size = new System.Drawing.Size(209, 259);
            this.treeViewSubscribed.TabIndex = 8;
            // 
            // buttonDeleteSubscribe
            // 
            this.buttonDeleteSubscribe.Location = new System.Drawing.Point(15, 397);
            this.buttonDeleteSubscribe.Name = "buttonDeleteSubscribe";
            this.buttonDeleteSubscribe.Size = new System.Drawing.Size(209, 23);
            this.buttonDeleteSubscribe.TabIndex = 9;
            this.buttonDeleteSubscribe.Text = "Usuń wybraną subskrybcję";
            this.buttonDeleteSubscribe.UseVisualStyleBackColor = true;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(156, 8);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 10;
            this.buttonLogOut.Text = "Wyloguj się";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // labelUserLogin
            // 
            this.labelUserLogin.AutoSize = true;
            this.labelUserLogin.Location = new System.Drawing.Point(17, 62);
            this.labelUserLogin.Name = "labelUserLogin";
            this.labelUserLogin.Size = new System.Drawing.Size(40, 13);
            this.labelUserLogin.TabIndex = 11;
            this.labelUserLogin.Text = "LOGIN";
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelUserLogin);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonDeleteSubscribe);
            this.Controls.Add(this.treeViewSubscribed);
            this.Controls.Add(this.buttonBackToNote);
            this.Controls.Add(this.labelUserPhone);
            this.Controls.Add(this.labelUserMail);
            this.Controls.Add(this.buttonAddSubscribe);
            this.Controls.Add(this.labelUserName);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(240, 500);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonAddSubscribe;
        private System.Windows.Forms.Label labelUserMail;
        private System.Windows.Forms.Label labelUserPhone;
        private System.Windows.Forms.Button buttonBackToNote;
        private System.Windows.Forms.TreeView treeViewSubscribed;
        private System.Windows.Forms.Button buttonDeleteSubscribe;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Label labelUserLogin;
    }
}
