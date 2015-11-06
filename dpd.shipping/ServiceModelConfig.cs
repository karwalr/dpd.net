using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace dpd.shipping
{
    public static class ServiceModelConfig
    {
        public static readonly String Host = "https://api.dpd.co.uk/";
        public static readonly HttpClient HttpClient = new HttpClient();
        public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();

        public static void Create(String dpdUserName, String dpdPassword, string dpdAccountNumber, string dpdSessionId = "")
        {
            var auth = String.Format("{0}:{1}", dpdUserName, dpdPassword);
            auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));

            //Flush any existing headers
            HttpClient.DefaultRequestHeaders.Remove("GEOClient");
            HttpClient.DefaultRequestHeaders.Remove("GEOSession");

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            HttpClient.DefaultRequestHeaders.Add("GEOClient", "account/" + dpdAccountNumber);

            if(!string.IsNullOrEmpty(dpdSessionId))
            {
                HttpClient.DefaultRequestHeaders.Add("GEOSession", dpdSessionId);
            }
        }
    }
}
