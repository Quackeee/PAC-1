﻿using PAC_1.ViewModels;
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
            if (parameter.ToString() == "AddEditPatientForm")
            {
                mainWindowVM.SelectedViewModel = new AddEditPatientFormVM();
            }
            else if (parameter.ToString() == "GroupForm")
            {
                mainWindowVM.SelectedViewModel = new GroupFormVM();
            }
            else if (parameter.ToString() == "IndividualForm")
            {
                mainWindowVM.SelectedViewModel = new IndividualFormVM();
            }
            else if (parameter.ToString() == "PatientListForm")
            {
                mainWindowVM.SelectedViewModel = new PatientListFormVM();
            }
            else if (parameter.ToString() == "SchoolForm")
            {
                mainWindowVM.SelectedViewModel = new SchoolFormVM();
            }
            else if (parameter.ToString() == "WelcomeForm")
            {
                mainWindowVM.SelectedViewModel = new WelcomeFormVM();
            }
            else if(parameter.ToString() == "ChoosePatientsForm")
            {
                mainWindowVM.SelectedViewModel = new ChoosePatientsFormVM();
            }
            
        }
    }
}
