using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    class Specialist
    {
        public Specialist(string firstname, string lastName, School school)
        {
            FirstName = firstname;
            LastName = lastName;
            School = school;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public School School { get; }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName} {School.ShortName}");
        }
    }
}
