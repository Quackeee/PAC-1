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

namespace PAC_1.ViewModels
{
    class CreateReportFormVM : ViewModelBase
    {
        private RelayCommand _createReport;
        public Patient SelectedPatient { get; set; }
        public RelayCommand CreateReport
        {
            get 
            {
                if (_createReport == null)
                {
                    _createReport = new RelayCommand(
                        arg =>
                        {
                            //Data.Patients.RemoveAt(Data.Patients.IndexOf(SelectedPatient));
                            GenerateReport();
                        },
                        arg => SelectedPatient != null || SelectedPatient is null
                        ); ;
                }
                return _createReport;
            }
        }

        public void GenerateReport()
        {
            PdfWriter writer = new PdfWriter("D:\\probny_dokument_wpf.pdf");

            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            Paragraph header = new Paragraph("Header")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);


            document.Add(header);
            document.Close();
        }
    }
}
