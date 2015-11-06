# dpd.net
A .NET wrapper for DPD's Shipping API. DPD's API is very much a work-in-progress so I have only wrapped the 2 core methods required to create a shipment.  

Async and Sync methods abailable for everything.

Includes a test console app to demo the functionality.

## API Support

- Login. This returns the session token needed for all further requests
- Shipping/Shipment. This essentially is the core method as it creates a shipment from a sender to a receiver, and returns a tracking/consignment number

## Usage

Simply create a new instance of the DpdShippingClient and call the CreateShipment method (Note, this also wraps the login to keep things simple)

