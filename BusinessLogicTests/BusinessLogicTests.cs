using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;

namespace BusinessLogicTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        Country testCountry = new Country("Test Country", "Some description");
        TourAgency testAgency = new TourAgency("test agency", "test@email.com", "test.com");
        Theme testTheme = new Theme("test theme", "description");

        [TestMethod]
        public void Country_Is_matching_tour()
        {
            // arrange
            Country copiedCountry = new Country(testCountry); 
            Tour testTour = new Tour("test tour", "descriprion", testAgency, copiedCountry, testTheme, DateTime.Now, DateTime.Now, 100f);

            bool expected = true;

            // act
            bool actual = testCountry.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Country_Is_not_matching_tour()
        {
            // arrange
            Country anotherCountry = new Country("another country", "description");
            Tour testTour = new Tour("test tour", "descriprion", testAgency, anotherCountry, testTheme, DateTime.Now, DateTime.Now, 100f);

            bool expected = false;

            // act
            bool actual = testCountry.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Theme_Is_matching_tour()
        {
            // arrange
            Theme copiedTheme = new Theme(testTheme);
            Tour testTour = new Tour("test tour", "descriprion", testAgency, testCountry, copiedTheme, DateTime.Now, DateTime.Now, 100f);

            bool expected = true;

            // act
            bool actual = testTheme.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Theme_Is_not_matching_tour()
        {
            // arrange
            Theme anotherTheme = new Theme("another theme", "description");
            Tour testTour = new Tour("test tour", "descriprion", testAgency, testCountry, anotherTheme, DateTime.Now, DateTime.Now, 100f);

            bool expected = false;

            // act
            bool actual = testTheme.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Preferences_are_matching_tour()
        {
            // arrange
            Theme copiedTheme = new Theme(testTheme);
            Country copiedCountry = new Country(testCountry);

            Preferences preferences = new Preferences(copiedCountry, copiedTheme, new DateTime(2021, 05, 15), new DateTime(2021, 06, 1), 50, 100);
            
            Tour testTour = new Tour("test tour", "descriprion", testAgency, testCountry, testTheme, new DateTime(2021, 5, 25), new DateTime(2021, 5, 30), 100f);

            bool expected = true;

            // act
            bool actual = preferences.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Preferences_are_not_matching_tour()
        {
            // let's change date and price in preferences to non-preferable

            // arrange
            Theme copiedTheme = new Theme(testTheme);
            Country copiedCountry = new Country(testCountry);

            Preferences preferences = new Preferences(copiedCountry, copiedTheme, new DateTime(2021, 06, 15), new DateTime(2021, 06, 30), 50, 90);

            Tour testTour = new Tour("test tour", "descriprion", testAgency, testCountry, testTheme, new DateTime(2021, 5, 25), new DateTime(2021, 5, 30), 100f);

            bool expected = false;

            // act
            bool actual = preferences.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Preferences_with_no_country_and_theme_are_matching_tour()
        {
            // arrange
            Theme emptyTheme = new Theme();
            Country emptyCountry = new Country();

            Preferences preferences = new Preferences(emptyCountry, emptyTheme, DateTime.Now, new DateTime(2021, 06, 1), 50, 100);

            Tour testTour = new Tour("test tour", "descriprion", testAgency, testCountry, testTheme, new DateTime(2021, 5, 25), new DateTime(2021, 5, 30), 100f);

            bool expected = true;

            // act
            bool actual = preferences.IsTourMatches(testTour);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
