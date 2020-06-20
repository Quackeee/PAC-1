using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAC_1.Model;

namespace PAC_1.ViewModels
{
    using VMBase;
    class PatientVM : ViewModelBase
    {
        private Patient _representedPatient;

        public PatientVM(Patient patient)
        {
            _representedPatient = patient;
        }

        public string Details => $"Imię: {_representedPatient.FirstName}\nNazwisko: {_representedPatient.LastName}\n" +
                                $"Wiek: {_representedPatient.Age}\nSzkoła: {_representedPatient.School}\n" +
                                $"Miejsce urodzenia: {_representedPatient.BirthPlace}\n Iloraz inteligencji {_representedPatient.Iq} ({_representedPatient.Scale})\n" +
                                $"Środowisko: {_representedPatient.Background}\nUwagi: {Other}";

        public string Other { get => string.IsNullOrEmpty(_representedPatient.Other) ? "brak" : _representedPatient.Other; }
        public string FirstName { get => _representedPatient.FirstName; }
        public string LastName { get => _representedPatient.LastName;  }
        public int Age { get => _representedPatient.Age; }
        public string School { get => _representedPatient.School.Name;  }
    }
}
