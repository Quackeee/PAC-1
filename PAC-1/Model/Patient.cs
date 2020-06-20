using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    
    class Patient
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string School { get; } //można stworzyć też klasę reprezentującą szkołę zamiast stringa  
        public int Age { get; }
        public string BirthPlace { get; }
        public int Iq { get; }
        public string Scale { get; } //skala użyta w badaniu IQ (zmienić na enum?)
        public string Background { get; } //że rodzina/dom dziecka, etc. (zmienić na enum?)
        public string Other { get; }

        // Pacjent będzie musiał mieć jeszcze swoje aktualne wyniki w formularzu, ale to jak będą opdowiednie klasy do tego

        public Patient(string firstName, string lastName, string school, int age, string birthplace, int iq, string scale, string background, string other = null)
        {
            FirstName = firstName;
            LastName = lastName;
            School = school;
            Age = age;
            BirthPlace = birthplace;
            Iq = iq;
            Scale = scale;
            Background = background;
            Other = other;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} {School}";
        }
    }
}
