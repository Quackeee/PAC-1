using PAC_1.Commands;
using PAC_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAC_1.ViewModels
{
    class MultipleSelectionFormVM : PatientSelectionFormVM
    {
        public MultipleSelectionFormVM() : base(SelectionMode.Multiple) { }
        public override ChangeViewCommand GotoQuestionary
        {
            get
            {
                if (_gotoQuestionary is null)
                {
                    _gotoQuestionary = new ChangeViewCommand
                    (
                       arg => new GroupFormVM(SelectedPatients.Cast<Patient>().ToArray()),
                       arg => (SelectedPatients != null && SelectedPatients.Cast<Patient>().Count() != 0)
                    );
                }
                return _gotoQuestionary;
            }
        }
        
    }
}
