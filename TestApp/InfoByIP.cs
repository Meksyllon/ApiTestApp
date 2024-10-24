using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal static class InfoByIP
    {
        public static string FirstIPRequest()
        {
            Console.WriteLine("Enter IP");
            var ip = Console.ReadLine(); ;
            var request = (HttpWebRequest)WebRequest.Create($"http://ipwho.is/{ip}");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(sReadData);

            return d.ToString();
        }

        public  static string SecondIPRequest()
        {
            Console.WriteLine("Enter IP");
            var ip = Console.ReadLine(); ;
            RestClient client = new RestClient($"https://suggestions.dadata.ru/suggestions/api/4_1/rs/iplocate/address?ip={ip}");
            RestRequest request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Token adcfb5ba15496bf555e22da6ed74ea6d5cdbba06");
            var response = client.Execute(request);

            string stream = response.Content;

            dynamic d = JsonConvert.DeserializeObject(stream);
            return d.ToString();
        }
    }
}
