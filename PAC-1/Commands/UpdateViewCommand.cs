using PAC_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAC_1.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowVM mainWindowVM;

        public UpdateViewCommand(MainWindowVM mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.GetType());

            if (parameter is string)
            {
                var name = parameter.ToString();

                if (name == "PatientListForm")
                {
                    mainWindowVM.SelectedViewModel = new PatientListFormVM();
                }
                else if (name == "SchoolForm")
                {
                    mainWindowVM.SelectedViewModel = new SchoolFormVM();
                }
                else if (name == "WelcomeForm")
                {
                    mainWindowVM.SelectedViewModel = new WelcomeFormVM();
                }
                else if (name == "AddEditPatientForm")
                {
                    mainWindowVM.SelectedViewModel = new AddEditPatientFormVM();
                }
            }
            else if (parameter is GotoGroupArgs)
            {
                mainWindowVM.SelectedViewModel = new GroupFormVM(parameter as GotoGroupArgs);
            }
            else if (parameter is GotoIndividualArgs)
            {
                mainWindowVM.SelectedViewModel = new IndividualFormVM(parameter as GotoIndividualArgs);
            }
            else if (parameter is GotoChoosePatientArgs)
            {
                mainWindowVM.SelectedViewModel = new ChoosePatientsFormVM(parameter as GotoChoosePatientArgs);
            }


        }
    }
}
