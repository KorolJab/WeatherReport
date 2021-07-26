using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class TemInfo
    {
        public float temp { get; set; }                                  //усреднённая температура
        public float feels_like { get; set; }                            //ощущается как
        public float temp_min { get; set; }                              //минимальная температура
        public float temp_max { get; set; }                              //максимальная температура
        public int pressure { get; set; }                                //давление
        public int humidity { get; set; }                                //видимость
        public int sea_level { get; set; }                               //уровень моря
    }
}
