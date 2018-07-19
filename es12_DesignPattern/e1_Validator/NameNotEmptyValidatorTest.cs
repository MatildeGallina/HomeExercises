using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class NameNotEmptyValidatorTest
    {
        [TestMethod]
        public void NameNotNull()
        {
            var validator = new NameNotEmptyValidator();
            var errors = validator.Validate(new Person { Name = null });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Name not valid!", errors[0]);
        }

        [TestMethod]
        public void NameNotEmpty()
        {
            var validator = new NameNotEmptyValidator();
            var errors = validator.Validate(new Person { Name = "" });
            
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Name not valid!", errors[0]);
        }

        [TestMethod]
        public void NameNotBlanks()
        {
            var validator = new NameNotEmptyValidator();
            var errors = validator.Validate(new Person { Name = "    " });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Name not valid!", errors[0]);
        }

        [TestMethod]
        public void NameValid()
        {
            var validator = new NameNotEmptyValidator();
            var errors = validator.Validate(new Person { Name = "Vighi" });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
