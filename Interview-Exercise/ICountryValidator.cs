using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Exercise
{
    /// <summary>
    /// Interface for country validator
    /// </summary>
    public interface ICountryValidator
    {
        void ValidateCountryCode(string countryCode);
    }
}
