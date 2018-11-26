using IMOS.Models.Tables;
using IMOS.ViewModels.Base;

namespace IMOS.ViewModels.Principal
{
    public class TabVentasPageViewModel : BindableBase
    {
        #region Properties
        private string _titleNombre;
        public string TitleNombre
        {
            get { return _titleNombre; }
            set { SetProperty(ref _titleNombre, value); }
        }
        private string _credito;
        public string Credito
        {
            get { return _credito; }
            set { SetProperty(ref _credito, value); }
        }

        private Clientes clientes;
        public Clientes Clientes
        {
            get { return clientes; }
            set { SetProperty(ref clientes, value); }
        }
        #endregion

        #region Constructor
        public TabVentasPageViewModel(Clientes clientes)
        {
            Clientes = new Clientes();
            Clientes = clientes;
            TitleNombre = clientes.Nombre;
            Credito = "WS no hay campo Credito en Cliente";
        }
        #endregion
    }
}
