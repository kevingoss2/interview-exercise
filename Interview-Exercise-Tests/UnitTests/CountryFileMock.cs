using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Interview_Exercise
{
    /// <summary>
    /// Manages the CSV files for countries
    /// </summary>
    public class CountryFileMock : ICountryFile
    {
        /// <summary>
        /// Constructor.  Sets the file path for all files
        /// </summary>
        public CountryFileMock()
        {

        }

        /// <summary>
        /// Adds a country to the appropriate file if it doesn't already exist.
        /// </summary>
        /// <param name="country"></param>
        public void Add(Country country)
        {

        }

        /// <summary>
        /// Deletes a country if it exists.  Throws exception if not.
        /// </summary>
        /// <param name="countryCode"></param>
        public void Delete(string countryCode)
        {


        }

        public void Clear()
        {

        }

        /// <summary>
        /// Determines if a country exists for the given countryCode
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public bool Exists(string countryCode)
        {
            return true;
        }

        /// <summary>
        /// Returns a country for a country code, throws exception if it doesn't exist.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public Country Get(string countryCode)
        {
            return new Country();
        }

        /// Updates a country for a country code, throws exception if it doesn't exist.
        public void Update(Country country)
        {

        }

        //reads a CSV file and returns the objects
        List<Country> GetFileCountries(string fileName)
        {
            return new List<Country>();
        }

        /// <summary>
        /// Saves a list of countries to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="countries"></param>
        void SaveFileCountries(string fileName, List<Country> countries)
        {

        }
    }
}
