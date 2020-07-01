using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAC_1.ViewModels
{
    class AddPatientFormVM : PatientEditorFormVM
    {
        public AddPatientFormVM()
        {
            if (_cachedData != null)
            {
                _loadStoredData();
                _cachedData = null;
            }
        }

        public override ChangeViewCommand Accept
        {
            get
            {
                return new ChangeViewCommand
                (
                    arg =>
                    {
                        Data.Patients.Add(new Patient(FirstName, LastName, School, (int)Age, BirthPlace, (int)Iq, Scale, Background, Other));
                        Data.SavePatients();
                        return new PatientListFormVM();
                    },
                    (arg) => _dataOk()
                );
            }
        }



    }
}
