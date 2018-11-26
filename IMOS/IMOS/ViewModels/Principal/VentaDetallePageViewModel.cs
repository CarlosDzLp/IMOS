using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using IMOS.DbLocal;
using IMOS.Models.Tables;
using IMOS.ViewModels.Base;
using IMOS.Views.Principal.Popup;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace IMOS.ViewModels.Principal
{
    public class VentaDetallePageViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region Properties
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                if (_textSearch != value)
                {
                    SetProperty(ref _textSearch, value);
                    SearchCommandExecuted();
                }
            }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private Clientes _clientes;
        public Clientes Clientes
        {
            get { return _clientes; }
         set { SetProperty(ref _clientes, value); }
        }


        private ObservableCollection<Producto> _listProducto;
        public ObservableCollection<Producto> ListProducto
        {
            get { return _listProducto; }
            set { SetProperty(ref _listProducto, value); }
        }

        private ObservableCollection<Producto> _listProductoMemory;
        public ObservableCollection<Producto> ListProductoMemory
        {
            get { return _listProductoMemory; }
            set { SetProperty(ref _listProductoMemory, value); }
        }
        #endregion

        #region Constructor
        public VentaDetallePageViewModel(Clientes clientes)
        {
            Clientes = new Clientes();
            Clientes = clientes;
            ListProductoMemory = new ObservableCollection<Producto>();
            ListProducto = new ObservableCollection<Producto>();
            LoadProductos();
            ShowProductoCommand = new Command(ShowProductoCommandExecuted);
            RefreshCommandList = new Command(LoadProductos);
            SearchCommand = new Command(SearchCommandExecuted);
        }
        #endregion

        #region Methods


        private void LoadProductos()         {             try             {
                IsRefreshing = true;                 ListProductoMemory.Clear();                 var producto = db.GetListProducto();                 foreach (var item in producto)                 {                     ListProductoMemory.Add(item);                 }
                ListProducto = ListProductoMemory;
                IsRefreshing = false;             }             catch (Exception ex)             {
                IsRefreshing = false;                 Debug.WriteLine(ex.Message);             }         } 
        private async void OnTapProducto(Producto producto)         {             try             {                 if (producto != null)                 {                     //despliega el popup para agregar productos pasandole el producto
                    await PopupNavigation.PushAsync(new AddProductoPopup(producto,Clientes.IdCliente));                 }             }             catch (Exception ex)             {                 Debug.WriteLine(ex.Message);             }         }
        #endregion

        #region Commands
        public ICommand ShowProductoCommand { get; set; }
        public ICommand RefreshCommandList { get; set; }
        public ICommand ItemClickCommand
        {
            get
            {
                return new Command((item) =>
                {
                    var selected = item as Producto;
                    OnTapProducto(selected);
                });
            }
        }
        public ICommand SearchCommand
        {
            get;
            set;
        }
        #endregion

        #region CommandExecuted
        private async void ShowProductoCommandExecuted()
        {
            try
            {
                //muetsra el detalle de los productos agrgados
                await PopupNavigation.PushAsync(new ShowProductoCartPopup(Clientes));
            }
            catch(Exception ex)
            {

            }
        }



        private void SearchCommandExecuted()
        {
            try
            {
                if (string.IsNullOrEmpty(TextSearch))
                {
                    ListProducto = ListProductoMemory;
                }
                else
                {
                    ListProducto = new ObservableCollection<Producto>(ListProductoMemory.Where(c => c.Descripcion.ToLower().Contains(TextSearch.ToLower())));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
