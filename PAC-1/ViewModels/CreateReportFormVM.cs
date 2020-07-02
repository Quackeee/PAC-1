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
using iText.Layout.Borders;
using System.Drawing;
using iText.IO.Image;
using PAC_1.Properties;

namespace PAC_1.ViewModels
{
    partial class PatientListFormVM : ViewModelBase
    {
        private RelayCommand _createReport;
        private List<int> TableManners = new List<int> { 0, 1, 17, 18, 33, 50, 68, 91, 92, 108 };
        private List<int> MotorSkills = new List<int> { 2, 3, 19, 34, 35, 51, 69, 70, 93, 109 };
        private List<int> ToiletAndWashing = new List<int> { 4, 20, 21, 36, 37, 52, 53, 71, 94, 110 };
        private List<int> DressingUp = new List<int> { 5, 6, 22, 23, 38, 54, 72, 73, 95, 111 };
        private List<int> Language = new List<int> { 7, 8, 24, 25, 39, 55, 56, 74, 96, 112 };
        private List<int> Differentiation = new List<int> { 9, 26, 40, 57, 58, 75, 76, 77, 97, 113 };
        private List<int> NumbersAndSizes = new List<int> { 10, 27, 41, 42, 59, 78, 79, 80, 98, 114 };
        private List<int> PencilAndPaperSkills = new List<int> { 11, 28, 43, 60, 81, 82, 99, 100, 101, 115 };
        private List<int> Playing = new List<int> { 12, 29, 44, 45, 61, 62, 63, 83, 102, 116 };
        private List<int> Housework = new List<int> { 13, 30, 46, 64, 84, 85, 86, 103, 104, 117 };
        private List<int> ManualSkills = new List<int> { 14, 15, 31, 47, 48, 65, 66, 87, 105, 118 };
        private List<int> Agility = new List<int> { 16, 32, 49, 67, 88, 89, 90, 106, 107, 119 };
        public Specialist specialist { get => new Specialist("Lucyna", "Kisiała-Majerczyk", Data.Schools[0]); }
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

            ImageData data = ImageDataFactory.Create(Resources.PAC1Diagram, null);
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(data);


            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            PdfFont normal = PdfFontFactory.CreateFont(Resources.NotoSerif_Regular, PdfEncodings.CP1250, true);
            PdfFont widebold = PdfFontFactory.CreateFont(Resources.NotoSerif_Bold, PdfEncodings.CP1250, true);
            PdfFont bold = PdfFontFactory.CreateFont(Resources.NotoSerif_CondensedBold, PdfEncodings.CP1250, true);
            PdfFont boldItalic = PdfFontFactory.CreateFont(Resources.NotoSerif_BoldItalic, PdfEncodings.CP1250, true);
            PdfFont italic = PdfFontFactory.CreateFont(Resources.NotoSerif_CondensedItalic, PdfEncodings.CP1250, true);
            PdfFont light = PdfFontFactory.CreateFont(Resources.NotoSerif_Light, PdfEncodings.CP1250, true);

            //Rectangle[] columns = {new Rectangle(36, 36, 254, 770),  new Rectangle(305, 36, 254, 770)};

            // document.SetRenderer(new ColumnDocumentRenderer(document, columns));

            GenerateHeader(document, bold);
            GenerateSection("Osoba przeprowadzająca badanie", document, boldItalic);
            GenerateSpecialistInfo(document, normal);
            GenerateSection("Osoba badana", document, boldItalic);
            GeneratePatientInfo(document, normal);

            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateSection("Odpowiedzi na pytania", document, boldItalic);

            /*************************************************************/
            GenerateSubsection("1.Obsługiwanie siebie", document, widebold);
            GenerateCategory("Zachowanie przy stole", document, bold);
            GenerateQuestionsInfo(document, light, normal, TableManners);
            GenerateCategory("Sprawność motoryczna", document, bold);
            GenerateQuestionsInfo(document, light, normal, MotorSkills);
            GenerateCategory("Ubieranie się", document, bold);
            GenerateQuestionsInfo(document, light, normal, DressingUp);
            GenerateCategory("Toaleta i mycie", document, bold);
            GenerateQuestionsInfo(document, light, normal, ToiletAndWashing);

            /*************************************************************/
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateSubsection("2.Komunikowanie się", document, widebold);
            GenerateCategory("Język", document, bold);
            GenerateQuestionsInfo(document, light, normal, Language);
            GenerateCategory("Ujmowanie różnic", document, bold);
            GenerateQuestionsInfo(document, light, normal, Differentiation);
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateCategory("Liczby i wielkości", document, bold);
            GenerateQuestionsInfo(document, light, normal, NumbersAndSizes);
            GenerateCategory("Posługiwanie się ołówkiem i papierem", document, bold);
            GenerateQuestionsInfo(document, light, normal, PencilAndPaperSkills);

            /*************************************************************/
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateSubsection("3.Uspołecznienie", document, widebold);
            GenerateCategory("Udział w zabawie", document, bold);
            GenerateQuestionsInfo(document, light, normal, Playing);
            GenerateCategory("Czynności domowe", document, bold);
            GenerateQuestionsInfo(document, light, normal, Housework);

