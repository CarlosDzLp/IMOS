using System;
namespace IMOS.Models
{
    public class Error
    {

        public Error()
        {

        }

        public Error(int intNumero, string strError)
        {
            Numero = intNumero;
            Mensaje = strError;
        }

        public int Numero { get; set; }
        public string Mensaje { get; set; }
    }
}
