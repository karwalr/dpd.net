using System.Collections.Generic;
using dpd.shipping;
using dpd.shipping.Model;
using dpd.shipping.Response;
using dpd.shipping.Utility;

namespace dpd.testapp
{
    class Program
    {
        private const string DpdUserName = "XXXXX";
        private const string DpdPassword = "XXXXX";
        private const string DpdAccountNumber = "1234567";

        static void Main(string[] args)
        {
            var client = new DpdShippingClient(DpdUserName, DpdPassword, DpdAccountNumber, "");

            List<Consignment> consignmentList = new List<Consignment>();
            Consignment consignment = new Consignment();
            consignment.consignmentNumber = null;
            consignment.consignmentRef = null;
            consignment.parcels = null;

            consignment.collectionDetails = new CollectionDetails
            {
                contactDetails = new ContactDetails
                {
                    contactName = "Joe Bloggs",
                    telephone = "0123456"
                },
                address = new Address
                {
                    countryCode = "GB",
                    county = "West Midlands",
                    locality = "West Midlands",
                    organisation = "Joe Bloggs Co",
                    street = "Joe Street",
                    town = "Wolverhampton",
                    postcode = "WV2 2NN"
                }
            };
            consignment.deliveryDetails = new DeliveryDetails
            {
                address = new Address
                {
                    countryCode = "GB",
                    county = "West Midlands",
                    locality = "West Midlands",
                    organisation = "Joe Bloggs Co",
                    street = "Joe Street",
                    town = "Wolverhampton",
                    postcode = "WV2 2NN"
                },
                contactDetails = new ContactDetails
                {
                    contactName = "Joe Bloggs",
                    telephone = "0123456"
                },
                notificationDetails = new NotificationDetails
                {
                    email = "joe@bloggs.co.uk",
                    mobile = "1234566"
                }
            };

            consignment.networkCode = StringUtility.GetDescription(NetworkService.DPDNextDay); //TODO. Extend for all types available
            consignment.numberOfParcels = 1; 
            consignment.totalWeight = 5.0M;
            consignment.shippingRef1 = "ORDERNUMBER";
            consignment.customsValue = null;    //if internationl, show order value
            consignment.deliveryInstructions = "Leave in porch";
            consignment.parcelDescription = ""; 
            consignment.liabilityValue = null;
            consignment.liability = false;
            consignmentList.Add(consignment);

            Shipment shipment = new Shipment();
            shipment.job_id = null;
            shipment.collectionOnDelivery = false;
            shipment.collectionDate = "2015-10-25T09:00:00"; //Must be a future date.
            shipment.consolidate = false;
            shipment.consignment = consignmentList;
            //shipment.invoice = null;  //TODO

            ShipmentResponse shipmentResponse = client.CreateShipment(shipment, DpdUserName, DpdPassword, DpdAccountNumber);
        }

    }
}
