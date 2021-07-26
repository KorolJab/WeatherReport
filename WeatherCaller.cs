using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherReport
{
    class WeatherCaller
    {
     
        HttpWebRequest httpWebRequest;
        HttpWebResponse httpWebResponse;
        private string lang;
        private string systemCounting;

        //десериализация json объект
        public WeatherCaller(string inputCity,string inputLang)
        {
            lang = inputLang;
            httpWebResponse = (HttpWebResponse)returnRequest(inputCity,inputLang).GetResponse();

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response());
            print(weatherResponse);
        }

        //создание объекта запроса
        private HttpWebRequest returnRequest(string inputCity= "Moscow", string inputLang="ru")
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={inputCity}&lang={inputLang}&units=metric&appid=969a42517e467cd22a2de2e462bd632f");
            return httpWebRequest;
        }
        
        //получение ответа с сайта
        private string response()
        {
            string tempResponse;

            using (StreamReader streamreader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                tempResponse = streamreader.ReadToEnd();
            }
            return tempResponse;
        }

        //вывод данных о погоде на экран на русском
        public void print(WeatherResponse weatherResponse)
        {
            if(lang=="ru")
            {
                Console.WriteLine($"В городе {weatherResponse.Name} сйечас:{weatherResponse.weather[0].description}");

                //просто температура
                Console.WriteLine($"Температура в городе {weatherResponse.Name} сейчас:{weatherResponse.main.temp}, ощущается как:{Math.Round(weatherResponse.main.feels_like)}");
                Console.WriteLine($"Минимальная темпаратура в городе:{weatherResponse.main.temp_min}, максимальная:{weatherResponse.main.temp_max}");

                //ветер
                Console.WriteLine($"Скорость ветра:{weatherResponse.wind.speed}, наклон ветра:{weatherResponse.wind.deg}");

                //побочные показатели
                Console.WriteLine($"Давление:{Math.Round(((weatherResponse.main.pressure * 1.0) / 133), 2) * 100} мм.р.с.");
                Console.WriteLine($"Видимость {weatherResponse.visibility / 1000}км, {weatherResponse.visibility % 1000}метров");

                //выводим длительность если идёт дождь
                if (weatherResponse.rain != null)
                {
                    Console.WriteLine($"Длительность дождя{ weatherResponse.rain.h1}{weatherResponse.rain.h3}");
                }
                //облака если есть
                if (weatherResponse.clouds != null)
                {
                    Console.WriteLine($"Показатель тумана: {weatherResponse.wind.gust}");
                }
            }

            //на английском
            else
            {
                Console.WriteLine($"In city {weatherResponse.Name} now:{weatherResponse.weather[0].description}");

                //просто температура
                Console.WriteLine($"Temperature in city {weatherResponse.Name} now:{weatherResponse.main.temp}, feels like:{Math.Round(weatherResponse.main.feels_like)}");
                Console.WriteLine($"Min temperature is:{weatherResponse.main.temp_min}, max:{weatherResponse.main.temp_max}");

                //ветер
                Console.WriteLine($"Speed of wind:{weatherResponse.wind.speed}, wind deg:{weatherResponse.wind.deg}");

                //побочные показатели
                Console.WriteLine($"Давление:{Math.Round(((weatherResponse.main.pressure * 1.0) / 133), 2) * 100} мм.р.с.");
                Console.WriteLine($"Visibility {weatherResponse.visibility / 1000}km, {weatherResponse.visibility % 1000}meters");

                //выводим длительность если дождь есть
                if (weatherResponse.rain != null)
                {
                    Console.WriteLine($"Rain duration{ weatherResponse.rain.h1}{weatherResponse.rain.h3}");
                }
                //облака если есть
                if (weatherResponse.clouds != null)
                {
                    Console.WriteLine($"Fog: {weatherResponse.wind.gust}");
                }
            }
            
        }
    }
}
