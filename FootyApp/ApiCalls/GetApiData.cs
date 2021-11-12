using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FootyApp.ApiCalls
{
    public class GetApiData
    {
        public static async Task<PremierLeagueJson.Standing> GetPremTableAsync()
        {
            string jsonString = "";
            var apiKey = "ccea16844b5a447fb3c7a00703a0e4ec";
            var premTableUrl = "http://api.football-data.org/v2/competitions/2021/standings";
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                var response = await client.GetAsync(premTableUrl);
                if (response != null)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonString);
                    Console.WriteLine("+++++++++++++++++++++++++++++++++");
                    var bbbb = JsonConvert.DeserializeObject<PremierLeagueJson.Root>(jsonString);
                    Console.WriteLine(bbbb.competition.name);
                    var standings = bbbb.standings[0];
                    return standings;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"errrrorrrrr '{ex.GetType()}': {ex.Message}";
                Console.WriteLine(jsonString);
                Console.WriteLine(errorMsg);
                throw new Exception(errorMsg);
            }
            return null;
        }

        [JsonObject]
        public class Response
        {
            public PremTableResponse PremTableResponse { get; set; }
        }

        [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
        public class PremTableResponse
        {
            [JsonProperty(PropertyName = "filters")]
            public List<string> Filters { get; set; }
            //public object Filters { get; set; }
            [JsonProperty(PropertyName = "competition")]
            public Competition Competition { get; set; }
            [JsonProperty(PropertyName = "season")]
            public Season Season { get; set; }
            [JsonProperty(PropertyName = "standings")]
            public Standings Standings { get; set; }
        }

        [JsonObject]
        public class Filters
        {

        }

        [JsonObject]
        public class Competition
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("area")]
            public Area Area { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("code")]
            public string Code { get; set; }
            [JsonPropertyName("plan")]
            public string Plan { get; set; }
            [JsonPropertyName("lastUpdated")]
            public string LastUpdated { get; set; }
        }

        [JsonObject]
        public class Area
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        [JsonObject]
        public class Season
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("startData")]
            public string StartDate { get; set; }
            [JsonPropertyName("endDate")]
            public string EndDate { get; set; }
            [JsonPropertyName("currentMatchday")]
            public int CurrentMatchday { get; set; }
            [JsonPropertyName("winner")]
            public string Winner { get; set; }
        }

        [JsonObject]
        public class Standings
        {

        }



        //    public static PremTableResponse GetPremTable()
        //    {
        //        var apiKey = "ccea16844b5a447fb3c7a00703a0e4ec";
        //        var premTableUrl = "http://api.football-data.org/v2/competitions/2021/standings";
        //        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(premTableUrl);

        //        WebReq.Method = "GET";
        //        WebReq.Headers["X-Auth-Token"] = apiKey;


        //        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

        //        Console.WriteLine(WebResp.StatusCode);
        //        Console.WriteLine(WebResp.StatusCode);
        //        Console.WriteLine(WebResp.StatusCode);
        //        Console.WriteLine(WebResp.Server);

        //        string jsonString;
        //        using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
        //        {
        //            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
        //            jsonString = reader.ReadToEnd();
        //        }

        //        Console.WriteLine("");
        //        Console.WriteLine(jsonString);
        //        Console.WriteLine("");


        //        List<PremTableResponse> response = JsonConvert.DeserializeObject<List<PremTableResponse>>(jsonString);

        //        //Console.WriteLine(response[0].PremTableResponse.Competition);
        //        return response[0];
        //    }
        //}
    }
}
