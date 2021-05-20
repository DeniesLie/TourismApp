using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Path path = new Path();
            Options opts = new Options("list", "view tours");
            Responce responce;
            RequestHandler requestHandler = new RequestHandler();

            while (true)
            {
                // ask user input
                try
                {
                    responce = requestHandler.GetRespone(ref path, ref opts);
                    responce.Display();

                    int user_responce;
                    AskUser.AskNUmber("Choose option", out user_responce);

                    // go back case
                    if (user_responce == 0)
                        path.Back();

                    // shut down case
                    if(user_responce == -1)
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    try
                    {
                        if(user_responce != 0)
                            path.Add(opts[user_responce]);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new WrongInputException("enter number of any option");
                    }
                }
                catch (WrongInputException exc)
                {
                    Console.WriteLine($"Input is not correct: {exc.Message}");
                }
                catch (AccessDeniedException exc)
                {
                    Console.WriteLine($"Access denied: {exc.Message}");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Input is not correct Enter fields with correct values");
                }
            }
        }

    }
}
