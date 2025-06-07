using System;
using System.Runtime.InteropServices;

namespace BankBusinessLayer
{
    public class clsPersons
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public clsPersons()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";

            
        }
        public clsPersons(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }


    }
}
