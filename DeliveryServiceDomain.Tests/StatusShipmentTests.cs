using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class StatusShipmentTests
    {
        private readonly StatusShipment _sut;
        public StatusShipmentTests()
        {
            _sut = new StatusShipment();
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

        [Fact]
        public void SetStatusNullObjectFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetStatus(null));
        }

        [Fact]
        public void SetStatusFact()
        {
            var adss = A.Fake<Status>();
            _sut.SetStatus(adss);

            Assert.Equal(adss, _sut.GetStatus());
        }

        [Fact]
        public void SetShipmentNullObjectFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetShipment(null));
        }

        [Fact]
        public void SetShipmentFact()
        {
            var shp = A.Fake<Shipment>();
            _sut.SetShipment(shp);

            Assert.Equal(shp, _sut.GetShipment());
        }

        [Theory]
        [MemberData(nameof(DateData))]
        public void SetDateOfEmploymentCorrectDateTheory(DateTime doe)
        {
            _sut.SetStatusTime(doe);
            Assert.Equal(doe, _sut.GetStatusTime());
        }

        [Theory]
        [MemberData(nameof(DateInFutureData))]
        public void SetDateOfEmploymentDateInFutureTheory(DateTime doe)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetStatusTime(doe));
        }

        public static IEnumerable<object[]> DateData()
        {
            yield return new object[] { new DateTime(2020, 10, 1) };
            yield return new object[] { new DateTime(2020, 10, 1, 22, 0, 0) };
        }

        public static IEnumerable<object[]> DateInFutureData()
        {
            yield return new object[] { DateTime.Today.AddYears(1) };
            yield return new object[] { DateTime.Today.AddDays(2) };
            yield return new object[] { DateTime.Today.AddMonths(1) };
            yield return new object[] { DateTime.Now.AddHours(1) };
            yield return new object[] { DateTime.Now.AddMinutes(5) };
            yield return new object[] { DateTime.Now.AddSeconds(1) };
        }
    }
}
