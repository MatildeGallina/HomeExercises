using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_Validator
{
    [TestClass]
    public class AddressValidatorTest
    {
        [TestMethod]
        public void AddressValid()
        {
            var addNotNull = new AddressNotNullValidator();
            var strNotEmpty = new StreetNotEmptyValidator();
            var zipVal = new ZipValidValidator();

            var baseVal = new List<BaseValidator>()
            {
                addNotNull, strNotEmpty, zipVal,
            };

            var val = new AddresValidator(baseVal);
            var errors = val.Validate(new Person
                                        {
                                           Address = new Address
                                           {
                                               Street = "via Roma, 5",
                                               ZIP = "33100"
                                           }
                                        });

            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void AddressNotNullValidatorErrorListNotEmpty()
        {
            var addNotNull = new AddressNotNullValidator();
            var strNotEmpty = new StreetNotEmptyValidator();
            var zipVal = new ZipValidValidator();

            var baseVal = new List<BaseValidator>()
            {
                addNotNull, strNotEmpty, zipVal,
            };

            var val = new AddresValidator(baseVal);
            var errors = val.Validate(new Person
                                            {
                                                Address = new Address
                                                {
                                                    Street = null,
                                                    ZIP = "33100"
                                                }
                                            });

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void StreetNotEmptyValidatorErrorListNotEmpty()
        {
            var addNotNull = new AddressNotNullValidator();
            var strNotEmpty = new StreetNotEmptyValidator();
            var zipVal = new ZipValidValidator();

            var baseVal = new List<BaseValidator>()
            {
                addNotNull, strNotEmpty, zipVal,
            };

            var val = new AddresValidator(baseVal);
            var errors = val.Validate(new Person
                                            {
                                                Address = new Address
                                                {
                                                    Street = "",
                                                    ZIP = "33100"
                                                }
                                            });

            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void ZIPValidValidatorErrorListNotEmpty()
        {
            var addNotNull = new AddressNotNullValidator();
            var strNotEmpty = new StreetNotEmptyValidator();
            var zipVal = new ZipValidValidator();

            var baseVal = new List<BaseValidator>()
            {
                addNotNull, strNotEmpty, zipVal,
            };

            var val = new AddresValidator(baseVal);
            var errors = val.Validate(new Person
            {
                Address = new Address
                {
                    Street = "via Roma, 5",
                    ZIP = "33j0"
                }
            });

            Assert.AreEqual(1, errors.Count);
        }
    }
}
