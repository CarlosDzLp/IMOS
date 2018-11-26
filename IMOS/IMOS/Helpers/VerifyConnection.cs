using System;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace IMOS.Helpers
{
    public class VerifyConnection
    {
        public static async Task<Response> IsConnected()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifique su coneccion a internet"
                };
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Verifique su coneccion a internet"
                };
            }
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }
    }
}
