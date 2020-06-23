using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAC_1.ViewModels
{
    class AddEditPatientFormVM : ViewModelBase
    {
        private static AddEditPatientFormVM _storedData;
        private void _loadStoredData()
        {
            FirstName = _storedData.FirstName;
            LastName = _storedData.LastName;
            School = _storedData.School;
            Age = _storedData.Age;
            Iq = _storedData.Iq;
            Scale = _storedData.Scale;
            Background = _storedData.Background;
            Other = _storedData.Other;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public School School { get; set; }
        public List<School> SchoolOptions { get => Data.schools; }
        public int? Age { get; set; }
        public string BirthPlace { get; set; }
        public int? Iq { get; set; }
        public string Scale { get; set; }
        public string Background { get; set; }
        public string Other { get; set; }

        public int[] AgeOptions { get => Data.AgeOptions; }

        public AddEditPatientFormVM()
        {
            if (_storedData != null)
            {
                _loadStoredData();
                _storedData = null;
            }
        }
        public AddEditPatientFormVM(PatientVM editedPatient)
        {
            //TODO
        }

        public ChangeViewCommand Accept
        {
            get
            {
                return new ChangeViewCommand
                (
                    () =>
                    {
                        Data.patients.Add(new Patient(FirstName, LastName, School, (int)Age, BirthPlace, (int)Iq, Scale, Background, Other));
                        return new PatientListFormVM();
                    },
                    (arg) =>
                        !string.IsNullOrEmpty(FirstName) &&
                        !string.IsNullOrEmpty(LastName) &&
                        !(School is null) &&
                        !(Iq is null) &&
                        !string.IsNullOrEmpty(Scale) &&
                        !string.IsNullOrEmpty(Background) &&
                        !(Age is null)
                ) ;
            }
        }

        public ChangeViewCommand AddSchool
        {
            get
            {
                return new ChangeViewCommand
                (
                    () => { _storedData = this; return new SchoolFormVM(); }
                );
            }
        }

    }
}
