
using IMOS.Models.Tables;
using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class VentaDetallePage : ContentPage
    {
        public VentaDetallePage(Clientes clientes)
        {
            InitializeComponent();
            this.BindingContext = new VentaDetallePageViewModel(clientes);
        }
    }
}
