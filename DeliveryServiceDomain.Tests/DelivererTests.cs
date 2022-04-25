using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class DelivererTests
    {
        private readonly Deliverer _sut;
        public DelivererTests()
        {
            _sut = new Deliverer();
        }

        [Theory]
        [MemberData(nameof(DateOfEmploymentData))]
        public void SetDateOfEmploymentCorrectDateTheory(DateTime doe)
        {
            _sut.SetDateOfEmployment(doe);
            Assert.Equal(doe, _sut.GetDateOfEmployment());
        }

        [Theory]
        [MemberData(nameof(DateOfEmploymentInFutureData))]
        public void SetDateOfEmploymentDateInFutureTheory(DateTime doe)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.SetDateOfEmployment(doe));
        }

        public static IEnumerable<object[]> DateOfEmploymentData()
        {
            yield return new object[] { new DateTime(2020, 10, 1) };
            yield return new object[] { new DateTime(2020, 10, 1, 22,0,0) };
        }

        public static IEnumerable<object[]> DateOfEmploymentInFutureData()
        {
            yield return new object[] { DateTime.Today.AddYears(1)};
            yield return new object[] { DateTime.Today.AddDays(2)};
            yield return new object[] { DateTime.Today.AddMonths(1)};
            yield return new object[] { DateTime.Now.AddHours(1)};
            yield return new object[] { DateTime.Now.AddMinutes(5)};
            yield return new object[] { DateTime.Now.AddSeconds(1)};
        }
    }
}
