using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class WindInfo
    {
        //скорость ветра
        public float speed { get; set; }
        //направление ветра
        public int deg { get; set; }
        //плотноть тумана
        public float gust { get; set; }
    }
}
