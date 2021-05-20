using System;
using System.Collections.Generic;
using BusinessLogic;
using System.Linq;

namespace ControllerApp
{
    public class Controller : IUserAccess
    {
        public DataContainer dataContainer = new DataContainer();
        public User currentUser;
        InstanceCreator instanceCreator;

        public User CurentUser
        {
            get
            {
                return currentUser;
            }
        }
        public List<Country> Countries {
            get
            {
                return ( dataContainer.countries); 
            }
            set
            {
                dataContainer.countries = value;
            }
        }
        public List<Theme> Themes
        {
            get
            {
                return (dataContainer.themes);
            }
            set
            {
                dataContainer.themes = value;
            }
        }
        public List<User> Users
        {
            get
            {
                return (dataContainer.users);
            }
            set
            {
                dataContainer.users = value;
            }
        }
        public List<Order> Orders
        {
            get
            {
                return (dataContainer.orders);
            }
            set
            {
                dataContainer.orders = value;
            }
        }
        public List<TourAgency> TourAgencies
        {
            get
            {
                return (dataContainer.tourAgencies);
            }
            set
            {
                dataContainer.tourAgencies = value;
            }
        }
        public List<Tour> Tours
        {
            get
            {
                return (dataContainer.tours);
            }
            set
            {
                dataContainer.tours = value;
            }
        }

        public Controller()
        {
            instanceCreator = new InstanceCreator(curentController: this);
            IReadData fileReader = new TxtFileReader(curentController: this);      
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\Countries.txt", ref dataContainer.countries);
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\Themes.txt", ref dataContainer.themes);
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\TourAgencies.txt", ref dataContainer.tourAgencies);
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\Tours.txt", ref dataContainer.tours);
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\Users.txt", ref dataContainer.users);
            fileReader.ReadInstances(@"C:\Users\Lienko\source\repos\TourismApp\ControllerApp\Data\Orders.txt", ref dataContainer.orders);
        }

        public List<Tour> FindTours(object filter)
        {
            if (filter is ITourFilter tourFilter && filter != null)
            {
                List<Tour> result = new List<Tour>();
                foreach (Tour tour in dataContainer.tours)
                {
                    if (tourFilter.IsTourMatches(tour))
                        result.Add(tour);
                }
                return result;
            }
            else
                return null;
        }

        public object CreatePreference(string formStr)
        {
            instanceCreator.Str = formStr;
            object preferences = new Preferences();

            try
            {
                instanceCreator.Init(ref preferences);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            
            if (preferences is ITourFilter result)
                return result;
            else
                return null;
        }
        public bool TryAuthorizeUser(string[] formFields)
        {
            User user = dataContainer.GetUserByEmail(formFields[0]);
            
            if (user == null)
                return false;

            if (user.IsPasswordCorrect(formFields[1]))
            {
                currentUser = user;
                return true;
            }
            else
                return false;
        }
        public void OrderTour(object tour, string[] formFields)
        {
            Tour tourToOrder;
            if (tour is Tour tourObj) {
                tourToOrder = dataContainer.GetTourByID(tourObj.TourID);
                currentUser.OrderTour(tourToOrder, Convert.ToInt32(formFields[0]), formFields[1], dataContainer.orders);
                // write change to file
            }
            
        }
    }
}
