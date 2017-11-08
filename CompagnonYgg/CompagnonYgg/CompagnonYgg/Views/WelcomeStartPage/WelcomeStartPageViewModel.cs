using Autofac;
using Doods.StdFramework;
using Doods.StdFramework.ApplicationObjects;
using Doods.StdFramework.Interfaces;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YggClientCodePcl.Categories;

namespace CompagnonYgg.Core.Views.WelcomeStartPage
{
    public class WelcomeStartPageViewModel : BaseViewModel
    {
        public string SeachText { get; set; }

        public ObservableRangeCollection<Category> Categories { get; private set; }

        public ObservableRangeCollection<SubCategory> SubCategories { get; private set; }

        private Category _selectedCategorie { get; set; }

        public Category SelectedCategorie
        {
            get => _selectedCategorie;
            set
            {
                _selectedCategorie = value;
                SubCategories.ReplaceRange(_selectedCategorie.SubCategorieses);
            }
        }


        public SubCategory SelectedSubCategories { get; set; }

        public ICommand SearchCmd { get; private set; }

        public WelcomeStartPageViewModel(ILogger logger) : base(logger)
        {
            SearchCmd = new Command(Search);
            Categories = new ObservableRangeCollection<Category>();
            SubCategories = new ObservableRangeCollection<SubCategory>();
        }

        private void Search(object obj)
        {
            throw new System.NotImplementedException();
        }

        protected override async Task Load()
        {
            var builder = AppContainer.Container.Resolve<CategoryBuilder>();
            var cat = builder.GetAllCategory();
            Categories.ReplaceRange(cat);


            var client = AppContainer.Container.Resolve<YggClientCodePcl.YggClient>();
            client.Index();


        }
    }
}