﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal static class AgeByName
    {
        public static string PredictAgeByName()
        {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            var request = (HttpWebRequest)WebRequest.Create($"https://api.agify.io?name={name}");
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JObject.Parse(sReadData);
            return $"Around {d.age}y.o. by {d.count} people";
        }
    }
}
