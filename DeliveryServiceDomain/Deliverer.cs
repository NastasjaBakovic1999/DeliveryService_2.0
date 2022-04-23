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
        /// <param name="doe"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