            /*************************************************************/
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateSubsection("4.Zajęcia", document, widebold);
            GenerateCategory("Sprawność manualna (ruchy palców)", document, bold);
            GenerateQuestionsInfo(document, light, normal, ManualSkills);
            GenerateCategory("Zręczność (kontrola motoryki)", document, bold);
            GenerateQuestionsInfo(document, light, normal, Agility);

            /*************************************************************/
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            GenerateSection("Diagram", document, bold);
            GenerateSubsection("Zadania z pozytywnym:", document, widebold);
            WriteResults(document, normal, true);
            GenerateSubsection("\nZadania z negatywnym rezultatem:", document, widebold);
            WriteResults(document, normal, false);
            GenerateSubsection("\nNiewykonane zadania:", document, widebold);
            WriteResults(document, normal, null);

            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            document.Add(image)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);


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

        public void GenerateSection(string s, Document document, PdfFont font)
        {
            string topic = "\n" + s;
            Paragraph Section = new Paragraph(topic)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(14);

            document.Add(Section);
        }

        public void GenerateSubsection(string topic, Document document, PdfFont font)
        {
            Paragraph subsection = new Paragraph(topic)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(12);

            document.Add(subsection);
        }
        public void GenerateCategory(string topic, Document document, PdfFont font)
        {
            Paragraph category = new Paragraph(topic)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);

            document.Add(category);
        }

        public void GenerateSpecialistInfo(Document document, PdfFont font)
        {
            string s = null;
            if (specialist.School.SecondNumber == null)
            {
                s = "Imię: " + specialist.FirstName +
                    "\n Nazwisko: " + specialist.LastName +
                    "\n Placówka: " + specialist.School.Name +
                    "\n           " + "ul. " + specialist.School.Street + " " + specialist.School.Number +
                    "\n           " + specialist.School.ZipCode + " " + specialist.School.City;
            }
            else
            {
                s = "Imię: " + specialist.FirstName +
                    "\n Nazwisko: " + specialist.LastName +
                    "\n Placówka: " + specialist.School.Name +
                    "\n           " + "ul. " + specialist.School.Street + " " + specialist.School.Number + "\\" + specialist.School.SecondNumber +
                    "\n           " + specialist.School.ZipCode + " " + specialist.School.City;
            }

            Paragraph specialistInfo = new Paragraph(s)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);


            document.Add(specialistInfo);
        }

        public void GeneratePatientInfo(Document document, PdfFont font)
        {
            string s = null;
            if (SelectedPatient.School.SecondNumber == null)
            {
                s = "Imię: " + SelectedPatient.FirstName +
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
            }
            else
            {
                s = "Imię: " + SelectedPatient.FirstName +
                   "\n Nazwisko: " + SelectedPatient.LastName +
                   "\n Wiek: " + SelectedPatient.Age.ToString() +
                   "\n Miejsce urodzenia: " + SelectedPatient.BirthPlace +
                   "\n IQ: " + SelectedPatient.Iq.ToString() +
                   "\n Mierzone w skali: " + SelectedPatient.Scale +
                   "\n Środowisko: " + SelectedPatient.Background +
                   "\n Inne: " + SelectedPatient.Other +
                   "\n Placówka: " + SelectedPatient.School.Name +
                   "\n           " + "ul. " + SelectedPatient.School.Street + " " + SelectedPatient.School.Number + "\\" + SelectedPatient.School.SecondNumber +
                   "\n           " + SelectedPatient.School.ZipCode + " " + SelectedPatient.School.City;
            }

            Paragraph specialistInfo = new Paragraph(s)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);
            document.Add(specialistInfo);
        }

        public void GenerateQuestionsInfo(Document document, PdfFont font, PdfFont font1, List<int> table)
        {
            foreach (var element in table)
            {
                Text question1 = new Text(Questionary.Questions[element].Summary).SetFont(font).SetFontSize(10);

                Text answer1 = new Text(MakeAnswer(SelectedPatient.QuestionResults[element])).SetFont(font1).SetFontSize(10);

                Text number = new Text((element + 1).ToString()).SetFont(font).SetFontSize(10);

                Paragraph questionAndAnswer = new Paragraph().Add(number).Add(") ").Add(question1).Add(" ").Add(answer1);

                document.Add(questionAndAnswer);
            }

        }

        public string MakeAnswer(bool? result)
        {
            string answer;

            if (result == null)
                answer = "Brak odpowiedzi";

            else if (result == true)
                answer = "Tak";

            else
                answer = "Nie";

            return answer;
        }

        public void WriteResults(Document document, PdfFont font, bool? expectedResult)
        {
            string sb = "";
            for (int i = 0; i < 120; i++)
            {
                if (SelectedPatient.QuestionResults[i] == expectedResult)
                {
                    sb += (i + 1) + ", ";
                }
            }

            Paragraph writeResults = new Paragraph().Add(new Text(sb))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(font)
                .SetFontSize(10);

            document.Add(writeResults);

        }

    }
}
