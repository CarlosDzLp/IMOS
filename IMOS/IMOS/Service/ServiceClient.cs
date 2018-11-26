using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace IMOS.Service
{
    public class ServiceClient
    {
        public async Task<T> GetListAllWithParam<T>(string where)
        {
            try
            {
                if (string.IsNullOrEmpty(where))
                {
                    Console.WriteLine("where empty");
                    return default(T);
                }
                string url = where;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://170.239.84.176/WSMobile/WSMobile.asmx/");

                var response = await client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var deserializer = JsonConvert.DeserializeObject<T>(responseString);
                    return deserializer;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default(T);
        }
    }
}
