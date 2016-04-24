namespace CCSURAT_Server
{
    partial class RemoteDesktop
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
            this.screenImageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseControlCheckbox = new System.Windows.Forms.CheckBox();
            this.keyboardControlCheckbox = new System.Windows.Forms.CheckBox();
            this.refreshInterval = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.imageQuality = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.monitorList = new System.Windows.Forms.ComboBox();
            this.refreshTextbox = new System.Windows.Forms.TextBox();
            this.qualityTextbox = new System.Windows.Forms.TextBox();
            this.sizeTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.screenImageBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // screenImageBox
            // 
            this.screenImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenImageBox.Location = new System.Drawing.Point(0, 80);
            this.screenImageBox.Name = "screenImageBox";
            this.screenImageBox.Size = new System.Drawing.Size(768, 431);
            this.screenImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenImageBox.TabIndex = 0;
            this.screenImageBox.TabStop = false;
            this.screenImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screenImageBox_MouseDown);
            this.screenImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenImageBox_MouseMove);
            this.screenImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screenImageBox_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.singleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(768, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // singleToolStripMenuItem
            // 
            this.singleToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleToolStripMenuItem.Name = "singleToolStripMenuItem";
            this.singleToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.singleToolStripMenuItem.Text = "Single";
            this.singleToolStripMenuItem.Click += new System.EventHandler(this.singleToolStripMenuItem_Click);
            // 
            // mouseControlCheckbox
            // 
            this.mouseControlCheckbox.AutoSize = true;
            this.mouseControlCheckbox.Location = new System.Drawing.Point(12, 31);
            this.mouseControlCheckbox.Name = "mouseControlCheckbox";
            this.mouseControlCheckbox.Size = new System.Drawing.Size(93, 17);
            this.mouseControlCheckbox.TabIndex = 2;
            this.mouseControlCheckbox.Text = "Enable mouse";
            this.mouseControlCheckbox.UseVisualStyleBackColor = true;
            this.mouseControlCheckbox.CheckedChanged += new System.EventHandler(this.mouseControlCheckbox_CheckedChanged);
            // 
            // keyboardControlCheckbox
            // 
            this.keyboardControlCheckbox.AutoSize = true;
            this.keyboardControlCheckbox.Location = new System.Drawing.Point(111, 31);
            this.keyboardControlCheckbox.Name = "keyboardControlCheckbox";
            this.keyboardControlCheckbox.Size = new System.Drawing.Size(106, 17);
            this.keyboardControlCheckbox.TabIndex = 3;
            this.keyboardControlCheckbox.Text = "Enable keyboard";
            this.keyboardControlCheckbox.UseVisualStyleBackColor = true;
            this.keyboardControlCheckbox.CheckedChanged += new System.EventHandler(this.keyboardControlCheckbox_CheckedChanged);
            // 
            // refreshInterval
            // 
            this.refreshInterval.AutoSize = false;
            this.refreshInterval.LargeChange = 100;
            this.refreshInterval.Location = new System.Drawing.Point(557, 1);
            this.refreshInterval.Maximum = 5000;
            this.refreshInterval.Minimum = 100;
            this.refreshInterval.Name = "refreshInterval";
            this.refreshInterval.Size = new System.Drawing.Size(135, 22);
            this.refreshInterval.SmallChange = 100;
            this.refreshInterval.TabIndex = 4;
            this.refreshInterval.TickFrequency = 100;
            this.refreshInterval.Value = 1000;
            this.refreshInterval.Scroll += new System.EventHandler(this.refreshInterval_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Monitor:";
            // 
            // imageQuality
            // 
            this.imageQuality.AutoSize = false;
            this.imageQuality.Location = new System.Drawing.Point(558, 27);
            this.imageQuality.Maximum = 100;
            this.imageQuality.Minimum = 1;
            this.imageQuality.Name = "imageQuality";
            this.imageQuality.Size = new System.Drawing.Size(135, 21);
            this.imageQuality.SmallChange = 5;
            this.imageQuality.TabIndex = 7;
            this.imageQuality.TickFrequency = 5;
            this.imageQuality.Value = 50;
            this.imageQuality.Scroll += new System.EventHandler(this.imageQuality_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Refresh interval:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(460, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Image quality:";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // monitorList
            // 
            this.monitorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monitorList.FormattingEnabled = true;
            this.monitorList.Location = new System.Drawing.Point(293, 3);
            this.monitorList.Name = "monitorList";
            this.monitorList.Size = new System.Drawing.Size(121, 21);
            this.monitorList.TabIndex = 10;
            // 
            // refreshTextbox
            // 
            this.refreshTextbox.Location = new System.Drawing.Point(698, 3);
            this.refreshTextbox.Name = "refreshTextbox";
            this.refreshTextbox.ReadOnly = true;
            this.refreshTextbox.Size = new System.Drawing.Size(67, 20);
            this.refreshTextbox.TabIndex = 11;
            this.refreshTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // qualityTextbox
            // 
            this.qualityTextbox.Location = new System.Drawing.Point(698, 29);
            this.qualityTextbox.Name = "qualityTextbox";
            this.qualityTextbox.ReadOnly = true;
            this.qualityTextbox.Size = new System.Drawing.Size(67, 20);
            this.qualityTextbox.TabIndex = 12;
            this.qualityTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sizeTextbox
            // 
            this.sizeTextbox.Location = new System.Drawing.Point(698, 54);
            this.sizeTextbox.Name = "sizeTextbox";
            this.sizeTextbox.ReadOnly = true;
            this.sizeTextbox.Size = new System.Drawing.Size(67, 20);
            this.sizeTextbox.TabIndex = 15;
            this.sizeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(515, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Size:";
            // 
            // imageSize
            // 
            this.imageSize.AutoSize = false;
            this.imageSize.Location = new System.Drawing.Point(557, 53);
            this.imageSize.Maximum = 100;
            this.imageSize.Minimum = 1;
            this.imageSize.Name = "imageSize";
            this.imageSize.Size = new System.Drawing.Size(135, 21);
            this.imageSize.TabIndex = 13;
            this.imageSize.TickFrequency = 5;
            this.imageSize.Value = 100;
            this.imageSize.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // RemoteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(768, 511);
            this.Controls.Add(this.sizeTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageSize);
            this.Controls.Add(this.qualityTextbox);
            this.Controls.Add(this.refreshTextbox);
            this.Controls.Add(this.monitorList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshInterval);
            this.Controls.Add(this.keyboardControlCheckbox);
            this.Controls.Add(this.mouseControlCheckbox);
            this.Controls.Add(this.screenImageBox);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(784, 550);
            this.Name = "RemoteDesktop";
            this.ShowIcon = false;
            this.Text = "RemoteDesktop";
            this.Load += new System.EventHandler(this.RemoteDesktop_Load);
            this.Shown += new System.EventHandler(this.RemoteDesktop_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemoteDesktop_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RemoteDesktop_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.screenImageBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screenImageBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleToolStripMenuItem;
        private System.Windows.Forms.CheckBox mouseControlCheckbox;
        private System.Windows.Forms.CheckBox keyboardControlCheckbox;
        private System.Windows.Forms.TrackBar refreshInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar imageQuality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ComboBox monitorList;
        private System.Windows.Forms.TextBox refreshTextbox;
        private System.Windows.Forms.TextBox qualityTextbox;
        private System.Windows.Forms.TextBox sizeTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar imageSize;
    }
}