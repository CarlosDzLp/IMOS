using System;
using System.Collections.Generic;
using IMOS.Models.Tables;
using IMOS.ViewModels.Principal.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace IMOS.Views.Principal.Popup
{
    public partial class ShowProductoCartPopup : PopupPage
    {
        public ShowProductoCartPopup(Clientes cliente)
        {
            InitializeComponent();
            this.BindingContext = new ShowProductoCartPopupViewModel(cliente);
        }
    }
}
