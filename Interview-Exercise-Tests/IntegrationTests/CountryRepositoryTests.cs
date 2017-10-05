using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview_Exercise;
using NUnit.Framework;
using System.IO;

namespace Interview_Exercise_Tests.UnitTests
{
    [TestFixture]
    public class CountryRepositoryTests
    {
        //instance of repository.  It will use the CountryFile class to persist and retrieve
        CountryCodeRepository _rep = new CountryCodeRepository();

        public CountryRepositoryTests()
        {
            //not good to be here but we need an empty directory
            _rep.Clear();
        }


        [Test,Order(1)]
        public void AddTest()
        {
            Country country = new Country() { Code = "USA", Name = "The United States of America" };

            _rep.Add(country);
            var c = _rep.Get(country.Code);
               
        }
        [Test,Order(2)]
        public void UpdateTest()
        {
            _rep.Update(new Country() { Code = "USA", Name = "The United States" });
            var c = _rep.Get("USA");
            Assert.AreEqual("The United States", c.Name);
        }
        [Test, Order(3)]
        public void GetTest()
        {
            var c = _rep.Get("USA");
            Assert.AreEqual("USA", c.Code);
        }
        [Test,Order(4)]
        public void DeleteTest()
        {
            _rep.Delete("USA");
            try
            {
                _rep.Get("USA");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }

        [Test,Order(5)]
        public void ClearTest()
        {
            //add some items
            _rep.Add(new Country() { Code = "USA", Name = "The United States of America" });

            _rep.Clear();
            //TBD: need the directory and to see if there are any CSV files in it
            string path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Interview-Exercise");
            string[] files = Directory.GetFiles(path);
            if (files != null && files.Length > 0)
                throw new ApplicationException("Clear did not work.");
        }


        [Test,Order(6)]
        public void DeleteInvalidTest()
        {
            try
            {
                _rep.Delete("ZZZ");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test,Order(7)]
        public void GetInvalidTest()
        {
            try
            {
                _rep.Get("ZZZ");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test,Order(8)]
        public void UpdateInvalidTest()
        {
            try
            {
                _rep.Update(new Country() { Code = "ZZZ", Name = "Test"});
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test,Order(9)]
        public void TestMultiFileTest()
        {
            //add two with different files
            _rep.Add(new Country() { Code = "USA", Name = "The United States of America" });
            _rep.Add(new Country() { Code = "MEX", Name = "Mexico" });

            //get both
            var c = _rep.Get("USA");
            c = _rep.Get("MEX");
            _rep.Clear();
        }
    }
}
