using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    class NamedIdentifiedDataCollection : NamedDataCollection
    {
        public NamedIdentifiedDataCollection(List<INameIdCollectable> aList) : base()
        {
            List<INameCollectable> baseList = new List<INameCollectable>();
            foreach(INameIdCollectable deriveObj in aList)
            {
                list.Add(deriveObj);
            }
        }

        public NamedIdentifiedDataCollection(List<User> userList)
        {
            foreach (User user in userList)
            {
                list.Add(user);
            }
        }
        public NamedIdentifiedDataCollection(List<Order> orderList)
        {
            foreach (Order order in orderList)
            {
                list.Add(order);
            }
        }
        public NamedIdentifiedDataCollection(List<Tour> tourList)
        {
            foreach (Tour tour in tourList)
            {
                list.Add(tour);
            }
        }
        public NamedIdentifiedDataCollection(List<TourAgency> tourAgencyList)
        {
            foreach (TourAgency tourAgency in tourAgencyList)
            {
                list.Add(tourAgency);
            }
        }

        public INameIdCollectable FindById(int id)
        {
            foreach(INameIdCollectable obj in list)
            {
                if(obj.ID == id)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
