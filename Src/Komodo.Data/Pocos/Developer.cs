using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Developer
    {
        public Developer(){}
        public Developer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Developer(bool hasPluralAccess)
        {
        if(hasPluralAccess == true)
        {
            System.Console.WriteLine("Access granted.");
        }
        else
        {
            System.Console.WriteLine("Access denied.");
        }
        }

        public int ID { get; set }
        public string FirstName { get; set }
        public string LastName { get; set }
    }