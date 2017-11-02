
using Xamarin.Forms;

namespace CompagnonYgg.Core.Views.MasterDetailHomePage
{
    public class MasterDetailPageDetail : ContentPage
    {
        public MasterDetailPageDetail()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}