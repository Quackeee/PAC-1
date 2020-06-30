using PAC_1.Commands;
using PAC_1.Model;
using PAC_1.Statics;
using PAC_1.ViewModels.VMBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Navigation;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.ObjectModel;

namespace PAC_1.ViewModels
{
    class CreateReportFormVM : ViewModelBase
    {
        private RelayCommand _createReport;
        public Patient SelectedPatient { get; set; }

        public ObservableCollection<Patient> Patients { get => Data.Patients; }
        public RelayCommand CreateReport
        {
            get 
            {
                if (_createReport == null)
                {
                    _createReport = new RelayCommand(
                        arg =>
                        {
                            //(Data.Patients.IndexOf(SelectedPatient));
                            GenerateReport(SelectedPatient);
                        },
                        arg => SelectedPatient != null
                        );
                }
                return _createReport;
            }
        }

        public void GenerateReport(Patient patient)
        {
            PdfWriter writer = new PdfWriter("D:\\probny_dokument_wpf.pdf");

            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            string s = patient.ToString();
            Paragraph header = new Paragraph(s)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);


            document.Add(header);
            document.Close();
        }

        public string GeneratePatientInfo()
        {
            return null;
        }

        public string GenerateSpecialistInfo()
        {
            return null;
        }
    }
}
