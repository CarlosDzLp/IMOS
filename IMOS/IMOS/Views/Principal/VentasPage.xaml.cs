using IMOS.ViewModels.Principal;
using Xamarin.Forms;

namespace IMOS.Views.Principal
{
    public partial class VentasPage : ContentPage
    {
        public VentasPage()
        {
            InitializeComponent();
            this.BindingContext = new VentasPageViewModel();
        }
    }
}
