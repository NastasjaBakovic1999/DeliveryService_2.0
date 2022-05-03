using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstastavlja agregiranu klasu izmedju objekata <br />
    ///     klasa AdditionalService i Shipment.
    /// </summary>
    /// <remarks>
    ///     Predstavlja pomocnu klasu koja olaksava mapiranje ORM alatima <br/>
    ///     i rad sa objektima u kontrolerima.
    /// </remarks>
    public class AdditionalServiceShipment
    {
        public AdditionalServiceShipment()
        {

        }
        public AdditionalServiceShipment(int idAS, int idS, AdditionalService ads, Shipment s)
        {
            AdditionalServiceId = idAS;
            ShipmentId = idS;
            AdditionalService = ads;
            Shipment = s;
        }

        /// <value>
        ///     Id objekta klase AdditionalService
        /// </value>
        public int AdditionalServiceId { get; set; }

        /// <remarks>
        ///     Predstavlja jednu dodatnu uslugu dodeljenu nekoj posiljci
        /// </remarks>
        /// <value>
        ///     Referenca na objekat klase AdditionalService
        /// </value>
        public AdditionalService AdditionalService { get; set; }

        /// <value>
        ///     Id objekta klase Shipment
        /// </value>
        public int ShipmentId { get; set; }

        /// <remarks>
        ///     Predstavlja posiljku na koju se odnosi jedna dodatna usluga
        /// </remarks>
        /// <value>
        ///     Referenca na objekat klase Shipment
        /// </value>
        public Shipment Shipment { get; set; }

        /// <summary>
        ///     Funkcija koja vraca Id objekta klase AddtionalService
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetAdditionalServiceId()
        {
            return AdditionalServiceId;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost Id-ja objekta klase AddtionalService
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdditionalServiceId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be lower than or equal to 0!");
            }

            AdditionalServiceId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca referencu na objekat klase AddtionalService
        /// </summary>
        /// <remarks>
        ///     Objekat predstavlja dodatnu uslugu dodeljenju jednoj posiljci
        /// </remarks>
        /// <returns>Objekat klase</returns>
        public AdditionalService GetAdditionalService()
        {
            return AdditionalService;
        }

        /// <summary>
        ///      Funkcija koja postavlja referencu na objekat klase AddtionalService
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="additionalService">Dodatna usluga koja se dodeljuje nekoj posiljci</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetAdditionalService(AdditionalService additionalService)
        {
            if (additionalService == null)
            {
                throw new ArgumentNullException("Additional Service cannot be null!");
            }

            AdditionalService = additionalService;
        }

        /// <summary>
        ///     Funkcija koja vraca Id objekta klase Shipment
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetShipmentId()
        {
            return ShipmentId;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost Id-ja objekta klase Shipment
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipmentId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be lower than or equal to 0!");
            }

            ShipmentId = id;
        }


        /// <summary>
        ///     Funkcija koja vraca referencu na objekat klase Shipment
        /// </summary>
        /// <remarks>
        ///     Objekat predstavlja posiljku kojoj se dodeljuje dodatna usluga
        /// </remarks>
        /// <returns>Objekat klase Shipment</returns>
        public Shipment GetShipment()
        {
            return Shipment;
        }

        /// <summary>
        ///      Funkcija koja postavlja referencu na objekat klase Shipment
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="shipment">Posiljka kojoj se dodeljuje neka dodatna usluga</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException("Shipment cannot be null!");
            }

            Shipment = shipment;
        }

        /// <summary>
        ///     Funkcija koja predstavlja override funkcije ToString
        /// </summary>
        /// <remarks>   
        ///     Vraca string vrednost koja sadrzi podatke o agregaciji <br />
        ///     dodatne usluge i posiljke
        /// </remarks>
        /// <returns>String sa podacima o objektu AdditionalServiceShipment</returns>
        public override string ToString()
        {
            return $"{Shipment} has {AdditionalService.AdditionalServiceName} additional service";
        }

        /// <summary>
        ///     Funkcija koja predstavlja override funkcije Equals
        /// </summary>
        /// <remarks>
        ///     Funkcija koja poredi dva objekta klase AdditionalServiceShipment <br />
        ///     i prema definisanim pravilima jednakosti odredjuje da li su ti objekti <br/>
        ///     jednaki (isti) ili ne.
        /// </remarks>
        /// <param name="obj">Objekat klase AdditionalServiceShipment koji se <br />
        /// poredi sa drugim objektom iste klase</param>
        /// <returns>Boolean vrednost - ukoliko su objekti jednaki true, u suprotnom false.</returns>
        public override bool Equals(object obj)
        {
            return obj is AdditionalServiceShipment shipment &&
                   AdditionalServiceId == shipment.AdditionalServiceId &&
                   EqualityComparer<AdditionalService>.Default.Equals(AdditionalService, shipment.AdditionalService) &&
                   ShipmentId == shipment.ShipmentId &&
                   EqualityComparer<Shipment>.Default.Equals(Shipment, shipment.Shipment);
        }

        /// <summary>
        ///     Funkcija koja predstavlja override funkcije GetHashCode
        /// </summary>
        /// <remarks>
        ///     Definise nacin na koji kreiramo jedinstveni hash kod objekta 
        /// </remarks>
        /// <returns>Objekat klase HashCode koji je jedinstveni identifikator objekta</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(AdditionalServiceId, AdditionalService, ShipmentId, Shipment);
        }
    }
}
