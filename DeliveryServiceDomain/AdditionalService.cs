using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class AdditionalService
    {
        private int AdditionalServiceId { get; set; }
        private string AdditionalServiceName { get; set; }
        private double AdditionalServicePrice { get; set; }
        private List<AdditionalServiceShipment> Shipments { get; set; }

        public int GetAdditionalServiceId()
        {
            return AdditionalServiceId;
        }

        public void SetAddiitonalServiceId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be lower than or equal to 0!");
            }

            AdditionalServiceId = id;
        }

        public string GetAdditionalServiceName()
        {
            if(AdditionalServiceName == null)
            {
                throw new NullReferenceException("Name is null!");
            }
            
            if (AdditionalServiceName == "" || AdditionalServiceName.Length == 0)
            {
                throw new InvalidOperationException("Name is empty string!");
            }
            return AdditionalServiceName;
        }

        public void SetAdditionalServiceName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null!");
            }

            if (name.Length == 0 || name == "")
            {
                throw new ArgumentException("Name cannot be empty space!");
            }

            AdditionalServiceName = name;
        }

        public double GetAdditionalServicePrice()
        {
            return AdditionalServicePrice;
        }

        public void SetAdditionalServicePrice(double price)
        {
            if(price < 0)
            {
                throw new ArgumentException("Price cannot be lower than 0!");
            }
        }

        public List<AdditionalServiceShipment> GetShipments()
        {
            return Shipments;
        }

        public void SetShipments(List<AdditionalServiceShipment> shipments)
        {
            if(shipments == null)
            {
                throw new ArgumentNullException("Shipments cannot be null!");
            }

            if (shipments.Count() == 0)
            {
                throw new ArgumentException("Shipments cannot be empty list!");
            }

            Shipments = shipments;
        }

    }
}
