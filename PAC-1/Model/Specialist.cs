using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    class Specialist
    {
        public string FirstName { get; }
        public string LastName { get; }
        public School School { get; } //tutaj tez dalam School. Moglabym zrobic klase poradnia z takimi samymi atrybutami, ale po co?

        public Specialist(string name, string lastName, School school)
        {
            FirstName = name;
            LastName = lastName;
            School = school;
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName} {School.ShortName}");
        }
    }
}
