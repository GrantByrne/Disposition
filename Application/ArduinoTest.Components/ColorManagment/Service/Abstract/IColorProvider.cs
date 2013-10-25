using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTest.Components.ColorManagment.Service.Abstract
{
    /// <summary>
    /// Provides a base set of expected functionality for handling 
    /// color specification for the Dioder
    /// </summary>
    public interface IColorProvider
    {
        /// <summary>
        /// Gets the color to show on the Dioder
        /// </summary>
        /// <returns>
        /// A byte array representing the colors to be displayed
        /// </returns>
        byte[] GetColors();
    }
}
