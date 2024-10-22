using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter IP");
            //var ip = Console.ReadLine(); ;
            //FirstRequest(ip);
            //SecondRequest(ip);
            ThirdRequest();
        }
        public static void FirstRequest(string ip)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://ipwho.is/{ip}");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(sReadData);

            Console.WriteLine(d);
        }

        public static void ThirdRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://dummyjson.com/users");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JObject.Parse(sReadData);

            foreach (dynamic user in d.users)
                Console.WriteLine($"{user.id} Name: {user.firstName} {user.lastName} | Phone: {user.phone}");            
        }


        public static void SecondRequest(string ip)
        {
            RestClient client = new RestClient($"https://suggestions.dadata.ru/suggestions/api/4_1/rs/iplocate/address?ip={ip}");
            RestRequest request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Token adcfb5ba15496bf555e22da6ed74ea6d5cdbba06");
            var response = client.Execute(request);

            string stream = response.Content;

            dynamic d = JsonConvert.DeserializeObject(stream);

            Console.WriteLine(d);
        }
    }
}
