using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PAC_1.ViewModels
{
    class SpecialistFormVM : ContainedFormVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolName { get; set; }
        public string ShortSchoolName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int? SecondNumber { get; set; }

        public ChangeViewCommand Accept
        {
            get => new ChangeViewCommand(
                arg =>
                {
                    Data.User = new Specialist(FirstName, LastName,
                        new School(SchoolName, ShortSchoolName,
                        ZipCode, City, Street, Number, SecondNumber));
                    Data.SaveUserData();
                    return new WelcomeFormVM();
                },
                arg => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(SchoolName) 
                && !string.IsNullOrEmpty(ShortSchoolName) && !string.IsNullOrEmpty(ZipCode) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(Number)

            );
        }

    }
}
