//-----------------------------------------
// David Zientara
// 11-9-2022
// Program prints Kayne + Ron Swanson quotes 
// 
//--------------------------------------------


using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KayneREST;

namespace KayneWest
{
    class Program
    {
        private static string? kanyeURL = "https://api.kanye.rest";
        private static string? ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        public static void Main(string[] args) //, JObject jObject)
        {
            //Program just alternates between Kayne quotes (from the Kayne API)
            //and Ron Swanson quotes (from the Ron Swanson quotes API) and prints them out
            var client = new HttpClient();
            int i = 0;
            KayneREST.QuoteGenerator quote = new QuoteGenerator();

            for (i = 0; i < 5; i++)
            {
                // Get and print a Kayne response:
                try
                {
                    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                    var kanyeQuote = JObject.Parse(json: kanyeResponse).GetValue("quote").ToString();
                    Console.WriteLine($"Kayne West: {quote.GetKayneQuote()}");
                }
                catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
                {
                    Console.WriteLine("Unknown error: " + ex.Message);
                }
                // Do the same thing for Ron Swanson:
                try
                {
                    var ronSwansonResponse = client.GetStringAsync(ronSwansonURL).Result;
                    var ronSwansonQuote = JArray.Parse(ronSwansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                    Console.WriteLine($"Ron Swanson: {ronSwansonQuote}");
                }
                catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
                {
                    Console.WriteLine("Unknown error: " + ex.Message);
                }
                // Print a separator to separate the quotes:
                Console.WriteLine("========================");
             }
        }
    }
}