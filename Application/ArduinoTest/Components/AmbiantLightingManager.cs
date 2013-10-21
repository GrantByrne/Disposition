using ArduinoTest.Components.Abstract;

namespace ArduinoTest.Components
{
    public class AmbiantLightingManager : IAmbiantLightingManager
    {
        #region Dependencies

        /// <summary>
        /// Handles the usage of the colors on the Ikea Dioder
        /// </summary>
        private readonly IDioderConnection _dioderConnection;

        /// <summary>
        /// Handles getting the color information off the 
        /// screen
        /// </summary>
        private readonly IScreenColorManager _screenColorManager;

        #endregion

        #region Constructors

        /// <summary>
        /// ctor
        /// </summary>
        public AmbiantLightingManager()
        {
            _dioderConnection = new DioderConnection();
            _screenColorManager = new ScreenColorManager();
        }

        #endregion

        /// <summary>
        /// Initializes all the components to make 
        /// magic happen
        /// </summary>
        public void Initialize()
        {
            _dioderConnection.Initialize();
        }

        /// <summary>
        /// Starts the awesomeness
        /// </summary>
        public void Run()
        {
            while (true)
            {
                try
                {
                    var color =_screenColorManager.GetCenterScreenColor();
                    _dioderConnection.DisplayColor(color);
                }
                catch
                {
                    _dioderConnection.Close();
                    throw;
                }
            }
        }

        public void Close()
        {
            _dioderConnection.Close();
        }
    }
}
