using System.Text.Json;
using PokemonExplorer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Pokemon;

namespace PokemonExplorer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Data.Pokemon> Pokemons { get; set; }= new ObservableCollection<Data.Pokemon>();
        public string Message { get; set; } = "Welcome to my PokemonExplorer!";


        private readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon") };
 

        public MainPage()
        {
            InitializeComponent();

            Pokemons.Add(new Data.Pokemon { Name = "Daniel" });

            BindingContext = this;
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            
            var details = e.Item as Data.Pokemon;
            await Navigation.PushModalAsync(new DetailPage(details));
            
        }
        public async Task GetPokemons()
        {
            var response = await httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody).Results;
            foreach (var pokemon in pokemons)
            {

                var cur = await httpClient.GetAsync(pokemon.Url);
                var body = await cur.Content.ReadAsStringAsync();

                var curdetails = JsonSerializer.Deserialize<Data.Pokemon>(body);
               
                Pokemons.Add(curdetails);
            }
            Message = "Received " + Pokemons.Count() + " pokemons!";
            

        }
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Get_Data(object sender, EventArgs e)
        {
            await GetPokemons();
        }
    }
}
