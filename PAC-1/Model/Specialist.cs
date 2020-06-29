using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    class Specialist
    {
        private string firstName = "Lucyna";
        private string lastName = "Kisiała-Majerczyk";
        public School school; //tutaj tez dalam School. Moglabym zrobic klase poradnia z takimi samymi atrybutami, ale po co?

        public Specialist(string firstname, string lastName, School school)
        {
            this.firstName = firstname;
            this.lastName = lastName;
            this.school = school;
        }

        public string FirstName
        {
            get => firstName;
        }

        public string LastName
        {
            get => lastName;
        }

        public School School
        {
            get 
            {
                School specialistSchool = new School("Szkoła Podstawowa nr 3", "SP3", "43-430", "Skoczów", "Górecka", "23");
                return specialistSchool;
            }
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName} {School.ShortName}");
        }
    }
}
