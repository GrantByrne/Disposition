using System.Text;
using ArduinoTest.Components.Abstract;
using ArduinoTest.Components.Domain;

namespace ArduinoTest.Components
{
    /// <summary>
    /// Manages operations surrounding the Ikea Dioder
    /// </summary>
    public class DioderConnection : IDioderConnection
    {
        #region Dependencies

        /// <summary>
        /// Handles the basic connection the arduino device
        /// </summary>
        private readonly IArduinoConnection _arduinoConnection;

        #endregion

        #region Constructors

        /// <summary>
        /// ctor
        /// </summary>
        public DioderConnection()
        {
            _arduinoConnection = new ArduinoConnection();
        }

        #endregion

        /// <summary>
        /// Assembles everything needed to interface with the 
        /// Dioder Device
        /// </summary>
        public void Initialize()
        {
            _arduinoConnection.Initialize();
        }

        /// <summary>
        /// Displays a specific color on the dioder
        /// </summary>
        /// <param name="color"></param>
        public void DisplayColor(Color color)
        {
            var colorString = GetColorString(color);
            _arduinoConnection.Write(colorString);
        }

        /// <summary>
        /// Maps the Color object to a string that the arduino 
        /// can understand
        /// </summary>
        /// <param name="color"></param>
        private static string GetColorString(Color color)
        {
            var colorStringBuilder = new StringBuilder();
            colorStringBuilder.Append(color.Red.ToString("000"));
            colorStringBuilder.Append(color.Green.ToString("000"));
            colorStringBuilder.Append(color.Blue.ToString("000"));
            return colorStringBuilder.ToString();
        }

        /// <summary>
        /// Closes the connection to the Dioder device
        /// </summary>
        public void Close()
        {
            _arduinoConnection.Close();
        }
    }
}
