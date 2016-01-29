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
            this.CPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curWindow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteCMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDownloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.portListTextbox = new System.Windows.Forms.TextBox();
            this.totalConLabel = new System.Windows.Forms.Label();
            this.curConLabel = new System.Windows.Forms.Label();
            this.disableConsoleCheckbox = new System.Windows.Forms.CheckBox();
            this.removeControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverControl = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listenOnPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.removeControl.SuspendLayout();
            this.serverControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(1085, 467);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 21);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // cmdTextbox
            // 
            this.cmdTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTextbox.Location = new System.Drawing.Point(457, 468);
            this.cmdTextbox.Name = "cmdTextbox";
            this.cmdTextbox.Size = new System.Drawing.Size(622, 20);
            this.cmdTextbox.TabIndex = 4;
            // 
            // console
            // 
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.ForeColor = System.Drawing.Color.Lime;
            this.console.Location = new System.Drawing.Point(304, 289);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(856, 173);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // zombieListView
            // 
            this.zombieListView.AllowColumnReorder = true;
            this.zombieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Version,
            this.computerName,
            this.username,
            this.OS,
            this.CPU,
            this.RAM,
            this.AV,
            this.curWindow});
            this.zombieListView.FullRowSelect = true;
            this.zombieListView.GridLines = true;
            this.zombieListView.Location = new System.Drawing.Point(2, 27);
            this.zombieListView.Name = "zombieListView";
            this.zombieListView.Size = new System.Drawing.Size(1158, 243);
            this.zombieListView.TabIndex = 6;
            this.zombieListView.UseCompatibleStateImageBehavior = false;
            this.zombieListView.View = System.Windows.Forms.View.Details;
            this.zombieListView.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.zombieListView_ControlRemoved);
            this.zombieListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zombieListView_KeyDown);
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
            // 
            // OS
            // 
            this.OS.Text = "OS";
            this.OS.Width = 110;
            // 
            // CPU
            // 
            this.CPU.Text = "CPU";
            this.CPU.Width = 230;
            // 
            // RAM
            // 
            this.RAM.Text = "RAM";
            this.RAM.Width = 50;
            // 
            // AV
            // 
            this.AV.Text = "Anti-virus";
            this.AV.Width = 110;
            // 
            // curWindow
            // 
            this.curWindow.Text = "Current Window";
            this.curWindow.Width = 280;
            // 
            // clientControl
            // 
            this.clientControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardToolStripMenuItem,
            this.sendMessageToolStripMenuItem,
            this.remoteCMDToolStripMenuItem,
            this.remoteDownloadToolStripMenuItem1,
            this.restartToolStripMenuItem,
            this.killToolStripMenuItem});
            this.clientControl.Name = "clientControl";
            this.clientControl.Size = new System.Drawing.Size(173, 136);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.clipboardToolStripMenuItem.Text = "Clipboard";
            this.clipboardToolStripMenuItem.Click += new System.EventHandler(this.clipboardToolStripMenuItem_Click);
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Message";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
            // 
            // remoteCMDToolStripMenuItem
            // 
            this.remoteCMDToolStripMenuItem.Name = "remoteCMDToolStripMenuItem";
            this.remoteCMDToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.remoteCMDToolStripMenuItem.Text = "Remote CMD";
            this.remoteCMDToolStripMenuItem.Click += new System.EventHandler(this.remoteCMDToolStripMenuItem_Click);
            // 
            // remoteDownloadToolStripMenuItem1
            // 
            this.remoteDownloadToolStripMenuItem1.Name = "remoteDownloadToolStripMenuItem1";
            this.remoteDownloadToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.remoteDownloadToolStripMenuItem1.Text = "Remote Download";
            this.remoteDownloadToolStripMenuItem1.Click += new System.EventHandler(this.remoteDownloadToolStripMenuItem1_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.killToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.portListTextbox);
            this.groupBox1.Controls.Add(this.totalConLabel);
            this.groupBox1.Controls.Add(this.curConLabel);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 173);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // portListTextbox
            // 
            this.portListTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.portListTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portListTextbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portListTextbox.Location = new System.Drawing.Point(7, 25);
            this.portListTextbox.Multiline = true;
            this.portListTextbox.Name = "portListTextbox";
            this.portListTextbox.ReadOnly = true;
            this.portListTextbox.Size = new System.Drawing.Size(283, 36);
            this.portListTextbox.TabIndex = 2;
            this.portListTextbox.Text = "Listening on port(s):";
            // 
            // totalConLabel
            // 
            this.totalConLabel.AutoSize = true;
            this.totalConLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalConLabel.Location = new System.Drawing.Point(13, 152);
            this.totalConLabel.Name = "totalConLabel";
            this.totalConLabel.Size = new System.Drawing.Size(147, 15);
            this.totalConLabel.TabIndex = 1;
            this.totalConLabel.Text = "Total connections: 0";
            // 
            // curConLabel
            // 
            this.curConLabel.AutoSize = true;
            this.curConLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curConLabel.Location = new System.Drawing.Point(-1, 132);
            this.curConLabel.Name = "curConLabel";
            this.curConLabel.Size = new System.Drawing.Size(161, 15);
            this.curConLabel.TabIndex = 0;
            this.curConLabel.Text = "Current connections: 0";
            // 
            // disableConsoleCheckbox
            // 
            this.disableConsoleCheckbox.AutoSize = true;
            this.disableConsoleCheckbox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableConsoleCheckbox.Location = new System.Drawing.Point(304, 467);
            this.disableConsoleCheckbox.Name = "disableConsoleCheckbox";
            this.disableConsoleCheckbox.Size = new System.Drawing.Size(147, 22);
            this.disableConsoleCheckbox.TabIndex = 2;
            this.disableConsoleCheckbox.Text = "Disable console";
            this.disableConsoleCheckbox.UseVisualStyleBackColor = true;
            // 
            // removeControl
            // 
            this.removeControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.removeControl.Name = "removeControl";
            this.removeControl.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // serverControl
            // 
            this.serverControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.clientsToolStripMenuItem});
            this.serverControl.Location = new System.Drawing.Point(0, 0);
            this.serverControl.Name = "serverControl";
            this.serverControl.Size = new System.Drawing.Size(1166, 24);
            this.serverControl.TabIndex = 8;
            this.serverControl.Text = "menuStrip1";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listenOnPortToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // listenOnPortToolStripMenuItem
            // 
            this.listenOnPortToolStripMenuItem.Name = "listenOnPortToolStripMenuItem";
            this.listenOnPortToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.listenOnPortToolStripMenuItem.Text = "Listen on port";
            this.listenOnPortToolStripMenuItem.Click += new System.EventHandler(this.listenOnPortToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteDownloadToolStripMenuItem});
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.clientsToolStripMenuItem.Text = "Clients";
            // 
            // remoteDownloadToolStripMenuItem
            // 
            this.remoteDownloadToolStripMenuItem.Name = "remoteDownloadToolStripMenuItem";
            this.remoteDownloadToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.remoteDownloadToolStripMenuItem.Text = "Remote Download";
            this.remoteDownloadToolStripMenuItem.Click += new System.EventHandler(this.remoteDownloadToolStripMenuItem_Click);
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 491);
            this.Controls.Add(this.serverControl);
            this.Controls.Add(this.disableConsoleCheckbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zombieListView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmdTextbox);
            this.Controls.Add(this.console);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.serverControl;
            this.Name = "ServerMainForm";
            this.Text = "CCSURAT-Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.clientControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.removeControl.ResumeLayout(false);
            this.serverControl.ResumeLayout(false);
            this.serverControl.PerformLayout();
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
        private System.Windows.Forms.ColumnHeader CPU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label totalConLabel;
        private System.Windows.Forms.Label curConLabel;
        private System.Windows.Forms.ColumnHeader RAM;
        private System.Windows.Forms.ColumnHeader AV;
        private System.Windows.Forms.ColumnHeader curWindow;
        private System.Windows.Forms.ContextMenuStrip removeControl;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteCMDToolStripMenuItem;
        private System.Windows.Forms.CheckBox disableConsoleCheckbox;
        private System.Windows.Forms.TextBox portListTextbox;
        private System.Windows.Forms.MenuStrip serverControl;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listenOnPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDownloadToolStripMenuItem1;
    }
}

