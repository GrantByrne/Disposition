using ArduinoTest.Components;

namespace ArduinoTest
{
    class Program
    {
        static void Main()
        {
            var ambiantLightingManager = new AmbiantLightingManager();
            ambiantLightingManager.Initialize();
            ambiantLightingManager.Run();
        }
    }
}
