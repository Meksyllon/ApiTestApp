using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal static class BitcoinPrice
    {
        public static string GetBitcoinPriceIndex()
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://api.coindesk.com/v1/bpi/currentprice.json");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JObject.Parse(sReadData);
            string info = $"Updated: {d.time.updated}\n{d.disclaimer}\n1 BitCoin is: \t{d.bpi.USD.rate_float} USD\n\t\t{d.bpi.EUR.rate_float} EUR";
            return info;
        }
    }
}
