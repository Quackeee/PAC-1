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

        public IndividualFormVM(Commands.GotoIndividualArgs parameter)
        {
            _questionedPatient = parameter.patient;
        }
    }
}
