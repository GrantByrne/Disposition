using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArduinoTest.Components.ColorManagment.Mapper.Abstract
{
    public interface IColorMapper
    {
        byte[] Map(Color color);
    }
}
