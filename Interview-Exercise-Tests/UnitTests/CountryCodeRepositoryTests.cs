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
    /// This fixture just unit tests the repository via mock file handling (Empty mock just to make sure the repository has no bugs without the file handler)
    /// 
    /// </summary>
    [TestFixture]
    public class CountryCodeRepositoryTests
    {
        //repository var
        CountryCodeRepository rep = null;

        /// <summary>
        /// Constructor.  Creates a repository with real validation but no actual file handling
        /// </summary>
        public CountryCodeRepositoryTests()
        {
            rep = new CountryCodeRepository(new CountryValidator(), new CountryFileMock());
        }

        /// <summary>
        /// Test add
        /// </summary>
        public void AddTest()
        {
            rep.Add(new Country());
        }

        /// <summary>
        /// test delete
        /// </summary>
        public void DeleteTest()
        {
            rep.Delete("USA");
        }

        /// <summary>
        /// test update
        /// </summary>
        public void UpdateTest() {
            rep.Update(new Country() { Code = "USA",Name="The United States of America" });
        }
    }



}
