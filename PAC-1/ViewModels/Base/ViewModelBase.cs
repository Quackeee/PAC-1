using PAC_1.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PAC_1.ViewModels.VMBase
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public static MainWindowVM mainWindow;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] namesOfProperties)
        {
            if (PropertyChanged != null)
            {
                foreach (var prop in namesOfProperties)
                { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
            }
        }

        private static ICommand _updateViewCommand;
        public static ICommand UpdateViewCommand
        {
            get
            {
                if (_updateViewCommand == null) _updateViewCommand = new UpdateViewCommand(mainWindow);
                return _updateViewCommand;
            }
        }

    }

    class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            else _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter);
        public event EventHandler CanExecuteChanged
        {
            add { if (_canExecute != null) CommandManager.RequerySuggested += value; }
            remove { if (_canExecute != null) CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter) { _execute(parameter); }
    }
}
