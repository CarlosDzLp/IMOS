using System;
using IMOS.ViewModels.Principal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IMOS.DbLocal;
using System.Diagnostics;

namespace IMOS.Views.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        DbContext db = new DbContext();
        Synchronization sync = new Synchronization();
        public MenuPage ()
		{
			InitializeComponent ();
		    this.BindingContext = new MenuPageViewModel();

            var user = db.GetUser();
            LblNombreCompleto.Text = user.NombreUsuario;
            txtEmpresa.Text = user.Empresa;
		}

        void clickCerrarSesion(object sender, System.EventArgs e)
        {
            try
            {
                App.MasterPageDetail.IsPresented = false;
                int result = db.DeleteUser();
                sync.DeleteAllTables();
                db.DeletevalidarVenta();
                if(result > 0)
                {
                    App.Current.MainPage = new NavigationPage(new Views.Session.LoginPage());
                }
                else
                {
                    App.MessageError("no se pudo cerrar sesion");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        void ClickSincronizacion(object sender, System.EventArgs e)
        {
            try
            {
                App.MasterPageDetail.IsPresented = false;
                Synchronization sync = new Synchronization();
                sync.AsyncData();
            }
            catch(Exception ex)
            {

            }
        }
	}
}