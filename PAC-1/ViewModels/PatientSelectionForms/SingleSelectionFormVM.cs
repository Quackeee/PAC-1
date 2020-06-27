using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
using PAC_1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAC_1.ViewModels
{
    class SingleSelectionFormVM : PatientSelectionFormVM
    {
        public SingleSelectionFormVM() : base(SelectionMode.Single) { }
        public override ChangeViewCommand GotoQuestionary
        {
            get {
                if (_gotoQuestionary is null)
                {
                    _gotoQuestionary = new ChangeViewCommand
                    (
                       arg => new IndividualFormVM(SelectedPatients.Cast<Patient>().First()),
                       arg => (SelectedPatients!=null &&  SelectedPatients.Cast<Patient>().Count() != 0)
                    );
                }
                return _gotoQuestionary;
             }
        }
        
    }
}
