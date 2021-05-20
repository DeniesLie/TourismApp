using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{


    class Options : IDisplayable
    {
        public List<string> _optionList = new List<string>();
        string Label;

        public Options(string label, string[] options)
        {
            Label = label;
            _optionList.Add("Go back");
            foreach (string option in options) { _optionList.Add(option); }
        }
        public Options(params string[] options) : this("Options", options)
        {
        }
        public Options() : this(new string[0])
        {

        }
        public Options(Options opt)
        {
            _optionList = new List<string>(opt._optionList);
        }

        public string this[int index]
        {
            get
            {
                return _optionList[index];
            }
        }

        public void Display()
        {
            Console.WriteLine("===============================================================================");
            Console.Write($"{Label??"Options"}: \n" +
                              "-1: Exit the program");
            for (int i = 0; i < _optionList.Count; i++)
            {
                Console.Write($" | {i}: {_optionList[i]}");
            }
        }
        

    }
}
