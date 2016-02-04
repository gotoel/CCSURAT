using System.Windows.Forms;

namespace CCSURAT_Server.ControlForms
{
    partial class RemoteCMD
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
            this.cmdPromptTextbox = new System.Windows.Forms.TextBox();
            this.cmdTextbox = new System.Windows.Forms.TextBox();
            this.cmdSendButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPromptTextbox
            // 
            this.cmdPromptTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPromptTextbox.Location = new System.Drawing.Point(1, 28);
            this.cmdPromptTextbox.Multiline = true;
            this.cmdPromptTextbox.Name = "cmdPromptTextbox";
            this.cmdPromptTextbox.ReadOnly = true;
            this.cmdPromptTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdPromptTextbox.Size = new System.Drawing.Size(559, 380);
            this.cmdPromptTextbox.TabIndex = 0;
            this.cmdPromptTextbox.TextChanged += new System.EventHandler(this.cmdPromptTextbox_TextChanged);
            // 
            // cmdTextbox
            // 
            this.cmdTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTextbox.Location = new System.Drawing.Point(4, 413);
            this.cmdTextbox.Name = "cmdTextbox";
            this.cmdTextbox.Size = new System.Drawing.Size(485, 20);
            this.cmdTextbox.TabIndex = 1;
            // 
            // cmdSendButton
            // 
            this.cmdSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSendButton.Location = new System.Drawing.Point(495, 413);
            this.cmdSendButton.Name = "cmdSendButton";
            this.cmdSendButton.Size = new System.Drawing.Size(59, 20);
            this.cmdSendButton.TabIndex = 2;
            this.cmdSendButton.Text = "Send";
            this.cmdSendButton.UseVisualStyleBackColor = true;
            this.cmdSendButton.Click += new System.EventHandler(this.cmdSendButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.stopToolStripMenuItem1,
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem1_Click);
            // 
            // stopToolStripMenuItem1
            // 
            this.stopToolStripMenuItem1.Name = "stopToolStripMenuItem1";
            this.stopToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem1.Text = "Stop";
            this.stopToolStripMenuItem1.Click += new System.EventHandler(this.stopToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // RemoteCMD
            // 
            this.AcceptButton = this.cmdSendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 438);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdSendButton);
            this.Controls.Add(this.cmdTextbox);
            this.Controls.Add(this.cmdPromptTextbox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RemoteCMD";
            this.ShowIcon = false;
            this.Text = "RemoteCMD";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cmdPromptTextbox;
        private System.Windows.Forms.TextBox cmdTextbox;
        private System.Windows.Forms.Button cmdSendButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}