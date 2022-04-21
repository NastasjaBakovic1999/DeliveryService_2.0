using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceDomain
{
    public class Customer : Person
    {
        private string Address { get; set; }
        private string PostalCode { get; set; }

        public string GetAddress()
        {
            return Address;
        }

        public void SetAddres(string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Address cannot be null!");
            }

            if (address.Length == 0 || address == "")
            {
                throw new ArgumentException("Address cannot be empty space!");
            }

            Address = address;
        }

        public string GetPostalCode()
        {
            return PostalCode;
        }

        public void SetPostalCode(string postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException("Postal Code cannot be null!");
            }

            if (postalCode.Length == 0 || postalCode == "")
            {
                throw new ArgumentException("Postal Code cannot be empty space!");
            }

            PostalCode = postalCode;
        }
    }
}
