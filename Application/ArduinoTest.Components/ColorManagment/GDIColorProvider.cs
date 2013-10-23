using ArduinoTest.Components.ColorManagment.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ArduinoTest.Components.ColorManagment
{
    public class GDIColorProvider : Form, IColorProvider
    {
        private static Rectangle box;

        private readonly IColorHelper _colorHelper;
        
        /// <summary>
        /// Ctor
        /// </summary>
        public GDIColorProvider()
        {
            _colorHelper = new ColorHelper();
            box = _colorHelper.GetCenterBox();
        }        
        
        public byte[] GetColors()
        {
            var colors = new byte[3];
            
            IntPtr hDesk = GetDesktopWindow();
            IntPtr hSrce = GetDC(IntPtr.Zero);
            IntPtr hDest = CreateCompatibleDC(hSrce);
            IntPtr hBmp = CreateCompatibleBitmap(hSrce, box.Width, box.Height);
            IntPtr hOldBmp = SelectObject(hDest, hBmp);
            bool b = BitBlt(hDest, box.X, box.Y, (box.Width - box.X), (box.Height - box.Y), hSrce, 0, 0, CopyPixelOperation.SourceCopy);
            using(var bmp = Bitmap.FromHbitmap(hBmp))
            {
                colors = _colorHelper.AverageColors(bmp);
            }
            
            SelectObject(hDest, hOldBmp);
            DeleteObject(hBmp);
            DeleteDC(hDest);
            ReleaseDC(hDesk, hSrce);

            return colors;
        }

        // P/Invoke declarations
        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr ptr);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr ptr);
    }
}
