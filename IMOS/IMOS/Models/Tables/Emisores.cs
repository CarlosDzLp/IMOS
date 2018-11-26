using System;
using System.Collections.Generic;
using SQLite;

namespace IMOS.Models.Tables
{
    public class Emisores
    {
        [PrimaryKey]
        public int IdEmisor { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
    }

    public class ListEmisores
    {
        public List<Emisores> ListaEmisores { get; set; }
        public Error Error { get; set; }
    }
}
