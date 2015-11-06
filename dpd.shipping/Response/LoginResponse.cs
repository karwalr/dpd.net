using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dpd.shipping.Response
{
    public class LoginResponse : BaseResponse
    {
        public data data { get; set; }
        public string error { get; set; }
    }

    public class data
    {
        public string flag { get; set; }
        public string geoSession { get; set; }
    }
}
