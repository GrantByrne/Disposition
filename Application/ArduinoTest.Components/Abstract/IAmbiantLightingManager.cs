namespace ArduinoTest.Components.Abstract
{
    public interface IAmbiantLightingManager
    {
        /// <summary>
        /// Initializes all the components to make 
        /// magic happen
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starts the awesomeness
        /// </summary>
        void Run();

        void Close();
    }
}