using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestPokemonRequest
{
    class Program
    {
        private static readonly HttpClient httpClient  = new HttpClient();


        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var Pokemons = new ObservableCollection<Pokemon>();

            var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody).Results;
            Console.WriteLine(pokemons.First().Name);
        }
    }
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
      
    }

    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}
