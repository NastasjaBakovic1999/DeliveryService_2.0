using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja dostavljaca
    /// </summary>
    /// <remarks>
    ///    <para>
    ///         U kontekstu datog softverskog sistema <br />
    ///         ova klasa predstavlja isporucioca paketa
    ///     </para>
    ///     <para>
    ///         Nasledjuje i prosiruje klasu Person.
    ///     </para>
    /// </remarks>
    public class Deliverer : Person
    {
        /// <value> 
        ///     Datum zaposlenja dostavljaca
        /// </value>
        public DateTime DateOfEmployment { get; set; }
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
        ///     Funkcija koja vraca vrednost atributa DateOfEmployment
        /// </summary>
        /// <returns>Datum zaposlenja dostavljaca</returns>
        public DateTime GetDateOfEmployment()
        {
            return DateOfEmployment;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa DateOfEmployment
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni datum ili vreme u buducnosti</term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="doe">Datum zaposlenja</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetDateOfEmployment(DateTime doe)
        {
            if(doe > DateTime.Now || doe > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("Date Of Employment cannot be in the future!");
            }

            DateOfEmployment = doe;
        }

        /// <summary>
        ///     Funkcija koja predstavlja override funkcije ToString
        /// </summary>
        /// <remarks>   
        ///     Vraca string vrednost koja sadrzi podatke o objektu <br />
        ///     klase Deliverer
        /// </remarks>
        /// <returns>String sa podacima o isporuciocu</returns>
        public override string ToString()
        {
            return $"Deliverer: {FirstName} {LastName}";
        }
    }
}
