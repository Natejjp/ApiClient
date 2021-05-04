using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace ApiClient
{
    class brewery
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brewery_type { get; set; }
        public string street { get; set; }
        public string address_2 { get; set; }
        public string address_3 { get; set; }
        public string city { get; set; }
        public string county_province { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string phone { get; set; }
        public string website_url { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime create_at { get; set; }

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync(
            "https://api.openbrewerydb.org/breweries/search?query=dog"
            );
            var breweries = await JsonSerializer.DeserializeAsync<List<brewery>>(responseAsStream);

            foreach (var brewery in breweries)
            {
                Console.WriteLine($"The brewery {brewery.name} is located in {brewery.city}!");
            }
        }
    }
}
