namespace CCSURAT_Server.ControlForms
{
    partial class InputBox
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
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputButton = new System.Windows.Forms.Button();
            this.inputBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 22);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(319, 50);
            this.inputTextBox.TabIndex = 0;
            // 
            // inputButton
            // 
            this.inputButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.inputButton.Location = new System.Drawing.Point(256, 78);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(75, 23);
            this.inputButton.TabIndex = 1;
            this.inputButton.Text = "OK";
            this.inputButton.UseVisualStyleBackColor = true;
            // 
            // inputBoxLabel
            // 
            this.inputBoxLabel.AutoSize = true;
            this.inputBoxLabel.Location = new System.Drawing.Point(10, 6);
            this.inputBoxLabel.Name = "inputBoxLabel";
            this.inputBoxLabel.Size = new System.Drawing.Size(56, 13);
            this.inputBoxLabel.TabIndex = 2;
            this.inputBoxLabel.Text = "inputLabel";
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 104);
            this.Controls.Add(this.inputBoxLabel);
            this.Controls.Add(this.inputButton);
            this.Controls.Add(this.inputTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.Text = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Label inputBoxLabel;
    }
}