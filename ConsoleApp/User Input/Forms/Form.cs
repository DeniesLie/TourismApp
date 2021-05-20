using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;

namespace ConsoleApp
{
    public class Form
    {
        protected string _title;
        protected string[] _fields;
        protected string[] _fieldsValues;

        public string[] FieldValues
        {
            get
            {
                return _fieldsValues;
            }
        }
        public string ValuesStr
        {
            get
            {
                string result = "";
                foreach (string field in _fieldsValues)
                {
                    result += field + "; ";
                }
                return result;
            }
        }

        public Form(string title, string[] fields)
        {
            _title = title;
            _fields = new string[fields.Length];
            _fieldsValues = new string[fields.Length];
            fields.CopyTo(_fields, 0);
        }

        public void Display()
        {
            Console.WriteLine(_title);
            int i = 0;
            foreach (string field in _fields)
            {
                Console.Write($"\t {field}: ");
                string responce = Console.ReadLine();
                _fieldsValues[i] = responce;
                i++;
            }
        }
    }
}
