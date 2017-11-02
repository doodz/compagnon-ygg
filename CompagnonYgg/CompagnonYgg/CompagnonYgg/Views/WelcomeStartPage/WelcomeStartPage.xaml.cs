using CompagnonYgg.Core.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompagnonYgg.Core.Views.WelcomeStartPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeStartPage : ContentPage
    {
        public WelcomeStartPage()
        {
            InitializeComponent();

            var test = new YggClient();
            var home = test.Home().Result;

            var parseur = new HtmlParseur();
            var row = parseur.Pars(home);

        }


    }
}