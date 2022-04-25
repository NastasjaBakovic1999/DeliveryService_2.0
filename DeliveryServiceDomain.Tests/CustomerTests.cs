using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class CustomerTests
    {
        private readonly Customer _sut;
        public CustomerTests()
        {
            _sut = new Customer();
        }

        [Theory]
        [InlineData("Ive Lole Ribara 5")]
        [InlineData("Mija Kovacevica 7b")]
        [InlineData("Vojislava Ilica 20")]
        public void SetAddressCorrectAddressTheory(string address)
        {
            _sut.SetAddres(address);
            Assert.Equal(address, _sut.GetAddress());
        }

        [Fact]
        public void SetAddressNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetAddres(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetAddressEmptyStringTheory(string address)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAddres(address));
        }

        [Theory]
        [InlineData("11000")]
        [InlineData("31330")]
        [InlineData("11061")]
        public void SetPostalCodeTheory(string code)
        {
            _sut.SetPostalCode(code);
            Assert.Equal(code, _sut.GetPostalCode());
        }

        [Fact]
        public void SetPostalCodeNullFact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetPostalCode(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetPostalCodeEmptyStringTheory(string code)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetAddres(code));
        }
    }
}
