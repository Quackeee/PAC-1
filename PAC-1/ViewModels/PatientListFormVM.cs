using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
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
        public ObservableCollection<Patient> Patients { get => Data.Patients; }

        override public ChangeViewCommand GotoAddPatient { get => new ChangeViewCommand(arg => new AddPatientFormVM()); }
        public ChangeViewCommand GotoEditPatient {
            get => new ChangeViewCommand(
                arg => new EditPatientFormVM(SelectedPatient),
                arg => SelectedPatient != null
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
                            Data.Patients.RemoveAt(Data.Patients.IndexOf(SelectedPatient));
                            OnPropertyChanged(nameof(Patients));
                        },
                        arg => SelectedPatient != null
                        ) ;
                }
                return _deletePatient;
            }
        }

        override public ChangeViewCommand GotoWelcome
        {
            get
            {
                return new ChangeViewCommand(arg =>
                   {
                       Data.SavePatients();
                       return new WelcomeFormVM();
                   }
                );
            }
        }
    }
}
