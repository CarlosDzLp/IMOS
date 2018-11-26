using SQLite;
using Newtonsoft.Json;

namespace IMOS.Models
{
    public class UserModel
    {
        [JsonProperty("IdEmpresa")]
        public int IdEmpresa { get; set; }

        [JsonProperty("Empresa")]
        public string Empresa { get; set; }

        [JsonProperty("RutEmpresa")]
        public string RutEmpresa { get; set; }


        [PrimaryKey]
        [JsonProperty("IdUsuario")]
        public int IdUsuario { get; set; }

        [JsonProperty("Usuario")]
        public string Usuario { get; set; }

        [JsonProperty("NombreUsuario")]
        public string NombreUsuario { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonProperty("Error")]
        [SQLite.Ignore]
        public Error Error { get; set; }
    }
}
