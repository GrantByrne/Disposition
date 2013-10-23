using ArduinoTest.Components.ColorManagment.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ArduinoTest.Components.ColorManagment
{
    public class ColorHelper : IColorHelper
    {
        private const int pixelSkip = 20;
        
        public byte[] AverageColors(Bitmap bitmap)
        {
            var color = new byte[3];

            int red = 0;
            int green = 0;
            int blue = 0;
            int count = 0;

            for (int y = 0; y < bitmap.Size.Height; y += pixelSkip)
            {
                for (int x = 0; x < bitmap.Size.Width; x += pixelSkip)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    red += (int)pixel.R;
                    green += (int)pixel.G;
                    blue += (int)pixel.B;

                    count++;
                }
            }

            color[0] = (byte)(red / count);
            color[1] = (byte)(green / count);
            color[2] = (byte)(blue / count);

            return color;
        }

        public byte[] GetProminentColor(Bitmap bitmap)
        {
            var color = new byte[3];

            var colorCount = new Dictionary<Color, int>();

            for (int y = 0; y < bitmap.Size.Height; y += pixelSkip)
            {
                for (int x = 0; x < bitmap.Size.Width; x += pixelSkip)
                {
                    var pixel = bitmap.GetPixel(x, y);

                    if(colorCount[pixel] == null)
                    {
                        colorCount[pixel] = 0;
                    }

                    colorCount[pixel] += 1;
                }
            }

            var prominentColor = colorCount.Keys.Max();
            color[0] = prominentColor.R;
            color[1] = prominentColor.G;
            color[2] = prominentColor.B;

            return color;
        }

        /// <summary>
        /// Creates a box that is 1/3 the size of the screen positioned in the center
        /// </summary>
        /// <returns></returns>
        public Rectangle GetCenterBox()
        {
            var box = new Rectangle();

            int m = 8;

            box.X = (Screen.PrimaryScreen.Bounds.Width - m) / 3;
            box.Y = (Screen.PrimaryScreen.Bounds.Height - m) / 3;

            box.Width = box.X * 2;
            box.Height = box.Y * 2;

            return box;
        }
    }
}
