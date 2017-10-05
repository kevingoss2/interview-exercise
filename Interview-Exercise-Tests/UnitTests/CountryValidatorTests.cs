using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview_Exercise;
using NUnit.Framework;

namespace Interview_Exercise_Tests.UnitTests
{
    /// <summary>
    /// Tests the CountryValidator class
    /// </summary>
    [TestFixture]
    public class CountryValidatorTests
    {

        /// <summary>
        /// Helper method to determine if a code is valid or not on the target test run
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        bool IsValidCode(string countryCode)
        {
            ICountryValidator validator = new CountryValidator();

            try
            {
                validator.ValidateCountryCode(countryCode);
            }
            catch(ArgumentException)
            {
                return false;
            }
            return true;
            
        }

        /// <summary>
        /// Test some in the invalid range
        /// </summary>
        [Test]
        public void InvalidUserRange()
        {
            if (IsValidCode("AAA"))
                Assert.Fail();
            if (IsValidCode("AAZ"))
                Assert.Fail();
            if (IsValidCode("QMA"))
                Assert.Fail();
            if (IsValidCode("QZZ"))
                Assert.Fail();
            if (IsValidCode("QMB"))
                Assert.Fail();
        }

        /// <summary>
        /// Test the valid case
        /// </summary>
        [Test]
        public void ValidCountryCode()
        {
            if (!IsValidCode("USA"))
                Assert.Pass();
        }

    }
}
