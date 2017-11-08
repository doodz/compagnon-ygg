using Doods.StdFramework.Mvvm;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompagnonYgg.Core.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPage : BaseMasterDetailPage<HomeMasterDetailPageMenuItem>
    {
        public HomeMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            var res = MasterPage.ListView.ItemsSource.Cast<HomeMasterDetailPageMenuItem>().FirstOrDefault();

            //var select = MasterPage.ListView.SelectedItem;
            SetPage(res);
        }

        protected override void OnSetPage()
        {
            MasterPage.ListView.SelectedItem = null;
        }


        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HomeMasterDetailPageMenuItem;
            SetPage(item);
        }

       
    }
}