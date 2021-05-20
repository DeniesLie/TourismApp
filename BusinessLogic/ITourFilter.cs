using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    /// <summary>
    /// This interface is implemented by classes that can be represented as filters for tour selection
    /// </summary>
    public interface ITourFilter
    {

        /// <param name="tour"></param>
        /// <returns>true if class is matching tour </returns>
        bool IsTourMatches(Tour tour);
    }
}
