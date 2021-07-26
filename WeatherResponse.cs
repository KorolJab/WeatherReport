using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class WeatherResponse
    {
        public TemInfo main { get; set; }
        public WindInfo wind { get; set; }
        public string Name { get; set; }
        public Rain rain { get; set; }
        public int visibility { get; set; }

        public Weather[] weather;               //массив с общими данными о погоде
        public Clouds clouds { get; set; }

    
    }
}
