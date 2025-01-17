﻿using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.ViewModels.VMBase;
using PAC_1.Statics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PAC_1.ViewModels
{
    partial class PatientListFormVM : ContainedFormVM
    {
        private Patient _selectedPatient;
        private RelayCommand _generateReport;
        public Patient SelectedPatient { get => _selectedPatient; set { _selectedPatient = value; OnPropertyChanged(nameof(PatientDetails));} }
        public ObservableCollection<Patient> Patients { get => Data.Patients; }

        override public ChangeViewCommand GotoAddPatient { get => new ChangeViewCommand(arg => new AddPatientFormVM()); }
        public ChangeViewCommand GotoEditPatient {
            get => new ChangeViewCommand(
                arg => new EditPatientFormVM(SelectedPatient),
                arg => SelectedPatient != null
                ); }

        private RelayCommand _deletePatient;
        public RelayCommand DeletePatient
        {
            get
            {
                if (_deletePatient == null)
                {
                    _deletePatient = new RelayCommand(
                        arg =>
                        {
                            Data.Patients.RemoveAt(Data.Patients.IndexOf(SelectedPatient));
                            OnPropertyChanged(nameof(Patients));
                            Data.SavePatients();
                        },
                        arg => SelectedPatient != null
                        ) ;
                }
                return _deletePatient;
            }
        }
        public string PatientDetails { get
            {
                if (SelectedPatient is null) return string.Empty;
                else return SelectedPatient.Details;
            }
        }
        public RelayCommand GenerateReport
        {
            get
            {
                if (_generateReport == null)
                {
                    _generateReport = new RelayCommand(
                        arg =>
                        {
                            new ReportGenerator().GenerateReport(SelectedPatient);
                        },
                        arg => SelectedPatient != null
                        );
                }
                return _generateReport;
            }
        }
    }
}
