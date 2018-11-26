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
    public class AddProductoPopupViewModel : BindableBase
    {
        Producto _producto = new Producto();
        DbContext db = new DbContext();
        #region Properties
        private string _nombreProducto;
        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { SetProperty(ref _nombreProducto, value); }
        }

        private string _cantidad;
        public string Cantidad
        {
            get { return _cantidad; }
            set 
            {
                if (_cantidad != value)                 {                     SetProperty(ref _cantidad, value);                     OnTapCantidad();                 }
            }
        }

        private string _precio;
        public string Precio
        {
            get { return _precio; }
            set { SetProperty(ref _precio, value); }
        }

        private string _valor;
        public string Valor
        {
            get { return _valor; }
            set { SetProperty(ref _valor, value); }
        }
        #endregion
        int idcliente = 0;
        #region constructor
        public AddProductoPopupViewModel(Producto producto, int IdCliente)
        {
            //ListVenta = new ObservableCollection<VentasCliente>();
            this.idcliente = idcliente;
            _producto = producto;
            NombreProducto = producto.Descripcion;
            Precio = producto.Precio.ToString();
            //LoadVenta();
            GuardarVentaCommand = new Command(GuardarVentaCommandExecuted);
        }
        #endregion

        #region Methods
        private void LoadVenta()
        {
            try
            {
                var user = db.GetUser();
                //var response = db.GetVentasProduct(user.IdUser, idcliente);
                //foreach(var item in response)
                //{
                  //  ListVenta.Add(item);
                //}
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void OnTapCantidad()         {             try             {                 if (!string.IsNullOrEmpty(Cantidad))                 {                     var precio = Convert.ToSingle(Precio);                     var totalvalor = Convert.ToInt32(Cantidad) * precio;                     Valor = totalvalor.ToString("N2");                 }
                else
                {
                    Valor = "0";
                }             }             catch (Exception ex)             {                 Debug.WriteLine(ex.Message);             }         }
        #endregion


        #region Command
        public ICommand GuardarVentaCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void GuardarVentaCommandExecuted()
        {
            try
            {
                //inserta un producto
                //if (Producto != null)
                //{
                  //  if (!string.IsNullOrEmpty(Cantidad))
                    //{
                      //  if (!string.IsNullOrEmpty(Precio))
                        //{
                          //  if (!string.IsNullOrEmpty(Valor))
                            //{
                              //  if(Venta!=null)
                                //{
                                    //inserta el producto de la venta
                                   // var user = db.GetUser();
                                    //var ventaproducto = new VentaProducto();
                                    //ventaproducto.IdProducto = Producto.IdProducto;
                                    //ventaproducto.IdUsuario = user.IdUser;
                                    //ventaproducto.IdCliente = idcliente;
                                    //ventaproducto.IdDirecion = Venta.IdDireccion;
                                    //ventaproducto.CodigoProducto = Producto.Codigo;
                                    //ventaproducto.NombreProducto = Producto.NombreProducto;
                                    //ventaproducto.CantidadProducto = Cantidad;
                                    //ventaproducto.PrecioProducto = Precio;
                                    //ventaproducto.ValorProducto = Valor;
                                    //ventaproducto.IdVentaCliente = Venta.IdVentaCliente;
                                    //ventaproducto.FechaCompra = DateTime.Now.ToString("dd/MM/yyyy");
                                    //db.InsertVenta(ventaproducto);
                                    await PopupNavigation.PopAsync();
                                //}
                                //else
                                //{
                                  //  App.MessageError("Ingrese una venta");
                                //}
                            //}
                            //else
                            //{
                              //  App.MessageError("No tiene valor");
                            //}
                        //}
                        //else
                        //{
                          //  App.MessageError("No tiene precio");
                        //}
                    //}
                    //else
                    //{
                      //  App.MessageError("No tiene cantidad");
                    //}
                //}
                //else
                //{
                  //  App.MessageError("No tiene producto cargado");
                //}
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
