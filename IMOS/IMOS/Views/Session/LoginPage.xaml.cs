using IMOS.ViewModels.Session;
using Xamarin.Forms;

namespace IMOS.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //se pasa el viewmodel a la vista
            this.BindingContext = new LoginPageViewModel();
        }
    }
}
