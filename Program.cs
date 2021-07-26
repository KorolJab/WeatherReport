using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace WeatherReport
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //пользователь вводит данные
            Console.Write("Введите город температуру которого вы хотите узнать:");
            string inputCity = Console.ReadLine();
            Console.Write("Введите язык вывода:");
            string inputLang = Console.ReadLine();
            WeatherCaller call = new WeatherCaller(inputCity,inputLang);
        }
    }

}
