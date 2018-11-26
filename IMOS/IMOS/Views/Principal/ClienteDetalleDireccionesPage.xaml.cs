using IMOS.Models.Tables;
using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class ClienteDetalleDireccionesPage : ContentPage
    {
        public ClienteDetalleDireccionesPage(Clientes client)
        {
            InitializeComponent();
            this.BindingContext = new ClienteDetalleDireccionesPageViewModel(client);
        }
    }
}
