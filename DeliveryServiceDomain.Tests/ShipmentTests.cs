using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class ShipmentTests
    {
        private readonly Shipment _sut;
        public ShipmentTests()
        {
            _sut = new Shipment();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetShipmentWeightIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetShipmentWeightId(id);
            Assert.Equal(expected, _sut.GetShipmentWeightId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetShipmentWeightIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetShipmentWeightId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetShipmentIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetShipmentId(id);
            Assert.Equal(expected, _sut.GetShipmentId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetShipmentIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetShipmentId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetCustomerIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetCustomerId(id);
            Assert.Equal(expected, _sut.GetCustomerId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetCustomerIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetCustomerId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetDelivererIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetDelivererId(id);
            Assert.Equal(expected, _sut.GetDelivererId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetDelivererIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetDelivererId(id));
        }

        [Fact]
        public void SetShipmentCodeFact()
        {
            var guid = new Guid();
            var code = guid.ToString().Substring(0, 11);

            _sut.SetShipmentCode(code);
            Assert.Equal(code, _sut.GetShipmentCode());
        }

        [Fact]
        public void SetShipmentCodeNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetShipmentCodeEmptyStringTheory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetShipmentCode(code));
        }

        [Theory]
        [InlineData("Odeca")]
        [InlineData("Racunarska tehnika")]
        public void SetShipmentContentTheory(string content)
        {
            _sut.SetShipmentContent(content);
            Assert.Equal(content, _sut.GetShipmentContent());
        }

        [Fact]
        public void SetShipmentContentNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentContent(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetShipmentContentEmptyStringTheory(string content)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetShipmentContent(content));
        }

        [Theory]
        [InlineData("Beograd")]
        [InlineData("Bajina Basta")]
        [InlineData("Ub")]
        public void SetSendingCityTheory(string sCity)
        {
            _sut.SetSendingCity(sCity);
            Assert.Equal(sCity, _sut.GetSendingCity());
        }

        [Fact]
        public void SetSendingCityNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingCity(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingCityEmptyStringTheory(string sCity)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingCity(sCity));
        }

        [Theory]
        [InlineData("Ive Lole Ribara 5")]
        [InlineData("Mija Kovacevica 7b")]
        [InlineData("Vojislava Ilica 20")]
        public void SetSendingAddressCorrectAddressTheory(string address)
        {
            _sut.SetSendingAddress(address);
            Assert.Equal(address, _sut.GetSendingAddress());
        }

        [Fact]
        public void SetSendingAddressNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingAddress(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingAddressEmptyStringTheory(string address)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingAddress(address));
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("31330")]
        public void SetSendingPostalCodeCorrectAddressTheory(string code)
        {
            _sut.SetSendingPostalCode(code);
            Assert.Equal(code, _sut.GetSendingPostalCode());
        }

        [Fact]
        public void SetSendingPostalCodeNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingPostalCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingPostalCodeEmptyStringTheory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingPostalCode(code));
        }

        [Theory]
        [InlineData("Beograd")]
        [InlineData("Bajina Basta")]
        [InlineData("Ub")]
        public void SetReceivngCityTheory(string sCity)
        {
            _sut.SetReceivingCity(sCity);
            Assert.Equal(sCity, _sut.GetReceivingCity());
        }

        [Fact]
        public void SetReceivingCityNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingCity(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingCityEmptyStringTheory(string sCity)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingCity(sCity));
        }

        [Theory]
        [InlineData("Ive Lole Ribara 5")]
        [InlineData("Mija Kovacevica 7b")]
        [InlineData("Vojislava Ilica 20")]
        public void SetReceivingAddressCorrectAddressTheory(string address)
        {
            _sut.SetReceivingAddress(address);
            Assert.Equal(address, _sut.GetReceivingAddress());
        }

        [Fact]
        public void SetReceivingAddressNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingAddress(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingAddressEmptyStringTheory(string address)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingAddress(address));
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("31330")]
        public void SetReceivingPostalCodeCorrectAddressTheory(string code)
        {
            _sut.SetReceivingPostalCode(code);
            Assert.Equal(code, _sut.GetSReceivingPostalCode());
        }

        [Fact]
        public void SetReceivingPostalCodeNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingPostalCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingPostalCodeEmptyStringTheory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingPostalCode(code));
        }

        [Theory]
        [InlineData("Nastasja Bakovic")]
        [InlineData("Ana-Marija Stefanovic-Perisic")]
        public void SetContactPersonNameCorrectAddressTheory(string name)
        {
            _sut.SetContactPersonName(name);
            Assert.Equal(name, _sut.GetContactPersonName());
        }

        [Fact]
        public void SetContactPersonNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetContactPersonName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetContactPersonEmptyStringTheory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetContactPersonName(name));
        }

        [Theory]
        [InlineData("06001234567")]
        [InlineData("452695")]
        [InlineData("011678543")]
        public void SetContactPersonPhoneCorrectAddressTheory(string phone)
        {
            _sut.SetContactPersonPhone(phone);
            Assert.Equal(phone, _sut.GetContactPersonPhone());
        }

        [Fact]
        public void SetContactPersonPhoneNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetContactPersonPhone(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetAddressEmptyStringTheory(string phone)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetContactPersonPhone(phone));
        }

        [Fact]
        public void SetAddressCorrectAddressFact()
        {
            var note = "Mozda nisu kod kuce";
            _sut.SetNote(note);
            Assert.Equal(note, _sut.GetNote());
        }

        [Fact]
        public void SetNoteNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetNote(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetNoteEmptyStringTheory(string note)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetNote(note));
        }

        [Fact]
        public void SetShipmentWeightNullObjectFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentWeight(null));
        }

        [Fact]
        public void SetShipmentWeightFact()
        {
            var adss = A.Fake<ShipmentWeight>();
            _sut.SetShipmentWeight(adss);

            Assert.Equal(adss, _sut.GetShipmentWeight());
        }

        [Fact]
        public void GetShipmentWeightNullObjectFact()
        {
            _sut.ShipmentWeight = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipmentWeight());
        }

        [Fact]
        public void GetShipmentWeightFact()
        {
            var sw = A.Fake<ShipmentWeight>();
            _sut.ShipmentWeight = sw;
            Assert.Equal(sw, _sut.GetShipmentWeight());
        }

        [Fact]
        public void SetCustomerNullObjectFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetCustomer(null));
        }

        [Fact]
        public void SetCustomerFact()
        {
            var adss = A.Fake<Customer>();
            _sut.SetCustomer(adss);

            Assert.Equal(adss, _sut.GetCustomer());
        }

        [Fact]
        public void GetCustomerNullObjectFact()
        {
            _sut.Customer = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetCustomer());
        }

        [Fact]
        public void GetCustomerFact()
        {
            var sw = A.Fake<Customer>();
            _sut.Customer = sw;
            Assert.Equal(sw, _sut.GetCustomer());
        }

        [Fact]
        public void SetDelivererNullObjectFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetDeliverer(null));
        }

        [Fact]
        public void SetDelivererFact()
        {
            var adss = A.Fake<Deliverer>();
            _sut.SetDeliverer(adss);

            Assert.Equal(adss, _sut.GetDeliverer());
        }

        [Fact]
        public void GetDelivererNullObjectFact()
        {
            _sut.Deliverer = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetDeliverer());
        }

        [Fact]
        public void GetDelivererFact()
        {
            var sw = A.Fake<Deliverer>();
            _sut.Deliverer = sw;
            Assert.Equal(sw, _sut.GetDeliverer());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(159)]
        public void SetPricePositiveAmountTheory(double price)
        {
            _sut.SetPrice(price);
            Assert.Equal(price, _sut.GetPrice());
        }

        [Fact]
        public void SetPriceNegativeAmountFact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetPrice(-10));
        }

        [Fact]
        public void SetAdditionalServicesNullListFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetAdditionalServices(null));
        }

        [Theory]
        [MemberData(nameof(AdditionalServicesData))]
        public void SetAdditionalServicesDoubleObjectsFact(List<AdditionalServiceShipment> shipments)
        {
            var sp = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);

            for (int i = 0; i < sp.Count; i++)
            {
                sp[i] = new AdditionalServiceShipment(i,
                                                     i + 1,
                                                     new AdditionalService(),
                                                     new Shipment());
            }

            _sut.SetAdditionalServices(sp);

            Assert.Throws<ArgumentException>(() => _sut.SetAdditionalServices(shipments));
        }

        [Fact]
        public void SetAdditionalServicesFact()
        {
            var shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);
            Random rand = new Random();

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new AdditionalServiceShipment(rand.Next(50, 101),
                                                                  rand.Next(10, 200),
                                                                  new AdditionalService(),
                                                                  new Shipment());
            }


            _sut.SetAdditionalServices(shipments);
            Assert.Equal(10, _sut.GetAdditionalServices().Count);
        }

        [Fact]
        public void SetShipmentStatusesNullListFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentStatuses(null));
        }


        [Theory]
        [MemberData(nameof(ShipmentSattusesData))]
        public void SetShipmentStatusesDoubleObjectsFact(List<StatusShipment> shipments)
        {
            var sp = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(10);

            for (int i = 0; i < sp.Count; i++)
            {
                sp[i] = new StatusShipment(i,
                                        i + 1,
                                        new Status(),
                                        new Shipment(),
                                        DateTime.Today);
            }

            _sut.SetShipmentStatuses(sp);

            Assert.Throws<ArgumentException>(() => _sut.SetShipmentStatuses(shipments));
        }

        [Fact]
        public void SetShipmentStatusesFact()
        {
            var shipments = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(10);
            Random rand = new Random();

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new StatusShipment(rand.Next(50, 101),
                                                                  rand.Next(10, 200),
                                                                  new Status(),
                                                                  new Shipment(),
                                                                   DateTime.Today);
            }


            _sut.SetShipmentStatuses(shipments);
            Assert.Equal(10, _sut.GetShipmentStatuses().Count);
        }

        public static IEnumerable<object[]> AdditionalServicesData()
        {
            var shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new AdditionalServiceShipment(i,
                                                             i+1,
                                                             new AdditionalService(),
                                                             new Shipment());
            }

            yield return new object[] { shipments.GetRange(1, 1) };
            yield return new object[] { shipments.GetRange(1, 5) };
            yield return new object[] { shipments.GetRange(3, 7) };

            var moreShipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(2);
            shipments.InsertRange(0, moreShipments);

            yield return new object[] {shipments };

        }

        public static IEnumerable<object[]> ShipmentSattusesData()
        {
            var shipments = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(10);

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new StatusShipment(i,
                                        i + 1,
                                        new Status(),
                                        new Shipment(),
                                        DateTime.Today);
            }

            yield return new object[] { shipments.GetRange(1, 1) };
            yield return new object[] { shipments.GetRange(1, 5) };
            yield return new object[] { shipments.GetRange(3, 7) };

            var moreShipments = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(2);
            shipments.InsertRange(0, moreShipments);

            yield return new object[] { shipments };

        }
    }
}
