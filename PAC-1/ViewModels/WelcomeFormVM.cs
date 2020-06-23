﻿using PAC_1.Commands;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAC_1.ViewModels
{
    class WelcomeFormVM : ViewModelBase
    {
        public UpdateViewCommand GotoGroup { get => new UpdateViewCommand(() => new ChoosePatientsFormVM(true)); }
        public UpdateViewCommand GotoIndividual { get => new UpdateViewCommand(() => new ChoosePatientsFormVM(false)); }
    }
}
