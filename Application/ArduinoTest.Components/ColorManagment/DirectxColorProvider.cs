using ArduinoTest.Components.ColorManagment.Abstract;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SlimDX;
using System.Collections.ObjectModel;

namespace ArduinoTest.Components.ColorManagment
{
    /// <summary>
    /// Detects the average color of the screen using DirectX
    /// </summary>
    public class DirectxColorProvider : IColorProvider
    {
        /// <summary>
        /// Handles the graphics device
        /// </summary>
        private static Device d;

        /// <summary>
        /// Holds a list of the points which the program will be getting 
        /// the color data for
        /// </summary>
        private static Collection<long> colorPoints;
        
        /// <summary>
        /// Ctor
        /// </summary>
        public DirectxColorProvider()
        {
            PresentParameters present_params = new PresentParameters();
            if (d == null)
            {
                d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
            }
            if (colorPoints == null)
            {
                colorPoints = GetColorPoints();
            }
        }

        /// <summary>
        /// Gets the average color of the screen
        /// </summary>
        /// <returns></returns>
        public byte[] GetColors()
        {
            var color = new byte[4];

            using (var screen = this.CaptureScreen())
            {
                DataRectangle dr = screen.LockRectangle(LockFlags.None);
                using (var gs = dr.Data)
                {
                    color = avcs(gs, colorPoints);
                }
            }

            return color;
        }

        /// <summary>
        /// Gets the screen surface
        /// </summary>
        /// <returns></returns>
        private Surface CaptureScreen()
        {
            Surface s = Surface.CreateOffscreenPlain(d, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
            d.GetFrontBufferData(0, s);
            return s;
        }

        /// <summary>
        /// Averages the colors in the collection
        /// </summary>
        /// <param name="gs"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        private static byte[] avcs(DataStream gs, Collection<long> positions)
        {
            byte[] bu = new byte[4];
            int r = 0;
            int g = 0;
            int b = 0;
            int i = 0;

            foreach (long pos in positions)
            {
                gs.Position = pos;
                gs.Read(bu, 0, 4);
                r += bu[2];
                g += bu[1];
                b += bu[0];
                i++;
            }

            byte[] result = new byte[3];
            result[0] = (byte)(r / i);
            result[1] = (byte)(g / i);
            result[2] = (byte)(b / i);

            return result;
        }

        /// <summary>
        /// Gets all the points that we would like to analyze the color of
        /// </summary>
        /// <returns></returns>
        private Collection<long> GetColorPoints()
        {
            const long offset = 20;
            const long Bpp = 4;

            var box = GetBox();

            var colorPoints = new Collection<long>();
            for (var x = box.X; x < (box.X + box.Length); x += offset)
            {
                for (var y = box.Y; y < (box.Y + box.Height); y += offset)
                {
                    long pos = (y * Screen.PrimaryScreen.Bounds.Width + x) * Bpp;
                    colorPoints.Add(pos);
                }
            }

            return colorPoints;
        }

        /// <summary>
        /// Creates a box that is 1/3 the size of the screen positioned in the center
        /// </summary>
        /// <returns></returns>
        private ScreenBox GetBox()
        {
            var box = new ScreenBox();

            int m = 8;

            box.X = (Screen.PrimaryScreen.Bounds.Width - m) / 3;
            box.Y = (Screen.PrimaryScreen.Bounds.Height - m) / 3;

            box.Length = box.X * 2;
            box.Height = box.Y * 2;

            return box;
        }

        private class ScreenBox
        {
            public long X { get; set; }
            public long Y { get; set; }
            public long Length { get; set; }
            public long Height { get; set; }
        }


        public byte[] GetProminentColor(Bitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}
