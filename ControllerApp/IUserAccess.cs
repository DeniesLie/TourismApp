using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;

namespace ControllerApp
{
    public interface IUserAccess
    {
        List<Country> Countries { get; set; }
        List<Theme> Themes { get; set; }
        User CurentUser { get; }
        List<Tour> FindTours(object filter);

        public object CreatePreference(string formStr);
        public bool TryAuthorizeUser(string[] formFields);
        public void OrderTour(object tour, string[] formFields);
    }
}
