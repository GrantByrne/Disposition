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
using System.Drawing.Printing;

namespace ArduinoTest.Components.ColorManagment.Service
{
    /// <summary>
    /// Detects the average color of the screen using DirectX
    /// </summary>
    public class DirectxColorProvider : Form, IColorProvider
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
                _samplePoints = _samplePointService.GetSamplePoints(.1f);
            }

            if(_graphics == null)
            {
                _graphics = this.CreateGraphics();
            }
        }

        private static Graphics _graphics;

        /// <summary>
        /// Gets the average color of the screen
        /// </summary>
        /// <returns></returns>
        public byte[] GetColors()
        {
            var color = new byte[3];

            using(var memoryImage = new Bitmap(_samplePoints.CenterBox.Width, _samplePoints.CenterBox.Height, _graphics))
            {
                using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                {
                    var size = new System.Drawing.Size
                    {
                        Width = _samplePoints.CenterBox.Width,
                        Height = _samplePoints.CenterBox.Height
                    };

                    memoryGraphics.CopyFromScreen(_samplePoints.CenterBox.X,
                                                    _samplePoints.CenterBox.Y,
                                                    0,
                                                    0,
                                                    size,
                                                    CopyPixelOperation.SourceCopy);


                    var colors = new List<Color>();
                    foreach (var point in _samplePoints.Points)
                    {
                        var pixel = memoryImage.GetPixel(point.X - _samplePoints.CenterBox.X, point.Y - _samplePoints.CenterBox.Y);
                        var sampledColor = Color.FromArgb(pixel.R, pixel.G, pixel.B);
                        colors.Add(sampledColor);
                    }
                    var averageColor = _colorHelper.ComputeAverageColors(colors);
                    color = _colorMapper.Map(averageColor);

                }                    
                
            }
            

            return color;
        }
    }
}
