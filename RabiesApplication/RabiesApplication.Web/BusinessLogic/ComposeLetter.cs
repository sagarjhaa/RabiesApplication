using System;
using Microsoft.Office.Interop.Word;
using System.Web;

namespace RabiesApplication.Web.BusinessLogic
{
    public class ComposeLetter
    {
        private Application WordApplication = new Application();
        private Document Document ;//= WordApplication.Documents.Add();
        private static readonly string DocumentSavePath = "C:\\Users\\Sagar\\Desktop\\";
        private static readonly string HeaderImage = HttpContext.Current.Server.MapPath("~/Content/images/Header_Ccbh.png");

        public ComposeLetter()
        {
            Document = WordApplication.Documents.Add();
        }

        private void AddHeaderImage()
        {
            Section firstSection = Document.Sections.First;
            firstSection.PageSetup.TopMargin = (float)100.00;
            HeaderFooter header = firstSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
            header.Shapes.AddPicture(HeaderImage,Top:-30);
            
        }

        private  void AddFooter()
        {
            
        }

        public void TenDayQuarantineLetter()
        {
            this.AddHeaderImage();

            WordApplication.Visible = true;
            WordApplication.Selection.TypeText("Date");

            //Save Document
            SaveFile();
            
        }


        public void SaveFile()
        {
            Guid filename = Guid.NewGuid();
            Document.SaveAs(DocumentSavePath + filename.ToString() + ".docx");
            WordApplication.Application.Quit();
        }
        
    }
}
