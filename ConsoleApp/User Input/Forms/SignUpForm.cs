using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class SignUpForm : Form
    {
        public SignUpForm() : base("Sign Up Form", new string[6] { "name", "surname", "email", "phone", "passord", "repeat password" })
        {

        }
    }
}
