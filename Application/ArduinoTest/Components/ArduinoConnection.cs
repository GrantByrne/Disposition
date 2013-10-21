using System.IO;
using System.IO.Ports;
using ArduinoTest.Components.Abstract;

namespace ArduinoTest.Components
{
    /// <summary>
    /// Aids in the process of connecting to 
    /// an arduino device
    /// </summary>
    public class ArduinoConnection : IArduinoConnection
    {
        /// <summary>
        /// The actual connection to the arduino device
        /// </summary>
        private static SerialPort _serialPort;

        /// <summary>
        /// Starts up the connection to the Arduino device
        /// </summary>
        public void Initialize()
        {
            if(_serialPort == null)
            {
                _serialPort = CreateNewSerialPort();
            }

            if(!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
        }

        /// <summary>
        /// Ends the connection to the Arduino
        /// </summary>
        public void Close()
        {
            _serialPort.Close();
        }

        /// <summary>
        /// Writes some text to the arduino device
        /// </summary>
        /// <param name="text">
        /// The text being written to the arduino device
        /// </param>
        public void Write(string text)
        {
            if(_serialPort == null)
            {
                const string message = "Connection to the Arduino device has not be initialized.";
                throw new IOException(message);
            }

            _serialPort.Write(text);
        }

        /// <summary>
        /// Creates the settings for an arduino specific 
        /// connection
        /// </summary>
        /// <returns></returns>
        private static SerialPort CreateNewSerialPort()
        {
            return new SerialPort("COM3")
            {
                BaudRate = 9600
            };
        }
    }
}
