using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal static class CountryByName
    {
        public static string PredictCountryByName()
        {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            var request = (HttpWebRequest)WebRequest.Create($"https://api.nationalize.io?name={name}");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();
            dynamic d = JObject.Parse(sReadData);
            dynamic countryList = (JArray)d.country;
            var info = new StringBuilder();
            foreach (var country in countryList)
            {
                var countryName = new RegionInfo(country.country_id.ToString()).EnglishName;
                var probability = Math.Round((double)(country.probability * 100), 2);
                info.Append($"{countryName} - {probability}%\n");
            }
            info.Append($"Based on {d.count} data");

            return info.ToString();
        }
    }
}
