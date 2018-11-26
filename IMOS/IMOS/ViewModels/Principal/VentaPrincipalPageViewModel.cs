using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using IMOS.DbLocal;
using IMOS.Models.Tables;
using IMOS.ViewModels.Base;
using Xamarin.Forms;

namespace IMOS.ViewModels.Principal
{
    public class VentaPrincipalPageViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region Properties
        private ObservableCollection<DireccionesClientes> _listdirecciones;
        public ObservableCollection<DireccionesClientes> ListDirecciones
        {
            get { return _listdirecciones; }
            set { SetProperty(ref _listdirecciones, value); }
        }
        private DireccionesClientes _direcciones;
        public DireccionesClientes Direcciones
        {
            get { return _direcciones; }
            set
            {
                SetProperty(ref _direcciones, value);
            }
        }

        private Clientes _clientes;
        public Clientes Clientes
        {
            get { return _clientes; }
            set
            {
                SetProperty(ref _clientes, value);
            }
        }
        private string _comentario;
        public string Comentario
        {
            get { return _comentario; }
            set { SetProperty(ref _comentario, value); }
        }
        private string _nombreventa;
        public string NombreVenta
        {
            get { return _nombreventa; }
            set { SetProperty(ref _nombreventa, value); }
        }
        private DateTime _dateEmision;
        public DateTime DateEmision
        {
            get { return _dateEmision; }
            set { SetProperty(ref _dateEmision, value); }
        }
        #endregion

        #region Contructor
        public VentaPrincipalPageViewModel(Clientes clientes)
        {
            Clientes = new Clientes();
            Clientes = clientes;
            ListDirecciones = new ObservableCollection<DireccionesClientes>();
            GuardarVentaCommand = new Command(GuardarVentaCommandExecuted);
            DateEmision = DateTime.Now;
            LoadClientes();
        }
        #endregion

        #region Methods
        private void LoadClientes()
        {
            try
            {
                if (Clientes != null)
                {
                    ListDirecciones.Clear();
                    var direccionesList = db.GetDireccionesClientesID(Clientes.IdCliente);
                    foreach (var item in direccionesList)
                    {
                        ListDirecciones.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand GuardarVentaCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void GuardarVentaCommandExecuted()
        {
            try
            {
                if (Clientes != null)
                {
                    if (Direcciones != null)
                    {
                        if (!string.IsNullOrEmpty(Comentario))
                        {
                            if (DateEmision.Date.Date >= DateTime.Now.Date)
                            {
                                if (!string.IsNullOrEmpty(NombreVenta))
                                {
                                    var date = DateEmision.ToString("dd/MM/yyyy");
                                    var user = db.GetUser();
                                    //var clienteventa = new VentasCliente();
                                    //clienteventa.IdUsuario = Clientes.IdUsuario;
                                    //clienteventa.IdCliente = Clientes.IdCliente;
                                    //clienteventa.IdDireccion = Direcciones.IdDirecciones;
                                    //clienteventa.NombreVenta = NombreVenta;
                                    //clienteventa.Comentario = Comentario;
                                    //clienteventa.FechaEmision = date;
                                    //db.InsertVentaCliente(clienteventa);
                                    NombreVenta = string.Empty;
                                    Comentario = string.Empty;
                                }
                                else
                                {
                                    App.MessageError("ingrese un nombre de la venta");
                                }
                            }
                            else
                            {
                                App.MessageError("ingrese una fecha mayor o igual a la actual");
                            }
                        }
                        else
                        {
                            App.MessageError("ingrese un comentario");
                        }
                    }
                    else
                    {
                        App.MessageError("eliga una direccion");
                    }
                }
                else
                {
                    App.MessageError("eliga un cliente");
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
