using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class BirthInRangeValidatorTest
    {
        [TestMethod]
        public void BirthOlder()
        {
            var validator = new BirthInRangeValidator();
            var errors = validator.Validate(new Person { Birth = new DateTime(1899, 12, 31) });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Birth not valid!", errors[0]);
        }

        [TestMethod]
        public void BirthYounger()
        {
            var validator = new BirthInRangeValidator();
            var errors = validator.Validate(new Person { Birth = new DateTime(2018, 01, 01) });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Birth not valid!", errors[0]);
        }

        [TestMethod]
        public void BirthOlderValid()
        {
            var validator = new BirthInRangeValidator();
            var errors = validator.Validate(new Person { Birth = new DateTime(1900, 01, 01) });

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void BirthYougerValid()
        {
            var validator = new BirthInRangeValidator();
            var errors = validator.Validate(new Person { Birth = new DateTime(2017, 12, 31) });

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void BirthValid()
        {
            var validator = new BirthInRangeValidator();
            var errors = validator.Validate(new Person { Birth = new DateTime(2001, 09, 11) });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
