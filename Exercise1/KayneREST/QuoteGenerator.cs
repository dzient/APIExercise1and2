using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayneREST
{
    public class QuoteGenerator
    {
        private static string? ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

        int i = 0;

        string kayneResponse, ronResponse, chuckResponse, musicResponse, numbersResponse;
        private string? kayneURL = "https://api.kanye.rest";
        private string chuckURL = "https://api.chucknorris.io/jokes/random";
        private string musixmatchURL = "https://api.musixmatch.com/ws/1.1/chart.tracks.get?chart_name=top&page=1&page_size=5&country=it&f_has_lyrics=1"; //" https://api.musixmatch.com/ws/1.1/";
        private string numbersURL = "http://numbersapi.com/#";
        /// </summary>

        public QuoteGenerator()
        {
            var client = new HttpClient();
            kayneResponse = client.GetStringAsync(kayneURL).Result;
            ronResponse = client.GetStringAsync(ronSwansonURL).Result;
            //musicResponse = client.GetStringAsync(musicmatchURL).Result();

        }

        public String GetKayneQuote()
        {
            //var client = new HttpClient();
            //var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            return JObject.Parse(json: kayneResponse).GetValue("quote").ToString();
        }
        public string getRonQuote()
        {
            //var ronSwansonResponse = client.GetStringAsync(ronSwansonURL).Result;
            var ronSwansonQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronSwansonQuote;
        }
        public string ChuckNorrisQuote()
        {
            var client = new HttpClient();
            chuckResponse = client.GetStringAsync(chuckURL).Result;
            if (chuckResponse != null)
                return JObject.Parse(json: chuckResponse).GetValue("value").ToString();
            return "Insert Chuck Norris quote here";
        }
        public string NumbersQuote()
        {
            var rand = new Random();
            var client = new HttpClient();
            int num = rand.Next() % 100;
            string res = numbersURL + num.ToString();
            numbersResponse = client.GetStringAsync(numbersURL).Result;
            if (numbersResponse != null)
                return JObject.Parse(json: chuckResponse).GetValue("text").ToString();
            //return numbersResponse.ToString();
             //   return JArray.Parse(json: numbersResponse).ToString();

            return "Insert numbers quote here";
        }
    }
}
