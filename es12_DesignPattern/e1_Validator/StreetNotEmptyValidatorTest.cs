using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class StreetNotEmptyValidatorTest
    {
        [TestMethod]
        public void StreetEmpty()
        {
            var val = new StreetNotEmptyValidator();
            var errors = val.Validate(new Person { Address = new Address { Street = "" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Street not valid!", errors[0]);
        }

        [TestMethod]
        public void StreetNull()
        {
            var val = new StreetNotEmptyValidator();
            var errors = val.Validate(new Person { Address = new Address { Street = null } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Street not valid!", errors[0]);
        }

        [TestMethod]
        public void StreetNotEmpty()
        {
            var val = new StreetNotEmptyValidator();
            var errors = val.Validate(new Person { Address = new Address { Street = "new street" } });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
