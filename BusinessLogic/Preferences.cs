using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Preferences : ITourFilter
    {
        Country _countryOfArrival;
        Theme _theme;

        public Preferences() { }
        public Preferences(Country countryOfArrival, Theme theme, DateTime arrivalTimeFrom, DateTime arrivalTimeTo, float priceFrom, float priceTo)
        {
            _countryOfArrival = new Country(countryOfArrival);
            _theme = new Theme(theme);
            ArrivalTimeFrom = arrivalTimeFrom;
            ArrivalTimeTo = arrivalTimeTo;
            PriceFrom = priceFrom;
            PriceTo = priceTo;
        }

        /// <summary> Copying constructor </summary>
        /// <param name="preferences"> preferences to copy </param>
        public Preferences(Preferences preferences)
        {
            CountryOfTour = preferences.CountryOfTour;
            Theme = preferences.Theme;
        }
        
        /// <value> preferable country </value>
        public Country CountryOfTour
        {
            get
            {
                return new Country(_countryOfArrival);
            }
            set
            {
                _countryOfArrival = new Country(value);
            }
        }

        /// <value> preferable theme of tour </value>
        public Theme Theme
        {
            get
            {
                return new Theme(_theme);
            }
            set
            {
                _theme = new Theme(value);
            }
        }

        /// <value> minimum date that arranges user </value>
        public DateTime ArrivalTimeFrom { get; set; }
        /// <value> maximum date that arranges user </value>
        public DateTime ArrivalTimeTo { get; set; }

        /// <value> minimum price that arranges user </value>
        public float PriceFrom { get; set; }
        /// <value> maximum price that arranges user </value>
        public float PriceTo { get; set; }

        /// <summary>
        /// implemented from ITourFilter method
        /// checks if tour mathces preferences 
        /// </summary>
        /// <param name="tour"> tour to check </param>
        /// <returns> true if tour matches preferences </returns>
        public bool IsTourMatches(Tour tour)
        {
            bool countryCondition, themeCondition;

            countryCondition = CountryOfTour.Name == null ? true : CountryOfTour.Equals(tour.CountryOfArrival);
            themeCondition = Theme.Name == null ? true : Theme.Equals(tour.TourTheme);

            if (tour != null &&
                (countryCondition) &&
                (themeCondition) &&
                (ArrivalTimeTo >= tour.StartTime || ArrivalTimeFrom <= tour.EndTime) &&
                (PriceFrom <= tour.PricePerPerson && tour.PricePerPerson <= PriceTo))

                return true;
            else
                return false;
        }
    }
}
