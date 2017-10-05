using System;
namespace Interview_Exercise
{
    /// <summary>
    /// Main data repository class
    /// </summary>
    public class CountryCodeRepository : ICountryRepository
    {
        CountryFile _file = new CountryFile();
        //Country Code validator
        ICountryValidator _codeValidator;
        //user default validator
        public CountryCodeRepository()
        {
            _codeValidator = new CountryValidator();
        }
        //use custom validator
        public CountryCodeRepository(ICountryValidator validator)
        {
            _codeValidator = validator;
        }


        public void Add(Country country)
        {
            _codeValidator.ValidateCountryCode(country.Code);
            _file.Add(country);
        }
        public void Update(Country country)
        {
            _codeValidator.ValidateCountryCode(country.Code);
            _file.Update(country);
        }
        public void Delete(string countryCode)
        {
            _file.Delete(countryCode);
        }
        public Country Get(string countryCode)
        {
            return _file.Get(countryCode);
        }
        public void Clear()
        {
            _file.Clear();
        }

    }
}
