using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PokemonExplorer.Data
{
    public class Pokemon
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        private string NameValue;
        [JsonPropertyName("name")]
        public string Name
        {
            get => NameValue;
            set
            {
                NameValue = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        protected void RaisePropertyChanged(string propertyName) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
        [JsonPropertyName("abilities")]
        public ObservableCollection<Abilities> Abilities { get; set; }

        [JsonPropertyName("sprites")]
        public Sprite Sprites { get; set; }

    }

    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
    public class Sprite
    {
        [JsonPropertyName("front_default")]
        public string Front_default { get; set; }
       
      
        [JsonPropertyName("back_default")]
        public string Back_default { get; set; }
        protected void RaisePropertyChanged(string propertyName) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }
    }
}
