using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    using VMBase;
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using PAC_1.Commands;
    using PAC_1.Views;

    class PatientListVM : ViewModelBase
    {
        private int _selectedIndex = -1;

        private ObservableCollection<PatientVM> _patients = null;

        public ObservableCollection<PatientVM> Patients { get
            {
                if (_patients == null)
                {
                    _patients = new ObservableCollection<PatientVM>();
                }
                return _patients;
            }
        }
        
        public string SelectedPatientDetials { get
            {
                if (SelectedIndex != -1)
                    return _patients[_selectedIndex].Details;
                else return null;
            }
        }

        public int SelectedIndex { get => _selectedIndex; set { _selectedIndex = value; OnPropertyChanged(nameof(SelectedPatientDetials)); } }
        private ICommand _deletePatient = null;

        public ICommand DeletePatient { get { 
            if (_deletePatient == null)
                {
                    _deletePatient = new RelayCommand(
                        arg =>
                        {
                            _patients.RemoveAt(_selectedIndex);
                            OnPropertyChanged(nameof(Patients));
                        },
                        arg => SelectedIndex != -1
                        );
                }
                return _deletePatient;
            }
        }
        
        public UpdateViewCommand GotoAddPatient {
            get => new UpdateViewCommand(() => new AddEditPatientFormVM());
        }
        public UpdateViewCommand GotoEditPatient
        {
            get => new UpdateViewCommand(() => new AddEditPatientFormVM());
        }
    }
}
