using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class WelcomeFormVM : ViewModelBase
    {
        public Commands.ChangeViewArgs GotoIndividual { get => new Commands.GotoChoosePatientArgs(false); }
        public Commands.ChangeViewArgs GotoGroup { get => new Commands.GotoChoosePatientArgs(true); }
    }
}
