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
    class SpecialistFormVM : ViewModelBase
    {
        public string FirstName;
        public string LastName;
        public string SchoolName;
        public string ShortSchoolName;
        public string ZipCode;
        public string City;
        public string Street;
        public string Number;
        public int? SecondNumber;

        public override ChangeViewCommand GotoWelcome
        {
            get => new ChangeViewCommand(
                arg =>
                {
                    Data.User = new Specialist(FirstName, LastName,
                        new School(SchoolName, ShortSchoolName,
                        ZipCode, City, Street, Number, SecondNumber));
                    Data.SaveUserData();
                    return new WelcomeFormVM();
                }
            );
        }

    }
}
