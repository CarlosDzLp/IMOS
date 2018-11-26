using IMOS.Views.Principal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IMOS.DbLocal;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IMOS
{
    public partial class App : Application
    {
        public static MasterPage MasterPageDetail { get; set; }
        public App()
        {
            InitializeComponent();
            //
            var db = new DbContext();
            var user = db.GetUser();
            if (user != null)
            {
                MainPage = new MasterPage();
            }
            else
            {
                MainPage = new NavigationPage(new Views.Session.LoginPage());
            }
        }
        public static void MessageError(string mesage)
        {
            App.Current.MainPage.DisplayAlert("Error", mesage, "Aceptar");
        }
        public static void MessageSuccess(string mesage)
        {
            App.Current.MainPage.DisplayAlert("IMOS", mesage, "Aceptar");
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
