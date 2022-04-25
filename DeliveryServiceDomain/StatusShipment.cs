using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstastavlja agregiranu klasu izmedju objekata <br />
    ///     klasa Status i Shipment.
    /// </summary>
    /// <remarks>
    ///     Predstavlja pomocnu klasu koja olaksava mapiranje ORM alatima <br/>
    ///     i rad sa objektima u kontrolerima.
    /// </remarks>
    public class StatusShipment
    {
        public StatusShipment()
        {

        }

        public StatusShipment(int sId, int shId, Status status, Shipment shipment, DateTime dt)
        {
            StatusId = sId;
            ShipmentId = shId;
            Status = status;
            Shipment = shipment;
            StatusTime = dt;
        }

        /// <value>
        ///     Id objekta klase Status
        /// </value>
        public int StatusId { get; set; }

        /// <value>
        ///     Referenca na objekat klase Status
        /// </value>
        public Status Status { get; set; }

        /// <value>
        ///     Id objekta klase Shipment
        /// </value>
        public int ShipmentId { get; set; }

        /// <value>
        ///     Referenca na objekat klase Shipment
        /// </value>
        public Shipment Shipment { get; set; }

        /// <value>
        ///     Datum i vreme kada se jedna posiljka nasla u jednom statusu
        /// </value>
        /// <remarks>
        ///     Ovaj atribut predstavlja doodatni podatak agregacije <br />
        ///     i omogucava da se jedna posiljka moze vise puta naci <br />
        ///     u jednom istom statusu
        /// </remarks>
        public DateTime StatusTime { get; set; }


        /// <summary>
        ///     Funkcija koja vraca Id objekta klase Status
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetStatusId()
        {
            return StatusId;
        }

        /// <summary>
        ///     Funkcija koja postavlja Id objekta klase Status
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetStatusId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            StatusId = id;
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
        ///     Funkcija koja postavlja Id objekta klase Shipment
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">ID obejkta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetShipmentId(int id)
        {
            if (id < 0 || id == 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca referencu na objekat klase Status
        /// </summary>
        /// <remarks>
        ///     Objekat predstavlja status koji se dodeljuje posiljci
        /// </remarks>
        /// <returns>Objekat klase Status</returns>
        public Status GetStatus()
        {

            return Status;
        }

        /// <summary>
        ///      Funkcija koja postavlja referencu na objekat klase Status
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="status">Status koji se pridruzuje odredjenoj posiljci</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetStatus(Status status)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status cannot be null!");
            }

            Status = status;
        }


        /// <summary>
        ///     Funkcija koja vraca referencu na objekat klase Shipment
        /// </summary>
        /// <remarks>
        ///     Objekat predstavlja posiljku kojoj se dodeljuje neki status
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
        /// <param name="shipment">Posiljka kojoj se dodeljuje odredjeni status</param>
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
        ///     Funkcija koja vraca vrednost atributa StatusTime
        /// </summary>
        /// <returns>Vreme kada je posiljka dobila odredjeni status</returns>
        public DateTime GetStatusTime()
        {
            return StatusTime;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa StatusTime
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni datum ili vreme u bduucnosti</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="dt">Vreme kada se posiljka nasla u nekom statusu</param>
        /// <exception cref="ArgumentException"></exception>
        public void SetStatusTime(DateTime dt)
        {
            if (dt > DateTime.Now || dt > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("Status Time cannot be in the future!");
            }

            StatusTime = dt;
        }
    }
}
