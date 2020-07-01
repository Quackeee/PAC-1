using PAC_1.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PAC_1.ViewModels.VMBase
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] namesOfProperties)
        {
            if (PropertyChanged != null)
            {
                foreach (var prop in namesOfProperties)
                { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
            }
        }

        virtual public ChangeViewCommand GotoAddPatient { get => new ChangeViewCommand(arg => new AddPatientFormVM()); }
        virtual public ChangeViewCommand GotoWelcome { get => new ChangeViewCommand(arg => new WelcomeFormVM()); }
        virtual public ChangeViewCommand GotoPatientList { get => new ChangeViewCommand(arg => new PatientListFormVM()); }
    }
}
