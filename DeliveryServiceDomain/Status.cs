using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<StatusShipment> Shipments { get; set; }

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

        public string GetStatusName()
        {
            if (StatusName == null)
            {
                throw new NullReferenceException("Status Name is null!");
            }

            return StatusName;
        }

        public void SetStatusName(string status)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status Name cannot be null!");
            }

            if (status.Length == 0 || status == "")
            {
                throw new ArgumentException("Status Name cannot be empty string!");
            }

            StatusName = status;
        }
    }
}
