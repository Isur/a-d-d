namespace ADD.UserConrols
{
    partial class NoteControl
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
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.loadingProgressBar = new CircularProgressBar.CircularProgressBar();
            this.treeViewNotes = new System.Windows.Forms.TreeView();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Location = new System.Drawing.Point(228, 28);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(266, 278);
            this.richTextBoxNote.TabIndex = 2;
            this.richTextBoxNote.Text = "";
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
            this.loadingProgressBar.Location = new System.Drawing.Point(218, 106);
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
            this.loadingProgressBar.TabIndex = 7;
            this.loadingProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.loadingProgressBar.Value = 68;
            this.loadingProgressBar.Visible = false;
            // 
            // treeViewNotes
            // 
            this.treeViewNotes.Location = new System.Drawing.Point(4, 27);
            this.treeViewNotes.Name = "treeViewNotes";
            this.treeViewNotes.Size = new System.Drawing.Size(218, 278);
            this.treeViewNotes.TabIndex = 8;
            this.treeViewNotes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewNotes_NodeMouseDoubleClick);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(0, 0);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 9;
            this.buttonLogout.Text = "Wyloguj";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.Location = new System.Drawing.Point(419, 3);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonProfile.TabIndex = 10;
            this.buttonProfile.Text = "Profil";
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(228, 0);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 11;
            this.buttonDownload.Text = "Pobierz";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // NoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonProfile);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.treeViewNotes);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.richTextBoxNote);
            this.Name = "NoteControl";
            this.Size = new System.Drawing.Size(498, 309);
            this.Load += new System.EventHandler(this.NoteControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxNote;
        private CircularProgressBar.CircularProgressBar loadingProgressBar;
        private System.Windows.Forms.TreeView treeViewNotes;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonDownload;
    }
}
