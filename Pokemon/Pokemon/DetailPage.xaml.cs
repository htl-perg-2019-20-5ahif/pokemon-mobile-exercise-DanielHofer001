using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PokemonExplorer.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public PokemonExplorer.Data.Pokemon Pokemon { get; set; }

        public DetailPage(PokemonExplorer.Data.Pokemon details)
        {
            InitializeComponent();

            Pokemon = details;

            BindingContext = Pokemon;
        }
       
    }
}
