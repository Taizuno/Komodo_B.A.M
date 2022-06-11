using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Developer
    {
        public Developer(){}
        public Developer(string firstName, string lastName, bool pluralsight, bool pluralsightLiscense)
        {
            FirstName = firstName;
            LastName = lastName;
            Pluralsight = pluralsight;
            PluralsightLicense = pluralsightLicense;
        }
        public int ID { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}

        public bool Pluralsight { get; set;}

        public bool PluralsightLicense{get; set;}
    }