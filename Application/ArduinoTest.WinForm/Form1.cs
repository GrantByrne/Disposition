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
using ArduinoTest.Components.ColorManagment.Service.Abstract;
using ArduinoTest.Components.ColorManagment.Service;

namespace ArduinoTest.WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Handles the connection to the arduino device
        /// </summary>
        private readonly IArduinoConnection _arduinoConnection;

        private readonly IColorProvider _colorProvider;

        public Form1()
        {
            _arduinoConnection = new ArduinoConnection();
            _colorProvider = new DirectxColorProvider();

            InitializeComponent();

            _arduinoConnection.Initialize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var colors = _colorProvider.GetColors();

            // Send it off to the arduino
            _arduinoConnection.Write(colors);
        }
    }
}
