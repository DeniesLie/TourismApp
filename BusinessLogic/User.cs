using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class User : Person
    {
        public User() { }
        public User(string name, string surname, string email, string phone, string password) : base(name, surname, email, phone)
        {
            Password = password;
        }
        /// <summary> Copying constructor </summary>
        /// <param name="user"> user to copy </param>
        public User(User user) : this(user.Name, user.Surname ,user.Email, user.Phone, user.Password)
        {

        }

        public int UserID { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// Check wether input password is corredt
        /// </summary>
        /// <param name="password"> input password </param>
        /// <returns></returns>
        public bool IsPasswordCorrect(string password)
        {
            if (password == Password)
                return true;
            else
                return false;
        }

        /// <summary>
        /// order tour by user
        /// </summary>
        /// <param name="tour"> tour to order instnace </param>
        /// <param name="numOfTourists"> entity of people </param>
        /// <param name="description"> user's additional preferences etc. </param>
        /// <param name="orders"> list of all orders(used with data container orders list) </param>
        public void OrderTour(Tour tour, int numOfTourists, string description, List<Order> orders)
        {
            Order newOrder = new Order();
            newOrder.OrderID = orders[orders.Count - 1].OrderID + 1;
            newOrder.Tour = tour;
            newOrder.OrderOwner = this;
            newOrder.NumOfTourists = numOfTourists;
            newOrder.Description = description;

            orders.Add(newOrder);
        }
    }
}
