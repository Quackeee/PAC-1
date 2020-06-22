using PAC_1.Commands;
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
        private ObservableCollection<PatientVM> _patients;
        private object _selectedPatientIndex;
        public SelectionMode Selection;

        public ObservableCollection<PatientVM> Patients { get => _patients; }
        //public PatientVM ChosenPatient { get => _patients[_selectedPatientIndex]; }
        public object SelectedPatientIndex { get => _selectedPatientIndex; set { _selectedPatientIndex = value; OnPropertyChanged(nameof(SelectedPatientIndex), nameof(GotoQuestionary)); } }

        private UpdateViewCommand _gotoQuestionary;
        /*private ViewModelBase questionaryvm()
        {
            if (_selectedPatientIndex != null)
            {
                if (IsForGroup)
                {
                    var selectedPatientIndexes = _selectedPatientIndex as int[];
                    var selectedPatients = new PatientVM[selectedPatientIndexes.Length];
                    foreach (int index in selectedPatientIndexes)
                        selectedPatients[index] = Patients[index];

                    return new GroupFormVM(selectedPatients);
                }
                else if ((int)_selectedPatientIndex != -1)
                {
                    return new IndividualFormVM(_patients[(int)_selectedPatientIndex]);
                }
                else return null;
            }
            return null;
        }*/
        public UpdateViewCommand GotoQuestionary
        {
            get {
                if (_gotoQuestionary is null)
                {
                    _gotoQuestionary = new UpdateViewCommand
                    (
                       () => {
                           if (_selectedPatientIndex != null)
                           {
                               if (IsForGroup)
                               {
                                   var selectedPatientIndexes = _selectedPatientIndex as int[];
                                   var selectedPatients = new PatientVM[selectedPatientIndexes.Length];
                                   foreach (int index in selectedPatientIndexes)
                                       selectedPatients[index] = Patients[index];

                                   return new GroupFormVM(selectedPatients);
                               }
                               else if ((int)_selectedPatientIndex != -1)
                               {
                                   return new IndividualFormVM(_patients[(int)_selectedPatientIndex]);
                               }
                               else throw new InvalidOperationException();
                           }
                           else throw new InvalidOperationException();
                       },
                       (arg) =>
                       {
                           if (_selectedPatientIndex is null) return false;
                           else if ((_selectedPatientIndex is int) && (((int)_selectedPatientIndex) == -1)) return false;
                           else if (_selectedPatientIndex is int[] && (_selectedPatientIndex as int[]).Length == 0) return false;
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
            Selection = IsForGroup ? SelectionMode.Multiple : SelectionMode.Single;
            _patients = new ObservableCollection<PatientVM>();

            Debug.WriteLine(IsForGroup);
        }
    }
}
