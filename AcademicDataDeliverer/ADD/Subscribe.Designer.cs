namespace ADD
{
    partial class Subscribe
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new CircularProgressBar.CircularProgressBar();
            this.comboBoxSpecialization = new System.Windows.Forms.ComboBox();
            this.comboBoxFaculty = new System.Windows.Forms.ComboBox();
            this.comboBoxCollege = new System.Windows.Forms.ComboBox();
            this.labelSpecialization = new System.Windows.Forms.Label();
            this.labelFaculty = new System.Windows.Forms.Label();
            this.labelCollege = new System.Windows.Forms.Label();
            this.buttonSubscribe = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progressBar.AnimationSpeed = 500;
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressBar.InnerMargin = 2;
            this.progressBar.InnerWidth = -1;
            this.progressBar.Location = new System.Drawing.Point(60, 11);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.MarqueeAnimationSpeed = 2000;
            this.progressBar.Name = "progressBar";
            this.progressBar.OuterColor = System.Drawing.Color.Gray;
            this.progressBar.OuterMargin = -25;
            this.progressBar.OuterWidth = 26;
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.progressBar.ProgressWidth = 25;
            this.progressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.progressBar.Size = new System.Drawing.Size(82, 84);
            this.progressBar.StartAngle = 270;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progressBar.SubscriptText = ".23";
            this.progressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progressBar.SuperscriptText = "°C";
            this.progressBar.TabIndex = 26;
            this.progressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.progressBar.Value = 68;
            this.progressBar.Visible = false;
            // 
            // comboBoxSpecialization
            // 
            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(58, 59);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            this.comboBoxSpecialization.Size = new System.Drawing.Size(139, 21);
            this.comboBoxSpecialization.TabIndex = 25;
            this.comboBoxSpecialization.DropDown += new System.EventHandler(this.comboBoxSpecialization_DropDown);
            // 
            // comboBoxFaculty
            // 
            this.comboBoxFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFaculty.FormattingEnabled = true;
            this.comboBoxFaculty.Location = new System.Drawing.Point(58, 32);
            this.comboBoxFaculty.Name = "comboBoxFaculty";
            this.comboBoxFaculty.Size = new System.Drawing.Size(139, 21);
            this.comboBoxFaculty.TabIndex = 24;
            this.comboBoxFaculty.DropDown += new System.EventHandler(this.comboBoxFaculty_DropDown);
            // 
            // comboBoxCollege
            // 
            this.comboBoxCollege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCollege.FormattingEnabled = true;
            this.comboBoxCollege.Location = new System.Drawing.Point(58, 5);
            this.comboBoxCollege.Name = "comboBoxCollege";
            this.comboBoxCollege.Size = new System.Drawing.Size(139, 21);
            this.comboBoxCollege.TabIndex = 23;
            this.comboBoxCollege.DropDown += new System.EventHandler(this.comboBoxCollege_DropDown);
            // 
            // labelSpecialization
            // 
            this.labelSpecialization.AutoSize = true;
            this.labelSpecialization.Location = new System.Drawing.Point(6, 62);
            this.labelSpecialization.Name = "labelSpecialization";
            this.labelSpecialization.Size = new System.Drawing.Size(49, 13);
            this.labelSpecialization.TabIndex = 22;
            this.labelSpecialization.Text = "Kierunek";
            // 
            // labelFaculty
            // 
            this.labelFaculty.AutoSize = true;
            this.labelFaculty.Location = new System.Drawing.Point(9, 35);
            this.labelFaculty.Name = "labelFaculty";
            this.labelFaculty.Size = new System.Drawing.Size(46, 13);
            this.labelFaculty.TabIndex = 21;
            this.labelFaculty.Text = "Wydział";
            // 
            // labelCollege
            // 
            this.labelCollege.AutoSize = true;
            this.labelCollege.Location = new System.Drawing.Point(7, 8);
            this.labelCollege.Name = "labelCollege";
            this.labelCollege.Size = new System.Drawing.Size(48, 13);
            this.labelCollege.TabIndex = 20;
            this.labelCollege.Text = "Uczelnia";
            // 
            // buttonSubscribe
            // 
            this.buttonSubscribe.Location = new System.Drawing.Point(118, 113);
            this.buttonSubscribe.Name = "buttonSubscribe";
            this.buttonSubscribe.Size = new System.Drawing.Size(75, 23);
            this.buttonSubscribe.TabIndex = 27;
            this.buttonSubscribe.Text = "Subskrybuj";
            this.buttonSubscribe.UseVisualStyleBackColor = true;
            this.buttonSubscribe.Click += new System.EventHandler(this.buttonSubscribe_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(10, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NewSubscribeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 148);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubscribe);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.comboBoxSpecialization);
            this.Controls.Add(this.comboBoxFaculty);
            this.Controls.Add(this.comboBoxCollege);
            this.Controls.Add(this.labelSpecialization);
            this.Controls.Add(this.labelFaculty);
            this.Controls.Add(this.labelCollege);
            this.Name = "NewSubscribeDialog";
            this.Text = "Subskrybuj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar progressBar;
        private System.Windows.Forms.ComboBox comboBoxSpecialization;
        private System.Windows.Forms.ComboBox comboBoxFaculty;
        private System.Windows.Forms.ComboBox comboBoxCollege;
        private System.Windows.Forms.Label labelSpecialization;
        private System.Windows.Forms.Label labelFaculty;
        private System.Windows.Forms.Label labelCollege;
        private System.Windows.Forms.Button buttonSubscribe;
        private System.Windows.Forms.Button buttonCancel;
    }
}