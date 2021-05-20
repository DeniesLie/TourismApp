using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Theme : ITourFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Theme() { }
        public Theme(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        // <summary> Copying constructor </summary>
        /// <param name="theme"> theme to copy </param>
        public Theme(Theme theme)
        {

            Name = theme?.Name;
            Description = theme?.Description;
        }

        public override bool Equals(object obj)
        {
            return obj is Theme theme &&
                   Name == theme.Name &&
                   Description == theme.Description;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description);
        }
        public bool IsTourMatches(Tour tour)
        {
            if (this.Equals(tour.TourTheme))
                return true;
            else
                return false;
        }
    }
}
