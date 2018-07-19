using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class AddressNotNullValidatorTest
    {
        [TestMethod]
        public void AddressNull()
        {
            var val = new AddressNotNullValidator();
            var errors = val.Validate(new Person { Address = null });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Address not valid", errors[0]);
        }

        [TestMethod]
        public void AddressNotNull()
        {
            var val = new AddressNotNullValidator();
            var errors = val.Validate(new Person { Address = new Address() });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
