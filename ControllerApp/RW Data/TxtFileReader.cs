using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using System.IO;

namespace ControllerApp
{
    class TxtFileReader : IReadData
    {
        Controller controller;

        public TxtFileReader(Controller curentController)
        {
            controller = curentController;
        }

        public void ReadInstances<T>(string path, ref List<T> listObj) where T : new()
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                InstanceCreator instanceCreator = new InstanceCreator(curentController: controller);

                string line; 
                while( (line = sr.ReadLine()) != null)
                {
                    instanceCreator.Str = line;
                    object instance = new T();
                    instanceCreator.Init(ref instance);

                    if (instance is T resultInstance)
                        listObj.Add(resultInstance);
                }
            }
        }
    }
}
