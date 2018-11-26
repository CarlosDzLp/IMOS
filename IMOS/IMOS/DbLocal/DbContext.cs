using System;
using System.Collections.Generic;
using IMOS.Dependency;
using IMOS.Models;
using SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using IMOS.Models.Tables;
using System.Collections.ObjectModel;

namespace IMOS.DbLocal
{
    public class DbContext
    {
        #region Contructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                //creacion de la coneccion
                var dbPath = DependencyService.Get<IFilePath>().GetPath();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<UserModel>();
                connection.CreateTable<ValidateCrearVenta>();
                connection.CreateTable<Clientes>();
                connection.CreateTable<DireccionesClientes>();
                connection.CreateTable<Producto>();
                connection.CreateTable<Comuna>();
                connection.CreateTable<Emisores>();
                connection.CreateTable<Regiones>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion

        #region Usuario
        public void InsertUser(UserModel user)
        {
            try
            {
                connection.Insert(user);
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public UserModel GetUser()
        {
            try
            {
                var result = connection.Table<UserModel>().FirstOrDefault();
                return result;
            }
            catch (SQLite.SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public int DeleteUser()
        {
            try
            {
                var result = connection.DeleteAll<UserModel>();
                return result;
            }
            catch (SQLiteException ex)
            {
                return 0;
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ValidarCrearVentaMenu
        public void CerrarVenta()
        {
            try
            {
                var query = connection.Table<ValidateCrearVenta>().Where(c => c.Validate == false).FirstOrDefault();
                query.Validate = true;
                var result = connection.Update(query);
            }
            catch (SQLiteException ex)
            {

            }
        }
        public void AbrirVenta()
        {
            try
            {
                var validateventa = new ValidateCrearVenta();
                var user = GetUser();
                validateventa.RutEmpresa = user.RutEmpresa;
                validateventa.FechaHora = DateTime.Now.ToString();
                validateventa.Validate = false;
                var query = connection.Insert(validateventa);
            }
            catch (SQLiteException ex)
            {

            }
        }
        public bool validarVenta()
        {
            try
            {
                var query = connection.Table<ValidateCrearVenta>().Where(c => c.Validate == false).FirstOrDefault();
                if (query != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public ValidateCrearVenta GetvalidarVenta()
        {
            try
            {
                var query = connection.Table<ValidateCrearVenta>().Where(c => c.Validate == false).FirstOrDefault();
                return query;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public void DeletevalidarVenta()
        {
            try
            {
                connection.DeleteAll<ValidateCrearVenta>();
            }
            catch(SQLiteException ex)
            {

            }
        }
        #endregion

        #region Clientes
        public void DeleteAllClientes()
        {
            try
            {
                connection.DeleteAll<Clientes>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertClientes(Clientes clientes)
        {
            try
            {
                connection.Insert(clientes);
            }
            catch (Exception ex)
            {

            }
        }
        public List<Clientes> GetListClientes()
        {
            try
            {
                var listcliente = connection.Table<Clientes>().ToList();
                return listcliente;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public Clientes GetClientes(int IdCliente)
        {
            try
            {
                var cliente = connection.Table<Clientes>().Where(c=>c.IdCliente==IdCliente).FirstOrDefault();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region DirrecionesClientes
        public void DeleteAllDireccinesClientes()
        {
            try
            {
                connection.DeleteAll<DireccionesClientes>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertDireccionesClientes(DireccionesClientes direccionesclientes)
        {
            try
            {
                connection.Insert(direccionesclientes);
            }
            catch (Exception ex)
            {

            }
        }
        public List<DireccionesClientes> GetListDirecciones()
        {
            try
            {
                var listdirecciones = connection.Table<DireccionesClientes>().ToList();
                return listdirecciones;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<DireccionesClientes>GetDireccionesClientesID(int idCliente)
        {
            try
            {
                var listdirecciones = connection.Table<DireccionesClientes>().Where(c => c.IdCliente == idCliente).ToList();
                return listdirecciones;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //verificar si se valida por diferentes id en Direcciones
        #endregion

        #region Producto
        public void DeleteAllProducto()
        {
            try
            {
                connection.DeleteAll<Producto>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertProducto(Producto producto)
        {
            try
            {
                connection.Insert(producto);
            }
            catch (Exception ex)
            {

            }
        }
        public List<Producto>GetListProducto()
        {
            try
            {
                var listproducto = connection.Table<Producto>().ToList();
                return listproducto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public Producto GetProducto(int IdProducto)
        {
            try
            {
                var producto = connection.Table<Producto>().Where(C=>C.IdProducto==IdProducto).FirstOrDefault();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Comuna
        public void DeleteAllComuna()
        {
            try
            {
                connection.DeleteAll<Comuna>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertComuna(Comuna comuna)
        {
            try
            {
                connection.Insert(comuna);
            }
            catch (Exception ex)
            {

            }
        }
        public List<Comuna>GetListComuna()
        {
            try
            {
                var listcomuna = connection.Table<Comuna>().ToList();
                return listcomuna;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Emisores
        public void DeleteAllEmisores()
        {
            try
            {
                connection.DeleteAll<Emisores>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertEmisores(Emisores emisores)
        {
            try
            {
                connection.Insert(emisores);
            }
            catch (Exception ex)
            {

            }
        }
        public List<Emisores>GetListEmisores()
        {
            try
            {
                var listemisores = connection.Table<Emisores>().ToList();
                return listemisores;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public Emisores GetEmisores(int IdEmisor)
        {
            try
            {
                var emisores = connection.Table<Emisores>().Where(c=>c.IdEmisor==IdEmisor).FirstOrDefault();
                return emisores;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Regiones
        public void DeleteAllRegiones()
        {
            try
            {
                connection.DeleteAll<Regiones>();
            }
            catch (Exception ex)
            {

            }
        }
        public void InsertRegiones(Regiones regiones)
        {
            try
            {
                connection.Insert(regiones);
            }
            catch (Exception ex)
            {

            }
        }
        public List<Regiones>GetListRegiones()
        {
            try
            {
                var listregiones = connection.Table<Regiones>().ToList();
                return listregiones;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public Regiones GetRegiones(int IdRegiones)
        {
            try
            {
                var regiones = connection.Table<Regiones>().Where(c => c.IdRegion == IdRegiones).FirstOrDefault();
                return regiones;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
