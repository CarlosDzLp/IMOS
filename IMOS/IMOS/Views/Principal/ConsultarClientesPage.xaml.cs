using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class ConsultarClientesPage : ContentPage
    {
        public ConsultarClientesPage()
        {
            InitializeComponent();
            this.BindingContext = new ConsultaclientesPageViewModel();
        }
    }
}
