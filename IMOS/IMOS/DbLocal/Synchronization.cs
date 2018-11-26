using System;
using System.Threading.Tasks;
using IMOS.Service;
using IMOS.Models.Tables;
using IMOS.Models;
using System.Linq;
using System.Collections.Generic;
using IMOS.Helpers;
using Xamarin.Forms;

namespace IMOS.DbLocal
{
    public class Synchronization
    {
        private ServiceClient client = new ServiceClient();
        private DbContext db = new DbContext();
        private const string urlCliente = "ObtenerClientesGet?strRutEmpresa=";
        private const string urlDireccionesCliente = "ObtenerClienteDireccionesGet?strRutEmpresa=";
        private const string urlProducto = "ObtenerProductosGet?strRutEmpresa=";
        private const string urlComuna = "ObtenerComunasGet?strRutEmpresa=";
        private const string urlEmisores = "ObtenerEmisoresGet?strRutEmpresa=";
        private const string urlRegiones = "ObtenerRegionesGet?strRutEmpresa=";
        private int asyncCount = 0;

        public void AsyncData()
        {
            try
            {
                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async() =>
                    {
                        string[] tables = new string[10];
                        var user = db.GetUser();
                        var verify = await VerifyConnection.IsConnected();
                        if (verify.IsSuccess)
                        {
                            string validateUserresponse = string.Format("ValidarAccesoGet?strRutEmpresa={0}&strUsuario={1}&strPass={2}", user.RutEmpresa, user.Usuario, user.Password);
                            var validateUser = await client.GetListAllWithParam<UserModel>(validateUserresponse);
                            if(validateUser.Error==null)
                            {
                                DeleteAllTables();
                                //comienza Service Cliente
                                var responseCliente = await client.GetListAllWithParam<ListClientes>(urlCliente + user.RutEmpresa);
                                if (responseCliente.Error == null)
                                {
                                    if (responseCliente.ListaClientes.Count > 0)
                                    {
                                        foreach (var item in responseCliente.ListaClientes)
                                        {
                                            db.InsertClientes(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[0] = "Clientes";
                                    asyncCount++;
                                }
                                //Termina Service Cliente

                                //comienza Service DireccionesCliente
                                var responseDireccionesCliente = await client.GetListAllWithParam<ListDireccionesClientes>(urlDireccionesCliente + user.RutEmpresa);
                                if (responseDireccionesCliente.Error == null)
                                {
                                    if (responseDireccionesCliente.ListaDirecciones.Count > 0)
                                    {
                                        foreach (var item in responseDireccionesCliente.ListaDirecciones)
                                        {
                                            db.InsertDireccionesClientes(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[1] = "DirecionesClientes";
                                    asyncCount++;
                                }
                                //Termina Service DireccionesCliente

                                //comienza Service Producto
                                var responseProducto = await client.GetListAllWithParam<ListProducto>(urlProducto + user.RutEmpresa);
                                if (responseProducto.Error == null)
                                {
                                    if (responseProducto.ListaProductos.Count > 0)
                                    {
                                        foreach (var item in responseProducto.ListaProductos)
                                        {
                                            db.InsertProducto(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[2] = "Producto";
                                    asyncCount++;
                                }
                                //Termina Service Producto



                                //comienza Service Comuna
                                var responseComuna = await client.GetListAllWithParam<ListComuna>(urlComuna + user.RutEmpresa);
                                if (responseComuna.Error == null)
                                {
                                    if (responseComuna.ListaComunas.Count > 0)
                                    {
                                        foreach (var item in responseComuna.ListaComunas)
                                        {
                                            db.InsertComuna(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[3] = "Comuna";
                                    asyncCount++;
                                }
                                //Termina Service Comuna


                                //comienza Service Emisores
                                var responseEmisores = await client.GetListAllWithParam<ListEmisores>(urlEmisores + user.RutEmpresa);
                                if (responseEmisores.Error == null)
                                {
                                    if (responseEmisores.ListaEmisores.Count > 0)
                                    {
                                        foreach (var item in responseEmisores.ListaEmisores)
                                        {
                                            db.InsertEmisores(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[4] = "Emisores";
                                    asyncCount++;
                                }
                                //Termina Service Emisores

                                //comienza Service Regiones
                                var responseRegiones = await client.GetListAllWithParam<ListRegiones>(urlRegiones + user.RutEmpresa);
                                if (responseRegiones.Error == null)
                                {
                                    if (responseRegiones.ListaRegiones.Count > 0)
                                    {
                                        foreach (var item in responseRegiones.ListaRegiones)
                                        {
                                            db.InsertRegiones(item);
                                        }
                                    }
                                }
                                else
                                {
                                    tables[5] = "Regiones";
                                    asyncCount++;
                                }
                                if (asyncCount > 0)
                                {
                                    var stringmessage = "Errores al sincronizar: " + tables[0] + "," + tables[1] + "," + tables[2] + "," + tables[3] + "," + tables[4] + "," + tables[5];
                                    var notification = Plugin.LocalNotifications.CrossLocalNotifications.Current;
                                    notification.Show("IMOS", stringmessage);
                                    asyncCount = 0;
                                    stringmessage = string.Empty;
                                }
                                else
                                {
                                    Plugin.Toast.CrossToastPopUp.Current.ShowToastMessage("Sincronizacion terminada");
                                    //mostrar un toas qiue indique que se termino de sincronizar
                                }
                                //Termina Service Regiones
                            }
                            else
                            {
                                App.MessageError("hubo un error al sincronizar");
                            }
                        }
                        else
                        {
                            App.MessageError("Verifique su coneccion syncronizacion incompleta");
                        }
                    });
                });
            }
            catch(Exception ex)
            {

            }
        }
        public void DeleteAllTables()
        {
            try
            {
                db.DeleteAllClientes();
                db.DeleteAllDireccinesClientes();
                db.DeleteAllProducto();
                db.DeleteAllComuna();
                db.DeleteAllEmisores();
                db.DeleteAllRegiones();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
