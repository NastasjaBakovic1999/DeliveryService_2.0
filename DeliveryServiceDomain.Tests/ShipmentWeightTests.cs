using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class ShipmentWeightTests
    {
        private readonly ShipmentWeight _sut;
        public ShipmentWeightTests()
        {
            _sut = new ShipmentWeight();
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
        [InlineData("Od 0,5 do 1kg")]
        [InlineData("Preko 20kg")]
        public void SetShipmentWeight_Descpription_Theory(string desc)
        {
            _sut.SetShipmentWeightDescpription(desc);
            Assert.Equal(desc, _sut.GetShipmentWeightDescpription());
        }

        [Fact]
        public void SetShipmentWeightDescription_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmentWeightDescpription(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetShipmentWeightDescpription_EmptyString_Theory(string content)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetShipmentWeightDescpription(content));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(159)]
        public void SetShipmentWeightPrice_PositiveAmount_Theory(double price)
        {
            _sut.SetShipmentWeightPrice(price);
            Assert.Equal(price, _sut.GetShipmentWeightPrice());
        }

        [Fact]
        public void SetShipmentWeightPrice_NegativeAmount_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetShipmentWeightPrice(-10));
        }

        [Fact]
        public void SetShipments_NullList_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipmens(null));
        }

        [Theory]
        [MemberData(nameof(ShipmentsData))]
        public void SetShipments_DoubleObjects_Fact(List<Shipment> shipments)
        {
            var sp = (List<Shipment>)A.CollectionOfFake<Shipment>(10);

            for (int i = 0; i < sp.Count; i++)
            {
                sp[i] = new Shipment(i,
                                    i + 1,
                                    i,
                                    i+1);
            }

            _sut.SetShipmens(sp);

            Assert.Throws<ArgumentException>(() => _sut.SetShipmens(shipments));
        }

        [Fact]
        public void SetShipments_Fact()
        {
            var shipments = (List<Shipment>)A.CollectionOfFake<Shipment>(10);
            Random rand = new Random();

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new Shipment(rand.Next(50, 101),
                                                                  rand.Next(10, 200),
                                                                  rand.Next(50, 101),
                                                                  rand.Next(10, 200));
            }


            _sut.SetShipmens(shipments);
            Assert.Equal(10, _sut.GetShipments().Count);
        }

        public static IEnumerable<object[]> ShipmentsData()
        {
            var shipments = (List<Shipment>)A.CollectionOfFake<Shipment>(10);

            for (int i = 0; i < shipments.Count; i++)
            {
                shipments[i] = new Shipment(i,
                                    i + 1,
                                    i,
                                    i + 1);
            }

            yield return new object[] { shipments.GetRange(1, 1) };
            yield return new object[] { shipments.GetRange(1, 5) };
            yield return new object[] { shipments.GetRange(3, 7) };

            var moreShipments = (List<Shipment>)A.CollectionOfFake<Shipment>(2);
            shipments.InsertRange(0, moreShipments);

            yield return new object[] { shipments };

        }


        [Fact]
        public void GetShipmentsNullFact()
        {
            _sut.Shipments = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipmentsFact()
        {
            _sut.Shipments = (List<Shipment>)A.CollectionOfFake<Shipment>(10);
            Assert.Equal(10, _sut.GetShipments().Count);
        }
    }
}
