using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ArduinoTest.Components;
using ArduinoTest.Components.ColorManagment.Abstract;
using ArduinoTest.Components.ColorManagment;

namespace ArduinoTest.Test.Load
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShowDown()
        {
            const int iteration = 100;

            // Way 1
            IColorProvider way1 = new DirectxColorProvider();

            // Way 2
            IColorProvider way2 = new GDIColorProvider();            

            var timer1 = new Stopwatch();
            timer1.Start();

            for (int x = 0; x < iteration; x++)
            {
                way1.GetColors();
            }

            timer1.Stop();
            Console.WriteLine(timer1.Elapsed);

            

            var timer2 = new Stopwatch();
            timer2.Start();

            for (int x = 0; x < iteration; x++)
            {
                way2.GetColors();
            }

            timer2.Stop();
            Console.WriteLine(timer2.Elapsed);
        }
    }
}
