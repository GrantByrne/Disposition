using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using ArduinoTest.Components.ColorManagment.Service.Abstract;
using ArduinoTest.Components.ColorManagment.Mapper.Abstract;
using ArduinoTest.Components.ColorManagment.Mapper;

namespace ArduinoTest.Components.ColorManagment.Service
{
    public class GDIColorProvider : Form, IColorProvider
    {
        private readonly IColorHelper _colorHelper;
        private readonly ISamplePointService _samplePointService;
        private readonly IColorMapper _colorMapper;
        private static SamplePoints SamplePoints;

        /// <summary>
        /// Ctor
        /// </summary>
        public GDIColorProvider()
        {
            _colorHelper = new ColorHelper();
            _samplePointService = new SamplePointService();
            _colorMapper = new ColorMapper();
            SamplePoints = _samplePointService.GetSamplePoints(.30f);
        }

        public byte[] GetColors()
        {
            var colors = new byte[3];

            IntPtr hDesk = GetDesktopWindow();
            IntPtr hSrce = GetWindowDC(hDesk);
            IntPtr hDest = CreateCompatibleDC(hSrce);
            IntPtr hBmp = CreateCompatibleBitmap(hSrce, SamplePoints.CenterBox.Width*2, SamplePoints.CenterBox.Height*2);
            IntPtr hOldBmp = SelectObject(hDest, hBmp);
            //bool b = BitBlt(hDest,
            //                0,
            //                0,
            //                SamplePoints.CenterBox.Width*2,
            //                SamplePoints.CenterBox.Height*2,
            //                hSrce,
            //                0,
            //                0,
            //                CopyPixelOperation.SourceCopy);

            //using (var bmp = Bitmap.FromHbitmap(hBmp))
            //{
            //    var colorsList = new List<Color>();
            //    foreach (var point in SamplePoints.Points)
            //    {

            //        var pixel = bmp.GetPixel(point.X, point.Y);
            //        var pixelColor = Color.FromArgb(pixel.R, pixel.G, pixel.B);
            //        colorsList.Add(pixelColor);
            //    }
            //    var averagedColor = _colorHelper.ComputeAverageColors(colorsList);
            //    colors = _colorMapper.Map(averagedColor);
            //}
            var colorsList = new List<Color>();
            foreach(var point in SamplePoints.Points)
            {
                uint pixel = 0;
                pixel = GetPixel(hSrce, Cursor.Position.X, Cursor.Position.Y);
                Color color = Color.FromArgb((int) pixel);
                colorsList.Add(color);
            }
            var averagedColor = _colorHelper.ComputeAverageColors(colorsList);
            colors = _colorMapper.Map(averagedColor);
            

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
        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
    }
}
