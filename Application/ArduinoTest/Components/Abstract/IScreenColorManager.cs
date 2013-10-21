using ArduinoTest.Components.Domain;

namespace ArduinoTest.Components.Abstract
{
    public interface IScreenColorManager
    {
        /// <summary>
        /// Gets the color of the pixel at the center of the screen
        /// </summary>
        /// <returns></returns>
        Color GetCenterScreenColor();
    }
}