using IMOS.Models.Tables;
using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class TabVentasPage : TabbedPage
    {
        public TabVentasPage(Clientes clientes)
        {
            InitializeComponent();
            this.BindingContext = new TabVentasPageViewModel(clientes);
            Children.Add(new VentaPrincipalPage(clientes));
            Children.Add(new VentaDetallePage(clientes));
        }
    }
}
