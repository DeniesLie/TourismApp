using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class PreferencesForm : Form
    {
        public PreferencesForm() : base("Preferences Form", new string[6] { "Country of tour", "Theme", "Time of arrival from", "Time of arrival to", "price from", "price to" })
        {

        }
    }
}
