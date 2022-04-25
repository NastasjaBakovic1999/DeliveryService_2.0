using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja status posiljke
    /// </summary>
    public class Status
    {
        /// <value>
        ///     Id objekta klase Status
        /// </value>
        public int StatusId { get; set; }
        /// <value>
        ///    Naziv tj opis statusa posiljke
        /// </value>
        public string StatusName { get; set; }
        /// <value>
        ///     Lista objekata agregirane klase StatusShipment
        /// </value>
        /// <remarks>
        ///     <para>
        ///         Ova lista predstavlja pomocnu strukturu <br />
        ///         jer definise parove posiljaka i statuse koje se odnose <br />
        ///         na tu posiljku. 
        ///     </para>
        ///     <para>
        ///         Olaksava mapiranje ORM alatima i rad sa objektima u kontroleru.
        ///     </para>
        /// </remarks>
        public List<StatusShipment> Shipments { get; set; } = new List<StatusShipment>();

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
        ///     Funkcija koja vraca vrednost atributa StatusName
        /// </summary>
        /// <returns>Naziv statusa</returns>
        public string GetStatusName()
        {
            return StatusName;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa StatusName
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni naziv null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni naziv prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="status">Opis statusa</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetStatusName(string status)
        {
            if (status == null)
            {
                throw new ArgumentNullException("Status Name cannot be null!");
            }

            if (status.Trim().Length == 0 || status == "")
            {
                throw new ArgumentException("Status Name cannot be empty string!");
            }

            StatusName = status;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na listu objekata klase StatusShipment
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na listu objekata null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<StatusShipment> GetShipments()
        {
            if (Shipments == null)
            {
                throw new NullReferenceException("Shipment Statuses is null!");
            }

            return Shipments;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na listu objekata klase StatusShipment
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na listu objekata null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///          <item>
        ///             <term>Ukoliko postojeca lista objekata sadrzi neki objekat prosledjene liste</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <param name="addss">Lista posiljaka koje imaju odredjeni status</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipments(List<StatusShipment> ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach (StatusShipment statusShipment in ss)
            {
                if (Shipments.Any(a => a.ShipmentId == statusShipment.ShipmentId && 
                                        a.StatusId == statusShipment.StatusId))
                {
                    throw new ArgumentException("Status shipments list already contains some of the forwarded objects!");
                }
            }

            Shipments.AddRange(ss);
        }
    }
}
