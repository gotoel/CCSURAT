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
            this.components = new System.ComponentModel.Container();
            this.cmdPromptTextbox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdTextbox = new System.Windows.Forms.TextBox();
            this.cmdSendButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPromptTextbox
            // 
            this.cmdPromptTextbox.ContextMenuStrip = this.contextMenuStrip1;
            this.cmdPromptTextbox.Location = new System.Drawing.Point(1, 2);
            this.cmdPromptTextbox.Multiline = true;
            this.cmdPromptTextbox.Name = "cmdPromptTextbox";
            this.cmdPromptTextbox.ReadOnly = true;
            this.cmdPromptTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdPromptTextbox.Size = new System.Drawing.Size(559, 406);
            this.cmdPromptTextbox.TabIndex = 0;
            this.cmdPromptTextbox.TextChanged += new System.EventHandler(this.cmdPromptTextbox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // cmdTextbox
            // 
            this.cmdTextbox.Location = new System.Drawing.Point(4, 413);
            this.cmdTextbox.Name = "cmdTextbox";
            this.cmdTextbox.Size = new System.Drawing.Size(485, 20);
            this.cmdTextbox.TabIndex = 1;
            // 
            // cmdSendButton
            // 
            this.cmdSendButton.Location = new System.Drawing.Point(495, 413);
            this.cmdSendButton.Name = "cmdSendButton";
            this.cmdSendButton.Size = new System.Drawing.Size(59, 20);
            this.cmdSendButton.TabIndex = 2;
            this.cmdSendButton.Text = "Send";
            this.cmdSendButton.UseVisualStyleBackColor = true;
            this.cmdSendButton.Click += new System.EventHandler(this.cmdSendButton_Click);
            // 
            // RemoteCMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 438);
            this.Controls.Add(this.cmdSendButton);
            this.Controls.Add(this.cmdTextbox);
            this.Controls.Add(this.cmdPromptTextbox);
            this.Name = "RemoteCMD";
            this.Text = "RemoteCMD";
            this.Load += new System.EventHandler(this.RemoteCMD_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cmdPromptTextbox;
        private System.Windows.Forms.TextBox cmdTextbox;
        private System.Windows.Forms.Button cmdSendButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}