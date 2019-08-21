using Everis.Data;
using Everis.Services;
using Everis.Views;
using Xamarin.Forms;

namespace Everis
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var criarTabelas = new DataBase();
            criarTabelas.InitTables();
            DependencyService.Register<EventoDataStore>();
            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
