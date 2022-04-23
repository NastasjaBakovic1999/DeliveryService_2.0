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
        /// <param name="id"></param>
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
        /// <param name="additionalService"></param>
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
        /// <param name="id"></param>
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
        /// <param name="shipment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void GetShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException("Shipment cannot be null!");
            }

            Shipment = shipment;
        }
    }
}
