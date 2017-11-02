using Doods.StdFramework.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompagnonYgg.Core.Views.MasterDetailHomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ViewPage<MasterDetailHomePageViewModel>
    {
        public readonly ListView ListView;
        public MasterDetailPageMaster()
        {
            InitializeComponent();
            ListView = MenuItemsListView;
        }
    }
}