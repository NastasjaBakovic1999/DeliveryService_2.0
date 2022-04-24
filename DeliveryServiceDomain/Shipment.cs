using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceDomain
{
    /// <summary>
    ///     Klasa koja predstavlja posiljku
    /// </summary>
    public class Shipment
    {
        /// <value>
        ///     Id objekta klase ShipmentWeight
        /// </value>
        public int ShipmentWeightId { get; set; }

        /// <value>
        ///     Id objekta klase Shipment
        /// </value>
        public int ShipmentId { get; set; }

        /// <value>
        ///     Jedinstveni kod posiljke
        /// </value>
        public string ShipmentCode { get; set; }

        /// <value>
        ///     Referenca na objekat klase ShipmentWeight
        /// </value>
        public ShipmentWeight ShipmentWeight { get; set; }

        /// <value>
        ///     Sadrzaj posiljke
        /// </value>
        public string ShipmentContent { get; set; }

        /// <value>
        ///     Grad posiljaoca
        /// </value>
        public string SendingCity { get; set; }

        /// <value>
        ///     Adresa posiljaoca
        /// </value>
        public string SendingAddress { get; set; }

        /// <value>
        ///     Postanski broj posiljaoca
        /// </value>
        public string SendingPostalCode { get; set; }

        /// <value>
        ///     Grad primaoca
        /// </value>
        public string ReceivingCity { get; set; }

        /// <value>
        ///     Adresa primaoca
        /// </value>
        public string ReceivingAddress { get; set; }

        /// <value>
        ///     Postanski broj primaoca
        /// </value>
        public string ReceivingPostalCode { get; set; }

        /// <value>
        ///     Ime i prezime kontakt osobe
        /// </value>
        public string ContactPersonName { get; set; }

        /// <value>
        ///     Broj telefona kontakt osobe
        /// </value>
        public string ContactPersonPhone { get; set; }

        /// <value>
        ///     Id objekta klase Customer
        /// </value>
        public int CustomerId { get; set; }

        /// <value>
        ///     Referenca na objekat klase Customer
        /// </value>
        public Customer Customer { get; set; }

        /// <value>
        ///     Id objekta klase Deliverer
        /// </value>
        public int DelivererId { get; set; }

        /// <value>
        ///     Referenca na objekat klase Deliverer
        /// </value>
        public Deliverer Deliverer { get; set; }

        /// <value>
        ///     Cena posiljke
        /// </value>
        public double Price { get; set; }

        /// <remarks>  
        ///     <para>
        ///         Ova lista predstavlja pomocnu strukturu <br />
        ///         jer definise parove posiljaka i dodatnih usluga koje se odnose <br />
        ///         na tu posiljku. 
        ///     </para>
        ///     <para>
        ///         Olaksava mapiranje ORM alatima i rad sa objektima u kontroleru.
        ///     </para>
        /// </remarks>
        /// <value>
        ///     Referenca na listu objekata agregirane klase AdditionalServiceShipment
        /// </value>
        public List<AdditionalServiceShipment> AdditionalServices { get; set; }

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
        /// <value>
        ///     Referenca na listu objekata agregirane klase StatusShipment
        /// </value>
        public List<StatusShipment> ShipmentStatuses { get; set; }

        /// <value>
        ///     Napomena uz posiljku
        /// </value>
        public string Note { get; set; }


        /// <summary>
        ///     Funkcija koja vraca Id objekta klase ShipmentWeight
        /// </summary>
        /// <returns>Id objekta</returns>
        public int GetShipmentWeightId()
        {
            return ShipmentWeightId;
        }

        /// <summary>
        ///     Funkcija koja postavlja Id objekta klase ShipmentWeight
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetShipmentWeightId(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentWeightId = id;
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
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetShipmentId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            ShipmentId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ShipmentCode
        /// </summary>
        /// <returns>Jedinstveni kod posiljke</returns>
        public string GetShipmentCode()
        {

            return ShipmentCode;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ShipmentCode
        ///         <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni kod null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni kod prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="code">Jedinstveni kod posiljke</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipmentCode(string code)
        {
            if(code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if(code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            ShipmentCode = code;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ShipmentContent
        /// </summary>
        /// <returns>Sadrzaj posiljke</returns>
        public string GetShipmentContent()
        {
            return ShipmentContent;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ShipmentContent
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni sadrzaj null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni sadrzaj prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="content">Sadrzaj posiljke</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetShipmentContent(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("Shipment Content cannot be null!");
            }

            if (content.Length == 0 || content == "")
            {
                throw new ArgumentException("Shipment Content cannot be empty string!");
            }

            ShipmentContent = content;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa SendingCity
        /// </summary>
        /// <returns>Grad posiljaoca</returns>
        public string GetSendingCity()
        {
            return SendingCity;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa SendingCity
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni grad null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni grad prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="sCity">Grad posiljaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetSendingCity(string sCity)
        {
            if (sCity == null)
            {
                throw new ArgumentNullException("Sending City cannot be null!");
            }

            if (sCity.Length == 0 || sCity == "")
            {
                throw new ArgumentException("Sending City cannot be empty string!");
            }

            SendingCity = sCity;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa SendingAddress
        /// </summary>
        /// <returns>Adresa posiljaoca</returns>
        public string GetSendingAddress()
        {
            if (SendingAddress == null)
            {
                throw new NullReferenceException("Sending Address is null!");
            }

            return SendingAddress;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa SendingAddress
        ///       <list type="bullet">
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
        /// <param name="sAddress">Adresa posiljaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetSendingAddress(string sAddress)
        {
            if (sAddress == null)
            {
                throw new ArgumentNullException("Sending Address cannot be null!");
            }

            if (sAddress.Length == 0 || sAddress == "")
            {
                throw new ArgumentException("Sending Address cannot be empty string!");
            }

            SendingAddress = sAddress;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa SendingPostalCode
        /// </summary>
        /// <returns>Postanski broj posiljaoca</returns>
        public string GetSendingPostalCode()
        {
            return SendingPostalCode;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa SendingPostalCode
        ///      <list type="bullet">
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
        /// <param name="code">Postanski kod posiljaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetSendingPostalCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if (code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            SendingPostalCode = code;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ReceivingCity
        /// </summary>
        /// <returns>Grad primaoca</returns>
        public string GetReceivingCity()
        {
            if (ReceivingCity == null)
            {
                throw new NullReferenceException("Receiving City is null!");
            }

            return ReceivingCity;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ReceivingCity
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni grad null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni grad prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="rCity">Grad primaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetReceivingCity(string rCity)
        {
            if (rCity == null)
            {
                throw new ArgumentNullException("Receiving City cannot be null!");
            }

            if (rCity.Length == 0 || rCity == "")
            {
                throw new ArgumentException("Receiving City cannot be empty string!");
            }

            ReceivingCity = rCity;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ReceivingAddress
        /// </summary>
        /// <returns>Adresa primaoca</returns>
        public string GetReceivingAddress()
        {
            if (ReceivingAddress == null)
            {
                throw new NullReferenceException("Receiving Address is null!");
            }

            return ReceivingAddress;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ReceivingAddress
        ///       <list type="bullet">
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
        /// <param name="rAddress">Adresa primaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetReceivingAddress(string rAddress)
        {
            if (rAddress == null)
            {
                throw new ArgumentNullException("Receiving Address cannot be null!");
            }

            if (rAddress.Length == 0 || rAddress == "")
            {
                throw new ArgumentException("Receiving Address cannot be empty string!");
            }

            ReceivingAddress = rAddress;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ReceivingPostalCode
        /// </summary>
        /// <returns>Postanski broj primaoca</returns>
        public string GetSReceivingPostalCode()
        {
            if (ReceivingPostalCode == null)
            {
                throw new NullReferenceException("Receiving Postal Code is null!");
            }

            return ReceivingPostalCode;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ReceivingPostalCode
        ///      <list type="bullet">
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
        /// <param name="code">Postanski kod primaoca</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetReceivingPostalCode(string code)
        {
            if (code == null)
            {
                throw new ArgumentNullException("Code cannot be null!");
            }

            if (code.Length == 0 || code == "")
            {
                throw new ArgumentException("Code cannot be empty string!");
            }

            ReceivingPostalCode = code;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ContactPersonName
        /// </summary>
        /// <returns>Ime kontakt osobe</returns>
        public string GetContactPersonName()
        {
            return ContactPersonName;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ContactPersonName
        ///        <list type="bullet">
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
        /// <param name="name">Ime kontakt osobe</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetContactPersonName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name cannot be null!");
            }

            if (name.Length == 0 || name == "")
            {
                throw new ArgumentException("Name cannot be empty string!");
            }

            ContactPersonName = name;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa ContactPersonPhone
        /// </summary>
        /// <returns>Broj telefona kontakt osobe</returns>
        public string GetContactPersonPhone()
        {
            return ContactPersonPhone;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa ContactPersonPhone
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni broj null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjeni broj prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="phone">Broj telefona kontakt osobe</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetContactPersonPhone(string phone)
        {
            if (phone == null)
            {
                throw new ArgumentNullException("Phone cannot be null!");
            }

            if (phone.Length == 0 || phone == "")
            {
                throw new ArgumentException("Phone cannot be empty string!");
            }

            ContactPersonPhone = phone; 
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa Note
        /// </summary>
        /// <returns>Napomena uz posiljku</returns>
        public string GetNote()
        {
            return Note;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa Note
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena napomena null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///         <item>
        ///             <term>Ukoliko je prosledjena napomena prazan string</term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="note">Napomena uz posiljku</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetNote(string note)
        {
            if (note == null)
            {
                throw new ArgumentNullException("Note cannot be null!");
            }

            if (note.Length == 0 || note == "")
            {
                throw new ArgumentException("Note cannot be empty string!");
            }

            Note = note;
        }

        /// <summary>
        ///     Funkcija koja vraca Id objekta klase Customer
        /// </summary>
        /// <returns>Id korinika tj kupca</returns>
        public int GetCustomerId()
        {
            return CustomerId;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost Id-ja objekta klase Customer
        ///    <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCustomerId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            CustomerId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca Id objekta klase Deliverer
        /// </summary>
        /// <returns>Id dostavljaca</returns>
        public int GetDelivererId()
        {
            return DelivererId;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost Id-ja objekta klase Deliverer
        ///    <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni id manji ili jednak 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="id">Id objekta</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetDelivererId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be lower than or equal to 0!");
            }

            DelivererId = id;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na objekat klase ShipmentWeight
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na objekat null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public ShipmentWeight GetShipmentWeight()
        {
            if(ShipmentWeight == null)
            {
                throw new NullReferenceException("Shipment Weight is null!");
            }

            return ShipmentWeight;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na objekat klase ShipmentWeight
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <param name="sw">Tezina posiljke</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetShipmentWeight(ShipmentWeight sw)
        {
            if (sw == null)
            {
                throw new ArgumentNullException("Shipment Weight cannot be null!");
            }

            ShipmentWeight = sw;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na objekat klase Customer
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na objekat null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Customer GetCustomer()
        {
            if (ShipmentWeight == null)
            {
                throw new NullReferenceException("Customer is null!");
            }

            return Customer;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na objekat klase Customer
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <param name="customer">Kupac koji narucuje posiljku</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("Customer cannot be null!");
            }

            Customer = customer;
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na objekat klase Deliverer
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na objekat null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Deliverer GetDeliverer()
        {
            if (Deliverer == null)
            {
                throw new NullReferenceException("Deliverer is null!");
            }

            return Deliverer;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na objekat klase Deliverer
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjeni objekat null</term>
        ///             <description>Funkcija baca <see cref="ArgumentNullException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <param name="deliverer">Dostavljac koji je zaduzen za posiljku</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetDeliverer(Deliverer deliverer)
        {
            if (deliverer == null)
            {
                throw new ArgumentNullException("Deliverer cannot be null!");
            }

            Deliverer = deliverer;
        }


        /// <summary>
        ///     Funkcija koja vraca vrednost reference <br />
        ///     na listu objekata klase AdditionalServiceShipment
        ///       <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je referenca na listu objekata null</term>
        ///             <description>Funkcija baca <see cref="NullReferenceException"/> gresku.</description>
        ///         </item>
        ///       </list>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public List<AdditionalServiceShipment> GetAdditionalServices()
        {
            if(AdditionalServices == null)
            {
                throw new NullReferenceException("Additional Services is null!");
            }

            return AdditionalServices;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost reference <br />
        ///     na listu objekata klase AdditionalServiceShipment
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
        /// <param name="addss">Lista posiljaka i njihovih dodatnih usluga</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdditionalServices(List<AdditionalServiceShipment> addss)
        {
            if(addss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach(AdditionalServiceShipment additionalService in addss)
            {
                if (AdditionalServices.Contains(additionalService))
                {
                    throw new ArgumentException("Additional services list already contains some of the forwarded objects!");
                }
            }

            AdditionalServices.AddRange(addss);
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
        public List<StatusShipment> GetShipmentStatuses()
        {
            if (ShipmentStatuses == null)
            {
                throw new NullReferenceException("Shipment Statuses is null!");
            }

            return ShipmentStatuses;
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
        /// <param name="addss">Lista posiljaka i njihovih statusa</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetAdShipmentStatuses(List<StatusShipment> ss)
        {
            if (ss == null)
            {
                throw new ArgumentNullException("Argument cannot be null!");
            }

            foreach (StatusShipment statusShipment in ss)
            {
                if (ShipmentStatuses.Contains(statusShipment))
                {
                    throw new ArgumentException("Status shipments list already contains some of the forwarded objects!");
                }
            }

            ShipmentStatuses.AddRange(ss);
        }

        /// <summary>
        ///     Funkcija koja vraca vrednost atributa Price
        /// </summary>
        /// <returns>Cena posiljke</returns>
        public double GetPrice()
        {
            return Price;
        }

        /// <summary>
        ///     Funkcija koja postavlja vrednost atributa Price
        ///      <list type="bullet">
        ///         <item>
        ///             <term>Ukoliko je prosledjena cena manja od 0 </term>
        ///             <description>Funkcija baca <see cref="ArgumentOutOfRangeException"/> gresku.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="price">Cena posiljke</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetPrice(double price)
        {
            if(price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be lower than 0!");
            }

            Price = price;
        }
    }
}
