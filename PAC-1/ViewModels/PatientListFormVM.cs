using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class PatientListFormVM : ViewModelBase
    {
        public Patient SelectedPatient { get; set; }
        public ObservableCollection<Patient> Patients { get => Data.patients; }

        new public ChangeViewCommand GotoAddPatient { get => new ChangeViewCommand(() => new AddEditPatientFormVM()); }
        public ChangeViewCommand GotoEditPatient {
            get => new ChangeViewCommand(
                () => new AddEditPatientFormVM(SelectedPatient),
                (arg) => SelectedPatient != null
                ); }

        private RelayCommand _deletePatient;
        public RelayCommand DeletePatient
        {
            get
            {
                if (_deletePatient == null)
                {
                    _deletePatient = new RelayCommand(
                        arg =>
                        {
                            Data.patients.RemoveAt(Data.patients.IndexOf(SelectedPatient));
                            OnPropertyChanged(nameof(Patients));
                        },
                        arg => SelectedPatient != null
                        ) ;
                }
                return _deletePatient;
            }
        }

    }
}
