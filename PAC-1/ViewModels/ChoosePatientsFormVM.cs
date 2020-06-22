using PAC_1.Commands;
using PAC_1.ViewModels.VMBase;
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

        public ChangeViewArgs GotoQuestionary
        {
            get
            {
                if (_selectedPatientIndex != null)
                {
                    if (IsForGroup)
                    {
                        var selectedPatientIndexes = _selectedPatientIndex as int[];
                        var selectedPatients = new PatientVM[selectedPatientIndexes.Length];
                        foreach (int index in selectedPatientIndexes)
                            selectedPatients[index] = Patients[index];

                        return new GotoGroupArgs(selectedPatients);
                    }
                    else if ((int)_selectedPatientIndex != -1)
                    {
                        return new GotoIndividualArgs(_patients[(int)_selectedPatientIndex]);
                    }
                    else return null;
                }
                return null;
            }
        }
        public bool IsForGroup { get; }

        public ChoosePatientsFormVM(GotoChoosePatientArgs args)
        {
            IsForGroup = args.IsForGroup;
            Selection = IsForGroup ? SelectionMode.Multiple : SelectionMode.Single;
            _patients = new ObservableCollection<PatientVM>();

            Debug.WriteLine(IsForGroup);
        }
    }
}
