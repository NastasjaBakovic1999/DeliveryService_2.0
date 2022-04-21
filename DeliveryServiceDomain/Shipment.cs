using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Shipment
    {
        public int ShipmentWeightId { get; set; }
        public int ShipmentId { get; set; }
        public string ShipmentCode { get; set; }
        public ShipmentWeight ShipmentWeight { get; set; }
        public string ShipmentContent { get; set; }
        public string SendingCity { get; set; }
        public string SendingAddress { get; set; }
        public string SendingPostalCode { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingAddress { get; set; }
        public string ReceivingPostalCode { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DelivererId { get; set; }
        public Deliverer Deliverer { get; set; }
        public double Price { get; set; }
        public List<AdditionalServiceShipment> AdditionalServices { get; set; }
        public List<StatusShipment> ShipmentStatuses { get; set; }
        public string Note { get; set; }

        public int GetShipmentWeightId()
        {
            return ShipmentWeightId;
        }

        public void SetShipmentWeightId(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentWeightId = id;
        }

        public int GetShipmentId()
        {
            return ShipmentId;
        }

        public void SetShipmentId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentId = id;
        }

        public string GetShipmentCode()
        {
            if (ShipmentCode == null)
            {
                throw new NullReferenceException("Shipment Code is null!");
            }

            return ShipmentCode;
        }

        public void SetShipmentCode(string code)
        {
            if(code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if(code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            ShipmentCode = code;
        }

        public string GetShipmentContent()
        {
            if (ShipmentContent == null)
            {
                throw new NullReferenceException("Shipment Content is null!");
            }

            return ShipmentContent;
        }

        public void SetShipmentContent(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("Shipment Content cannot be null!");
            }

            if (content.Length == 0 || content == "")
            {
                throw new ArgumentException("Shipment Content cannot be empty string!");
            }

            ShipmentContent = content;
        }

        public string GetSendingCity()
        {
            if (SendingCity == null)
            {
                throw new NullReferenceException("Sending City is null!");
            }

            return SendingCity;
        }

        public void SetSendingCity(string sCity)
        {
            if (sCity == null)
            {
                throw new ArgumentNullException("Sending City cannot be null!");
            }

            if (sCity.Length == 0 || sCity == "")
            {
                throw new ArgumentException("Sending City cannot be empty string!");
            }

            SendingCity = sCity;
        }

        public string GetSendingAddress()
        {
            if (SendingAddress == null)
            {
                throw new NullReferenceException("Sending Address is null!");
            }

            return SendingAddress;
        }

        public void SetSendingAddress(string sAddress)
        {
            if (sAddress == null)
            {
                throw new ArgumentNullException("Sending Address cannot be null!");
            }

            if (sAddress.Length == 0 || sAddress == "")
            {
                throw new ArgumentException("Sending Address cannot be empty string!");
            }

            SendingAddress = sAddress;
        }

        public string GetSendingPostalCode()
        {
            if (SendingPostalCode == null)
            {
                throw new NullReferenceException("Sending Postal Code is null!");
            }

            return SendingPostalCode;
        }

        public void SetSendingPostalCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if (code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            SendingPostalCode = code;
        }

        public string GetReceivingCity()
        {
            if (ReceivingCity == null)
            {
                throw new NullReferenceException("Receiving City is null!");
            }

            return ReceivingCity;
        }

        public void SetReceivingCity(string rCity)
        {
            if (rCity == null)
            {
                throw new ArgumentNullException("Receiving City cannot be null!");
            }

            if (rCity.Length == 0 || rCity == "")
            {
                throw new ArgumentException("Receiving City cannot be empty string!");
            }

            ReceivingCity = rCity;
        }

        public string GetReceivingAddress()
        {
            if (ReceivingAddress == null)
            {
                throw new NullReferenceException("Receiving Address is null!");
            }

            return ReceivingAddress;
        }

        public void SetReceivingAddress(string rAddress)
        {
            if (rAddress == null)
            {
                throw new ArgumentNullException("Receiving Address cannot be null!");
            }

            if (rAddress.Length == 0 || rAddress == "")
            {
                throw new ArgumentException("Receiving Address cannot be empty string!");
            }

            ReceivingAddress = rAddress;
        }

        public string GetSReceivingPostalCode()
        {
            if (ReceivingPostalCode == null)
            {
                throw new NullReferenceException("Receiving Postal Code is null!");
            }

            return ReceivingPostalCode;
        }

        public void SetReceivingPostalCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if (code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            ReceivingPostalCode = code;
        }

        public string GetContactPersonName()
        {
            if (ShipmentCode == null)
            {
                throw new NullReferenceException("Contact Person Name is null!");
            }

            return ContactPersonName;
        }

        public void SetContactPersonName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null!");
            }

            if (name.Length == 0 || name == "")
            {
                throw new ArgumentException("Name cannot be empty string!");
            }

            ContactPersonName = name;
        }

        public string GetContactPersonPhone()
        {
            if (ContactPersonPhone == null)
            {
                throw new NullReferenceException("Contact Person Phone is null!");
            }

            return ContactPersonPhone;
        }

        public void SetContactPersonPhone(string phone)
        {
            if (phone == null)
            {
                throw new ArgumentNullException("Phone cannot be null!");
            }

            if (phone.Length == 0 || phone == "")
            {
                throw new ArgumentException("Phone cannot be empty string!");
            }

            ContactPersonPhone = phone; 
        }

        public string GetNote()
        {
            if (Note == null)
            {
                throw new NullReferenceException("Note is null!");
            }

            return Note;
        }

        public void SetNote(string note)
        {
            if (note == null)
            {
                throw new ArgumentNullException("Note cannot be null!");
            }

            if (note.Length == 0 || note == "")
            {
                throw new ArgumentException("Note cannot be empty string!");
            }

            Note = note;
        }

        public int GetCustomerId()
        {
            return CustomerId;
        }

        public void SetCustomerId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            CustomerId = id;
        }

        public int GetDelivererId()
        {
            return DelivererId;
        }

        public void SetDelivererId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            DelivererId = id;
        }

        public ShipmentWeight GetShipmentWeight()
        {
            if(ShipmentWeight == null)
            {
                throw new NullReferenceException("Shipment Weight is null!");
            }

            return ShipmentWeight;
        }

        public void SetShipmentWeight(ShipmentWeight sw)
        {
            if (sw == null)
            {
                throw new ArgumentNullException("Shipment Weight cannot be null!");
            }

            ShipmentWeight = sw;
        }

        public Customer GetCustomer()
        {
            if (ShipmentWeight == null)
            {
                throw new NullReferenceException("Customer is null!");
            }

            return Customer;
        }

        public void SetCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null!");
            }

            Customer = customer;
        }

        public Deliverer GetDeliverer()
        {
            if (Deliverer == null)
            {
                throw new NullReferenceException("Deliverer is null!");
            }

            return Deliverer;
        }

        public void SetDeliverer(Deliverer deliverer)
        {
            if (deliverer == null)
            {
                throw new ArgumentNullException("Deliverer cannot be null!");
            }

            Deliverer = deliverer;
        }

        public List<AdditionalServiceShipment> GetAdditionalServices()
        {
            if(AdditionalServices == null)
            {
                throw new NullReferenceException("Additional Services is null!");
            }

            return AdditionalServices;
        }

        public void SetAdditionalServices(List<AdditionalServiceShipment> addss)
        {
            if(addss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach(AdditionalServiceShipment additionalService in addss)
            {
                if (AdditionalServices.Contains(additionalService))
                {
                    throw new ArgumentException("Additional services list already contains some of the forwarded objects!");
                }
            }

            AdditionalServices = addss;
        }

        public List<StatusShipment> GetShipmentStatuses()
        {
            if (ShipmentStatuses == null)
            {
                throw new NullReferenceException("Shipment Statuses is null!");
            }

            return ShipmentStatuses;
        }

        public void SetAdShipmentStatuses(List<StatusShipment> ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach (StatusShipment statusShipment in ss)
            {
                if (ShipmentStatuses.Contains(statusShipment))
                {
                    throw new ArgumentException("Status shipments list already contains some of the forwarded objects!");
                }
            }

            ShipmentStatuses = ss;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double price)
        {
            if(price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be lower than 0!");
            }

            Price = price;
        }
    }
}
