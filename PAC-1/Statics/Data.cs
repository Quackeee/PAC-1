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
        private static ObservableCollection<Patient> _patients;
        private static List<School> _schools;
        private static int[] _ageOptions;
        private static int _ageRange = 20;

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

        public static List<School> Schools
        {
            get
            {
                if (_schools is null)
                    LoadSchools();
                return _schools;
            }
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

        public static void SavePatients()
        {
            var savingPatients = new List<Patient>();

            foreach (var patient in Patients)
            {
                savingPatients.Add(patient);
            }

            string SaveJson = JsonConvert.SerializeObject(savingPatients);
            File.WriteAllText(@"./patients.json", SaveJson);
        }

        public static void LoadPatients()
        {
            if (_patients is null) _patients = new ObservableCollection<Patient>();

            if (File.Exists(@"./patients.json"))
            {
                List<Patient> load = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(@"./patients.json"));

                if (load != null)
                {
                    foreach (Patient patient in load)
                    {
                        _patients.Add(new Patient(patient));
                    }
                }
            }
        }

        public static void LoadSchools()
        {
            _schools = new List<School>();

            if (File.Exists(@"./schools.json"))
            {
                _schools = JsonConvert.DeserializeObject<List<School>>(File.ReadAllText(@"./schools.json"));
            }
        }

        public static void SaveSchools()
        {
            var savingSchools = new List<School>();

            foreach (var school in Schools)
            {
                savingSchools.Add(school);
            }

            string SaveJson = JsonConvert.SerializeObject(savingSchools);
            File.WriteAllText(@"./schools.json", SaveJson);
        }
    }
}
