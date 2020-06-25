using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class IndividualFormVM : ViewModelBase
    {
        PatientVM _questionedPatient;
        
        Question[] _selectedSubcathegory = Questionary.TableManners;
        public string SelectedSubcathegoryName { get => Questionary.SubcathegoryName[_selectedSubcathegory]; }
        
        public IndividualFormVM(PatientVM patient)
        {
            _questionedPatient = patient;
        }

        public Question[] SelectedSubcathegory {
            get => _selectedSubcathegory;
            set { _selectedSubcathegory = value; OnPropertyChanged(nameof(SelectedSubcathegory), nameof(SelectedSubcathegoryName)); }
        }

    }
}
