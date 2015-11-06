using dpd.shipping.Model;
using dpd.shipping.Request.Base;
using dpd.shipping.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace dpd.shipping.Request
{
    public class LoginRequest : PostRequest<LoginResponse, Login>
    {
        public LoginRequest(Login login)
            : base(login)
        {
            RequestUrl = "user/?action=login";
        }
    }
}
