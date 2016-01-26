namespace CCSURAT_Server
{
    partial class ServerMainForm
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
            this.sendButton = new System.Windows.Forms.Button();
            this.cmdTextbox = new System.Windows.Forms.TextBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.zombieListView = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.computerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(540, 484);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 21);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // cmdTextbox
            // 
            this.cmdTextbox.Location = new System.Drawing.Point(2, 484);
            this.cmdTextbox.Name = "cmdTextbox";
            this.cmdTextbox.Size = new System.Drawing.Size(532, 20);
            this.cmdTextbox.TabIndex = 4;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.ForeColor = System.Drawing.Color.Lime;
            this.console.Location = new System.Drawing.Point(0, 253);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(619, 229);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // zombieListView
            // 
            this.zombieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Version,
            this.computerName,
            this.username,
            this.OS});
            this.zombieListView.FullRowSelect = true;
            this.zombieListView.GridLines = true;
            this.zombieListView.Location = new System.Drawing.Point(2, 4);
            this.zombieListView.Name = "zombieListView";
            this.zombieListView.Size = new System.Drawing.Size(613, 243);
            this.zombieListView.TabIndex = 6;
            this.zombieListView.UseCompatibleStateImageBehavior = false;
            this.zombieListView.View = System.Windows.Forms.View.Details;
            this.zombieListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zombieListView_MouseDown);
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 100;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 90;
            // 
            // computerName
            // 
            this.computerName.Text = "Computer Name";
            this.computerName.Width = 120;
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 70;
            // 
            // OS
            // 
            this.OS.Text = "OS";
            this.OS.Width = 110;
            // 
            // clientControl
            // 
            this.clientControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.killToolStripMenuItem});
            this.clientControl.Name = "clientControl";
            this.clientControl.Size = new System.Drawing.Size(150, 70);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Message";
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 508);
            this.Controls.Add(this.zombieListView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmdTextbox);
            this.Controls.Add(this.console);
            this.Name = "ServerMainForm";
            this.Text = "CCSURAT-Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.clientControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox cmdTextbox;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader computerName;
        private System.Windows.Forms.ColumnHeader username;
        public System.Windows.Forms.ListView zombieListView;
        private System.Windows.Forms.ColumnHeader OS;
        private System.Windows.Forms.ContextMenuStrip clientControl;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
    }
}

