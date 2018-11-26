using System;
using System.Collections.Generic;
using SQLite;
namespace IMOS.Models.Tables
{
    public class Comuna
    {
        [PrimaryKey]
        public int IdComuna { get; set; }
        public string Codigo { get; set; }
        public int IdRegion { get; set; }
        public string NombreComuna { get; set; }
    }

    public class ListComuna
    {
        public List<Comuna> ListaComunas { get; set; }
        public Error Error { get; set; }
    }
}
