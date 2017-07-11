using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace RabiesApplication.Web.BusinessLogic
{
    public static class ComposeLetter
    {
        private static readonly Application WordApplication = new Application();
        private static readonly Document Document = WordApplication.Documents.Add();
        private static readonly string DocumentSavePath = "C:\\Users\\Sagar\\Desktop\\mydoc.docx";


        //private

        public static void TenDayQuarantineLetter()
        {
            WordApplication.Selection.TypeText("This is document");
            Document.SaveAs(DocumentSavePath);
            WordApplication.Application.Quit();
        }



    }
}
