using ArduinoTest.Components.ColorManagment.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoTest.Components.ColorManagment.Service
{
    /// <summary>
    /// Helps figure out how much of the screen you want it offsetted
    /// </summary>
    public class SamplePointService : ISamplePointService
    {
        public SamplePoints GetSamplePoints(float screenPercentage)
        {
            var samplePoints = new SamplePoints();

            // Get the box sizing
            samplePoints.CenterBox = GetCenterBox(screenPercentage);

            // Get the sample points
            samplePoints.Points = GenerateSamplePoints(samplePoints.CenterBox);

            return samplePoints;
        }

        /// <summary>
        /// Creates a box that is 1/3 the size of the screen positioned in the center
        /// </summary>
        /// <returns></returns>
        private Rectangle GetCenterBox(float screenPercentage)
        {
            var box = new Rectangle();

            // Get the Screen Height
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Place the box on the screen
            box.X = (int)(screenWidth * screenPercentage);
            box.Y = (int)(screenHeight * screenPercentage);

            // Determine the size of the box
            box.Width = box.X;
            box.Height = box.Y;

            return box;
        }

        private List<Point> GenerateSamplePoints(Rectangle rectangle)
        {
            var points = new List<Point>();

            const int pointSkip = 20;

            for (var x = rectangle.X; x < (rectangle.X + rectangle.Y); x += pointSkip)
            {
                for (var y = rectangle.Y; y < (rectangle.Y + rectangle.Height); y += pointSkip)
                {
                    points.Add(new Point(x, y));
                }
            }

            return points;
        }

    }
}
