using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessLogic;

namespace ControllerApp
{
    public class DataContainer
    {
        public List<User> users = new List<User>();
        public List<Order> orders = new List<Order>();
        public List<Tour> tours = new List<Tour>();
        public List<TourAgency> tourAgencies = new List<TourAgency>();
        public List<Country> countries = new List<Country>();
        public List<Theme> themes = new List<Theme>();

        public Country GetCountryByName(string name)
        {
            return countries.Where(country => country.Name == name).FirstOrDefault();
        }
        public Theme GetThemeByName(string name)
        {
            return themes.Where(theme => theme.Name == name).FirstOrDefault();
        }
        public Order GetOrderByID(int id)
        {
            return orders.Where(order => order.OrderID == id).FirstOrDefault();
        }
        public Tour GetTourByID(int id)
        {
            return tours.Where(tour => tour.TourID == id).FirstOrDefault();
        }
        public User GetUserByID(int id){
            return users.Where(user => user.UserID == id).FirstOrDefault();
        }
        public TourAgency GetAgencyByID(int id)
        {
            return tourAgencies.Where(agency => agency.AgencyID == id).FirstOrDefault();
        }
        public User GetUserByEmail(string email)
        {
            return users.Where(user => user.Email == email).FirstOrDefault();
        }
    }
}
