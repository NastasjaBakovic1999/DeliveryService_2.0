using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja osobu
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Ova klasa predstavlja nadtip klasama koje je <br />
    ///     nasledjuju i prosiruju. 
    /// </para>
    /// <para>
    ///     Sama klasa Person nasledjuje i prosiruje klasu <seealso cref="IdentityUser"/>. <br />
    ///     <seealso href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser?view=aspnetcore-1.1">Vise o klasi IdentityUser i ostalim klasama Identity namespace-a</seealso>
    /// </para>
    /// </remarks>
    public class Person : IdentityUser<int>
    {
        /// <value>
        ///     Ime osobe
        /// </value>
        public string FirstName { get; set; }

        /// <value>
        ///     Prezime osobe
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa FirstName
        /// </summary>
        /// <returns>Ime osobe</returns>
        public string GetFirstName()
        {
            return FirstName;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa FirstName
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeno ime null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeno ime prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="fName">Ime osobe</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetFirstName(string fName)
        {
            if (fName == null)
            {
                throw new ArgumentNullException("First Name cannot be null!");
            }

            if (fName.Length == 0 || fName == "")
            {
                throw new ArgumentException("First Name cannot be empty space!");
            }

            FirstName = fName;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa LastName
        /// </summary>
        /// <returns>Prezime osobe</returns>
        public string GetLastName()
        {
            return FirstName;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa LastName
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeno prezime null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeno prezime prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="lName">Prezime osobe</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetLastName(string lName)
        {
            if (lName == null)
            {
                throw new ArgumentNullException("Last Name cannot be null!");
            }

            if (lName.Length == 0 || lName == "")
            {
                throw new ArgumentException("Last Name cannot be empty space!");
            }

            LastName = lName;
        }
    }
}
