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
    public class CountryFile : ICountryFile
    {
        /// <summary>
        /// holds the path where the CSV files exist. set in constructor
        /// </summary>
        string _path = null;
        
        
        /// <summary>
        /// Constructor.  Sets the file path for all files
        /// </summary>
        public CountryFile() {
            _path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"Interview-Exercise");
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        /// <summary>
        /// Adds a country to the appropriate file if it doesn't already exist.
        /// </summary>
        /// <param name="country"></param>
        public void Add(Country country)
        {
            string fileName = Path.Combine(_path, country.Code.Substring(0, 1) + ".csv");
            if (Exists(country.Code))
            {
                throw new ArgumentException("Country already exists");
            }
            List<Country> countries = GetFileCountries(fileName);
            countries.Add(country);
            countries.Sort();
            SaveFileCountries(fileName, countries);
        }

        /// <summary>
        /// Deletes a country if it exists.  Throws exception if not.
        /// </summary>
        /// <param name="countryCode"></param>
        public void Delete(string countryCode)
        {
            string fileName = Path.Combine(_path, countryCode.Substring(0, 1) + ".csv");
            if (!Exists(countryCode))
            {
                throw new ArgumentException("Country does not exist");
            }
            List<Country> countries = GetFileCountries(fileName);
            Country country = countries.FirstOrDefault(c => c.Code == countryCode);
            if (country == null)
            {
                throw new ArgumentException("Country does not exist");
            }
            countries.Remove(country);
            SaveFileCountries(fileName, countries);

        }

        public void Clear()
        {
            string[] files = Directory.GetFiles(_path, "*.csv");
            foreach (var f in files)
                File.Delete(f);
        }

        /// <summary>
        /// Determines if a country exists for the given countryCode
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public bool Exists(string countryCode)
        {
            string fileName = Path.Combine(_path, countryCode.Substring(0, 1) + ".csv");

            if(!File.Exists(fileName))
                return false;
            
            using(StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();
                while(line != null)
                {
                    string[] args = line.Split(new char[] { ',' });
                    if (args[0] == countryCode)
                        return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Returns a country for a country code, throws exception if it doesn't exist.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public Country Get(string countryCode)
        {
            string fileName = Path.Combine(_path, countryCode.Substring(0, 1) + ".csv");
            List<Country> countries = GetFileCountries(fileName);
            Country c = countries.FirstOrDefault(c2 => c2.Code == countryCode);
            if (c == null)
                throw new ArgumentException("Country does not exist");
            return c;
        }

        /// Updates a country for a country code, throws exception if it doesn't exist.
        public void Update(Country country)
        {
            string fileName = Path.Combine(_path, country.Code.Substring(0, 1) + ".csv");
            List<Country> countries = GetFileCountries(fileName);
            Country c = countries.FirstOrDefault(c2 => c2.Code == country.Code);
            if (c == null)
                throw new ArgumentException("Country does not exist");
            c.Name = country.Name;
            SaveFileCountries(fileName, countries);
        }

        //reads a CSV file and returns the objects
        List<Country> GetFileCountries(string fileName)
        {
            List<Country> ret = new List<Country>();
            if (!File.Exists(fileName))
                return ret;
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] args = line.Split(new char[] { ',' });
                    Country c = new Country() { Name = args[1], Code = args[0] };
                    ret.Add(c);
                    line = sr.ReadLine();      
                }
            }
            return ret;
        }

        /// <summary>
        /// Saves a list of countries to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="countries"></param>
        void SaveFileCountries(string fileName,List<Country> countries)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
            else
                File.Create(fileName).Dispose();
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                foreach(var c in countries)
                {
                    sw.WriteLine(string.Format("{0},{1}", c.Code, c.Name));
                }
            }
        }
    }
}
