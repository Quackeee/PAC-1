using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class GroupFormVM : ViewModelBase
    {
        private ObservableCollection<PatientVM> _questionedPatients;

        public GroupFormVM(Commands.GotoGroupArgs questionedPatients)
        {
            _questionedPatients = new ObservableCollection<PatientVM>(questionedPatients.patients);
        }
    }
}
