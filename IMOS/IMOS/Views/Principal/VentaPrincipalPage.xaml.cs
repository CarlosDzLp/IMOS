using IMOS.Models.Tables;
using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class VentaPrincipalPage : ContentPage
    {
        public VentaPrincipalPage(Clientes clientes)
        {
            InitializeComponent();
            this.BindingContext = new VentaPrincipalPageViewModel(clientes);
        }
    }
}
