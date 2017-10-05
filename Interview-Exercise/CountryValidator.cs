using System;


namespace Interview_Exercise
{
    public class CountryValidator: ICountryValidator
    {
        public CountryValidator()
        {

        }
        // will throw exceptions for invalid items
       public void ValidateCountryCode(string countryCode)
        {
            //normalize the country code to upper case for all operations
            countryCode = countryCode.ToUpper();

            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentException("No country code supplied.", "countryCode");

            //length validation
            if (countryCode.Length != 3)
                throw new ArgumentException("Country Code must be 3 chracters long", "countryCode");

            ValidateUserStringRanges(countryCode);
        }
        /// <summary>
        /// User-assigned codes cannot be added to the repository.  User-assigned codes are defined by the following ranges: AAA to AAZ, QMA to QZZ, XAA to XZZ, and ZZA to ZZZ
        /// </summary>
        /// <param name="countryCode"></param>
        void ValidateUserStringRanges(string countryCode)
        {
            //AAA to AAZ
            RangeCompare(countryCode, "AAA", "AAZ");
            //QMA to QZZ
            RangeCompare(countryCode, "QMA", "QZZ");
            //XAA to XZZ
            RangeCompare(countryCode, "XAA", "XZZ");
            //ZZA to ZZZ
            RangeCompare(countryCode, "ZZA", "ZZZ");
        }

        void RangeCompare(string countryCode,string min, string max)
        {
            if ((string.Compare(countryCode, min) == 1 || string.Compare(countryCode, min) == 0)
                && (string.Compare(countryCode, max) == -1 || string.Compare(countryCode, max) == 0))
                throw new ArgumentException("Invalid country code", "countryCode");
        }

    }
}
