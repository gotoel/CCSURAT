using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CCSURAT_Client.Control
{
    class RemoteDesktop
    {
        private Bitmap image;
        private byte[] imageBytes;


        public byte[] GetScreenshot(string quality, string size, string deviceName)
        {
            try
            {
                CreateScreenShot(Convert.ToInt64(quality), float.Parse(size), deviceName);
                // Convert command tag open/close strings to byte arrays.
                byte[] start = Encoding.ASCII.GetBytes("[[BINARY]][[SCREENSHOT]]");
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
                            } catch(Exception ex)
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
