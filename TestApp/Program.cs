using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(InfoByIP.FirstIPRequest());
            //Console.WriteLine(InfoByIP.SecondIPRequest());
            //Console.WriteLine(BitcoinPrice.GetBitcoinPriceIndex());
            //Console.WriteLine(RandomCatFact.GetRandomCatFact());
            //Console.WriteLine(AgeByName.PredictAgeByName());
            //Console.WriteLine(GenderByName.PredictGenderByName());
            Console.WriteLine(CountryByName.PredictCountryByName());
        }
    }
}
