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
            this.buttonAddSubscribe = new System.Windows.Forms.Button();
            this.labelUserMail = new System.Windows.Forms.Label();
            this.labelUserPhone = new System.Windows.Forms.Label();
            this.buttonBackToNote = new System.Windows.Forms.Button();
            this.treeViewSubscribed = new System.Windows.Forms.TreeView();
            this.buttonDeleteSubscribe = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.labelUserLogin = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxUserLogin = new System.Windows.Forms.TextBox();
            this.textBoxUserMail = new System.Windows.Forms.TextBox();
            this.textBoxUserPhone = new System.Windows.Forms.TextBox();
            this.loadingProgressBar = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(232, 83);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(90, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "IMIE NAZWISKO";
            // 
            // buttonAddSubscribe
            // 
            this.buttonAddSubscribe.Location = new System.Drawing.Point(284, 210);
            this.buttonAddSubscribe.Name = "buttonAddSubscribe";
            this.buttonAddSubscribe.Size = new System.Drawing.Size(209, 23);
            this.buttonAddSubscribe.TabIndex = 4;
            this.buttonAddSubscribe.Text = "Subskrybuj Nowy";
            this.buttonAddSubscribe.UseVisualStyleBackColor = true;
            this.buttonAddSubscribe.Click += new System.EventHandler(this.buttonAddSubscribe_Click);
            // 
            // labelUserMail
            // 
            this.labelUserMail.AutoSize = true;
            this.labelUserMail.Location = new System.Drawing.Point(289, 136);
            this.labelUserMail.Name = "labelUserMail";
            this.labelUserMail.Size = new System.Drawing.Size(32, 13);
            this.labelUserMail.TabIndex = 5;
            this.labelUserMail.Text = "MAIL";
            // 
            // labelUserPhone
            // 
            this.labelUserPhone.AutoSize = true;
            this.labelUserPhone.Location = new System.Drawing.Point(226, 158);
            this.labelUserPhone.Name = "labelUserPhone";
            this.labelUserPhone.Size = new System.Drawing.Size(95, 13);
            this.labelUserPhone.TabIndex = 6;
            this.labelUserPhone.Text = "PHONE NUMBER";
            // 
            // buttonBackToNote
            // 
            this.buttonBackToNote.Location = new System.Drawing.Point(284, 181);
            this.buttonBackToNote.Name = "buttonBackToNote";
            this.buttonBackToNote.Size = new System.Drawing.Size(209, 23);
            this.buttonBackToNote.TabIndex = 7;
            this.buttonBackToNote.Text = "Powrót do notatek";
            this.buttonBackToNote.UseVisualStyleBackColor = true;
            this.buttonBackToNote.Click += new System.EventHandler(this.buttonBackToNote_Click);
            // 
            // treeViewSubscribed
            // 
            this.treeViewSubscribed.Location = new System.Drawing.Point(3, 3);
            this.treeViewSubscribed.Name = "treeViewSubscribed";
            this.treeViewSubscribed.Size = new System.Drawing.Size(209, 259);
            this.treeViewSubscribed.TabIndex = 8;
            // 
            // buttonDeleteSubscribe
            // 
            this.buttonDeleteSubscribe.Location = new System.Drawing.Point(284, 239);
            this.buttonDeleteSubscribe.Name = "buttonDeleteSubscribe";
            this.buttonDeleteSubscribe.Size = new System.Drawing.Size(209, 23);
            this.buttonDeleteSubscribe.TabIndex = 9;
            this.buttonDeleteSubscribe.Text = "Usuń wybraną subskrybcję";
            this.buttonDeleteSubscribe.UseVisualStyleBackColor = true;
            this.buttonDeleteSubscribe.Click += new System.EventHandler(this.buttonDeleteSubscribe_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(504, 3);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 10;
            this.buttonLogOut.Text = "Wyloguj się";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // labelUserLogin
            // 
            this.labelUserLogin.AutoSize = true;
            this.labelUserLogin.Location = new System.Drawing.Point(281, 107);
            this.labelUserLogin.Name = "labelUserLogin";
            this.labelUserLogin.Size = new System.Drawing.Size(40, 13);
            this.labelUserLogin.TabIndex = 11;
            this.labelUserLogin.Text = "LOGIN";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(353, 76);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(226, 20);
            this.textBoxUserName.TabIndex = 12;
            // 
            // textBoxUserLogin
            // 
            this.textBoxUserLogin.Location = new System.Drawing.Point(353, 103);
            this.textBoxUserLogin.Name = "textBoxUserLogin";
            this.textBoxUserLogin.ReadOnly = true;
            this.textBoxUserLogin.Size = new System.Drawing.Size(226, 20);
            this.textBoxUserLogin.TabIndex = 13;
            // 
            // textBoxUserMail
            // 
            this.textBoxUserMail.Location = new System.Drawing.Point(353, 129);
            this.textBoxUserMail.Name = "textBoxUserMail";
            this.textBoxUserMail.ReadOnly = true;
            this.textBoxUserMail.Size = new System.Drawing.Size(226, 20);
            this.textBoxUserMail.TabIndex = 14;
            // 
            // textBoxUserPhone
            // 
            this.textBoxUserPhone.Location = new System.Drawing.Point(353, 155);
            this.textBoxUserPhone.Name = "textBoxUserPhone";
            this.textBoxUserPhone.ReadOnly = true;
            this.textBoxUserPhone.Size = new System.Drawing.Size(226, 20);
            this.textBoxUserPhone.TabIndex = 15;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.loadingProgressBar.AnimationSpeed = 500;
            this.loadingProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.loadingProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.loadingProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadingProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadingProgressBar.InnerMargin = 2;
            this.loadingProgressBar.InnerWidth = -1;
            this.loadingProgressBar.Location = new System.Drawing.Point(250, 92);
            this.loadingProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.loadingProgressBar.MarqueeAnimationSpeed = 2000;
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.OuterColor = System.Drawing.Color.Gray;
            this.loadingProgressBar.OuterMargin = -25;
            this.loadingProgressBar.OuterWidth = 26;
            this.loadingProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loadingProgressBar.ProgressWidth = 25;
            this.loadingProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.loadingProgressBar.Size = new System.Drawing.Size(82, 84);
            this.loadingProgressBar.StartAngle = 270;
            this.loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.loadingProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.loadingProgressBar.SubscriptText = ".23";
            this.loadingProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.loadingProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.loadingProgressBar.SuperscriptText = "°C";
            this.loadingProgressBar.TabIndex = 16;
            this.loadingProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.loadingProgressBar.Value = 68;
            this.loadingProgressBar.Visible = false;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.textBoxUserPhone);
            this.Controls.Add(this.textBoxUserMail);
            this.Controls.Add(this.textBoxUserLogin);
            this.Controls.Add(this.textBoxUserName);
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
            this.Size = new System.Drawing.Size(582, 269);
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
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxUserLogin;
        private System.Windows.Forms.TextBox textBoxUserMail;
        private System.Windows.Forms.TextBox textBoxUserPhone;
        private CircularProgressBar.CircularProgressBar loadingProgressBar;
    }
}
