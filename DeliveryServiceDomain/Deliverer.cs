using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    public class Deliverer : Person
    {
        private DateTime DateOfEmployment { get; set; }

        public DateTime GetDateOfEmployment()
        {
            return DateOfEmployment;
        }

        public void SetDateOfEmployment(DateTime doe)
        {
            if(doe > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Date Of Employment cannot be in the future!");
            }

            DateOfEmployment = doe;
        }
    }
}
