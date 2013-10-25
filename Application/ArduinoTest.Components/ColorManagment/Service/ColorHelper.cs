using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ArduinoTest.Components.ColorManagment.Service.Abstract;

namespace ArduinoTest.Components.ColorManagment.Service
{
    /// <summary>
    /// Helps with the process of resolving a single color from many colors
    /// </summary>
    public class ColorHelper : IColorHelper
    {
        /// <summary>
        /// Gets the average of all the colors provided
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// A color object that represents the average of all the sampled 
        /// colors
        /// </returns>
        public Color ComputeAverageColors(IEnumerable<Color> colors)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int count = 0;

            foreach(var color in colors)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
                count++;
            }

            return Color.FromArgb(red/count, green/count, blue/count);
        }

        /// <summary>
        /// Computes the color that shows up the most often
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// The color object that showed up the most often
        /// </returns>
        public Color ComputeProminentColor(IEnumerable<Color> colors)
        {
            var colorCount = new Dictionary<Color, int?>();

            foreach(var color in colors)
            {
                if(!colorCount.ContainsKey(color))
                {
                    colorCount[color] = 0;
                }
                colorCount[color]++;
            }

            return colorCount.OrderByDescending(p => p.Value).First().Key;
        }
    }
}
