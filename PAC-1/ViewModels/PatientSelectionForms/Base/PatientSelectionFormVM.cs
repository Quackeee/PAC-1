﻿using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PAC_1.Commands;

namespace PAC_1.ViewModels
{
    abstract class PatientSelectionFormVM : ViewModelBase
    {
        protected ChangeViewCommand _gotoQuestionary;
        public SelectionMode Selection { get; protected set; }
        public ObservableCollection<Patient> Patients { get => Data.Patients; }
        public IList SelectedPatients { get; set; }
        public abstract ChangeViewCommand GotoQuestionary { get; }

        public PatientSelectionFormVM(SelectionMode selectionMode) { Selection = selectionMode; }
    }
}