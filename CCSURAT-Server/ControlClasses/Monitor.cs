using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSURAT_Server.ControlClasses
{

    // Contains values of a client's monitor.
    public class Monitor
    {
        private bool primary;
        private int x, y, width, height;
        private string name;
        private Image screenImage;

        public Monitor(bool primary, int x, int y, int width, int height, string name)
        {
            this.primary = primary;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.name = name;
        }

        public bool isPrimary() { return primary; }
        public int getX() { return x; }
        public int getY() { return y; }
        public int getWidth() { return width; }
        public int getHeight() { return height; }
        public string deviceName() { return name; }

        public void setScreenImage(Image i) { screenImage = i; }
        public Image getScreenImage() { return screenImage; }

    }
}
