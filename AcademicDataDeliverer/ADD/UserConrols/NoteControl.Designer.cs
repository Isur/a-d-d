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
            this.menuStripSelect = new System.Windows.Forms.MenuStrip();
            this.uczelniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wydziałToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kierunekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przedmiotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROFILToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wYLOGUJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripSelect
            // 
            this.menuStripSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uczelniaToolStripMenuItem,
            this.wydziałToolStripMenuItem,
            this.kierunekToolStripMenuItem,
            this.przedmiotToolStripMenuItem,
            this.mENUToolStripMenuItem});
            this.menuStripSelect.Location = new System.Drawing.Point(0, 0);
            this.menuStripSelect.Name = "menuStripSelect";
            this.menuStripSelect.Size = new System.Drawing.Size(400, 24);
            this.menuStripSelect.TabIndex = 0;
            this.menuStripSelect.Text = "Menu";
            // 
            // uczelniaToolStripMenuItem
            // 
            this.uczelniaToolStripMenuItem.Name = "uczelniaToolStripMenuItem";
            this.uczelniaToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.uczelniaToolStripMenuItem.Text = "Uczelnia";
            // 
            // wydziałToolStripMenuItem
            // 
            this.wydziałToolStripMenuItem.Name = "wydziałToolStripMenuItem";
            this.wydziałToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.wydziałToolStripMenuItem.Text = "Wydział";
            // 
            // kierunekToolStripMenuItem
            // 
            this.kierunekToolStripMenuItem.Name = "kierunekToolStripMenuItem";
            this.kierunekToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.kierunekToolStripMenuItem.Text = "Kierunek";
            // 
            // przedmiotToolStripMenuItem
            // 
            this.przedmiotToolStripMenuItem.Name = "przedmiotToolStripMenuItem";
            this.przedmiotToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.przedmiotToolStripMenuItem.Text = "Przedmiot";
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(4, 28);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(120, 277);
            this.listBoxNotes.TabIndex = 1;
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Location = new System.Drawing.Point(131, 28);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(266, 278);
            this.richTextBoxNote.TabIndex = 2;
            this.richTextBoxNote.Text = "";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pROFILToolStripMenuItem,
            this.wYLOGUJToolStripMenuItem});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.mENUToolStripMenuItem.Text = "MENU";
            // 
            // pROFILToolStripMenuItem
            // 
            this.pROFILToolStripMenuItem.Name = "pROFILToolStripMenuItem";
            this.pROFILToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pROFILToolStripMenuItem.Text = "PROFIL";
            // 
            // wYLOGUJToolStripMenuItem
            // 
            this.wYLOGUJToolStripMenuItem.Name = "wYLOGUJToolStripMenuItem";
            this.wYLOGUJToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wYLOGUJToolStripMenuItem.Text = "WYLOGUJ";
            // 
            // NoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxNote);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.menuStripSelect);
            this.Name = "NoteControl";
            this.Size = new System.Drawing.Size(400, 309);
            this.menuStripSelect.ResumeLayout(false);
            this.menuStripSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripSelect;
        private System.Windows.Forms.ToolStripMenuItem uczelniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wydziałToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kierunekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przedmiotToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.RichTextBox richTextBoxNote;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROFILToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wYLOGUJToolStripMenuItem;
    }
}
