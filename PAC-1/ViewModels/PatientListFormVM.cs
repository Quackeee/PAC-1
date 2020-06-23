using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class PatientListFormVM : ViewModelBase
    {
        public List<Patient> Patients { get => Data.patients; }

        public ChangeViewCommand GotoEditPatient { get => new ChangeViewCommand(() => new AddEditPatientFormVM()); }

    }
}
