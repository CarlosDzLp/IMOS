using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using IMOS.DbLocal;
using IMOS.Models.Tables;
using IMOS.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace IMOS.ViewModels.Principal.Popup
{
    public class ShowProductoCartPopupViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region Properties
        private Clientes _cliente;
        public Clientes Cliente
        {
            get { return _cliente; }
            set { SetProperty(ref _cliente, value); }
        }


        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        private bool _visibleList;
        public bool VisibleList
        {
            get { return _visibleList; }
            set { SetProperty(ref _visibleList, value); }
        }

        private bool _visibleLabel;
        public bool VisibleLabel
        {
            get { return _visibleLabel; }
            set { SetProperty(ref _visibleLabel, value); }
        }
        #endregion


        #region Constructor
        public ShowProductoCartPopupViewModel(Clientes cliente)
        {
            Cliente = new Clientes();
            Cliente = cliente;
            //ListVentaProducto = new ObservableCollection<VentaProducto>();
            LoadVentaProduct();
            RefreshCommandList = new Command(LoadVentaProduct);
            ClickCloseCommand = new Command(async() => { await PopupNavigation.PopAsync(); });
        }
        #endregion

        #region Methods
        private void LoadVentaProduct()
        {
            try
            {
                IsRefreshing = true;
                //var listventa = db.GetListVentaProducto(Cliente.IdUsuario, Cliente.IdCliente);
                //if(listventa.Count>0)
                //{
                    VisibleLabel = false;
                    VisibleList = true;
                  //  foreach (var item in listventa)
                    //{
                      //  ListVentaProducto.Add(item);
                   // }
                //}
                //else
                //{
                    VisibleLabel = true;
                    VisibleList = false;
                //}
                IsRefreshing = false;
            }
            catch (Exception ex)
            {
                IsRefreshing = false;
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand RefreshCommandList { get; set; }
        public ICommand ClickCloseCommand { get; set; }
        #endregion
    }
}
