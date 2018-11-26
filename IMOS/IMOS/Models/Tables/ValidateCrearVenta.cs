using System;
using SQLite;

namespace IMOS.Models.Tables
{
    public class ValidateCrearVenta
    {
        [PrimaryKey,AutoIncrement]
        public int IdvalidateVenta { get; set; }
        public string RutEmpresa { get; set; }
        public string FechaHora { get; set; }
        public bool Validate { get; set; }
    }
}
