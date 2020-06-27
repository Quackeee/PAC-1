using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAC_1.Statics;

namespace PAC_1.ViewModels
{
    class IndividualFormVM : QuestionaryFormVM
    {
        Patient _questionedPatient;
        Questionary.Cathegory _selectedCathegory = Questionary.SelfHelp;
        private int _selectedSubcathegoryIndex = 0;
        public override Patient SelectedPatient { get => _questionedPatient; }
        public string SelectedSubcathegoryName { get => Questionary.SubcathegoryName[SelectedSubcathegory]; }

        public Questionary.Cathegory SelectedCathegory
        {
            get => _selectedCathegory;
            set { _selectedCathegory = value; OnPropertyChanged(nameof(SelectedSubcathegory), nameof(SelectedSubcathegoryName)); }
        }

        public QuestionVM[] SelectedSubcathegory
        {
            get => SelectedCathegory.Subcathegories[_selectedSubcathegoryIndex];
        }
        
        public RelayCommand ChangeSelectedCathegory
        {
            get
            {
                return new RelayCommand(
                    arg =>
                    {
                        _selectedSubcathegoryIndex = 0;
                        SelectedCathegory = (Questionary.Cathegory)arg;
                    }
                    );
            }
        }

        public RelayCommand TraverseSubcathegoriesRight
        {
            get
            {
                return new RelayCommand(
                    arg =>
                    {
                        _selectedSubcathegoryIndex += 1;
                        if (_selectedSubcathegoryIndex >= _selectedCathegory.Subcathegories.Length) _selectedSubcathegoryIndex -= _selectedCathegory.Subcathegories.Length;
                        OnPropertyChanged(nameof(SelectedSubcathegory), nameof(SelectedSubcathegoryName));
                    }
                    );
            }
        }

        public RelayCommand TraverseSubcathegoriesLeft
        {
            get
            {
                return new RelayCommand(
                    arg =>
                    {
                        _selectedSubcathegoryIndex -= 1;
                        if (_selectedSubcathegoryIndex < 0 ) _selectedSubcathegoryIndex += _selectedCathegory.Subcathegories.Length;
                        OnPropertyChanged(nameof(SelectedSubcathegory), nameof(SelectedSubcathegoryName));
                    }
                    );
            }
        }

        public IndividualFormVM(Patient patient)
        {
            _questionedPatient = patient;
            Data.OpenQuestionaryForm = this;
        }
    }
}
