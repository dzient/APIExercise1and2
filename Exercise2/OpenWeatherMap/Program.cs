//-----------------------------------------
// David Zientara
// 11-9-2022
// Program uses OpenWeatherMap to 
// generate a weather report given a city
// 
//--------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OpenWeatherMap
{
    class Program
    {


        public static void Main()
        {
            var client = new HttpClient();
            //Console.WriteLine("Please enter API key: ");
            // I pasted the API key here so you don't have to enter it:
            var api_key = "f1a9a38f0ec88365e3892954efa68313";
            //Console.ReadLine();
            var city_name = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name (or quit to exit: ");
                //Enter city name and catch a null reference and any other exceptions:
                try
                {
                    city_name = Console.ReadLine();
                }
                catch (System.NullReferenceException) //NullReferenceException often happens
                {
                    Console.WriteLine("Null reference exception.");
                    return;
                }
                catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
                {
                    Console.WriteLine("Unknown error: " + ex.Message);
                }
                if (city_name != "quit") // Put this so that if the user enters quit, the program terminates
                {
                    // create the weather URL:
                    var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";
                    try
                    {
                        // Get the current string, format it and print it out:
                        var response = client.GetStringAsync(weatherURL).Result;
                        var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                        Console.WriteLine(formattedResponse);
                        Console.WriteLine();
                    }
                    catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
                    {
                        //Not sure what errors this generates, but catching an exeception is better than nothing:
                        Console.WriteLine("Unknown error: " + ex.Message);
                    }
                }
            } while (city_name != "quit") ;
        }
    }
}