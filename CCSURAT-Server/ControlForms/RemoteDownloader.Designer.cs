namespace CCSURAT_Server.ControlForms
{
    partial class RemoteDownloader
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
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextbox = new System.Windows.Forms.TextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.hiddenRadioButton = new System.Windows.Forms.RadioButton();
            this.visibleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download URL:";
            // 
            // urlTextbox
            // 
            this.urlTextbox.Location = new System.Drawing.Point(101, 6);
            this.urlTextbox.Name = "urlTextbox";
            this.urlTextbox.Size = new System.Drawing.Size(402, 20);
            this.urlTextbox.TabIndex = 1;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(402, 104);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(101, 23);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Download + Run";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // hiddenRadioButton
            // 
            this.hiddenRadioButton.AutoSize = true;
            this.hiddenRadioButton.Location = new System.Drawing.Point(21, 19);
            this.hiddenRadioButton.Name = "hiddenRadioButton";
            this.hiddenRadioButton.Size = new System.Drawing.Size(59, 17);
            this.hiddenRadioButton.TabIndex = 3;
            this.hiddenRadioButton.TabStop = true;
            this.hiddenRadioButton.Text = "Hidden";
            this.hiddenRadioButton.UseVisualStyleBackColor = true;
            this.hiddenRadioButton.CheckedChanged += new System.EventHandler(this.hiddenRadioButton_CheckedChanged);
            // 
            // visibleRadioButton
            // 
            this.visibleRadioButton.AutoSize = true;
            this.visibleRadioButton.Location = new System.Drawing.Point(21, 42);
            this.visibleRadioButton.Name = "visibleRadioButton";
            this.visibleRadioButton.Size = new System.Drawing.Size(55, 17);
            this.visibleRadioButton.TabIndex = 4;
            this.visibleRadioButton.TabStop = true;
            this.visibleRadioButton.Text = "Visible";
            this.visibleRadioButton.UseVisualStyleBackColor = true;
            this.visibleRadioButton.CheckedChanged += new System.EventHandler(this.visibleRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hiddenRadioButton);
            this.groupBox1.Controls.Add(this.visibleRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(403, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 66);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Run type";
            // 
            // RemoteDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 132);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.urlTextbox);
            this.Controls.Add(this.label1);
            this.Name = "RemoteDownloader";
            this.Text = "RemoteDownloader";
            this.Load += new System.EventHandler(this.RemoteDownloader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextbox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.RadioButton hiddenRadioButton;
        private System.Windows.Forms.RadioButton visibleRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}