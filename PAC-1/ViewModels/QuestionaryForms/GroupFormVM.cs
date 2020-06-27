using PAC_1.Model;
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
    class GroupFormVM : QuestionaryFormVM
    {
        private Patient[] _questionedPatients;

        public GroupFormVM(Patient[] questionedPatients)
        {
            _questionedPatients = questionedPatients;
        }

        public override Patient SelectedPatient => throw new NotImplementedException();
    }
}
