using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class StatusTests
    {
        private readonly Status _sut;
        public StatusTests()
        {
            _sut = new Status();
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(200, 200)]
        public void SetStatusIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetStatusId(id);
            Assert.Equal(expected, _sut.GetStatusId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetStatusIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetStatusId(id));
        }

        [Theory]
        [InlineData("Kod kurira")]
        [InlineData("Isporucena")]
        public void SetStatusNameTheory(string name)
        {
            _sut.SetStatusName(name);
            Assert.Equal(name, _sut.GetStatusName());
        }

        [Fact]
        public void SetStatusNameNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetStatusName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetStatusNameEmptyStringTheory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetStatusName(name));
        }

        [Fact]
        public void SetShipmentsNullListFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipments(null));
        }

        [Theory]
        [MemberData(nameof(ShipmentsData))]
        public void SetShipmentsDoubleObjectsFact(List<StatusShipment> shipments)
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

            _sut.SetShipments(sp);

            Assert.Throws<ArgumentException>(() => _sut.SetShipments(shipments));
        }

        [Fact]
        public void SetShipmentsFact()
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


            _sut.SetShipments(shipments);
            Assert.Equal(10, _sut.GetShipments().Count);
        }

        public static IEnumerable<object[]> ShipmentsData()
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


        [Fact]
        public void GetShipmentsNullFact()
        {
            _sut.Shipments = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipmentsFact()
        {
            _sut.Shipments = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(10);
            Assert.Equal(10, _sut.GetShipments().Count);
        }
    }
}
