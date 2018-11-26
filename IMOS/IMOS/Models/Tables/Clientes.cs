using System.Collections.Generic;
using SQLite;

namespace IMOS.Models.Tables
{
    public class Clientes
    {
        [PrimaryKey]
        public int IdCliente { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Giro { get; set; }
        public int DiasPago { get; set; }
    }

    public class ListClientes
    {
        public List<Clientes> ListaClientes { get; set; }
        public Error Error { get; set; }
    }
}
