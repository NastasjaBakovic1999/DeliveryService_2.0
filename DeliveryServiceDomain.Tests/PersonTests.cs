using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceDomain.Tests
{
    public class PersonTests
    {
        private readonly Person _sut;
        public PersonTests()
        {
            _sut = new Person();
        }

        [Theory]
        [InlineData("Marko")]
        [InlineData("Ana Marija")]
        [InlineData("Ana")]
        public void SetFirstName_Theory(string name)
        {
            _sut.SetFirstName(name);
            Assert.Equal(name, _sut.GetFirstName());
        }

        [Fact]
        public void SetFirstName_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetFirstName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetFirstName_EmptyString_Theory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetFirstName(name));
        }

        [Theory]
        [InlineData("Mihajlovic")]
        [InlineData("Petrovic-Simic")]
        [InlineData("Ilic")]
        public void SetLastName_Theory(string name)
        {
            _sut.SetLastName(name);
            Assert.Equal(name, _sut.GetLastName());
        }

        [Fact]
        public void SetLastName_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SetLastName(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("        ")]
        public void SetLastName_EmptyString_Theory(string name)
        {
            Assert.Throws<ArgumentException>(() => _sut.SetLastName(name));
        }
    }
}
