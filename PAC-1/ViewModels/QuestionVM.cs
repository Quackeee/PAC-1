using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    class QuestionVM : ViewModelBase
    {
        private Question _representedQuestion;

        public QuestionVM(Question question)
        {
            _representedQuestion = question;
        }

        private Patient _questionedPatient { get => Data.OpenQuestionaryForm.SelectedPatient; }
        private bool? _status { get => _questionedPatient.QuestionResults[ID - 1]; set => _questionedPatient.QuestionResults[ID - 1] = value; }


        public bool YesOptionChecked
        {
            get
            {
                Debug.WriteLine($"{ID} => Status was {_status}");
                return _status ?? false;
            }
            set
            {
                Debug.WriteLine($"{ID} => Status has been set");
                if (value == false && _status == true) _status = null;
                else _status = value;
                OnPropertyChanged(nameof(YesOptionChecked), nameof(NoOptionChecked));
            }
        }
        public bool NoOptionChecked {
            get => !_status ?? false;
            set
            {
                if (value == false && _status == false) _status = null;
                else _status = !value;
                OnPropertyChanged(nameof(YesOptionChecked), nameof(NoOptionChecked));
            }
        }

        public int ID { get => _representedQuestion.ID; }
        public string Summary { get => _representedQuestion.Summary; }
        public string Description { get => _representedQuestion.Description; }
        public string Label { get => $"{ID}) {Summary}"; }
    }
}
