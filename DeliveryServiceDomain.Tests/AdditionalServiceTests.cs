using FakeItEasy;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class AdditionalServiceTests
    {
        private readonly AdditionalService _sut;
        public AdditionalServiceTests()
        {
            _sut = new AdditionalService();
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(10,10)]
        [InlineData(200,200)]
        public void SetAdditionalServiceId_PositiveInt_Theory(int expected, int id)
        {
            _sut.SetAddiitonalServiceId(id);
            Assert.Equal(expected, _sut.GetAdditionalServiceId());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetAdditionalServiceId_NegativeIntOrZero_Theory(int id)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAddiitonalServiceId(id));
        }

        [Theory]
        [InlineData("SMS obavestenje")]
        [InlineData("Osiguranje vrednosti")]
        [InlineData("Dodatno pakovanje")]
        public void SetAdditionalServiceName_CorrectName_Theory(string name)
        {
            _sut.SetAdditionalServiceName(name);
            Assert.Equal(name, _sut.GetAdditionalServiceName());
        }

        [Fact]
        public void SetAdditionalServiceName_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetAdditionalServiceName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetAdditionalServiceName_EmptyString_Theory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAdditionalServiceName(name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(159)]
        public void SetAdditionalServicePrice_PositiveAmount_Theory(double price)
        {
            _sut.SetAdditionalServicePrice(price);
            Assert.Equal(price, _sut.GetAdditionalServicePrice());
        }

        [Fact]
        public void SetAdditionalServicePrice_NegativeAmount_Fact()
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAdditionalServicePrice(-10));
        }

        [Fact]
        public void GetShipments_Null_Fact()
        {
            _sut.Shipments = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipments_EmptyList_Fact()
        {
            _sut.Shipments = new List<AdditionalServiceShipment>();
            Assert.Throws<Exception>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipments_Fact()
        {
            _sut.Shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);
            Assert.Equal(10, _sut.GetShipments().Count);
        }

        [Fact]
        public void SetShipments_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipments(null));
        }

        [Fact]
        public void SetShipments_EmptyList_Fact()
        {
            var shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(0);
            Assert.Throws<ArgumentException>(() => _sut.SetShipments(shipments));
        }

        [Fact]
        public void SetShipments_Fact()
        {
            var shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);
            Random rand = new Random();

            for(int i=0;i<shipments.Count; i++)
            {
                shipments[i] = new AdditionalServiceShipment(rand.Next(50, 101),
                                                                  rand.Next(10, 200),
                                                                  new AdditionalService(),
                                                                  new Shipment());
            }


            _sut.SetShipments(shipments);
            Assert.Equal(10, _sut.GetShipments().Count);
        }
    }
}
