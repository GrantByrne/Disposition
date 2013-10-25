using System;
using System.Drawing;
using System.Collections.Generic;

namespace ArduinoTest.Components.ColorManagment.Service.Abstract
{
    public interface ISamplePointService
    {
        SamplePoints GetSamplePoints(float screenPercentage);
    }
}
