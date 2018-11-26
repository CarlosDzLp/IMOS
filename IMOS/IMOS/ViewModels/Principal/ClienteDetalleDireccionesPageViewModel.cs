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
    public class ClienteDetalleDireccionesPageViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region Properties
        private ObservableCollection<DireccionesClientes> _listdirecciones;
        public ObservableCollection<DireccionesClientes> ListDirecciones
        {
            get { return _listdirecciones; }
            set { SetProperty(ref _listdirecciones, value); }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private Clientes _client;
        public Clientes clientes
        {
            get { return _client; }
            set { SetProperty(ref _client, value); }
        }
        private string titleCliente;
        public string TitleCliente
        {
            get { return titleCliente; }
            set { SetProperty(ref titleCliente, value); }
        }

        private bool _IsVisibleAddDirecciones = false;
        public bool IsVisibleAddDirecciones
        {
            get { return _IsVisibleAddDirecciones; }
            set { SetProperty(ref _IsVisibleAddDirecciones, value); }
        }


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }
        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { SetProperty(ref direccion, value); }
        }
        private string pais;
        public string Pais
        {
            get { return pais; }
            set { SetProperty(ref pais, value); }
        }
        private string region;
        public string Region
        {
            get { return region; }
            set { SetProperty(ref region, value); }
        }
        private string comuna;
        public string Comuna
        {
            get { return comuna; }
            set { SetProperty(ref comuna, value); }
        }
        private string ciudad;
        public string Ciudad
        {
            get { return ciudad; }
            set { SetProperty(ref ciudad, value); }
        }
        #endregion

        #region Constructor
        public ClienteDetalleDireccionesPageViewModel(Clientes cliente)
        {
            ListDirecciones = new ObservableCollection<DireccionesClientes>();
            clientes = new Clientes();
            clientes = cliente;
            //TitleCliente = clientes.NombreCliente;
            AddDireccionCommand = new Command(AddDireccionCommandExecuted);
            RefreshCommandList = new Command(LoadDirecciones);
            InsertDireccionesCommand = new Command(InsertDireccionesCommandExecuted);
            LoadDirecciones();
        }
        #endregion

        #region Commands
        public ICommand AddDireccionCommand { get; set; }
        public ICommand RefreshCommandList { get; set; }
        public ICommand InsertDireccionesCommand { get; set; }
        #endregion

        #region CommandExecuted
        private int count = 0;
        private void AddDireccionCommandExecuted()
        {
            try
            {
                if(count == 0)
                {
                    IsVisibleAddDirecciones = true;
                    count = 1;
                }
                else
                {
                    IsVisibleAddDirecciones = false;
                    count = 0;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void InsertDireccionesCommandExecuted()
        {
            try
            {
                if(!string.IsNullOrEmpty(Nombre))
                {
                    if (!string.IsNullOrEmpty(Telefono))
                    {
                        if (!string.IsNullOrEmpty(Direccion))
                        {
                            if (!string.IsNullOrEmpty(Pais))
                            {
                                if (!string.IsNullOrEmpty(Region))
                                {
                                    if (!string.IsNullOrEmpty(Comuna))
                                    {
                                        if (!string.IsNullOrEmpty(Ciudad))
                                        {
                                            var direcciones = new DireccionesClientes();
                                            //direcciones.IdUsuario = clientes.IdUsuario;
                                            direcciones.IdCliente = clientes.IdCliente;
                                            direcciones.Nombre = Nombre;
                                            direcciones.Telefono = Telefono;
                                            direcciones.Direccion = Direccion;
                                            //direcciones.Pais = Pais;
                                            //direcciones.Region = Region;
                                            //direcciones.Comuna = Comuna;
                                            direcciones.Ciudad = Ciudad;
                                            //db.InsertDirecciones(direcciones);
                                            LoadDirecciones();
                                            IsVisibleAddDirecciones = false;
                                            Nombre = string.Empty;
                                            Telefono = string.Empty;
                                            Direccion = string.Empty;
                                            Pais = string.Empty;
                                            Region = string.Empty;
                                            Comuna = string.Empty;
                                            Ciudad = string.Empty;
                                        }
                                        else
                                        {
                                            App.MessageError("Ingrese una ciudad");
                                        }
                                    }
                                    else
                                    {
                                        App.MessageError("Ingrese una comuna");
                                    }
                                }
                                else
                                {
                                    App.MessageError("Ingrese una region");
                                }
                            }
                            else
                            {
                                App.MessageError("Ingrese un pais");
                            }
                        }
                        else
                        {
                            App.MessageError("Ingrese una direccion");
                        }
                    }
                    else
                    {
                        App.MessageError("Ingrese un telefono");
                    }
                }
                else
                {
                    App.MessageError("Ingrese un nombre");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Methods
        private void LoadDirecciones()
        {
            try
            {
                IsRefreshing = true;
                ListDirecciones.Clear();
                //ar direcciones = db.GetListDirecciones(clientes.IdUsuario, clientes.IdCliente);
                //foreach(var item in direcciones)
                //{
                  //  ListDirecciones.Add(item);
                //}
                IsRefreshing = false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                IsRefreshing = false;
            }
        }
        #endregion
    }
}
