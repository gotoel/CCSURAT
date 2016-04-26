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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMainForm));
            this.sendButton = new System.Windows.Forms.Button();
            this.cmdTextbox = new System.Windows.Forms.TextBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.zombieListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ping = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurWindow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.remoteCMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDownloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.windowManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.funToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.networkPerfGroupbox = new System.Windows.Forms.GroupBox();
            this.downSpeedLabel = new System.Windows.Forms.Label();
            this.upSpeedLabel = new System.Windows.Forms.Label();
            this.ramUsageLabel = new System.Windows.Forms.Label();
            this.cpuUsageLabel = new System.Windows.Forms.Label();
            this.perfTimer = new System.Windows.Forms.Timer(this.components);
            this.disablePerfCheckbox = new System.Windows.Forms.CheckBox();
            this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clientControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.removeControl.SuspendLayout();
            this.serverControl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.networkPerfGroupbox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(1106, 501);
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
            this.cmdTextbox.Location = new System.Drawing.Point(620, 502);
            this.cmdTextbox.Name = "cmdTextbox";
            this.cmdTextbox.Size = new System.Drawing.Size(480, 20);
            this.cmdTextbox.TabIndex = 4;
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ForeColor = System.Drawing.Color.Lime;
            this.console.Location = new System.Drawing.Point(3, 22);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(685, 147);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // zombieListView
            // 
            this.zombieListView.AllowColumnReorder = true;
            this.zombieListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zombieListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zombieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.IP,
            this.Ping,
            this.Version,
            this.ComputerName,
            this.User,
            this.OS,
            this.CPU,
            this.RAM,
            this.AV,
            this.CurWindow});
            this.zombieListView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zombieListView.FullRowSelect = true;
            this.zombieListView.GridLines = true;
            this.zombieListView.Location = new System.Drawing.Point(0, 27);
            this.zombieListView.Name = "zombieListView";
            this.zombieListView.Size = new System.Drawing.Size(1187, 277);
            this.zombieListView.TabIndex = 6;
            this.zombieListView.UseCompatibleStateImageBehavior = false;
            this.zombieListView.View = System.Windows.Forms.View.Details;
            this.zombieListView.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.zombieListView_ControlRemoved);
            this.zombieListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zombieListView_KeyDown);
            this.zombieListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zombieListView_MouseDown);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 80;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 100;
            // 
            // Ping
            // 
            this.Ping.Text = "Ping";
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 105;
            // 
            // ComputerName
            // 
            this.ComputerName.Text = "Computer Name";
            this.ComputerName.Width = 125;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 70;
            // 
            // OS
            // 
            this.OS.Text = "OS";
            this.OS.Width = 120;
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
            this.AV.Width = 120;
            // 
            // CurWindow
            // 
            this.CurWindow.Text = "Current Window";
            this.CurWindow.Width = 265;
            // 
            // clientControl
            // 
            this.clientControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardToolStripMenuItem,
            this.sendMessageToolStripMenuItem,
            this.toolStripSeparator1,
            this.remoteCMDToolStripMenuItem,
            this.remoteDesktopToolStripMenuItem,
            this.remoteDownloadToolStripMenuItem1,
            this.toolStripSeparator2,
            this.windowManagerToolStripMenuItem,
            this.toolStripSeparator4,
            this.funToolStripMenuItem,
            this.toolStripSeparator3,
            this.restartToolStripMenuItem,
            this.killToolStripMenuItem});
            this.clientControl.Name = "clientControl";
            this.clientControl.Size = new System.Drawing.Size(173, 226);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // remoteCMDToolStripMenuItem
            // 
            this.remoteCMDToolStripMenuItem.Name = "remoteCMDToolStripMenuItem";
            this.remoteCMDToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.remoteCMDToolStripMenuItem.Text = "Remote CMD";
            this.remoteCMDToolStripMenuItem.Click += new System.EventHandler(this.remoteCMDToolStripMenuItem_Click);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.remoteDesktopToolStripMenuItem_Click);
            // 
            // remoteDownloadToolStripMenuItem1
            // 
            this.remoteDownloadToolStripMenuItem1.Name = "remoteDownloadToolStripMenuItem1";
            this.remoteDownloadToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.remoteDownloadToolStripMenuItem1.Text = "Remote Download";
            this.remoteDownloadToolStripMenuItem1.Click += new System.EventHandler(this.remoteDownloadToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // windowManagerToolStripMenuItem
            // 
            this.windowManagerToolStripMenuItem.Name = "windowManagerToolStripMenuItem";
            this.windowManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.windowManagerToolStripMenuItem.Text = "Window Manager";
            this.windowManagerToolStripMenuItem.Click += new System.EventHandler(this.windowManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(169, 6);
            // 
            // funToolStripMenuItem
            // 
            this.funToolStripMenuItem.Name = "funToolStripMenuItem";
            this.funToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.funToolStripMenuItem.Text = "Fun";
            this.funToolStripMenuItem.Click += new System.EventHandler(this.funToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.portListTextbox);
            this.groupBox1.Controls.Add(this.totalConLabel);
            this.groupBox1.Controls.Add(this.curConLabel);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 172);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // portListTextbox
            // 
            this.portListTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.portListTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portListTextbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.totalConLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalConLabel.Location = new System.Drawing.Point(15, 152);
            this.totalConLabel.Name = "totalConLabel";
            this.totalConLabel.Size = new System.Drawing.Size(145, 16);
            this.totalConLabel.TabIndex = 1;
            this.totalConLabel.Text = "Total connections: 0";
            // 
            // curConLabel
            // 
            this.curConLabel.AutoSize = true;
            this.curConLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curConLabel.Location = new System.Drawing.Point(-1, 132);
            this.curConLabel.Name = "curConLabel";
            this.curConLabel.Size = new System.Drawing.Size(161, 16);
            this.curConLabel.TabIndex = 0;
            this.curConLabel.Text = "Current connections: 0";
            // 
            // disableConsoleCheckbox
            // 
            this.disableConsoleCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disableConsoleCheckbox.AutoSize = true;
            this.disableConsoleCheckbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableConsoleCheckbox.Location = new System.Drawing.Point(490, 503);
            this.disableConsoleCheckbox.Name = "disableConsoleCheckbox";
            this.disableConsoleCheckbox.Size = new System.Drawing.Size(124, 18);
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
            this.clientsToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.serverControl.Location = new System.Drawing.Point(0, 0);
            this.serverControl.Name = "serverControl";
            this.serverControl.Size = new System.Drawing.Size(1187, 24);
            this.serverControl.TabIndex = 8;
            this.serverControl.Text = "menuStrip1";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listenOnPortToolStripMenuItem});
            this.controlToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.controlToolStripMenuItem.Text = "Server";
            // 
            // listenOnPortToolStripMenuItem
            // 
            this.listenOnPortToolStripMenuItem.Name = "listenOnPortToolStripMenuItem";
            this.listenOnPortToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.listenOnPortToolStripMenuItem.Text = "Listen on port";
            this.listenOnPortToolStripMenuItem.Click += new System.EventHandler(this.listenOnPortToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteDownloadToolStripMenuItem});
            this.clientsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.clientsToolStripMenuItem.Text = "Clients";
            // 
            // remoteDownloadToolStripMenuItem
            // 
            this.remoteDownloadToolStripMenuItem.Name = "remoteDownloadToolStripMenuItem";
            this.remoteDownloadToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.remoteDownloadToolStripMenuItem.Text = "Remote Download";
            this.remoteDownloadToolStripMenuItem.Click += new System.EventHandler(this.remoteDownloadToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // pingTimer
            // 
            this.pingTimer.Interval = 2000;
            this.pingTimer.Tick += new System.EventHandler(this.pingTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.networkPerfGroupbox);
            this.groupBox2.Controls.Add(this.ramUsageLabel);
            this.groupBox2.Controls.Add(this.cpuUsageLabel);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(308, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 173);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Performance";
            // 
            // networkPerfGroupbox
            // 
            this.networkPerfGroupbox.Controls.Add(this.downSpeedLabel);
            this.networkPerfGroupbox.Controls.Add(this.upSpeedLabel);
            this.networkPerfGroupbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkPerfGroupbox.Location = new System.Drawing.Point(6, 87);
            this.networkPerfGroupbox.Name = "networkPerfGroupbox";
            this.networkPerfGroupbox.Size = new System.Drawing.Size(164, 81);
            this.networkPerfGroupbox.TabIndex = 5;
            this.networkPerfGroupbox.TabStop = false;
            this.networkPerfGroupbox.Text = "Network: N/A";
            // 
            // downSpeedLabel
            // 
            this.downSpeedLabel.AutoSize = true;
            this.downSpeedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downSpeedLabel.Location = new System.Drawing.Point(20, 46);
            this.downSpeedLabel.Name = "downSpeedLabel";
            this.downSpeedLabel.Size = new System.Drawing.Size(55, 16);
            this.downSpeedLabel.TabIndex = 7;
            this.downSpeedLabel.Text = "DOWN:";
            // 
            // upSpeedLabel
            // 
            this.upSpeedLabel.AutoSize = true;
            this.upSpeedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upSpeedLabel.Location = new System.Drawing.Point(44, 30);
            this.upSpeedLabel.Name = "upSpeedLabel";
            this.upSpeedLabel.Size = new System.Drawing.Size(36, 16);
            this.upSpeedLabel.TabIndex = 6;
            this.upSpeedLabel.Text = "UP: ";
            // 
            // ramUsageLabel
            // 
            this.ramUsageLabel.AutoSize = true;
            this.ramUsageLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramUsageLabel.Location = new System.Drawing.Point(14, 53);
            this.ramUsageLabel.Name = "ramUsageLabel";
            this.ramUsageLabel.Size = new System.Drawing.Size(113, 16);
            this.ramUsageLabel.TabIndex = 4;
            this.ramUsageLabel.Text = "RAM Usage: 0%";
            // 
            // cpuUsageLabel
            // 
            this.cpuUsageLabel.AutoSize = true;
            this.cpuUsageLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuUsageLabel.Location = new System.Drawing.Point(16, 32);
            this.cpuUsageLabel.Name = "cpuUsageLabel";
            this.cpuUsageLabel.Size = new System.Drawing.Size(111, 16);
            this.cpuUsageLabel.TabIndex = 3;
            this.cpuUsageLabel.Text = "CPU Usage: 0%";
            // 
            // perfTimer
            // 
            this.perfTimer.Interval = 1000;
            this.perfTimer.Tick += new System.EventHandler(this.perfTimer_Tick);
            // 
            // disablePerfCheckbox
            // 
            this.disablePerfCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disablePerfCheckbox.AutoSize = true;
            this.disablePerfCheckbox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disablePerfCheckbox.Location = new System.Drawing.Point(319, 502);
            this.disablePerfCheckbox.Name = "disablePerfCheckbox";
            this.disablePerfCheckbox.Size = new System.Drawing.Size(155, 18);
            this.disablePerfCheckbox.TabIndex = 9;
            this.disablePerfCheckbox.Text = "Disable performance";
            this.disablePerfCheckbox.UseVisualStyleBackColor = true;
            // 
            // taskbarIcon
            // 
            this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
            this.taskbarIcon.Text = "CCSURAT-Server";
            this.taskbarIcon.Visible = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.console);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(490, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(691, 172);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            // 
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.disablePerfCheckbox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.serverControl);
            this.Controls.Add(this.disableConsoleCheckbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zombieListView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.cmdTextbox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.serverControl;
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "ServerMainForm";
            this.Text = "CCSURAT-Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.clientControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.removeControl.ResumeLayout(false);
            this.serverControl.ResumeLayout(false);
            this.serverControl.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.networkPerfGroupbox.ResumeLayout(false);
            this.networkPerfGroupbox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox cmdTextbox;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader ComputerName;
        private System.Windows.Forms.ColumnHeader User;
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
        private System.Windows.Forms.ColumnHeader CurWindow;
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
        private System.Windows.Forms.ColumnHeader Ping;
        private System.Windows.Forms.Timer pingTimer;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer perfTimer;
        private System.Windows.Forms.Label cpuUsageLabel;
        private System.Windows.Forms.CheckBox disablePerfCheckbox;
        private System.Windows.Forms.Label ramUsageLabel;
        private System.Windows.Forms.GroupBox networkPerfGroupbox;
        private System.Windows.Forms.Label downSpeedLabel;
        private System.Windows.Forms.Label upSpeedLabel;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader ID;
        public System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem funToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem windowManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

