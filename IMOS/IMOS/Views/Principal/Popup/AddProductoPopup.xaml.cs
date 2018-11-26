using System;
using System.Collections.Generic;
using IMOS.Models.Tables;
using IMOS.ViewModels.Principal.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace IMOS.Views.Principal.Popup
{
    public partial class AddProductoPopup : PopupPage
    {
        public AddProductoPopup(Producto producto, int IdCliente)
        {
            InitializeComponent();
            this.BindingContext = new AddProductoPopupViewModel(producto, IdCliente);
        }
    }
}
