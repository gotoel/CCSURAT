using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CCSURAT_Client.Control
{
    class RemoteDesktop
    {
        private Bitmap image;
        private byte[] imageBytes;

        private static object screenImageLock = new object();

        // Native methods
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x01;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [DllImport("user32.dll")]
        public static extern bool keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        public const int KEYEVENTF_KEYDOWN = 0x0001;
        public const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        // Handle mouse click even at X/Y
        public void MouseClick(long x, long y, string button, string clickAction)
        {
            Cursor.Position = new Point((int)x, (int)y);

            // Button type support. TO-DO: Add more button support.
            switch (button)
            {
                case "Left":
                    if(clickAction.Equals("Down"))
                        mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    else
                        mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case "Right":
                    if(clickAction.Equals("Down"))
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    else
                        mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
            }
        }

        // Handle mouse move even at X/Y
        public void MouseMove(long x, long y)
        {
            Cursor.Position = new Point((int)x, (int)y);
            //mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        // Handle key press events using the key's keycode
        // May need to add a KeyRelease function on server+client
        public void KeyPress(string key, string pressAction)
        {
            if (pressAction.Equals("Down"))
                keybd_event(Convert.ToByte(key), 0, KEYEVENTF_KEYDOWN, 0);
            else
                keybd_event(Convert.ToByte(key), 0, KEYEVENTF_KEYUP, 0);
        }

        public byte[] GetScreenshot(string quality, string size, string deviceName)
        {
            try
            {
                CreateScreenShot(Convert.ToInt64(quality), float.Parse(size), deviceName);
                // Convert command tag open/close strings to byte arrays.
                byte[] start = Encoding.ASCII.GetBytes("[[BINARY]][[SCREENSHOT]]" + deviceName + "|*|");
                byte[] end = Encoding.ASCII.GetBytes("[[/SCREENSHOT]][[/BINARY]]");
                // Create a temp value to hold the image byte data padded with the command tag bytes.
                byte[] temp = new byte[start.Length + end.Length + imageBytes.Length];
                start.CopyTo(temp, 0);
                imageBytes.CopyTo(temp, start.Length);
                end.CopyTo(temp, start.Length + imageBytes.Length);
                return temp;
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        // Creates an image from a screenshot of the screen.
        private void CreateScreenShot(long quality, float size, string deviceName)
        {
            try
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    // Only create a screenshot of requested device.
                    if (screen.DeviceName.Equals(deviceName))
                    {
                        ImageCodecInfo[] iciCodecs = ImageCodecInfo.GetImageDecoders();
                        ImageCodecInfo jpeg = GetEncoderInfo("image/jpeg");
                        image = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);
                        // Use the using keyword so the Graphics are properly disposed to prevent memory leaks.
                        using (Graphics g = Graphics.FromImage(image))
                        {
                            try
                            {
                                lock (screenImageLock)
                                {
                                    g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                                    EncoderParameters encs = new EncoderParameters(1);
                                    EncoderParameter enc = new EncoderParameter(myEncoder, quality);
                                    encs.Param[0] = enc;
                                    image = Resize(image, size);
                                    MemoryStream temp = new MemoryStream();
                                    image.Save(temp, jpeg, encs);
                                    image = new Bitmap(temp);
                                    imageBytes = temp.GetBuffer();
                                    temp.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("ERROR MAKING SCREENSHOT: " + ex.ToString());
                            }
                            finally
                            {
                                // Fixes that terrible memory leak.......
                                g.Dispose();
                                image.Dispose();
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private Bitmap Resize(Bitmap image, float size)
        {
            try
            {

                int originalW = image.Width;
                int originalH = image.Height;

                //get the new size based on the size change
                int resizedW = (int)(originalW * size);
                int resizedH = (int)(originalH * size);

                //create a new Bitmap the size of the new image
                Bitmap bmp = new Bitmap(resizedW, resizedH);
                Graphics graphic = Graphics.FromImage(bmp);
                graphic.DrawImage(image, 0, 0, resizedW, resizedH);
                graphic.Dispose();
                return bmp;
            }
            catch (Exception ex)
            {
                return image;
            }
        }
    }
}
