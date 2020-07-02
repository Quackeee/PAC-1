using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    abstract class QuestionaryFormVM : ContainedFormVM
    {
        public abstract Patient SelectedPatient { get; }

        public override ChangeViewCommand GotoWelcome
        {
            get => new ChangeViewCommand(
                arg =>
                    {
                        Data.SavePatients();
                        return new WelcomeFormVM();
                    }
                );
        }
    }
}
