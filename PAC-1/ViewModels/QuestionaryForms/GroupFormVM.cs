using iText.Layout.Element;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class GroupFormVM : QuestionaryFormVM
    {
        private Patient[] _questionedPatients;
        private int _selectedPatientIndex;
        public static QuestionVM[] Questions { get => Questionary.Playing; }

        public GroupFormVM(Patient[] questionedPatients)
        {
            Data.OpenQuestionaryForm = this;
            _questionedPatients = questionedPatients;
        }

        public override Patient SelectedPatient
        {
            get => _questionedPatients[_selectedPatientIndex];
        }
        public int SelectedPatientIndex
        {
            get => _selectedPatientIndex;
            set
            {
                if (value != -1)
                {
                    _selectedPatientIndex = value;
                    foreach (var question in Questions)
                        question.RaiseSelectedPatientChanged();
                }
            }
        }
        public Patient[] QuestionedPatients { get => _questionedPatients; }
        
    }
}
