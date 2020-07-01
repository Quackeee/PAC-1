using Newtonsoft.Json;
using PAC_1.Statics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Model
{
    class Patient
    {
        [JsonProperty]
        private int _schoolIndex;
        

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public School School { get => Data.Schools[_schoolIndex]; set => _schoolIndex=Data.Schools.IndexOf(value); }
        public int Age { get; set; }
        public string BirthPlace { get; set; }
        public int Iq { get; set; }
        public string Scale { get; set; } //skala użyta w badaniu IQ (zmienić na enum?)
        public string Background { get; set; } //że rodzina/dom dziecka, etc. (zmienić na enum?)
        public string Other { get; set; }
        public bool?[] QuestionResults { get; set; } = new bool?[120];// = new bool?[120];//odpowiedzi na pytania
        public string Notes { get; set; }

        // Trzeba stworzyć pole na datę i czas badania, ale to później 

        public Patient() { }
        public Patient(string firstName, string lastName, School school, int age, string birthplace, int iq, string scale, string background, string other = null)
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

        public Patient(Patient p)
        {
            FirstName = p.FirstName;
            LastName = p.LastName;
            School = p.School;
            Age = p.Age;
            BirthPlace = p.BirthPlace;
            Iq = p.Iq;
            Scale = p.Scale;
            Background = p.Background;
            Other = p.Other;
        }

        public override string ToString()
        {
            //Tu zmieniłam na skrótową nazwę szkoły

            return string.Format($"{FirstName} {LastName} {Age} {School.ShortName}");
        }
    }
}
