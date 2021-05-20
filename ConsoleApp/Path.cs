using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Path
    {
        List<String> _path = new List<string>();

        public Path()
        {
            _path.Add("menu");
        }

        public Path(params string[] path) : this() //
        {
            foreach (string word in path)
            {
                _path.Add(word);
            }
        }

        public void Add(string step)
        {
            _path.Add(step);
        }
        public void Back()
        {
            if (_path.Count > 1)
                _path.RemoveAt(_path.Count - 1);
        }

        public string this[int index]
        {
            get
            {
                if (index == -1)
                    return _path[_path.Count - 1];
                else if (index >= _path.Count)
                    return null;
                else
                    return _path[index];
            }
            set
            {
                if (index == -1)
                   _path[_path.Count - 1] = value;
                else
                   _path[index] = value;
            }
        }
    }
}
