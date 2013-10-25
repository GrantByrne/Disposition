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
using ArduinoTest.Components.ColorManagment.Service.Abstract;
using ArduinoTest.Components.ColorManagment.Mapper.Abstract;
using ArduinoTest.Components.ColorManagment.Mapper;

namespace ArduinoTest.Components.ColorManagment.Service
{
    /// <summary>
    /// Detects the average color of the screen using DirectX
    /// </summary>
    public class DirectxColorProvider : IColorProvider
    {
        private readonly IColorHelper _colorHelper;
        private readonly ISamplePointService _samplePointService;
        private readonly IColorMapper _colorMapper;

        /// <summary>
        /// Handles the graphics device
        /// </summary>
        private static Device d;

        private static SamplePoints _samplePoints;

        /// <summary>
        /// Ctor
        /// </summary>
        public DirectxColorProvider()
        {
            _colorHelper = new ColorHelper();
            _samplePointService = new SamplePointService();
            _colorMapper = new ColorMapper();

            PresentParameters present_params = new PresentParameters();
            if (d == null)
            {
                d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
            }
            if (_samplePoints == null)
            {
                _samplePoints = _samplePointService.GetSamplePoints(.30f);
            }
        }

        /// <summary>
        /// Gets the average color of the screen
        /// </summary>
        /// <returns></returns>
        public byte[] GetColors()
        {
            var color = new byte[3];

            using (var screen = this.CaptureScreen())
            {
                DataRectangle dr = screen.LockRectangle(LockFlags.None);
                using (var gs = dr.Data)
                {
                    var colors = new List<Color>();
                    foreach (var point in _samplePoints.Points)
                    {
                        const int bpp = 4;
                        gs.Position = point.X * point.Y * bpp;
                        var bu = new byte[4];
                        gs.Read(bu, 0, 4);
                        colors.Add(Color.FromArgb(bu[2], bu[1], bu[0]));
                    }
                    var averageColor = _colorHelper.ComputeAverageColors(colors);
                    color = _colorMapper.Map(averageColor);
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
            d.GetBackBuffer(0, 0);
            return s;
        }

    }
}
