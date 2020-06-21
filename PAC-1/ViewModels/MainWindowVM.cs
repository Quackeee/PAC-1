using PAC_1.Commands;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAC_1.ViewModels
{
	public class MainWindowVM : ViewModelBase
	{
		private ViewModelBase _selectedViewModel;

		public ViewModelBase SelectedViewModel
		{
			get { return _selectedViewModel; }
			set 
			{ 
				_selectedViewModel = value;
				OnPropertyChanged(nameof(SelectedViewModel));
			}
		}
		public ICommand UpdateViewCommand { get; set; }

		public MainWindowVM()
		{
			UpdateViewCommand = new UpdateViewCommand(this);
		}

		
	}
}
