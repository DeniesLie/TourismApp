using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    abstract class Responce
    {
        protected string _title;
        protected Options _opts;

        public abstract void Display();
    }
}
