using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class CrearClientePage : ContentPage
    {
        public CrearClientePage()
        {
            InitializeComponent();
            this.BindingContext = new CrearClientePageViewModel();
        }
    }
}
