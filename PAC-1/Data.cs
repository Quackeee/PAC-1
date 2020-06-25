using PAC_1.Model;
using PAC_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1
{
    static class Data
    {
        private static ObservableCollection<Patient> _patients;
        private static int[] _ageOptions;
        private static int _ageRange = 20;

        public static ObservableCollection<Patient> patients
        {
            get
            {
                if (_patients is null) _patients = new ObservableCollection<Patient> {
                    new Patient("Krzysztof", "Kłak", schools[0], 20, "Zabrze", 100, "nwm", "normalne"),
                    new Patient("Natalia", "Szarek", schools[0], 20, "Cieszyn", 200, "nwm", "normalne")
                };
                return _patients;
            }
        }
        

        public static List<School> schools = new List<School>()
        {
            new School("Politechnika Śląska","polsl",null,"Gliwice","Akademicka",null,null)
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
    }
}
