namespace ArduinoTest.Components.Abstract
{
    /// <summary>
    /// Aids in the process of connecting to 
    /// an arduino device
    /// </summary>
    public interface IArduinoConnection
    {
        /// <summary>
        /// Starts up the connection to the Arduino device
        /// </summary>
        void Initialize();

        /// <summary>
        /// Ends the connection to the Arduino
        /// </summary>
        void Close();

        /// <summary>
        /// Writes some text to the arduino device
        /// </summary>
        /// <param name="text">
        /// The text being written to the arduino device
        /// </param>
        void Write(string text);
    }
}