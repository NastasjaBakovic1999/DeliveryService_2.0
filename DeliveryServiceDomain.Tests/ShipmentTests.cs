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
        public void SetShipmentWeightId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetShipmentWeightId(id);
            Assert.Equal(expected, _sut.GetShipmentWeightId());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetShipmentWeightId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetShipmentWeightId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetShipmentId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetShipmentId(id);
            Assert.Equal(expected, _sut.GetShipmentId());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetShipmentId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetShipmentId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetCustomerId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetCustomerId(id);
            Assert.Equal(expected, _sut.GetCustomerId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetCustomerId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetCustomerId(id));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetDelivererId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetDelivererId(id);
            Assert.Equal(expected, _sut.GetDelivererId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetDelivererId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetDelivererId(id));
        }

        [Fact]
        public void SetShipmentCode_Fact()
        {
            var guid = new Guid();
            var code = guid.ToString().Substring(0, 11);

            _sut.SetShipmentCode(code);
            Assert.Equal(code, _sut.GetShipmentCode());
        }

        [Fact]
        public void SetShipmentCode_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetShipmentCode_EmptyString_Theory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetShipmentCode(code));
        }

        [Theory]
        [InlineData("Odeca")]
        [InlineData("Racunarska tehnika")]
        public void SetShipmentContent_Theory(string content)
        {
            _sut.SetShipmentContent(content);
            Assert.Equal(content, _sut.GetShipmentContent());
        }

        [Fact]
        public void SetShipmentContent_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentContent(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetShipmentContent_EmptyString_Theory(string content)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetShipmentContent(content));
        }

        [Theory]
        [InlineData("Beograd")]
        [InlineData("Bajina Basta")]
        [InlineData("Ub")]
        public void SetSendingCity_Theory(string sCity)
        {
            _sut.SetSendingCity(sCity);
            Assert.Equal(sCity, _sut.GetSendingCity());
        }

        [Fact]
        public void SetSendingCity_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingCity(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingCity_EmptyString_Theory(string sCity)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingCity(sCity));
        }

        [Theory]
        [InlineData("Ive Lole Ribara 5")]
        [InlineData("Mija Kovacevica 7b")]
        [InlineData("Vojislava Ilica 20")]
        public void SetSendingAddress_CorrectAddress_Theory(string address)
        {
            _sut.SetSendingAddress(address);
            Assert.Equal(address, _sut.GetSendingAddress());
        }

        [Fact]
        public void SetSendingAddress_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingAddress(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingAddress_EmptyString_Theory(string address)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingAddress(address));
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("31330")]
        public void SetSendingPostalCode_CorrectAddress_Theory(string code)
        {
            _sut.SetSendingPostalCode(code);
            Assert.Equal(code, _sut.GetSendingPostalCode());
        }

        [Fact]
        public void SetSendingPostalCode_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetSendingPostalCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetSendingPostalCode_EmptyString_Theory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetSendingPostalCode(code));
        }

        [Theory]
        [InlineData("Beograd")]
        [InlineData("Bajina Basta")]
        [InlineData("Ub")]
        public void SetReceivngCity_Theory(string sCity)
        {
            _sut.SetReceivingCity(sCity);
            Assert.Equal(sCity, _sut.GetReceivingCity());
        }

        [Fact]
        public void SetReceivingCity_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingCity(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingCity_EmptyString_Theory(string sCity)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingCity(sCity));
        }

        [Theory]
        [InlineData("Ive Lole Ribara 5")]
        [InlineData("Mija Kovacevica 7b")]
        [InlineData("Vojislava Ilica 20")]
        public void SetReceivingAddress_CorrectAddress_Theory(string address)
        {
            _sut.SetReceivingAddress(address);
            Assert.Equal(address, _sut.GetReceivingAddress());
        }

        [Fact]
        public void SetReceivingAddress_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingAddress(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingAddress_EmptyString_Theory(string address)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingAddress(address));
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("31330")]
        public void SetReceivingPostalCode_CorrectAddress_Theory(string code)
        {
            _sut.SetReceivingPostalCode(code);
            Assert.Equal(code, _sut.GetSReceivingPostalCode());
        }

        [Fact]
        public void SetReceivingPostalCode_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetReceivingPostalCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetReceivingPostalCode_EmptyString_Theory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetReceivingPostalCode(code));
        }

        [Theory]
        [InlineData("Nastasja Bakovic")]
        [InlineData("Ana-Marija Stefanovic-Perisic")]
        public void SetContactPersonName_CorrectName_Theory(string name)
        {
            _sut.SetContactPersonName(name);
            Assert.Equal(name, _sut.GetContactPersonName());
        }

        [Fact]
        public void SetContactPersonName_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetContactPersonName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetContactPersonName_EmptyString_Theory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetContactPersonName(name));
        }

        [Theory]
        [InlineData("06001234567")]
        [InlineData("452695")]
        [InlineData("011678543")]
        public void SetContactPersonPhone_CorrectAddress_Theory(string phone)
        {
            _sut.SetContactPersonPhone(phone);
            Assert.Equal(phone, _sut.GetContactPersonPhone());
        }

        [Fact]
        public void SetContactPersonPhone_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetContactPersonPhone(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetAddress_EmptyString_Theory(string phone)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetContactPersonPhone(phone));
        }

        [Fact]
        public void SetAddress_CorrectAddress_Fact()
        {
            var note = "Mozda nisu kod kuce";
            _sut.SetNote(note);
            Assert.Equal(note, _sut.GetNote());
        }

        [Fact]
        public void SetNote_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetNote(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetNote_EmptyString_Theory(string note)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetNote(note));
        }

        [Fact]
        public void SetShipmentWeight_NullObject_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentWeight(null));
        }

        [Fact]
        public void SetShipmentWeight_Fact()
        {
            var adss = A.Fake<ShipmentWeight>();
            _sut.SetShipmentWeight(adss);

            Assert.Equal(adss, _sut.GetShipmentWeight());
        }

        [Fact]
        public void GetShipmentWeight_NullObject_Fact()
        {
            _sut.ShipmentWeight = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipmentWeight());
        }

        [Fact]
        public void GetShipmentWeight_Fact()
        {
            var sw = A.Fake<ShipmentWeight>();
            _sut.ShipmentWeight = sw;
            Assert.Equal(sw, _sut.GetShipmentWeight());
        }

        [Fact]
        public void SetCustomer_NullObject_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetCustomer(null));
        }

        [Fact]
        public void SetCustomer_Fact()
        {
            var adss = A.Fake<Customer>();
            _sut.SetCustomer(adss);

            Assert.Equal(adss, _sut.GetCustomer());
        }

        [Fact]
        public void GetCustomer_NullObject_Fact()
        {
            _sut.Customer = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetCustomer());
        }

        [Fact]
        public void GetCustomer_Fact()
        {
            var sw = A.Fake<Customer>();
            _sut.Customer = sw;
            Assert.Equal(sw, _sut.GetCustomer());
        }

        [Fact]
        public void SetDeliverer_NullObject_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetDeliverer(null));
        }

        [Fact]
        public void SetDeliverer_Fact()
        {
            var adss = A.Fake<Deliverer>();
            _sut.SetDeliverer(adss);

            Assert.Equal(adss, _sut.GetDeliverer());
        }

        [Fact]
        public void GetDeliverer_NullObject_Fact()
        {
            _sut.Deliverer = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetDeliverer());
        }

        [Fact]
        public void GetDeliverer_Fact()
        {
            var sw = A.Fake<Deliverer>();
            _sut.Deliverer = sw;
            Assert.Equal(sw, _sut.GetDeliverer());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(159)]
        public void SetPrice_PositiveAmount_Theory(double price)
        {
            _sut.SetPrice(price);
            Assert.Equal(price, _sut.GetPrice());
        }

        [Fact]
        public void SetPrice_NegativeAmount_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetPrice(-10));
        }

        [Fact]
        public void SetAdditionalServices_NullList_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetAdditionalServices(null));
        }

        [Theory]
        [MemberData(nameof(AdditionalServicesData))]
        public void SetAdditionalServices_DoubleObjects_Fact(List<AdditionalServiceShipment> shipments)
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
        public void SetAdditionalServices_Fact()
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
        public void SetShipmentStatuses_NullList_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentStatuses(null));
        }


        [Theory]
        [MemberData(nameof(ShipmentSattusesData))]
        public void SetShipmentStatuses_DoubleObjects_Fact(List<StatusShipment> shipments)
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
        public void SetShipmentStatuses_Fact()
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
