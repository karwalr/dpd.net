using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using dpd.shipping.Response;
using System.Net;

namespace dpd.shipping.Request.Base
{
    public abstract class BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {
        protected HttpClient HttpClient;
        protected JsonSerializerSettings SerializerSettings;
        protected String Host;
        protected String RequestUrl;
        protected HttpMethod RequestMethod;

        protected BaseRequest(String host, HttpClient httpClient, JsonSerializerSettings serializerSettings)
        {
            Host = host;
            HttpClient = httpClient;
            SerializerSettings = serializerSettings;

            if (!Host.EndsWith("/"))
            {
                Host += "/";
            }
        }

        public virtual async Task<TResponse> ExecuteAsync()
        {
            return null;
        }

        public virtual TResponse Execute()
        {
            return null;
        }

        protected async Task<TResponse> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var contentJson = await response.Content.ReadAsStringAsync();

            TResponse result;

            try
            {
                result = JsonConvert.DeserializeObject<TResponse>(contentJson);
            }
            catch (Exception e)
            {
                result = new TResponse
                {
                    Message = "The server did not response with proper JSON (" + contentJson + ")"
                };
            }

            if (result == null)
            {
                result = new TResponse();
            }

            if (String.IsNullOrEmpty(result.Message))
            {
                result.Message = response.ReasonPhrase;
            }

            result.HttpResponseCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
            {
                result.Ok = true;
            }

            result.OnDeserialised();

            return result;
        }

        protected TResponse DeserializeResponse(HttpResponseMessage response)
        {
            var contentJson = response.Content.ReadAsStringAsync();

            TResponse result;

            try
            {
                result = JsonConvert.DeserializeObject<TResponse>(contentJson.Result);
            }
            catch (Exception e)
            {
                result = new TResponse
                {
                    Message = "The server did not response with proper JSON (" + contentJson + ")"
                };
            }

            if (result == null)
            {
                result = new TResponse();
            }

            if (String.IsNullOrEmpty(result.Message))
            {
                result.Message = response.ReasonPhrase;
            }

            result.HttpResponseCode = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted ||
                    response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
            {
                result.Ok = true;
            }

            result.OnDeserialised();

            return result;
        }
    }
}
