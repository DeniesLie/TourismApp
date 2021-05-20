using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{

    public class Country : ITourFilter
    {
        public Country() { }

        /// <param name="name"> Name of country </param>
        /// <param name="description"> Desciption about a country (what types of tourism, when is the best season for vising a country) </param>
        public Country(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        /// <summary> Copying constructor </summary>
        /// <param name="country"> country to copy </param>
        public Country(Country country)
        {
            Name = country?.Name;
            Description = country?.Description;
        }

        /// <value> Name of country </value>
        public string Name { get; set; }
        /// <value> Desciption about a country (what types of tourism, when is the best season for vising a country)</value>
        public string Description { get; set; }
        
        /// <param name="obj"> country to compare</param>
        /// <returns> true if same country, false if not</returns>
        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Name == country.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        /// <summary>
        /// Implementing of method from ITourFilter interface
        /// check if tour is held in this country
        /// </summary>
        /// <param name="tour"> tour to check </param>
        /// <returns> true if if tour is held in this country, false if not </returns>
        public bool IsTourMatches (Tour tour)
        {
            if (this.Equals(tour.CountryOfArrival))
                return true;
            else
                return false;
        }
    }
}
