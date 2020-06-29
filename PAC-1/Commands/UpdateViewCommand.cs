using Newtonsoft.Json;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAC_1.Commands
{
    public class ChangeViewCommand : ICommand
    {
        public static MainWindowVM mainWindowVM;
        private Func<object, ViewModelBase> _getVM;
        private Predicate<object> _canExecute;

        public ChangeViewCommand(Func<object, ViewModelBase> getVM, Predicate<object> canExecute = null)
        {
            _getVM = getVM;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            mainWindowVM.SelectedViewModel = _getVM(parameter);
        }
        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add { if (_canExecute != null) CommandManager.RequerySuggested += value; }
            remove { if (_canExecute != null) CommandManager.RequerySuggested -= value; }
        }
    }
}
