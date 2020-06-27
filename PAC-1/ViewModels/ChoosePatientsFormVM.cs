using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
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
        private ObservableCollection<Patient> _patients;
        private int _selectedPatientIndex;
        public SelectionMode Selection { get; }

        public ObservableCollection<Patient> Patients { get => _patients; }
        public int SelectedPatientIndex { get => _selectedPatientIndex; set { _selectedPatientIndex = value; OnPropertyChanged(nameof(SelectedPatientIndex)); } }

        private ChangeViewCommand _gotoQuestionary;

        public ChangeViewCommand GotoQuestionary
        {
            get {
                if (_gotoQuestionary is null)
                {
                    _gotoQuestionary = new ChangeViewCommand
                    (
                       () =>
                       {
                           //if (_selectedPatientIndex != null)
                           {
                               /*if (IsForGroup)
                               {
                                   var selectedPatientIndexes = _selectedPatientIndex as int[];
                                   var selectedPatients = new PatientVM[selectedPatientIndexes.Length];
                                   foreach (int index in selectedPatientIndexes)
                                       selectedPatients[index] = new PatientVM(Patients[index]);

                                   return new GroupFormVM(selectedPatients);
                               }
                               else*/ if ((int)_selectedPatientIndex != -1)
                               {
                                   return new IndividualFormVM(_patients[_selectedPatientIndex]);
                               }
                               else throw new InvalidOperationException();
                           }
                           //else throw new InvalidOperationException();
                       },
                       arg => _selectedPatientIndex != -1
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
            _patients = Data.Patients;
        }
    }
}
