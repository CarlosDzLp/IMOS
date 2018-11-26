using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using IMOS.DbLocal;
using IMOS.Models.Tables;
using IMOS.ViewModels.Base;
using Xamarin.Forms;

namespace IMOS.ViewModels.Principal
{
    public class ConsultaclientesPageViewModel : BindableBase,INotifyPropertyChanged
    {
        DbContext db = new DbContext();
        #region Properties
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set 
            { 
                if(_textSearch!=value)
                {
                    SetProperty(ref _textSearch, value);
                    SearchCommandExecuted();
                }
            }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private ObservableCollection<Clientes> _listClientes;
        public ObservableCollection<Clientes> ListClientes
        {
            get { return _listClientes; }
            set 
            { 
                SetProperty(ref _listClientes, value);
            }
        }

        private ObservableCollection<Clientes> _Clientes;
        public ObservableCollection<Clientes> ListCli
        {
            get { return _Clientes; }
            set
            {
                SetProperty(ref _Clientes, value);
            }
        }
        #endregion

        #region Constructor
        public ConsultaclientesPageViewModel()
        {
            ListCli = new ObservableCollection<Clientes>();
            ListClientes = new ObservableCollection<Clientes>();
            RefreshCommandListExecuted();
            RefreshCommandList = new Command(RefreshCommandListExecuted);
            SearchCommand = new Command(SearchCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RefreshCommandList { get; set; }
        public ICommand SearchCommand 
        { 
            get; 
            set; 
        }
        #endregion

        #region Methods
        private void SearchCommandExecuted()
        {
            try
            {
                if(string.IsNullOrEmpty(TextSearch))
                {
                    ListClientes = ListCli;
                }
                else
                {
                    ListClientes = new ObservableCollection<Clientes>(ListCli.Where(c => c.Nombre.ToLower().Contains(TextSearch.ToLower())).OrderBy(cc => cc.Rut));
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void RefreshCommandListExecuted()
        {
            try
            {
                IsRefreshing = true;
                ListCli.Clear();
                var list = db.GetListClientes();
                foreach(var item in list)
                {
                    ListCli.Add(item);
                }
                ListClientes = ListCli;
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
