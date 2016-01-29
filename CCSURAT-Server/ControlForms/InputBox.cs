using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSURAT_Server.ControlForms
{
    // C# offers no input box that I could find, so this custom one is needed.
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public string Show(string info)
        {
            this.Text = "InputBox";
            inputBoxLabel.Text = info;
            if (this.ShowDialog() == DialogResult.OK)
                return inputTextBox.Text;
            else
                return null;
        }

        public string Show(string title, string prompt, string text)
        {
            this.Text = title;
            this.inputTextBox.Text = text;
            return Show(prompt);
        }

        public string Show(string title, string prompt, string text, string btnText)
        {
            inputButton.Text = btnText;
            return Show(title, prompt, text);
        }

    }
}
