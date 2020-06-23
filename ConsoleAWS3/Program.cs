using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAWS3
{
    class Program
    {


        public static async Task Main(string[] args)
        {
            string url = "https://7g2mowaod6.execute-api.us-west-1.amazonaws.com/h/ATH";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
                    beautifyJSon(strResult);
                }
                else
                {
                    Console.WriteLine("nothing");
                }
            }
            Console.ReadLine();

        }
        private static void beautifyJSon(string str)
        {
            JToken parsedJson = JToken.Parse(str);
            string beautifiedJson = parsedJson.ToString(Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(beautifiedJson);
        }
        
    }
}
