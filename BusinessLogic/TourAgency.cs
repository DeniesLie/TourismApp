using System;

namespace BusinessLogic
{
    public class TourAgency
    {
        public TourAgency() { }
        public TourAgency(string name, string email, string webpage)
        {
            Name = name;
            Email = email;
            WebPage = webpage;
        }

        /// <summary> Copying constructor </summary>
        /// <param name="tourAgency"> tour agency to copy </param>
        public TourAgency(TourAgency tourAgency)
        {
            AgencyID = tourAgency.AgencyID;
            Name = tourAgency.Name;
            Email = tourAgency.Email;
            WebPage = tourAgency.WebPage;
        }

        public int AgencyID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
    }
}
