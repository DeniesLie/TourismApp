using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;

namespace ControllerApp
{
    interface IReadData
    {
        void ReadInstances<T>(string path, ref List<T> listObj) where T : new(); 
    }
}
