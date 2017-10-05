using System;
namespace Interview_Exercise
{
    /// <summary>
    /// Main data repository class
    /// </summary>
    public class CountryCodeRepository : ICountryRepository
    {
        ICountryFile _file = null;
        //Country Code validator
        ICountryValidator _codeValidator;
        //user default validator
        public CountryCodeRepository()
        {
            _codeValidator = new CountryValidator();
            _file = new CountryFile();
        }
        //use custom validator and file handler... for testing
        public CountryCodeRepository(ICountryValidator validator,ICountryFile file)
        {
            _codeValidator = validator;
            _file = file;
        }

        /// <summary>
        /// Adds a country if it is valid
        /// </summary>
        /// <param name="country"></param>
        public void Add(Country country)
        {
            _codeValidator.ValidateCountryCode(country.Code);
            if (string.IsNullOrEmpty(country.Name))
            {
                throw new ArgumentException("Country name is required");
            }
            _file.Add(country);
        }

        /// <summary>
        /// Updates the country name if one exists for the code
        /// </summary>
        /// <param name="country"></param>
        public void Update(Country country)
        {
            _codeValidator.ValidateCountryCode(country.Code);
            _file.Update(country);
        }

        /// <summary>
        /// Deletes a country
        /// </summary>
        /// <param name="countryCode"></param>
        public void Delete(string countryCode)
        {
            _file.Delete(countryCode);
        }

        /// <summary>
        /// Retrieves a country based on the code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public Country Get(string countryCode)
        {
            return _file.Get(countryCode);
        }


        /// <summary>
        /// Clears the repository on disk
        /// </summary>
        public void Clear()
        {
            _file.Clear();
        }

    }
}
