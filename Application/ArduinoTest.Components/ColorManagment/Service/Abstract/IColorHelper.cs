using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTest.Components.ColorManagment.Service.Abstract
{
    /// <summary>
    /// Helps with the process of resolving a single color from many colors
    /// </summary>
    public interface IColorHelper
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
        Color ComputeAverageColors(IEnumerable<Color> colors);

        /// <summary>
        /// Computes the color that shows up the most often
        /// </summary>
        /// <param name="colors">
        /// The total collection of sampled colors
        /// </param>
        /// <returns>
        /// The color object that showed up the most often
        /// </returns>
        Color ComputeProminentColor(IEnumerable<Color> colors);
    }
}
