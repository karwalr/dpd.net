using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dpd.shipping.Response
{
    public class RestResponse<T>
    {
        public async Task<T> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var contentJson = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(contentJson);

            //result.Message = response.ReasonPhrase;
            //result.HttpResponseCode = response.StatusCode;

            return result;
        }
    }
}
