using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArduinoTest.Components;
using ArduinoTest.Components.Abstract;

namespace ArduinoTest.WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Handles the connection to the arduino device
        /// </summary>
        private readonly IArduinoConnection _arduinoConnection;

        private readonly IScreenColorManager _screenColorManager;

        private readonly IScreenColor _screenColor;

        public Form1()
        {
            _arduinoConnection = new ArduinoConnection();
            _screenColorManager = new ScreenColorManager();
            _screenColor = new ScreenColor();

            InitializeComponent();

            _arduinoConnection.Initialize();
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            //// Get the Red Color
            //var redText = RedTextBox.Text;
            //byte red;
            //byte.TryParse(redText, out red);

            //// Get the Green Color
            //var greenText = GreenTextBox.Text;
            //byte green;
            //byte.TryParse(greenText, out green);

            //// Get the Blue Color
            //var blueText = BlueTextBox.Text;
            //byte blue;
            //byte.TryParse(blueText, out blue);

            //byte[] colors = new byte[3];
            //colors[0] = red;
            //colors[1] = green;
            //colors[2] = blue;

            //// Send it off to the arduino
            //_arduinoConnection.Write(colors);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //var screenColor = _screenColorManager.GetCenterScreenColor();


            //byte[] colors = new byte[3];
            //colors[0] = screenColor.Red;
            //colors[1] = screenColor.Green;
            //colors[2] = screenColor.Blue;

            var colors = _screenColor.GetScreenColor();

            // Send it off to the arduino
            _arduinoConnection.Write(colors);


        }
    }
}
