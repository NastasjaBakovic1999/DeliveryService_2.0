using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja dodatne usluge koje se <br />
    ///     mogu dodeliti jednoj posiljci.
    /// </summary>
    public class AdditionalService
    {
        /// <value>
        ///     Id objekta klase AdditionalService
        /// </value>
        public int AdditionalServiceId { get; set; }

        /// <value>
        ///     Naziv, odnosno opis, dodatne usluge
        /// </value>
        public string AdditionalServiceName { get; set; }

        /// <value>
        ///     Cena dodatne usluge
        /// </value>
        public double AdditionalServicePrice { get; set; }

        /// <value>
        ///     Lista objekata klase AdditionalServiceShipment koji predstavljaju agregirane <br/>
        ///     objekte klasa AdditionalService i Shipment. 
        /// </value>
        /// <remarks>
        ///     Lista ima pomocnu funkciju, pre svega olaksava mapiranje ORM alatima, ali i rad <br />
        ///     sa objektima u kontrolerima.
        /// </remarks>
        public List<AdditionalServiceShipment> Shipments { get; set; }


        /// <summary>
        ///     Funkcija vraca Id objekta klase AdditonalService
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetAdditionalServiceId()
        {
            return AdditionalServiceId;
        }

        /// <summary>
        ///     Funkcija postavlja vrednost Id-a objekta klase AdditonalService.
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetAddiitonalServiceId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be lower than or equal to 0!");
            }

            AdditionalServiceId = id;
        }

        /// <summary>
        ///     Funkcija vraca vrednost atributa AdditionalServiceName
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je naziv null </term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item
        ///          <item>
        ///             <term>Ukoliko je naziv prazan string</term>
        ///             <description>Funkcija baca <see cref="InvalidOperationException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <returns>Naziv, odnosno, opis dodatne usluge</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetAdditionalServiceName()
        {
            if(AdditionalServiceName == null)
            {
                throw new NullReferenceException("Name is null!");
            }
            
            if (AdditionalServiceName == "" || AdditionalServiceName.Length == 0)
            {
                throw new InvalidOperationException("Name is empty string!");
            }
            return AdditionalServiceName;
        }


        /// <summary>
        ///     Funkcija postavlja vrednost atributa AdditionalServiceName
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni naziv null </term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///          <item>
        ///             <term>Ukoliko je prosledjeni naziv prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="name">Ime dodatne usluge</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdditionalServiceName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null!");
            }

            if (name.Length == 0 || name == "")
            {
                throw new ArgumentException("Name cannot be empty space!");
            }

            AdditionalServiceName = name;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa AdditionalServicePrice
        /// </summary>
        /// <returns>Cena odredjene dodatne usluge</returns>
        public double GetAdditionalServicePrice()
        {
            return AdditionalServicePrice;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa AdditionalServicePrice
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena cena manja od 0</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="price">Cena dodatne usluge</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdditionalServicePrice(double price)
        {
            if(price < 0)
            {
                throw new ArgumentException("Price cannot be lower than 0!");
            }
        }

        /// <summary>
        ///     Funkcija koja vraca listu objekata klase AdditionalServiceShipment
        /// </summary>
        /// <remarks>
        ///     Ova lista definiste dodatnu uslugu i posiljku na koju se ta usluga odnosi
        /// </remarks>
        /// <returns>Lista agregiranihh objekata</returns>
        public List<AdditionalServiceShipment> GetShipments()
        {
            return Shipments;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost liste objekata klase AdditionalServiceShipment
        ///        <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena lista null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko se neki od objekata prosledjene liste vec nalazi u postojecoj listi</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="shipments">Posiljke koje imaju odredjenu dodatnu uslugu</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipments(List<AdditionalServiceShipment> shipments)
        {
            if(shipments == null)
            {
                throw new ArgumentNullException("Shipments cannot be null!");
            }

            if (shipments.Count() == 0)
            {
                throw new ArgumentException("Shipments cannot be empty list!");
            }

            Shipments.AddRange(shipments);
        }

    }
}
