using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Tour
    {
        TourAgency _agency;
        Country _country;
        Theme _theme;
        
        public Tour() { }
        public Tour(string name, string description, TourAgency agency, Country country, Theme tourTheme, DateTime startTime, DateTime endTime, float pricePerPerson)
        {
            Name = name;
            Description = description;
            Agency = agency;
            CountryOfArrival = country;
            TourTheme = tourTheme;
            PricePerPerson = pricePerPerson;
        }

        /// <summary> Copying constructor </summary>
        /// <param name="tour"> tour to copy </param>
        public Tour (Tour tour) : this (tour.Name, tour.Description, tour.Agency, tour.CountryOfArrival, tour.TourTheme, tour.StartTime, tour.EndTime, tour.PricePerPerson)
        {
        }

        public int TourID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TourAgency Agency
        {
            get { return new TourAgency(_agency); }
            set
            {
                _agency = new TourAgency(value);
            }
        }
        public Country CountryOfArrival
        {
            get { return new Country(_country); }
            set
            {
                _country = new Country(value);
            }
        }
        public Theme TourTheme
        {
            get { return new Theme(_theme); }
            set
            {
                _theme = new Theme(value);
            }
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float PricePerPerson { get; set; }
    }
}