using PAC_1.Commands;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAC_1.ViewModels
{
	public class MainWindowVM : ViewModelBase
	{
		private ContainedFormVM _selectedViewModel;

		public ContainedFormVM SelectedViewModel
		{
			get { return _selectedViewModel; }
			set 
			{ 
				_selectedViewModel = value;
				OnPropertyChanged(nameof(SelectedViewModel));
			}
		}

		public MainWindowVM()
		{
            ChangeViewCommand.mainWindowVM = this;
			if (Data.TryLoadUserData())
				_selectedViewModel = new WelcomeFormVM();
			else _selectedViewModel = new SpecialistFormVM();
		}
	}
}
