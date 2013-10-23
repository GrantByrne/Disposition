using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTest.Components.ColorManagment.Abstract
{
    public interface IColorHelper
    {
        /// <summary>
        /// Averages the colors on a bitmap
        /// </summary>
        /// <param name="bitmap">
        /// The raw bitmap
        /// </param>
        /// <returns>
        /// The average color across the bitmap
        /// </returns>
        byte[] AverageColors(Bitmap bitmap);

        /// <summary>
        /// Creates a box that is 1/3 the size of the screen positioned in the center
        /// </summary>
        /// <returns></returns>
        Rectangle GetCenterBox();
    }
}
