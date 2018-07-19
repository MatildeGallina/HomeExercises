using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class ZipValidValidatorTest
    {
        [TestMethod]
        public void ZipCannotBeNull()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = null } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipCannotBeEmpty()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipCannotBeBlack()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "   " } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipLengthLessThanFive()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "123" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipLengthMoreThanFive()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "123456" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipLengthFive()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "12345" } });

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ZipWithNotOnlyDigits()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "pippo" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipCannotHaveSymbols()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "?0100" } });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("ZIP not valid!", errors[0]);
        }

        [TestMethod]
        public void ZipWithOnlyDigits()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "45892" } });

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void ZipCanStartWithZero()
        {
            var val = new ZipValidValidator();
            var errors = val.Validate(new Person { Address = new Address { ZIP = "00100" } });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
