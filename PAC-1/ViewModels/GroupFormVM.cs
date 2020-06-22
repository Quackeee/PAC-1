using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class GroupFormVM : ViewModelBase
    {
        private ObservableCollection<PatientVM> _questionedPatients;

        public GroupFormVM(PatientVM[] questionedPatients)
        {
            Debug.WriteLine("hej, hej!");
            _questionedPatients = new ObservableCollection<PatientVM>(questionedPatients);
        }
    }
}
