using System;
using System.Windows.Input;
using IMOS.Dependency;
using IMOS.ViewModels.Base;
using IMOS.Views.Principal;
using Xamarin.Forms;
using IMOS.DbLocal;
using System.Diagnostics;
using IMOS.Views.Session;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using IMOS.Service;
using IMOS.Models;
using IMOS.Helpers;

namespace IMOS.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        Synchronization sync = new Synchronization();
        #region Properties
        private string rut;
        public string Rut
        {
            get { return rut; }
            set { SetProperty(ref rut, value); }
        }
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { SetProperty(ref usuario, value); }
        }
        private string clave;
        public string Clave
        {
            get { return clave; }
            set { SetProperty(ref clave, value); }
        }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            LoginCommand = new Command(LoginCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand LoginCommand { get; set; }
        #endregion

        #region CommandExecuted

        private async void LoginCommandExecuted()
        {
            try
            {

                if(!string.IsNullOrEmpty(Rut))
                {
                    if(!string.IsNullOrEmpty(Usuario))
                    {
                        if(!string.IsNullOrEmpty(Clave))
                        {
                            var verify = await VerifyConnection.IsConnected();
                            if(verify.IsSuccess)
                            {
                                DependencyService.Get<IProgressDialog>().ProgressDialogShow();
                                ServiceClient client = new ServiceClient();
                                string query = string.Format("ValidarAccesoGet?strRutEmpresa={0}&strUsuario={1}&strPass={2}", Rut, Usuario, Clave);
                                var response = await client.GetListAllWithParam<UserModel>(query);
                                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                                if (response.Error != null)
                                {
                                    App.MessageError(response.Error.Mensaje);
                                }
                                else
                                {
                                    response.Password = Clave;
                                    InsertUsuario(response);
                                    sync.AsyncData();
                                    App.Current.MainPage = new MasterPage();
                                }
                            }
                            else
                            {
                                App.MessageError(verify.Message);
                            }
                        }
                        else
                        {
                            App.MessageError("Ingrese su Clave");
                        }
                    }
                    else
                    {
                        App.MessageError("Ingrese su usuario");
                    }
                }
                else
                {
                    App.MessageError("Ingrese el Rut");
                }
            }
            catch (Exception e)
            {
                DependencyService.Get<IProgressDialog>().ProgressDialogHide();
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion
        #region DbContext
        private void InsertUsuario(UserModel user)
        {
            try
            {
                var db = new DbContext();
                db.InsertUser(user);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
