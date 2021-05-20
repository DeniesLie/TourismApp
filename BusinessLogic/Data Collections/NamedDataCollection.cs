using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    class NamedDataCollection 
    {
        protected List<INameCollectable> list = new List<INameCollectable>();
        public NamedDataCollection()
        {

        }
        public NamedDataCollection(List<INameCollectable> aList)
        {
            list = new List<INameCollectable>(aList);
        }
        public NamedDataCollection(List<Country> countryList)
        {
            foreach(Country country in countryList)
            {
                list.Add(country);
            }
        }
        public NamedDataCollection(List<Theme> themeList)
        {
            foreach (Theme theme in themeList)
            {
                list.Add(theme);
            }
        }

        public INameCollectable FindByName(string name)
        {
            foreach(INameCollectable obj in list)
            {
                if (obj.Name == name)
                    return obj;
            }
            return null;
        }
    }

}
