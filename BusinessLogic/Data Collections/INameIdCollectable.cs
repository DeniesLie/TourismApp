using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    interface INameIdCollectable : INameCollectable
    {
        int ID { get; set; }
    }
}
