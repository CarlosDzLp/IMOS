using System;
using System.Collections.Generic;
using SQLite;

namespace IMOS.Models.Tables
{
    public class Regiones
    {
        [PrimaryKey]
        public int IdRegion { get; set; }
        public string Codigo { get; set; }
        public string NombreRegion { get; set; }
    }

    public class ListRegiones
    {
        public List<Regiones> ListaRegiones { get; set; }
        public Error Error { get; set; }
    }
}
