using PAC_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAC_1.ViewModels;

namespace PAC_1.Commands
{
    abstract class ChangeViewArgs{}
    class GotoIndividualArgs : ChangeViewArgs
    {
        public ViewModels.PatientVM patient;

        public GotoIndividualArgs(ViewModels.PatientVM questionedPatient)
        {
            patient = questionedPatient;
        }
    }
    class GotoGroupArgs : ChangeViewArgs
    {
        public PatientVM[] patients;

        public GotoGroupArgs(PatientVM[] questionedPatients)
        {
            patients = questionedPatients;
        }
    }
    class GotoChoosePatientArgs : ChangeViewArgs
    {
        public bool IsForGroup;

        public GotoChoosePatientArgs(bool isForGroup)
        {
            IsForGroup = isForGroup;
        }
    }
}
