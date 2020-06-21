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
            if(parameter.ToString() == "GroupForm" )
            {
                mainWindowVM.SelectedViewModel = new GroupFormVM();
            }
            else if(parameter.ToString() == "IndividualForm")
            {
                mainWindowVM.SelectedViewModel = new SchoolFormVM();
            }
        }
    }
}
