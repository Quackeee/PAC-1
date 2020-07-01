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
using Org.BouncyCastle.Bcpg.OpenPgp;

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

            string fileName = SelectedPatient.FirstName + "_" + SelectedPatient.LastName;
            PdfWriter writer = new PdfWriter("D:\\" + fileName + "_Raport.pdf");

            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFontFactory.Register(@".\noto-serif.regular.ttf", "Noto");
            PdfFontFactory.Register(@".\NotoSerif-CondensedBold.ttf", "BoldNoto");
            PdfFontFactory.Register(@".\NotoSerif-CondensedBoldItalic.ttf", "BoldItalicNoto");
            PdfFontFactory.Register(@".\NotoSerif-CondensedItalic.ttf", "ItalicNoto");
            PdfFontFactory.Register(@".\NotoSerif-Light.ttf", "Light");

            PdfFont normal = PdfFontFactory.CreateRegisteredFont("Noto", PdfEncodings.CP1250, true);
            PdfFont bold = PdfFontFactory.CreateRegisteredFont("BoldNoto", PdfEncodings.CP1250, true);
            PdfFont boldItalic = PdfFontFactory.CreateRegisteredFont("BoldItalicNoto", PdfEncodings.CP1250, true);
            PdfFont Italic = PdfFontFactory.CreateRegisteredFont("ItalicNoto", PdfEncodings.CP1250, true);
            PdfFont Light = PdfFontFactory.CreateRegisteredFont("Light", PdfEncodings.CP1250, true);

            Rectangle[] columns = {
                        new Rectangle(36, 36, 254, 770),
                    new Rectangle(305, 36, 254, 770)};

            GenerateHeader(document, bold);
            GenerateSection("1.Osoba przeprowadzająca badanie",document, boldItalic);
            GenerateSpecialistInfo(document, normal);
            GenerateSection("2.Osoba badana",document, boldItalic);
            GeneratePatientInfo(document, normal);
            
            GenerateSection("Odpowiedzi na pytania", document, boldItalic);

            document.Close();
            System.Diagnostics.Process.Start(@"D:\\" + fileName + "_Raport.pdf");
        }

        public void GenerateHeader(Document document, PdfFont font)
        {
            string s = "Inwentarz PAC-1";
            Paragraph header = new Paragraph(s)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(font)
                .SetFontSize(20);
            document.Add(header);
        }

        public void GenerateSection(string s,Document document, PdfFont font)
        {
            string topic = "\n" + s;
            Paragraph Section = new Paragraph(topic)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(12);

            document.Add(Section);
        }

        public void GenerateSubsection(string topic, Document document, PdfFont font)
        {
            Paragraph Subsection = new Paragraph(topic)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);
        }
        
        public void GenerateSpecialistInfo(Document document, PdfFont font)
        {
            string s = "Imię: " + specialist.FirstName +
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
            string s = "Imię: " + SelectedPatient.FirstName +
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

        public void GenerateQuestionsInfo(Document document, PdfFont font)
        {
            
        }
        
        
    }
}
