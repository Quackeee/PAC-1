using Newtonsoft.Json;
using PAC_1.Model;
using PAC_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        public static void SavePatients()
        {
            List<Patient> Savingpatients = new List<Patient>();

            foreach (Patient patient in Patients)
            {
                Savingpatients.Add(patient);
            }

            string SaveJson = JsonConvert.SerializeObject(Savingpatients);
            File.WriteAllText(@"./data.json", SaveJson);
        }

        public static ObservableCollection<Patient> Patients
        {
            get
            {
                if (_patients is null)
                {
                    LoadPatients();
                }

                return _patients;
            }
        }

        public static void LoadPatients()
        {
            if (File.Exists(@"./data.json"))
            {
                List<Patient> load = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(@"./data.json"));

                if (_patients is null) _patients = new ObservableCollection<Patient>();

                if (load != null)
                {
                    foreach (Patient patient in load)
                    {
                        _patients.Add(new Patient(patient));
                    }
                }
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
