using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja kupca.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         U kontekstu datog softverskog sistema <br />
    ///         ova klasa predstavlja korisnika koji narucuje uslugu <br/>
    ///         isporuke posiljke.
    ///     </para>
    ///     <para>
    ///         Nasledjuje i prosiruje klasu Person.
    ///     </para>
    /// </remarks>
    public class Customer : Person
    {
        /// <value>
        ///     Adresa kupca
        /// </value>
        public string Address { get; set; }

        /// <value>
        ///     Postanski broj kupca
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa Address
        /// </summary>
        /// <returns>Adresa kupca</returns>
        public string GetAddress()
        {
            return Address;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atrbuta Address
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena adresa null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjena adresa prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa PostalCode
        /// </summary>
        /// <returns>Postanski broj kupca</returns>
        public string GetPostalCode()
        {
            return PostalCode;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa PostalCode
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni postanski broj null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni postanski broj prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="postalCode"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
