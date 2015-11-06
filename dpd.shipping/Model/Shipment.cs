using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpd.shipping.Model
{
    public class Shipment
    {
        public object job_id { get; set; }  //can use this to group together shipments
        public bool collectionOnDelivery { get; set; }  //generally this will be false for us
        public object invoice { get; set; } //only needed for international shipments
        public string collectionDate { get; set; }
        public bool consolidate { get; set; }
        public List<Consignment> consignment { get; set; }
    }

    public class ContactDetails
    {
        public string contactName { get; set; }
        public string telephone { get; set; }
    }

    public class Address
    {
        public string organisation { get; set; }
        public string countryCode { get; set; }
        public string postcode { get; set; }
        public string street { get; set; }
        public string locality { get; set; }
        public string town { get; set; }
        public string county { get; set; }
    }

    public class CollectionDetails
    {
        public ContactDetails contactDetails { get; set; }
        public Address address { get; set; }
    }


    public class NotificationDetails
    {
        public string email { get; set; }
        public string mobile { get; set; }
    }

    public class DeliveryDetails
    {
        public ContactDetails contactDetails { get; set; }
        public Address address { get; set; }
        public NotificationDetails notificationDetails { get; set; }
    }

    public class Consignment
    {
        public string consignmentNumber { get; set; }
        public string consignmentRef { get; set; }
        public List<object> parcels { get; set; }
        public CollectionDetails collectionDetails { get; set; }
        public DeliveryDetails deliveryDetails { get; set; }
        public string networkCode { get; set; }
        public int numberOfParcels { get; set; }
        public decimal totalWeight { get; set; }
        public string shippingRef1 { get; set; }
        public string shippingRef2 { get; set; }
        public string shippingRef3 { get; set; }
        public object customsValue { get; set; }
        public string deliveryInstructions { get; set; }
        public string parcelDescription { get; set; }
        public object liabilityValue { get; set; }
        public bool liability { get; set; }
    }
}
