using ArduinoTest.Components.ColorManagment.Mapper.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoTest.Components.ColorManagment.Mapper
{
    public class ColorMapper : IColorMapper
    {
        public byte[] Map(System.Drawing.Color color)
        {
            return new Byte[]
            {
                color.R,
                color.G,
                color.B
            };
        }
    }
}
