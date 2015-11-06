using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dpd.shipping.Response
{
    public class ShipmentResponse : BaseResponse
    {
        [JsonProperty("error")]  //needed so doesnt clash with login response which also returns 'error' object
        public List<ShipError> ShipErrors { get; set; }
        [JsonProperty("data")]  //needed so doesnt clash with login response which also returns 'data' object
        public ShipData ShipData { get; set; }
    }

    public class ConsignmentDetail
    {
        public string consignmentNumber { get; set; }
        public List<string> parcelNumbers { get; set; }
    }

    
    public class ShipData
    {
        public int shipmentId { get; set; }
        public bool consolidated { get; set; }
        public List<ConsignmentDetail> consignmentDetail { get; set; }
    }

    public class ShipError
    {
        public string errorCode { get; set; }
        public string obj { get; set; }
        public string errorType { get; set; }
        public string errorMessage { get; set; }
        public object errorAction { get; set; }
    }
}
