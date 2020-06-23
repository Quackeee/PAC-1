using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace PAC_1.ViewModels
{
    class SchoolFormVM : ViewModelBase
    {
        public string Name { get; set; } //pelna nazwa placowki
        public string ShortName { get; set; } //skrotowa nazwa
        public string ZipCode { get; set; }
        public string City { get; set; } //mozesz zrefaktorowac. Nie wiedzialam, jak zrobic ogolna nazwe
        public string Street { get; set; }
        public int? Number { get; set; }
        public string SecondNumber { get; set; }


        public ChangeViewCommand Accept
        {
            get =>
                new ChangeViewCommand(
                    () => { Data.schools.Add(new School(Name, ShortName, ZipCode, City, Street, SecondNumber, Number)); return new AddEditPatientFormVM(); },
                    (arg) => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(ShortName)
            );
        }
        public ChangeViewCommand Cancel
        {
            get =>
                new ChangeViewCommand(
                    () => new AddEditPatientFormVM()
            );
        }
    }
}
