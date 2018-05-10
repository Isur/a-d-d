namespace ADD
{
    partial class MainForm
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
            this.labelTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTest.Location = new System.Drawing.Point(78, 0);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(221, 73);
            this.labelTest.TabIndex = 0;
            this.labelTest.Text = "A.D.D.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 93);
            this.Controls.Add(this.labelTest);
            this.Name = "MainForm";
            this.Text = "Academic Data Delivery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTest;
    }
}