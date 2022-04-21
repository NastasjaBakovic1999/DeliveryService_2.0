using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class ShipmentWeight
    {
        private int ShipmentWeightId { get; set; }
        private string ShipmentWeightDescpription { get; set; }
        private double ShipmentWeightPrice { get; set; }
        private List<Shipment> Shipments { get; set; }

        public int GetShipmentWeightId()
        {
            return ShipmentWeightId;
        }

        public void SetShipmentWeightId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentWeightId = id;
        }

        public double GetShipmentWeightPrice()
        {
            return ShipmentWeightPrice;
        }

        public void SetShipmentWeightPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be lower than 0!");
            }

            ShipmentWeightPrice = price;
        }

        public string GetShipmentWeightDescpription()
        {
            if (ShipmentWeightDescpription == null)
            {
                throw new NullReferenceException("Shipment Weight Descpription is null!");
            }

            return ShipmentWeightDescpription;
        }

        public void SetShipmentWeightDescpription(string desc)
        {
            if (desc == null)
            {
                throw new ArgumentNullException("Shipment Weight Descpription cannot be null!");
            }

            if (desc.Length == 0 || desc == "")
            {
                throw new ArgumentException("Shipment Weight Descpription cannot be empty string!");
            }

            ShipmentWeightDescpription = desc;
        }

        public List<Shipment> GetShipments()
        {
            if (Shipments == null)
            {
                throw new NullReferenceException("Shipments is null!");
            }

            return Shipments;
        }

        public void SetAdShipmentStatuses(List<Shipment> ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach (Shipment shipment in ss)
            {
                if (Shipments.Contains(shipment))
                {
                    throw new ArgumentException("Shipments list already contains some of the forwarded objects!");
                }
            }

            Shipments = ss;
        }
    }
}
