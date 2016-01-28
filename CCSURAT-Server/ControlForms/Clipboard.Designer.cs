namespace CCSURAT_Server.ControlForms
{
    partial class Clipboard
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
            this.clipboardTextbox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clipboardTextbox
            // 
            this.clipboardTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardTextbox.Location = new System.Drawing.Point(0, 27);
            this.clipboardTextbox.Multiline = true;
            this.clipboardTextbox.Name = "clipboardTextbox";
            this.clipboardTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clipboardTextbox.Size = new System.Drawing.Size(674, 255);
            this.clipboardTextbox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setClipboardToolStripMenuItem,
            this.getClipboardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setClipboardToolStripMenuItem
            // 
            this.setClipboardToolStripMenuItem.Name = "setClipboardToolStripMenuItem";
            this.setClipboardToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.setClipboardToolStripMenuItem.Text = "Set Clipboard";
            this.setClipboardToolStripMenuItem.Click += new System.EventHandler(this.setClipboardToolStripMenuItem_Click);
            // 
            // getClipboardToolStripMenuItem
            // 
            this.getClipboardToolStripMenuItem.Name = "getClipboardToolStripMenuItem";
            this.getClipboardToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.getClipboardToolStripMenuItem.Text = "Get Clipboard";
            this.getClipboardToolStripMenuItem.Click += new System.EventHandler(this.getClipboardToolStripMenuItem_Click);
            // 
            // Clipboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 282);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.clipboardTextbox);
            this.Name = "Clipboard";
            this.Text = "Clipboard";
            this.Load += new System.EventHandler(this.Clipboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox clipboardTextbox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getClipboardToolStripMenuItem;
    }
}