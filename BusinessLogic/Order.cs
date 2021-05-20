using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Order
    {
        Tour _tour;
        User _orderOwner;

        public Order() { }
        public Order(int orderID, Tour tour, User orderOwner, string description, int numOfTourists)
        {
            OrderID = orderID;
            Tour = tour;
            OrderOwner = orderOwner;
            Description = description;
            NumOfTourists = numOfTourists;
        }

        /// <summary> Copying constructor </summary>
        /// <param name="order"> order to copy </param>
        public Order(Order order)
        {
            OrderID = order.OrderID;
            Tour = order.Tour;
            OrderOwner = order.OrderOwner;
            Description = order.Description;
            NumOfTourists = order.NumOfTourists;
        }
        
        ///<value>ID of order</value>
        public int OrderID { get; set; }
        
        ///<value> tour that is ordered </value>
        public Tour Tour
        {
            get { return new Tour(_tour); }
            set
            {
                _tour = new Tour(value);
            }
        }
        
        /// <value> user who made order </value>
        public User OrderOwner
        {
            get { return new User(_orderOwner); }
            set
            {
                _orderOwner = new User(value);
            }
        }
        
        /// <value> description of tour </value>
        public string Description { get; set; }
        
        /// <value> entity of tourists pointed in order </value>
        public int NumOfTourists { get; set; }
        
        /// <value> total price of order (number of tourist * tour's price per person ) </value>
        public float TotalPrice 
        {
            get
            {
                return Tour.PricePerPerson * NumOfTourists;
            }
        }

    }
}
