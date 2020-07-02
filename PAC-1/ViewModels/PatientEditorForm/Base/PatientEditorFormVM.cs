using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC_1.ViewModels
{
    abstract class PatientEditorFormVM : ViewModelBase
    {
        public static PatientEditorFormVM CachedPatientEditor;
        protected bool _dataOk() =>
        (
            !string.IsNullOrEmpty(FirstName) &&
            !string.IsNullOrEmpty(LastName) &&
            !(School is null) &&
            !(Iq is null) &&
            !string.IsNullOrEmpty(Scale) &&
            !string.IsNullOrEmpty(Background) &&
            !(Age is null)
        );
        protected virtual void _loadStoredData()
        {
            FirstName = CachedPatientEditor.FirstName;
            LastName = CachedPatientEditor.LastName;
            School = CachedPatientEditor.School;
            BirthPlace = CachedPatientEditor.BirthPlace;
            Age = CachedPatientEditor.Age;
            Iq = CachedPatientEditor.Iq;
            Scale = CachedPatientEditor.Scale;
            Background = CachedPatientEditor.Background;
            Other = CachedPatientEditor.Other;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public School School { get; set; }
        public List<School> SchoolOptions { get => Data.Schools; }
        public int? Age { get; set; }
        public string BirthPlace { get; set; }
        public int? Iq { get; set; }
        public string Scale { get; set; }
        public string Background { get; set; }
        public string Other { get; set; }
        public int[] AgeOptions { get => Data.AgeOptions; }

        public abstract ChangeViewCommand Accept { get; }

        public ChangeViewCommand AddSchool
        {
            get
            {
                return new ChangeViewCommand
                (
                    arg => { CachedPatientEditor = this; return new SchoolFormVM(); }
                );
            }
        }
    }
}
