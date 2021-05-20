using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ControllerApp;
using BusinessLogic;

namespace ConsoleApp
{
    public class WrongInputException : Exception
    {
        public WrongInputException(string message)
            : base(message) { }
    }
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message) : base(message)
        {
        }
    }

    class RequestHandler
    {
        IUserAccess userAccess = new Controller();

        string pageTitle = null;
        Content pageContent = null;

        object countyThemelist;
        object chosedCountryTheme;
        object tourList;
        object tour;
        object preferences;

        private void GenerateMenu(ref Options opts)
        {
            pageTitle = "Menu";
            string menuText = "This programm let's you search for tours and 'order' tickets on tour you \n" +
                              "chose. You can find interseting for you tours by pointing on prefereable \n" +
                              "countries or themes. Besides this you can watch available countries or \n " +
                              "themes.";

            pageContent = new Content(menuText);
            opts = new Options("list", "view tours");
        }
        private void LogIn()
        {
            if (userAccess.CurentUser == null)
            {
                Form loginForm = new LogInForm();
                loginForm.Display();
                bool success = userAccess.TryAuthorizeUser(loginForm.FieldValues);
                if (success)
                    Console.WriteLine("Successfully logged-in!");
                else
                    throw new AccessDeniedException("Password or email is not correct");
            }
        }
        private void FillPreferences()
        {
            Form preferencesForm = new PreferencesForm();
            preferencesForm.Display();
            preferences = userAccess.CreatePreference(preferencesForm.ValuesStr);
        }
        private void GenerateViewList(Path path, ref Options opts, ref object list)
        {
            string option = path[2] == "countries" ? "country" : "theme";

            pageTitle = $"available {path[2]}";

            if (path[2] == "countries")
                list = userAccess.Countries;
            else
                list = userAccess.Themes;

            pageContent = new Content(list);
            opts = new Options($"Options(1.View info about specific {option})",
                                    new string[1] { "view info" });
        }
        
        private void GenerateViewInfo(ref Options opts,Path path, in object list, ref object chosedItem)
        {
            string option = path[2] == "countries" ? "country" : "theme";
            pageTitle = $"Info about {option}";
            int number;
            AskUser.AskNUmber($"Enter number of {option}", out number);
            // form content
            IList listOfObj = list as IList;
            chosedItem = listOfObj[number - 1];
            pageContent = new Content(chosedItem);
            //
            opts = new Options($"1.View related tours", new string[1] { "view tours" });
        }

        private void GenerateTourList(ref Options opts, in object tourFilter, ref object tourList)
        {
            pageTitle = "Related tours";

            tourList = userAccess.FindTours(tourFilter);
            
            if (tourList == null)
            {
                pageContent = new Content("No tours found ;(");
                opts = new Options();
            }

            else
            {
                pageContent = new Content(tourList);
                opts = new Options("1.View a tour", new string[1] { "view tour" });
            }
                

        }

        private void GenerateTourView(ref Options opts, in object tourList, ref object tour)
        {
            int tourNumber;
            AskUser.AskNUmber($"Enter number of tour", out tourNumber);
            // form content
            IList tours = tourList as IList;
            tour = tours[tourNumber - 1];
            pageContent = new Content(tour);
            opts = new Options("1.Order tour", new string[1] { "order" });
        }

        private void OrderTour(ref Options opts, object tour)
        {
            Form orderForm = new OrderForm();
            orderForm.Display();
            userAccess.OrderTour(tour, orderForm.FieldValues);
            Console.WriteLine("Order passed succesfully!");
            GenerateMenu(ref opts);
        }

        public Responce GetRespone(ref Path path, ref Options opts)
        {
            // SHOW MAIN MENU
            if (path[1] == null)
            {
                GenerateMenu(ref opts);
                LogIn();
            }
            

            switch (path[1])
            {
                // VIEW LIST;
                case "list":
                    // ASK USER TO CHOSE WHAT TO LIST
                    if (path[1] == path[-1])
                    {
                        opts = new Options("List by", new string[2] { "countries", "themes" });
                        pageContent = new Content();
                        pageTitle = "Choose countries or themes to continue";
                    }

                    if (path[2] == null) break;

                    // SHOW COUNTRIES LIST OR THEMES LIST
                    if (path[2] == path[-1])
                        GenerateViewList(path, ref opts, ref countyThemelist);
                    if (path[3] == null) break;

                    // VIEW INFO ABOUT SPECIFIC COUNTRY OR THEME
                    if (path[3] == "view info")
                    {
                        if (path[3] == path[-1]) // 3-rd element in path is last
                            GenerateViewInfo(ref opts, path, in countyThemelist, ref chosedCountryTheme);
                        if (path[4] == null) break;

                        // VIEW RELATED TOURS
                        if (path[4] == "view tours")
                        {
                            if (path[4] == path[-1])
                                GenerateTourList(ref opts, in chosedCountryTheme, ref tourList);
                            if (path[5] == null) break;

                            // VIEW SPECIFIC TOUR
                            if(path[5] == "view tour")
                            {
                                if (path[5] == path[-1])
                                    GenerateTourView(ref opts, in tourList, ref tour);
                                if (path[6] == null) break;

                                if (path[6] == "order")
                                {
                                    OrderTour(ref opts, tour);
                                    path = new Path();
                                }
                                    
                            }
                        }
                    }
                    break;

                
                case "view tours":
                    if (path[1] == path[-1] && preferences == null)
                        FillPreferences();
                    // ASK USER TO FILL PREFERENCES

                    // GENERATE TOUR LIST
                    GenerateTourList(ref opts, preferences, ref tourList);
                    // VIEW TOUR
                    if (path[2] == "view tour")
                    {
                        if (path[2] == path[-1])
                            GenerateTourView(ref opts, in tourList, ref tour);
                        if (path[3] == null) break;

                        if (path[3] == "order")
                        {
                            OrderTour(ref opts, tour);
                            path = new Path();
                        }
                          
                    }
                    break;

            }

            return new Page(pageTitle, pageContent, opts);
        }
    }
}
