using PAC_1.Model;
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
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;

namespace PAC_1.ViewModels
{
    abstract class PatientSelectionFormVM : ViewModelBase
    {
        protected ChangeViewCommand _gotoQuestionary;
        public SelectionMode Selection { get; protected set; }
        public ObservableCollection<Patient> patients = null;
        public IList SelectedPatients { get; set; }
        public abstract ChangeViewCommand GotoQuestionary { get; }
        public ObservableCollection<Patient> Patients
        { 
            get => Data.Patients;
        }
        public PatientSelectionFormVM(SelectionMode selectionMode) { Selection = selectionMode; }

        public static void Save()
        {
            List<Patient> Savingpatients = new List<Patient>();

            foreach (Patient patient in Data.Patients)
            {
                Savingpatients.Add(patient);
            }

            string SaveJson = JsonConvert.SerializeObject(Savingpatients);
            File.WriteAllText(@"./data.json", SaveJson);
        }

        public static void Load()
        {
            if (File.Exists(@"./data.json"))
            {
                List<Patient> load = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(@"./data.json"));

                if (load != null)
                {
                    foreach (Patient patient in load)
                    {
                        Data.Patients.Add(new Patient(patient));
                    }
                }
            }
        }

        public ICommand Write
        {
            get
            {
                return new RelayCommand(arg => Save(), arg => true);
            }
        }
    }
}
