using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using IMOS.DbLocal;
using IMOS.Models.Tables;
using IMOS.ViewModels.Base;
using IMOS.Views.Principal;
using Xamarin.Forms;
using IMOS.Helpers;

namespace IMOS.ViewModels.Principal
{
    public class CrearClientePageViewModel : BindableBase
    {
        #region Properties
        private bool _isVisibleAdd = false;
        public bool IsVisibleAdd
        {
            get { return _isVisibleAdd; }
            set { SetProperty(ref _isVisibleAdd, value); }
        }

        DbContext db = new DbContext();
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        private ObservableCollection<Clientes> listClientes;
        public ObservableCollection<Clientes> ListClientes
        {
            get { return listClientes; }
            set { SetProperty(ref listClientes, value); }
        }

        private string _RutCliente;
        public string RutCliente
        {
            get { return _RutCliente; }
            set { SetProperty(ref _RutCliente, value); }
        }
        private string _NombreCliente;
        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { SetProperty(ref _NombreCliente, value); }
        }
        private string _RazonSocialCliente;
        public string RazonSocialCliente
        {
            get { return _RazonSocialCliente; }
            set { SetProperty(ref _RazonSocialCliente, value); }
        }
        private string _GiroCliente;
        public string GiroCliente
        {
            get { return _GiroCliente; }
            set { SetProperty(ref _GiroCliente, value); }
        }
        private string _DiasPagoCliente;
        public string DiasPagoCliente
        {
            get { return _DiasPagoCliente; }
            set { SetProperty(ref _DiasPagoCliente, value); }
        }
        #endregion

        #region Constructor
        public CrearClientePageViewModel()
        {
            ListClientes = new ObservableCollection<Clientes>();
            LoadClientes();
            AddClienteCommand = new Command(AddClienteCommandExecuted);
            RefreshCommandList = new Command(LoadClientes);
            InsertClienteCommand = new Command(InsertClienteCommandExecuted);
        }
        #endregion

        #region Methods
        private void LoadClientes()
        {
            try
            {
                IsRefreshing = true;
                ListClientes.Clear();
                var user = db.GetUser();
                var cliente = db.GetListClientes();
                foreach(var item in cliente)
                {
                    ListClientes.Add(item);
                }
                IsRefreshing = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                IsRefreshing = false;
            }
        }
        private void OnTapSelectedCliente(Clientes clientes)
        {
            try
            {
                if(clientes != null)
                {
                    App.MasterPageDetail.IsPresented = false;
                    App.MasterPageDetail.Detail.Navigation.PushAsync(new ClienteDetalleDireccionesPage(clientes));
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Command
        public ICommand InsertClienteCommand { get; set; }
        public ICommand AddClienteCommand { get; set; }
        public ICommand RefreshCommandList { get; set; }
        public ICommand ItemClickCommand
        {
            get
            {
                return new Command((item) =>
                {
                    var selected = item as Clientes;
                    OnTapSelectedCliente(selected);
                });
            }
        }
        #endregion

        #region CommandExecuted
        private int count = 0;
        private void AddClienteCommandExecuted()
        {
            if(count == 0)
            {
                IsVisibleAdd = true;
                count = 1;
            }
            else
            {
                IsVisibleAdd = false;
                count = 0;
            }
        }
        private void InsertClienteCommandExecuted()
        {
            try
            {
                if(!string.IsNullOrEmpty(RutCliente))
                {
                    if (!string.IsNullOrEmpty(NombreCliente))
                    {
                        if (!string.IsNullOrEmpty(RazonSocialCliente))
                        {
                            if (!string.IsNullOrEmpty(GiroCliente))
                            {
                                if (!string.IsNullOrEmpty(DiasPagoCliente))
                                {
                                    var InsertCliente = new Clientes();
                                    var user = db.GetUser();
                                    //InsertCliente.IdUsuario = user.IdUser;
                                    //InsertCliente.RutCliente = RutCliente;
                                    //InsertCliente.NombreCliente = NombreCliente;
                                    //InsertCliente.RazonSocialCliente = RazonSocialCliente;
                                    //InsertCliente.GiroCliente = GiroCliente;
                                    //InsertCliente.DiasPagoCliente = DiasPagoCliente;
                                    //db.InsertCliente(InsertCliente);
                                    RutCliente = string.Empty;
                                    NombreCliente = string.Empty;
                                    RazonSocialCliente = string.Empty;
                                    GiroCliente = string.Empty;
                                    DiasPagoCliente = string.Empty;
                                    LoadClientes();
                                    IsVisibleAdd = false;
                                }
                                else
                                {
                                    App.MessageError("ingrese un dia de pago");
                                }
                            }
                            else
                            {
                                App.MessageError("ingrese un giro");
                            }
                        }
                        else
                        {
                            App.MessageError("ingrese una razon social");
                        }
                    }
                    else
                    {
                        App.MessageError("ingrese un nombre");
                    }
                }
                else
                {
                    App.MessageError("ingrese un rut");
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
