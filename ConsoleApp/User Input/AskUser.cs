using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    static class AskUser
    {
        public static void AskNUmber(string message, out int number)
        {
            Console.Write($"{message} : ");
            string userInput = Console.ReadLine();
            bool success = Int32.TryParse(userInput, out number);
            if (!success)
                throw new WrongInputException("Input errror: enter whole number");
        }

        public static void AreYouSure(out bool value)
        {
            Console.WriteLine("Are you sure? y/n:");
            char responce;
            bool success = Char.TryParse(Console.ReadLine(), out responce);
            if (success)
            {
                if (responce == 'y' || responce == 'Y')
                    value = true;
                else if (responce == 'n' || responce == 'N')
                    value = false;
                else
                {
                    value = false;
                    throw new WrongInputException("enter y(yes) to confirm or n(no) to refuse");
                }
            }
            else
            {
                value = false;
                throw new WrongInputException("enter y(yes) to confirm or n(no) to refuse");
            }
        }
    }
}
