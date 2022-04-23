using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja tezinu posiljke
    /// </summary>
    public class ShipmentWeight
    {
        /// <value>
        ///     Id objekta klase ShipmentWeight
        /// </value>
        public int ShipmentWeightId { get; set; }

        /// <value>
        ///     Opis tezine posiljke
        /// </value>
        /// <remarks>Tezina posiljke izrazava se u kg</remarks>
        public string ShipmentWeightDescpription { get; set; }

        /// <value>
        ///    Cena po tezini posiljke
        /// </value>
        public double ShipmentWeightPrice { get; set; }

        /// <value>
        ///     Lista objekata klase Shipment
        /// </value>
        /// <remarks>Ova lista objekata predstavlja pomocnu strukturu <br />
        ///           koja predstavlja sve posiljke sa odredjenom tezinom i <br />
        ///           ima kljucnu ulugo pri mapiranju nekim ORM alatom <br />
        ///           ali i koriscenju objekata u kontrolerima
        /// </remarks>
        public List<Shipment> Shipments { get; set; }


        /// <summary>
        ///     Funkcija koja vraca Id objekta klase ShipmentWeight
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetShipmentWeightId()
        {
            return ShipmentWeightId;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost Id-ja objekta klase ShipmentWeight
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetShipmentWeightId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentWeightId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ShipmentWeightPrice
        /// </summary>
        /// <returns>Cena po tezini posiljke</returns>
        public double GetShipmentWeightPrice()
        {
            return ShipmentWeightPrice;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ShipmentWeightPrice
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena cena manja od 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="price"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetShipmentWeightPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be lower than 0!");
            }

            ShipmentWeightPrice = price;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ShipmentWeightDescpription
        /// </summary>
        /// <returns>Opis tezine posiljke</returns>
        public string GetShipmentWeightDescpription()
        {
            return ShipmentWeightDescpription;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ShipmentWeightDescpription
        ///        <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni opis null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///          <item>
        ///             <term>Ukoliko je prosledjeni opis prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <param name="desc"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipmentWeightDescpription(string desc)
        {
            if (desc == null)
            {
                throw new ArgumentNullException("Shipment Weight Descpription cannot be null!");
            }

            if (desc.Length == 0 || desc == "")
            {
                throw new ArgumentException("Shipment Weight Descpription cannot be empty string!");
            }

            ShipmentWeightDescpription = desc;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na listu objekata klase Shipment
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na listu objekata null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<Shipment> GetShipments()
        {
            if (Shipments == null)
            {
                throw new NullReferenceException("Shipments is null!");
            }

            return Shipments;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na listu objekata klase Shipment
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
        /// <param name="addss"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdShipmentStatuses(List<Shipment> ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach (Shipment shipment in ss)
            {
                if (Shipments.Contains(shipment))
                {
                    throw new ArgumentException("Shipments list already contains some of the forwarded objects!");
                }
            }

            Shipments = ss;
        }
    }
}
