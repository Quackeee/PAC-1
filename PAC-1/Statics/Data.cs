using Newtonsoft.Json;
using PAC_1.Model;
using PAC_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.Statics
{
    static class Data
    {
        public static string DataDirectory;
        public static string UserDataDir;
        public static string SavedSchoolsDir;
        public static string SavedPatientsDir;

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
        public static Specialist User { get; set; }

        static Data()
        {
            DataDirectory = Environment.GetEnvironmentVariable("appdata") + "\\PAC1";
            UserDataDir = DataDirectory + "\\user.json";
            SavedSchoolsDir = DataDirectory + "\\schools.json";
            SavedPatientsDir = DataDirectory + "\\patients.json";
        }

        public static void SavePatients()
        {
            var patients = new List<Patient>();
            foreach (var patient in _patients)
                patients.Add(patient);

            string SaveJson = JsonConvert.SerializeObject(patients);
            File.WriteAllText(SavedPatientsDir, SaveJson);
            Debug.WriteLine("Patients saved");
        }

        public static void LoadPatients()
        {
            _patients = new ObservableCollection<Patient>();

            if (File.Exists(SavedPatientsDir))
            {
                List<Patient> load = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(SavedPatientsDir));

                if (load != null)
                    foreach (var patient in load)
                        _patients.Add(patient);
                Debug.WriteLine("Patients Loaded");
            }

        }

        public static void LoadSchools()
        {
            _schools = new List<School>();

            if (File.Exists(SavedSchoolsDir))
            {
                var loadedSchools = JsonConvert.DeserializeObject<List<School>>(File.ReadAllText(SavedSchoolsDir));
                if (loadedSchools != null)
                {
                    foreach (var school in loadedSchools)
                        _schools.Add(school);
                }
            }
        }

        public static void SaveSchools()
        {
            string SaveJson = JsonConvert.SerializeObject(_schools);
            File.WriteAllText(SavedSchoolsDir, SaveJson);
        }

        public static bool TryLoadUserData()
        {
            if (!File.Exists(UserDataDir)) return false;

            User = JsonConvert.DeserializeObject<Specialist>(File.ReadAllText(UserDataDir));
            Debug.WriteLine("Userdata loaded");
            return true;
        }

        public static void SaveUserData()
        {
            if (!Directory.Exists(DataDirectory)) Directory.CreateDirectory(DataDirectory);
            string rawJson = JsonConvert.SerializeObject(User);
            File.WriteAllText(UserDataDir, rawJson);
        }
    }
}
