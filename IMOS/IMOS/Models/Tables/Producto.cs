using System;
using System.Collections.Generic;
using SQLite;

namespace IMOS.Models.Tables
{
    public class Producto
    {
        [PrimaryKey]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string CodTipo { get; set; }
        public string Tipo { get; set; }
        public string CodSubTipo { get; set; }
        public string SubTipo { get; set; }
    }
    public class ListProducto
    {
        public List<Producto> ListaProductos { get; set; }
        public Error Error { get; set; }
    }
}
