using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class StatusShipment
    {
        private int StatusId { get; set; }
        private Status Status { get; set; }
        private int ShipmentId { get; set; }
        private Shipment Shipment { get; set; }
        private DateTime StatusTime { get; set; }

        public int GetStatusId()
        {
            return StatusId;
        }

        public void SetStatusId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            StatusId = id;
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

        public Status GetStatus()
        {
            if (Status == null)
            {
                throw new NullReferenceException("Status is null!");
            }

            return Status;
        }

        public void SetStatus(Status status)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status cannot be null!");
            }

            Status = status;
        }

        public Shipment GetShipment()
        {
            if (Shipment == null)
            {
                throw new NullReferenceException("Shipmentis null!");
            }

            return Shipment;
        }

        public void SetShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException("Shipment cannot be null!");
            }

            Shipment = shipment;
        }

        public DateTime GetStatusTime()
        {
            return StatusTime;
        }

        public void SetStatusTime(DateTime dt)
        {
            if(dt > DateTime.Now)
            {
                throw new ArgumentException("Status Time cannot be in the future!");
            }

            StatusTime = dt;
        }
    }
}
