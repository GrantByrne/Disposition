using ArduinoTest.Components.Domain;

namespace ArduinoTest.Components.Abstract
{
    public interface IDioderConnection
    {
        /// <summary>
        /// Assembles everything needed to interface with the 
        /// Dioder Device
        /// </summary>
        void Initialize();

        void DisplayColor(Color color);

        /// <summary>
        /// Closes the connection to the Dioder device
        /// </summary>
        void Close();
    }
}