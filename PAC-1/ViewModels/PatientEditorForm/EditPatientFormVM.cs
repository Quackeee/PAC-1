using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class EditPatientFormVM : PatientEditorFormVM
    {
        private Patient _editedPatient;

        public override ChangeViewCommand Accept
        {
            get
            {
                return new ChangeViewCommand(
                    arg =>
                    {
                        Data.Patients[Data.Patients.IndexOf(_editedPatient)] = new Patient(FirstName, LastName, School, (int)Age, BirthPlace, (int)Iq, Scale, Background, Other);
                        return new PatientListFormVM();
                    },
                    arg => _dataOk()
                    );
            }
        }

        protected override void _loadStoredData()
        {
            base._loadStoredData();
            _editedPatient = (_cachedData as EditPatientFormVM)._editedPatient;
        }

        private void _loadPatientData()
        {
            FirstName = _editedPatient.FirstName;
            LastName = _editedPatient.LastName;
            School = _editedPatient.School;
            BirthPlace = _editedPatient.BirthPlace;
            Age = _editedPatient.Age;
            Iq = _editedPatient.Iq;
            Scale = _editedPatient.Scale;
            Background = _editedPatient.Background;
            Other = _editedPatient.Other;
        }

        public EditPatientFormVM(Patient editedPatient)
        {
            _editedPatient = editedPatient;
            _loadPatientData();
        }
    }
}
