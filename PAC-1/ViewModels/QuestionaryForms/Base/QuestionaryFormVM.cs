using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    abstract class QuestionaryFormVM : ViewModelBase
    {
        public abstract Patient SelectedPatient { get; }
    }
}
