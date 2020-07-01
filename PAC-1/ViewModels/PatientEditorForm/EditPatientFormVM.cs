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
                        _editedPatient.FirstName = FirstName;
                        _editedPatient.LastName = LastName;
                        _editedPatient.School = School;
                        _editedPatient.Age = (int) Age;
                        _editedPatient.BirthPlace = BirthPlace;
                        _editedPatient.Iq = (int) Iq;
                        _editedPatient.Scale = Scale;
                        _editedPatient.Background = Background;
                        _editedPatient.Other = Other;
                        Data.SavePatients();
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
