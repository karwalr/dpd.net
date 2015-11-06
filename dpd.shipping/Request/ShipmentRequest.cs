using dpd.shipping.Model;
using dpd.shipping.Request.Base;
using dpd.shipping.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace dpd.shipping.Request
{
    public class ShipmentRequest : PostRequest<ShipmentResponse, Shipment>
    {
        public ShipmentRequest(Shipment shipment)
            : base(shipment)
        {
            RequestUrl = "shipping/shipment";
        }

        public async Task<ShipmentResponse> ExecuteShipmentAsync()
        {

            var json = JsonConvert.SerializeObject(Content, SerializerSettings);

            var response = await HttpClient.PostAsync(Host + RequestUrl, new StringContent(json, Encoding, MediaType));

            RestResponse<ShipmentResponse> r = new RestResponse<ShipmentResponse>();
            
            return await r.DeserializeResponseAsync(response);
        }
    }
}
