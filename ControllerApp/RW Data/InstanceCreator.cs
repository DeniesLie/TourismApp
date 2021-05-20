using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using ControllerApp;

namespace ControllerApp
{
    class InstanceCreator
    {
        public InstanceCreator(Controller curentController)
        {
            controller = curentController;
        }
        public InstanceCreator(string str, Controller curentController) : this(curentController)
        {
            Str = str;
            fields = CreateFields();
        }


        List<string> fields;
        Controller controller;
        string str;

        public string Str
        {
            get { return str; }
            set
            {
                str = value;
                fields = CreateFields();
            }
        }

        public void Init(ref object instance)
        {
            if (instance is Tour)
                instance = CreateTour();
            if (instance is Country)
                instance = CreateCountry();
            if (instance is Theme)
                instance = CreateTheme();
            if (instance is Order)
                instance = CreateOrder();
            if (instance is User)
                instance = CreateUser();
            if (instance is Preferences)
                instance = CreatePreferences();
            if (instance is TourAgency)
                instance = CreateAgency();
        }

        private List<string> CreateFields()
        {
            List<string> result = new List<string>();
            string fieldValue;
            int begin = 0;

            for (int i = 0; i < Str.Length; i++)
            {
                if (Str[i] == ';')
                {
                    fieldValue = Str[begin..i];
                    i++;
                    begin = i + 1;
                    result.Add(fieldValue);
                }
            }
            return result;
        }

        private TourAgency CreateAgency()
        {
            TourAgency agency = new TourAgency();
            agency.AgencyID = Convert.ToInt32(fields[0]);
            agency.Name = fields[1];
            agency.Email = fields[2];
            agency.WebPage = fields[3];
            return agency;
        }

        private User CreateUser()
        {
            User user = new User();
            user.UserID = Convert.ToInt32(fields[0]);
            user.Password = fields[1];
            user.Name = fields[2];
            user.Surname = fields[3];
            user.Email = fields[4];
            user.Phone = fields[5];
            
            return user;
        }
        private Tour CreateTour()
        {
            Tour tour = new Tour();
            tour.TourID = Convert.ToInt32(fields[0]);
            int agencyID = Convert.ToInt32(fields[1]);
            tour.Agency = controller.dataContainer.GetAgencyByID(agencyID);
            tour.Name = fields[2];
            tour.Description = fields[3];
            tour.CountryOfArrival = controller.dataContainer.GetCountryByName(fields[4]);
            tour.TourTheme = controller.dataContainer.GetThemeByName(fields[5]);
            tour.StartTime = Convert.ToDateTime(fields[6]);
            tour.EndTime = Convert.ToDateTime(fields[7]);
            tour.PricePerPerson = Convert.ToSingle(fields[8]);;
            return tour;
        }
        private Country CreateCountry()
        {
            Country country = new Country();
            country.Name = fields[0];
            country.Description = fields[1];
            return country;
        }
        private Theme CreateTheme()
        {
            Theme theme = new Theme();
            theme.Name = fields[0];
            theme.Description = fields[1];
            return theme;
        }
        private Preferences CreatePreferences()
        {
            Preferences preferences = new Preferences();

            if (fields[0] != "" && controller.dataContainer.GetCountryByName(fields[0]) == null ||
                fields[1] != "" && controller.dataContainer.GetThemeByName(fields[1]) == null)
                throw new KeyNotFoundException();

            preferences.CountryOfTour = fields[0] != "" ? controller.dataContainer.GetCountryByName(fields[0]) : null;
            preferences.Theme = fields[1] != "" ? controller.dataContainer.GetThemeByName(fields[1]) : null;
            preferences.ArrivalTimeFrom = fields[2] != "" ? Convert.ToDateTime(fields[2]) : DateTime.Now;
            preferences.ArrivalTimeTo = fields[3] != "" ? Convert.ToDateTime(fields[3]) : DateTime.Now.AddYears(5);
            preferences.PriceFrom = fields[4] != "" ? Convert.ToSingle(fields[4]) : 0;
            preferences.PriceTo = fields[5] != "" ? Convert.ToSingle(fields[5]) : 10000;
            return preferences;
        }
        private Order CreateOrder()
        {
            Order order = new Order();
            int tourID = Convert.ToInt32(fields[1]);
            int userID = Convert.ToInt32(fields[2]);

            order.Tour = controller.dataContainer.GetTourByID(tourID);
            order.OrderOwner = controller.dataContainer.GetUserByID(userID);

            order.Description = fields[3];
            order.NumOfTourists = Convert.ToInt32(fields[4]);
            return order;
        }

    }
}