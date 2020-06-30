using PAC_1.Model;
using PAC_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Statics
{
    static class Data
    {
        private static ObservableCollection<Patient> _patients = null;
        private static int[] _ageOptions;
        private static int _ageRange = 20;

        

        public static ObservableCollection<Patient> Patients
        {
            get
            {
                
                if (_patients is null)
                {
                    _patients = new ObservableCollection<Patient>();
                    _patients.Add(new Patient("Natalia", "Szarek", Schools[0], 20, "Cieszyn", 123, "jakaś skala", "rodzina"));
                    PatientSelectionFormVM.Load();
                }
                
                return _patients;
            }
        }
        

        public static List<School> Schools = new List<School>()
        {
            new School("Politechnika Śląska","polsl","44-100","Gliwice","Akademicka","23",null)
        };

        public static int[] AgeOptions
        {
            get
            {
                if (_ageOptions is null)
                {
                    _ageOptions = new int[_ageRange];
                    for (int i = 0; i < _ageRange;)
                    {
                        _ageOptions[i] = ++i;
                    }
                }
                return _ageOptions;
            }
        }

        public static QuestionaryFormVM OpenQuestionaryForm;
    }
}
