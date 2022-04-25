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
        public void SetAdditionalServiceIdPositiveIntTheory(int expected, int id)
        {
            _sut.SetAddiitonalServiceId(id);
            Assert.Equal(expected, _sut.GetAdditionalServiceId());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-199)]
        public void SetAdditionalServiceIdNegativeIntTheory(int id)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAddiitonalServiceId(id));
        }

        [Theory]
        [InlineData("SMS obavestenje")]
        [InlineData("Osiguranje vrednosti")]
        [InlineData("Dodatno pakovanje")]
        public void SetAdditionalServiceNameCorrectNameTheory(string name)
        {
            _sut.SetAdditionalServiceName(name);
            Assert.Equal(name, _sut.GetAdditionalServiceName());
        }

        [Fact]
        public void SetAdditionalServiceNameNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetAdditionalServiceName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetAdditionalServiceNameEmptyStringTheory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAdditionalServiceName(name));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(159)]
        public void SetAdditionalServicePricePositiveAmountTheory(double price)
        {
            _sut.SetAdditionalServicePrice(price);
            Assert.Equal(price, _sut.GetAdditionalServicePrice());
        }

        [Fact]
        public void SetAdditionalServicePriceNegativeAmountFact()
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAdditionalServicePrice(-10));
        }

        [Fact]
        public void GetShipmentsNullFact()
        {
            _sut.Shipments = null;
            Assert.Throws<NullReferenceException>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipmentsEmptyListFact()
        {
            _sut.Shipments = new List<AdditionalServiceShipment>();
            Assert.Throws<Exception>(() => _sut.GetShipments());
        }

        [Fact]
        public void GetShipmentsFact()
        {
            _sut.Shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(10);
            Assert.Equal(10, _sut.GetShipments().Count);
        }

        [Fact]
        public void SetShipmentsNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipments(null));
        }

        [Fact]
        public void SetShipmentsEmptyListFact()
        {
            var shipments = (List<AdditionalServiceShipment>)A.CollectionOfFake<AdditionalServiceShipment>(0);
            Assert.Throws<ArgumentException>(() => _sut.SetShipments(shipments));
        }

        [Fact]
        public void SetShipmentsFact()
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
