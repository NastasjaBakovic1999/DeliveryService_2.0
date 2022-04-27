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
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }

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
        /// <param name="address">Adresa kupca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetAddres(string address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Address cannot be null!");
            }

            if (address.Trim().Length == 0 || address == "")
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
        /// <param name="postalCode">Postanski broj kupca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetPostalCode(string postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException("Postal Code cannot be null!");
            }

            if (postalCode.Trim().Length == 0 || postalCode == "")
            {
                throw new ArgumentException("Postal Code cannot be empty space!");
            }

            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"Customer: {FirstName} {LastName}";
        }
    }
}
