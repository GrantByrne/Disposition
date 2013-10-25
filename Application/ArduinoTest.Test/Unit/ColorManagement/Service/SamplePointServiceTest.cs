using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArduinoTest.Components.ColorManagment.Service;
using ArduinoTest.Components.ColorManagment.Service.Abstract;

namespace ArduinoTest.Test.Unit.ColorManagement.Service
{
    [TestClass]
    public class SamplePointServiceTest
    {
        private readonly ISamplePointService _samplePointService;

        /// <summary>
        /// ctor
        /// </summary>
        public SamplePointServiceTest()
        {
            _samplePointService = new SamplePointService();
        }
        
        [TestMethod]
        public void GetSamplePoints_WithinRange_Succes()
        {
            var result = _samplePointService.GetSamplePoints(.30f);

            foreach(var point in result.Points)
            {
                Assert.IsTrue(point.X >= result.CenterBox.X);
                Assert.IsTrue(point.X <= result.CenterBox.X + result.CenterBox.Width);
                Assert.IsTrue(point.Y >= result.CenterBox.Y);
                Assert.IsTrue(point.Y <= result.CenterBox.Y + result.CenterBox.Height);
            }
        }
    }
}
