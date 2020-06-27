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
        protected static PatientEditorFormVM _cachedData;
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
            FirstName = _cachedData.FirstName;
            LastName = _cachedData.LastName;
            School = _cachedData.School;
            BirthPlace = _cachedData.BirthPlace;
            Age = _cachedData.Age;
            Iq = _cachedData.Iq;
            Scale = _cachedData.Scale;
            Background = _cachedData.Background;
            Other = _cachedData.Other;
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
                    arg => { _cachedData = this; return new SchoolFormVM(); }
                );
            }
        }
    }
}
