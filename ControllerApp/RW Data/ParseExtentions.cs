using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerApp
{
    public static class ParseExtentions
    {
        public static bool TryParse(string str, out List<int> intList)
        {
            List<int> result = new List<int>();
            int begin = 0;
            int digit;
            bool success;

            if (str == "[]")
            {
                intList = new List<int>();
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '[') {
                    begin += 1;
                    continue; 
                }
                if (str[i] == ',' || str[i] == ']') {
                    success = Int32.TryParse(str[begin..i], out digit);
                    if (success) {
                        result.Add(digit);
                        begin = i + 2;
                    }
                    else {
                        intList = null;
                        return false;
                    }
                }
            }
            intList = result;
            return true;
            
        }
    }
}
