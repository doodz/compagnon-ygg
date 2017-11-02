using CompagnonYgg.Core.Views.WelcomeStartPage;
using Xamarin.Forms;

namespace CompagnonYgg.Core
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            FirstLogin();
        }

        protected async override void OnStart()
        {

            //MobileCenter.Start("ios={a1180a5d-28a0-4ea3-9eda-7b2aa8d4cba3};android={e3bb5908-01c3-4286-811f-b07537a6a632};uwp={4fb715f8-a0ed-46ce-8ac8-9785a6ca11e4}", typeof(Analytics), typeof(Crashes));
            //await Analytics.SetEnabledAsync(true);
            //await Crashes.SetEnabledAsync(true);
            //Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
            //MobileCenter.Start(typeof(Analytics), typeof(Crashes));
            //MobileCenter.Start(typeof(Analytics), typeof(Crashes));
            //MessagingCenter.Subscribe<object, Exception>(this, Messages.ExceptionOccurred, OnAppExceptionOccurred);

            // Handle when your app starts
        }

        private void FirstLogin()
        {
            MainPage = new WelcomeStartPage();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            //CrossConnectivity.Current.ConnectivityChanged -= ConnectivityChanged;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            //Settings.Current.IsConnected = CrossConnectivity.Current.IsConnected;
            //CrossConnectivity.Current.ConnectivityChanged += ConnectivityChanged;
        }
    }
}
