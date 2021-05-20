using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DataCollection
    {
        protected List<object> list;
        public DataCollection(List<object> aList)
        {
            list = new List<object>(aList);
        }
    }
}
