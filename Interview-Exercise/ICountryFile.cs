using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_Exercise
{
    /// <summary>
    /// Interface for main IO and persistence of country objects
    /// </summary>
    public interface ICountryFile
    {
        void Add(Country country);
        void Update(Country country);
        void Delete(string countryCode);
        Country Get(string countryCode);
        bool Exists(string countryCode);
        void Clear();
    }
}
