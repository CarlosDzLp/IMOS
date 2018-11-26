using System.Collections.Generic;
using SQLite;

namespace IMOS.Models.Tables
{
    public class DireccionesClientes
    {
        [PrimaryKey]
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int IdRegion { get; set; }
        public int IdComuna { get; set; }
        public string NombreRegion { get; set; }
        public string NombreComuna { get; set; }
        public string Telefono { get; set; }
        public bool Principal { get; set; }
    }

    public class ListDireccionesClientes
    {
        public List<DireccionesClientes> ListaDirecciones { get; set; }
        public Error Error { get; set; }
    }
}
