using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e1_Validator
{
    [TestClass]
    public class IdValidValidatorTest
    {
        [TestMethod]
        public void Id0()
        {
            var validator = new IdValidValidator();
            var errors = validator.Validate(new Person { Id = 0 });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Id not valid!", errors[0]);
        }

        [TestMethod]
        public void Idminus1()
        {
            var validator = new IdValidValidator();
            var errors = validator.Validate(new Person { Id = -1 });

            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("Id not valid!", errors[0]);
        }

        [TestMethod]
        public void Id1()
        {
            var validator = new IdValidValidator();
            var errors = validator.Validate(new Person { Id = 1 });

            Assert.AreEqual(0, errors.Count);
        }
    }
}
