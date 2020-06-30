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
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Kernel.Geom;

namespace PAC_1.ViewModels
{
    class CreateReportFormVM : ViewModelBase
    {
        private RelayCommand _createReport;
        public Patient SelectedPatient { get; set; }
        public Specialist specialist { get => new Specialist("Lucyna", "Kisiała-Majerczyk", Data.Schools[0]); }
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
            PdfFontFactory.Register(@"C:\Users\nszar\AppData\Local\Microsoft\Windows\Fonts\noto-serif.regular.ttf", "Noto");
            PdfFontFactory.Register(@"C:\Windows\Fonts\NotoSerif-CondensedBold.ttf", "BoldNoto");
            PdfFont font = PdfFontFactory.CreateRegisteredFont("Noto", PdfEncodings.CP1250, true);
            PdfFont bold = PdfFontFactory.CreateRegisteredFont("BoldNoto", PdfEncodings.CP1250, true);

            Rectangle[] columns = {
                        new Rectangle(36, 36, 254, 770),
                    new Rectangle(305, 36, 254, 770)};

            string s = "Inwentarz PAC-1";
            Paragraph header = new Paragraph(s)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(bold)
                .SetFontSize(20);

            //Paragraph specialistInfo = new Paragraph(GenerateSpecialistInfo())
              // .SetTextAlignment(TextAlignment.RIGHT);
            document.Add(header);
            GenerateSpecialistInfo(document, font);
            GeneratePatientInfo(document, font);
            document.Close();
            System.Diagnostics.Process.Start(@"D:\\probny_dokument_wpf.pdf");
        }
        
        public void GenerateSpecialistInfo(Document document, PdfFont font)
        {
            string s = "\n1.Osoba przeprowadzająca badanie" +
                "\n\n Imię: " + specialist.FirstName +
                "\n Nazwisko: " + specialist.LastName +
                "\n Placówka: " + specialist.school.Name +
                "\n           " + "ul. " + specialist.school.Street + " " + specialist.school.Number +
                "\n           " + specialist.school.ZipCode + " " + specialist.school.City;

            Paragraph specialistInfo = new Paragraph(s)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);
                
                
            document.Add(specialistInfo);
        }

        public void GeneratePatientInfo(Document document, PdfFont font)
        {
            string s = "\n2.Osoba badana" +
                "\n\n Imię: " + SelectedPatient.FirstName +
                "\n Nazwisko: " + SelectedPatient.LastName +
                "\n Wiek: " + SelectedPatient.Age.ToString() +
                "\n Miejsce urodzenia: " + SelectedPatient.BirthPlace +
                "\n IQ: " + SelectedPatient.Iq.ToString() +
                "\n Mierzone w skali: " + SelectedPatient.Scale +
                "\n Środowisko: " + SelectedPatient.Background +
                "\n Inne: " + SelectedPatient.Other +
                "\n Placówka: " + SelectedPatient.School.Name +
                "\n           " + "ul. " + SelectedPatient.School.Street + " " + SelectedPatient.School.Number +
                "\n           " + SelectedPatient.School.ZipCode + " " + SelectedPatient.School.City;

            Paragraph specialistInfo = new Paragraph(s)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);
            document.Add(specialistInfo);
        }

        public string GenerateQuestionsInfo()
        {
            return null;
        }

        
    }
}
