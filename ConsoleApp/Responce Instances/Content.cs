using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;

namespace ConsoleApp
{
    class Content : IDisplayableInline
    {
        public object ContentObj { get; set; }
       
        public Content (object contentObj)
        {
            ContentObj = contentObj;
        }
        public Content() 
        { 
        }
        void DisplayTour(bool inline = false)
        {
            Tour tour = ContentObj as Tour;
            if (!inline)
            {
                Console.WriteLine($"{tour.Name}: \n" +
                                  $"*Theme: {tour.TourTheme.Name} \n" +
                                  $"*{tour.Description} \n" +
                                  $"*Country of arrival: {tour.CountryOfArrival.Name} \n" +
                                  $"*Agency that provides tour: {tour.Agency.Name} \n" +
                                  $"*Duration: from {tour.StartTime} to {tour.EndTime} \n" +
                                  $"*Price per person: {tour.PricePerPerson}");                     
            }
            else
            {
                Console.WriteLine($"{tour.Name??"Unnamed tour"} | {tour.TourTheme?.Name ??"No theme"} | {tour.CountryOfArrival?.Name ?? "No country?"} | {tour.Agency?.Name ?? "No agency"}");
            }
        }
        void DisplayCountry(bool inline = false)
        {
            Country country = ContentObj as Country;
            if (!inline)
            {
                Console.WriteLine($"{country.Name} \n" +
                                  $"Description: {country.Description}");
            }
            else
            {
                Console.WriteLine(country.Name);
            }

        }
        void DisplayTheme(bool inline = false)
        {
            Theme theme = ContentObj as Theme;
            if (!inline)
            {
                Console.WriteLine($"{theme.Name} \n" +
                                  $"Description {theme.Description}");
            }
            else
            {
                Console.WriteLine(theme.Name);
            }
        }
        
        void DisplayList()
        {
            IList list = ContentObj as IList;
            Content listItem;
            int i = 0;
            foreach (object listObject in list)
            {
                listItem = new Content(listObject);
                Console.Write($"{++i}. ");
                listItem.Display(inline:true);
            }
        }

        public void Display(bool inline = false)
        {
            if (ContentObj != null)
            {
                if (ContentObj is string)
                    Console.WriteLine(ContentObj);
                if (ContentObj is IList)
                    DisplayList();
                if (ContentObj is Tour)
                    DisplayTour(inline);
                if (ContentObj is Country)
                    DisplayCountry(inline);
                if (ContentObj is Theme)
                    DisplayTheme(inline);
            }
        }
    }
}
