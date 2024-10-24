using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal static class RandomCatFact
    {
        public static string GetRandomCatFact()
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://catfact.ninja/fact");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JObject.Parse(sReadData);
            return (string)d.fact;
        }
    }
}
