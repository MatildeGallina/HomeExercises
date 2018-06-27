using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace e1_ListUtility.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void empty_list_return_empty_not_negatives_list()
        {
            List<Item> items = new List<Item>();
            Utility u = new Utility();
            List<Item> notNegatives = u.Filter(items, Program.isNotNegative);

            Assert.AreEqual(0, notNegatives.Count);
        }

        [TestMethod]
        public void empty_list_return_empty_primes_list()
        {
            List<Item> items = new List<Item>();
            Utility u = new Utility();
            List<Item> primes = u.Filter(items, Program.isPrime);

            Assert.AreEqual(0, primes.Count);
        }

        [TestMethod]
        public void prime_filter()
        {
            Item i1 = new Item { Value = 2 };
            bool prime1 = Program.isPrime(i1);
            Assert.AreEqual(true, prime1);

            Item i2 = new Item { Value = 6 };
            bool prime2 = Program.isPrime(i2);
            Assert.AreEqual(false, prime2);
        }

        [TestMethod]
        public void negatives_prime_filter()
        {
            Item i1 = new Item { Value = -2 };
            bool prime1 = Program.isPrime(i1);
            Assert.AreEqual(false, prime1);

            Item i2 = new Item { Value = -6 };
            bool prime2 = Program.isPrime(i2);
            Assert.AreEqual(false, prime2);
        }

        [TestMethod]
        public void prime_filter_0_1()
        {
            Item i1 = new Item { Value = 0 };
            bool prime1 = Program.isPrime(i1);
            Assert.AreEqual(false, prime1);

            Item i2 = new Item { Value = 1 };
            bool prime2 = Program.isPrime(i2);
            Assert.AreEqual(false, prime2);
        }

        [TestMethod]
        public void not_negative_filter()
        {
            Item i1 = new Item { Value = 0 };
            bool notNegative1 = Program.isNotNegative(i1);
            Assert.AreEqual(true, notNegative1);

            Item i2 = new Item { Value = 1 };
            bool notNegative2 = Program.isNotNegative(i2);
            Assert.AreEqual(true, notNegative2);

            Item i3 = new Item { Value = -1 };
            bool notNegative3 = Program.isNotNegative(i3);
            Assert.AreEqual(false, notNegative3);
        }

        [TestMethod]
        public void Count_not_negative_list()
        {
            List<Item> items = new List<Item>()
            {
                new Item { Value = 5 },
                new Item { Value = -5 }
            };
            Utility u = new Utility();
            List<Item> notNegatives = u.Filter(items, Program.isNotNegative);

            Assert.AreEqual(1, notNegatives.Count);
        }

        [TestMethod]
        public void Count_primes_list()
        {
            List<Item> items = new List<Item>()
            {
                new Item { Value = 5 },
                new Item { Value = 4 }
            };
            Utility u = new Utility();
            List<Item> primes = u.Filter(items, Program.isPrime);

            Assert.AreEqual(1, primes.Count);
        }
    }
}
