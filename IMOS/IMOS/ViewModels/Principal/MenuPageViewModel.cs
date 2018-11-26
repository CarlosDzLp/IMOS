using System;
using IMOS.ViewModels.Base;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using IMOS.DbLocal;

namespace IMOS.ViewModels.Principal
{
    public class MenuPageViewModel : BindableBase
    {
        DbContext db = new DbContext();
        #region properties
        private bool _isOpenDay;
        public bool IsOpenDay
        {
            get { return _isOpenDay; }
            set { SetProperty(ref _isOpenDay, value); }
        }
        private bool _isCloseDay;
        public bool IsCloseDay
        {
            get { return _isCloseDay; }
            set { SetProperty(ref _isCloseDay, value); }
        }
        private bool _isVentasDay;
        public bool IsVentasDay
        {
            get { return _isVentasDay; }
            set { SetProperty(ref _isVentasDay, value); }
        }


        private bool _isEnabledClientes;
        public bool IsEnabledClientes
        {
            get { return _isEnabledClientes; }
            set { SetProperty(ref _isEnabledClientes, value); }
        }
        private bool _isConsultar = false;
        public bool IsConsultar
        {
            get { return _isConsultar; }
            set { SetProperty(ref _isConsultar, value); }
        }
        private bool _isNuevocliente = false;
        public bool IsNuevocliente
        {
            get { return _isNuevocliente; }
            set { SetProperty(ref _isNuevocliente, value); }
        }



        private bool _isEnabledReportes;
        public bool IsEnabledReportes
        {
            get { return _isEnabledReportes; }
            set { SetProperty(ref _isEnabledReportes, value); }
        }
        private bool _isCobranza = false;
        public bool IsCobranza
        {
            get { return _isCobranza; }
            set { SetProperty(ref _isCobranza, value); }
        }
        private bool _isInventario = false;
        public bool IsInventario
        {
            get { return _isInventario; }
            set { SetProperty(ref _isInventario, value); }
        }

        private bool _isContentVenta;
        public bool IsContentVenta
        {
            get { return _isContentVenta; }
            set { SetProperty(ref _isContentVenta, value); }
        }
        #endregion


        #region Constructor
        public MenuPageViewModel()
        {
            ClickVentas = new Command(ClickVentasExecuted);
            ClickReportes = new Command(ClickReportesExecuted);
            ClickClientes = new Command(ClickClientesExecuted);

            //ventas
            VentasCommand = new Command(VentasCommandExecuted);
            CrearVentaCommand = new Command(CrearVentaCommandExecuted);
            CerrarVentacommand = new Command(CerrarVentacommandExecuted);
            //clientes
            NuevoClienteCommand = new Command(NuevoClienteCommandExecuted);
            ConsultarClienteCommand = new Command(ConsultarClienteCommandExecuted);
            LoadMenu();
        }
        #endregion


        #region Commands
        public ICommand ClickVentas { get; set; }
        public ICommand ClickReportes { get; set; }
        public ICommand ClickClientes { get; set; }

        //ventas
        public ICommand VentasCommand { get; set; }
        public ICommand CrearVentaCommand { get; set; }
        public ICommand CerrarVentacommand { get; set; }

        //clientes
        public ICommand NuevoClienteCommand { get; set; }
        public ICommand ConsultarClienteCommand { get; set; }
        #endregion


        #region CommandsExecuted
        private void CerrarVentacommandExecuted()
        {
            try
            {
                db.CerrarVenta();
                LoadMenu();
            }
            catch(Exception ex)
            {

            }
        }
        private void CrearVentaCommandExecuted()
        {
            try
            {
                db.AbrirVenta();
                LoadMenu();
            }
            catch(Exception ex)
            {

            }
        }

        private void VentasCommandExecuted()
        {
            try
            {
                App.MasterPageDetail.IsPresented = false;
                App.MasterPageDetail.Detail.Navigation.PushAsync(new Views.Principal.VentasPage());
            }
            catch(Exception ex)
            {

            }
        }

        private void NuevoClienteCommandExecuted()
        {
            try
            {
                App.MasterPageDetail.IsPresented = false;
                App.MasterPageDetail.Detail.Navigation.PushAsync(new Views.Principal.CrearClientePage());
            }
            catch(Exception ex)
            {

            }
        }
        private void ConsultarClienteCommandExecuted()
        {
            try
            {
                App.MasterPageDetail.IsPresented = false;
                App.MasterPageDetail.Detail.Navigation.PushAsync(new Views.Principal.ConsultarClientesPage());
            }
            catch (Exception ex)
            {

            }
        }


        int ventas = 0;
        private void ClickVentasExecuted()
        {
            try
            {
                if(ventas == 0)
                {
                    IsContentVenta = true;
                    ventas = 1;
                }
                else
                {
                    IsContentVenta = false;
                    ventas = 0;
                }
            }
            catch(Exception ex)
            {

            }
        }
        int reportes = 0;
        private void ClickReportesExecuted()
        {
            try
            {
                if(reportes == 0)
                {
                    reportes = 1;
                    IsCobranza = true;
                    IsInventario = true;
                }
                else
                {
                    IsCobranza = false;
                    IsInventario = false;
                    reportes = 0;
                }
            }
            catch
            {

            }
        }
        int cliente = 0;
        private void ClickClientesExecuted()
        {
            try
            {
                if(cliente == 0)
                {
                    cliente = 1;
                    IsConsultar = true;
                    IsNuevocliente = true;
                }
                else
                {
                    IsConsultar = false;
                    IsNuevocliente = false;
                    cliente = 0;
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion


        #region Methods
        private void LoadMenu()
        {
            try
            {
                var validate = db.validarVenta();
                if(validate)
                {
                    //verdadero si hay venta abierta
                    IsOpenDay = false;
                    IsCloseDay = true;
                    IsVentasDay = true;
                    IsEnabledClientes = true; 
                    IsEnabledReportes = true;
                }
                else
                {
                    IsOpenDay = true;
                    IsCloseDay = false;
                    IsVentasDay = false;
                    IsEnabledClientes = false;
                    IsEnabledReportes = false;
                    //falso no hay venta abierta
                }
            }
            catch(Exception ex)
            {

            }

        }
        #endregion
    }
}
