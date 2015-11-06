using dpd.shipping.Model;
using dpd.shipping.Request;
using dpd.shipping.Request.Base;
using dpd.shipping.Response;
using System;
using System.Threading.Tasks;

namespace dpd.shipping
{
    public class DpdShippingClient
    {
        public DpdShippingClient(string dpdUserName, string dpdPassword, string dpdAccountNumber, string dpdSessionId)
        {
            ServiceModelConfig.Create(dpdUserName, dpdPassword, dpdAccountNumber, dpdSessionId);
        }

        public async Task<LoginResponse> LoginAsync()
        {
            return await SendRequestAsync(new LoginRequest(new Model.Login()));
        }

        public LoginResponse Login()
        {
            return SendRequest(new LoginRequest(new Model.Login()));
        }

        public async Task<ShipmentResponse> CreateShipmentAsync(Shipment shipment, string DpdUserName, string DpdPassword, string DpdAccountNumber)
        {
            ShipmentResponse shipmentResponse = new ShipmentResponse();

            //Call Login as we need the login session token here on the header to continue
            LoginResponse loginResponse = await LoginAsync();

            if (!string.IsNullOrEmpty(loginResponse.data.geoSession))
            {
                //Create a new instance of the class and add login session value to the HTTP header
                var loggedInClient = new DpdShippingClient(DpdUserName, DpdPassword, DpdAccountNumber, loginResponse.data.geoSession);

                shipmentResponse = await SendRequestAsync(new ShipmentRequest(shipment));
            }

            return shipmentResponse;
        }

        public ShipmentResponse CreateShipment(Shipment shipment, string DpdUserName, string DpdPassword, string DpdAccountNumber)
        {
            ShipmentResponse shipmentResponse = new ShipmentResponse();

            //Call Login as we need the login session token here on the header to continue
            LoginResponse loginResponse = Login();

            if (!string.IsNullOrEmpty(loginResponse.data.geoSession))
            {
                //Create a new instance of the class and add login session value to the HTTP header
                var loggedInClient = new DpdShippingClient(DpdUserName, DpdPassword, DpdAccountNumber, loginResponse.data.geoSession);

                shipmentResponse = SendRequest(new ShipmentRequest(shipment));
            }

            return shipmentResponse;
        }

        //*********************************************************************************************************

        private static async Task<TResponse> SendRequestAsync<TResponse>(BaseRequest<TResponse> request) where TResponse : BaseResponse, new()
        {
            try
            {
                return await request.ExecuteAsync();
            }
            catch (Exception e)
            {
                //Log.Error(request.GetType().FullName, e);

                return new TResponse()
                {
                    Error = e.InnerException != null ? e.InnerException.Message : e.Message,
                    Ok = false
                };
            }
        }

        private static TResponse SendRequest<TResponse>(BaseRequest<TResponse> request) where TResponse : BaseResponse, new()
        {
            try
            {
                return request.Execute();

            }
            catch (Exception e)
            {
                //Log.Error(request.GetType().FullName, e);

                return new TResponse()
                {
                    Error = e.InnerException != null ? e.InnerException.Message : e.Message,
                    Ok = false
                };
            }
        }
    }
}
