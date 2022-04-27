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
        public void SetStatusId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetStatusId(id);
            Assert.Equal(expected, _sut.GetStatusId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetStatusId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetStatusId(id));
        }

        [Theory]
        [InlineData("Kod kurira")]
        [InlineData("Isporucena")]
        public void SetStatusName_Theory(string name)
        {
            _sut.SetStatusName(name);
            Assert.Equal(name, _sut.GetStatusName());
        }

        [Fact]
        public void SetStatusName_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetStatusName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetStatusName_EmptyString_Theory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetStatusName(name));
        }

        [Fact]
        public void SetShipments_NullList_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipments(null));
        }

        [Theory]
        [MemberData(nameof(ShipmentsData))]
        public void SetShipments_DoubleObjects_Fact(List<StatusShipment> shipments)
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
        public void SetShipments_Fact()
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
        public void GetShipments_Null_Fact()
        {
            _sut.Shipments = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipments_Fact()
        {
            _sut.Shipments = (List<StatusShipment>)A.CollectionOfFake<StatusShipment>(10);
            Assert.Equal(10, _sut.GetShipments().Count);
        }
    }
}
