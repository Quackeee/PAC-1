using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAC_1.ViewModels
{
    class ChoosePatientsFormVM : ViewModelBase
    {
        private List<Patient> _patients;
        private object _selectedPatientIndices;
        public SelectionMode Selection { get; }

        public List<Patient> Patients { get => _patients; }
        //public PatientVM ChosenPatient { get => _patients[_selectedPatientIndex]; }
        public object SelectedPatientIndices { get => _selectedPatientIndices; set { _selectedPatientIndices = value; OnPropertyChanged(nameof(SelectedPatientIndices)); } }

        private UpdateViewCommand _gotoQuestionary;

        public UpdateViewCommand GotoQuestionary
        {
            get {
                if (_gotoQuestionary is null)
                {
                    _gotoQuestionary = new UpdateViewCommand
                    (
                       () =>
                       {
                           if (_selectedPatientIndices != null)
                           {
                               if (IsForGroup)
                               {
                                   var selectedPatientIndexes = _selectedPatientIndices as int[];
                                   var selectedPatients = new PatientVM[selectedPatientIndexes.Length];
                                   foreach (int index in selectedPatientIndexes)
                                       selectedPatients[index] = new PatientVM(Patients[index]);

                                   return new GroupFormVM(selectedPatients);
                               }
                               else if ((int)_selectedPatientIndices != -1)
                               {
                                   return new IndividualFormVM(new PatientVM(_patients[(int)_selectedPatientIndices]));
                               }
                               else throw new InvalidOperationException();
                           }
                           else throw new InvalidOperationException();
                       },
                       arg =>
                       {
                           if (_selectedPatientIndices is null) return false;
                           else if ((_selectedPatientIndices is int) && (((int)_selectedPatientIndices) == -1)) return false;
                           else if (_selectedPatientIndices is int[] && (_selectedPatientIndices as int[]).Length == 0) return false;
                           else return true;
                       }
                    );
                }
                return _gotoQuestionary;
             }
        }
        public bool IsForGroup { get; }

        public ChoosePatientsFormVM(bool isForGroup)
        {
            IsForGroup = isForGroup;
            Selection = IsForGroup ? SelectionMode.Extended : SelectionMode.Single;
            OnPropertyChanged(nameof(Selection));
            _patients = Data.patients;

            foreach (var patient in _patients)
            {
                Debug.WriteLine(patient);
            }
        }
    }
}
