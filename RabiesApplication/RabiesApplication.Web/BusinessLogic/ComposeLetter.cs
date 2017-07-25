using System;
using System.Linq;
using Microsoft.Office.Interop.Word;
using System.Web;
using System.Web.DynamicData;
using Microsoft.Office.Core;
using RabiesApplication.Models;

namespace RabiesApplication.Web.BusinessLogic
{
    public class ComposeLetter
    {
        private Application WordApplication = new Application();
        private Document Document ;
        private static readonly string DocumentSavePath = "C:\\Users\\Sagar\\Desktop\\";
        private static readonly string HeaderImage = HttpContext.Current.Server.MapPath("~/Content/images/Header_Ccbh.png");
        private Bite Bite;

        public ComposeLetter(Bite bite)
        {
            Document = WordApplication.Documents.Add();
            Bite = bite;
        }

        private void AddHeaderImage()
        {
            Section firstSection = Document.Sections.First;
            firstSection.PageSetup.TopMargin = (float)100.00;
            HeaderFooter header = firstSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
            header.Shapes.AddPicture(HeaderImage,Top:-30);
            
        }

        private void Address()
        {
            #region Date
                WordApplication.Selection.TypeText(DateTime.Now.ToShortDateString() + Environment.NewLine);
            #endregion

            #region Address
                string address = "Name" + Environment.NewLine
                                + "Address" + "\t\t\t" + " ANIMAL QUARANTINE ORDER " + Environment.NewLine
                                + "City,State,Zip" + Environment.NewLine;

                WordApplication.Selection.Range.Paragraphs.SpaceAfter = (float)0.0;
                WordApplication.Selection.TypeText(address);
                WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;
            #endregion
        }

        private  void AddFooterContact()
        {
            var footerTextbox = Document.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, PointToInches(1.0F), PointToInches(9.8F), 130, 70);
            footerTextbox.Select();
            footerTextbox.Line.Visible = MsoTriState.msoFalse;

            WordApplication.Selection.Range.Paragraphs.SpaceBefore = 0.0F;
            WordApplication.Selection.Range.Paragraphs.SpaceAfter = 0.0F;
            WordApplication.Selection.TypeText("Stacey Short, RS, MPH" + Environment.NewLine);
            WordApplication.Selection.TypeText("Program Manager" + Environment.NewLine);
            WordApplication.Selection.TypeText("216-201-2001 ext. 1253" + Environment.NewLine);
            WordApplication.Selection.TypeText("sshort@ccbh.net" + Environment.NewLine);
        }


       

        public void TenDayQuarantineLetterSame()
        {
            AddHeaderImage();

            Address();

            #region Greeting
            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
            #endregion

            #region FirstParagraph

            string firstparagraph;
                firstparagraph = "Our office has received a report that your pet" +
                                        " '[Pet Name]' bit you, a family member, or a member " +
                                        "of your household on [biteDate]." + Environment.NewLine;
           


            WordApplication.Selection.TypeText(firstparagraph);
            #endregion

            #region SecondParagraph

            string secondparagraph = "Ohio law* requires us to follow up on this report because dogs, cats, and other animals can carry rabies" +
                                    " and pass it on to people and animals through a bite or scratch. Rabies is a very serious diseases." +
                                    " There is no treatment once symtoms begin and the disease can kill you." + Environment.NewLine;
            WordApplication.Selection.TypeText(secondparagraph);
            #endregion

            #region ThirdParagraph
            WordApplication.Selection.Font.Bold = 10;
            string thirdparagraph = "Ohio law* says that:" + Environment.NewLine;
            WordApplication.Selection.TypeText(thirdparagraph);

            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;
            WordApplication.Selection.TypeText("You must quarantine your pet for 10 days, starting the day of the incident, and" + Environment.NewLine);
            WordApplication.Selection.TypeText("You must show proof that your pet has a current rabies vaccination from a veterinarian." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

            #endregion

            #region ForthParagraph

            WordApplication.Selection.Font.Bold = 10;
            WordApplication.Selection.TypeText("To quarantine your pet, you must do these things:" + Environment.NewLine);
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

            WordApplication.Selection.TypeText("Keep your pet at home or at an approved kennel." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet away from people and other animals." + Environment.NewLine);
            WordApplication.Selection.TypeText("Watch your pet to be sure it stays healthy. If your pet starts to show signs of illness or strange behavior," +
                                               " please call your vet and our office immediately." + Environment.NewLine);
            WordApplication.Selection.TypeText("If you decide to have your pet put down or if your pet dies, then it must be tested for rabies. Contact" +
                                               " your vet and our office to determine the procedures for testing." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

            #endregion

            #region FifthParagraph

            WordApplication.Selection.Font.Bold = 10;
            WordApplication.Selection.TypeText("At the end of the 10 days:" + Environment.NewLine);
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

            WordApplication.Selection.TypeText("Our office will contact you to make sure that your pet has successfully completed the quarantine. An" +
                                               " animal that successfully completes the quarantine is one that is still alive and showing no signs of illness" +
                                               " or strange behavior." + Environment.NewLine);


                WordApplication.Selection.TypeText("If your pet has a current rabies vaccination: Fill out the Pet Owner Section of the enclosed Rabies " +
                                                   "Vaccination & Quarantine Release form and send it to us by mail, " +
                                                   "fax at 216-676-1316, or email at sshort@ccbh.net. Please be sure to check the box for " +
                                                   "Yes, my animal successfully completed the quarantine." + Environment.NewLine);



            WordApplication.Selection.TypeText("If your pet does not have a rabies vaccination: You are required to take your pet to a " +
                                               "veterinarian on or shortly after day 10 to receive a rabies vaccination and to have the release " +
                                               "form completed. Your pet must stay in quarantine until our office receives the completed release " +
                                               "form from the veterinarian." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;
            #endregion

            #region ContactInfomration
            WordApplication.Selection.TypeText("Thank you for your cooperation. Please contact us at 216-201-2001 ext. 1253 with questions.");
            AddFooterContact();
            #endregion

            //Save Document
            SaveFile();
        }

        public void TenDayQuarantineLetterDifferent()
        {
            AddHeaderImage();

            Address();

            #region Greeting
            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
            #endregion

            #region FirstParagraph

            string firstparagraph;
            
                firstparagraph = "Our office has received a report that your pet [pet name] bit someone on [biteDate]." + Environment.NewLine;
            


            WordApplication.Selection.TypeText(firstparagraph);
            #endregion

            #region SecondParagraph

            string secondparagraph = "Ohio law* requires us to follow up on this report because dogs, cats, and other animals can carry rabies" +
                                    " and pass it on to people and animals through a bite or scratch. Rabies is a very serious diseases." +
                                    " There is no treatment once symtoms begin and the disease can kill you." + Environment.NewLine;
            WordApplication.Selection.TypeText(secondparagraph);
            #endregion

            #region ThirdParagraph
            WordApplication.Selection.Font.Bold = 10;
            string thirdparagraph = "Ohio law* says that:" + Environment.NewLine;
            WordApplication.Selection.TypeText(thirdparagraph);

            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;
            WordApplication.Selection.TypeText("You must quarantine your pet for 10 days, starting the day of the incident, and" + Environment.NewLine);
            WordApplication.Selection.TypeText("You must show proof that your pet has a current rabies vaccination from a veterinarian." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

            #endregion

            #region ForthParagraph

            WordApplication.Selection.Font.Bold = 10;
            WordApplication.Selection.TypeText("To quarantine your pet, you must do these things:" + Environment.NewLine);
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

            WordApplication.Selection.TypeText("Keep your pet at home or at an approved kennel." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet away from people and other animals." + Environment.NewLine);
            WordApplication.Selection.TypeText("Watch your pet to be sure it stays healthy. If your pet starts to show signs of illness or strange behavior," +
                                               " please call your vet and our office immediately." + Environment.NewLine);
            WordApplication.Selection.TypeText("If you decide to have your pet put down or if your pet dies, then it must be tested for rabies. Contact" +
                                               " your vet and our office to determine the procedures for testing." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

            #endregion

            #region FifthParagraph

            WordApplication.Selection.Font.Bold = 10;
            WordApplication.Selection.TypeText("At the end of the 10 days:" + Environment.NewLine);
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

            WordApplication.Selection.TypeText("Our office will contact you to make sure that your pet has successfully completed the quarantine. An" +
                                               " animal that successfully completes the quarantine is one that is still alive and showing no signs of illness" +
                                               " or strange behavior." + Environment.NewLine);

            
                WordApplication.Selection.TypeText("If your pet has a current rabies vaccination: Contact us at 216-201-2001 ext. 1253" +
                                                   " or at sshort@ccbh.net to provide the name of the veterinary hospital at which it was given." + Environment.NewLine);
            

            WordApplication.Selection.TypeText("If your pet does not have a rabies vaccination: You are required to take your pet to a " +
                                               "veterinarian on or shortly after day 10 to receive a rabies vaccination and to have the release " +
                                               "form completed. Your pet must stay in quarantine until our office receives the completed release " +
                                               "form from the veterinarian." + Environment.NewLine);

            WordApplication.Selection.Range.ListFormat.RemoveNumbers();
            WordApplication.Selection.Font.Bold = 0;
            WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;
            #endregion

            #region ContactInfomration
            WordApplication.Selection.TypeText("Thank you for your cooperation. Please contact us at 216-201-2001 ext. 1253 with questions.");
            AddFooterContact();
            #endregion

            //Save Document
            SaveFile();
        }

        public void WildUnknowAnimal() { }

        public void SixMonthQuarantine() { }

        public void TenDayQuarantineShelter() { }

        public void FourFiveDayQuarantine() { }


        private void SaveFile()
        {
            Guid filename = Guid.NewGuid();
            //Todo : Need to save the binary data to a table for reproduction of all communications.
            Document.SaveAs(DocumentSavePath + filename.ToString() + ".docx");
            WordApplication.Application.Quit();
        }

        #region Helper
        private static float PointToInches(float point)
        {
            return point * 72.0F;
        }
        #endregion

        #region CommentCode
        //private void GenerateTenDayQuarantineLetter(bool ownerVictimSame)
        //{
        //    AddHeaderImage();

        //    Address();

        //    #region Greeting
        //        WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
        //    #endregion

        //    #region FirstParagraph

        //    string firstparagraph;
        //    if (ownerVictimSame)
        //    {
        //        firstparagraph = "Our office has received a report that your pet" +
        //                                " '[Pet Name]' bit you, a family member, or a member " +
        //                                "of your household on [biteDate]." + Environment.NewLine;
        //    }
        //    else
        //    {
        //        firstparagraph ="Our office has received a report that your pet [pet name] bit someone on [biteDate]." +Environment.NewLine;
        //    }


        //        WordApplication.Selection.TypeText(firstparagraph);
        //    #endregion

        //    #region SecondParagraph

        //        string secondparagraph ="Ohio law* requires us to follow up on this report because dogs, cats, and other animals can carry rabies" +
        //                                " and pass it on to people and animals through a bite or scratch. Rabies is a very serious diseases." +
        //                                " There is no treatment once symtoms begin and the disease can kill you." + Environment.NewLine;
        //        WordApplication.Selection.TypeText(secondparagraph);
        //    #endregion

        //    #region ThirdParagraph
        //        WordApplication.Selection.Font.Bold = 10;
        //        string thirdparagraph = "Ohio law* says that:" + Environment.NewLine;
        //        WordApplication.Selection.TypeText(thirdparagraph);

        //        WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
        //        WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;
        //        WordApplication.Selection.TypeText("You must quarantine your pet for 10 days, starting the day of the incident, and" + Environment.NewLine);
        //        WordApplication.Selection.TypeText("You must show proof that your pet has a current rabies vaccination from a veterinarian." + Environment.NewLine);

        //        WordApplication.Selection.Range.ListFormat.RemoveNumbers();
        //        WordApplication.Selection.Font.Bold = 0;
        //        WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

        //    #endregion

        //    #region ForthParagraph

        //    WordApplication.Selection.Font.Bold = 10;
        //        WordApplication.Selection.TypeText("To quarantine your pet, you must do these things:" + Environment.NewLine);
        //        WordApplication.Selection.Font.Bold = 0;
        //        WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
        //        WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

        //        WordApplication.Selection.TypeText("Keep your pet at home or at an approved kennel." + Environment.NewLine);
        //        WordApplication.Selection.TypeText("Keep your pet away from people and other animals." + Environment.NewLine);
        //        WordApplication.Selection.TypeText("Watch your pet to be sure it stays healthy. If your pet starts to show signs of illness or strange behavior," +
        //                                           " please call your vet and our office immediately." + Environment.NewLine);
        //        WordApplication.Selection.TypeText("If you decide to have your pet put down or if your pet dies, then it must be tested for rabies. Contact" +
        //                                           " your vet and our office to determine the procedures for testing." + Environment.NewLine);

        //        WordApplication.Selection.Range.ListFormat.RemoveNumbers();
        //        WordApplication.Selection.Font.Bold = 0;
        //        WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;

        //    #endregion

        //    #region FifthParagraph

        //    WordApplication.Selection.Font.Bold = 10;
        //        WordApplication.Selection.TypeText("At the end of the 10 days:" + Environment.NewLine);
        //        WordApplication.Selection.Font.Bold = 0;
        //        WordApplication.Selection.Range.ListFormat.ApplyBulletDefault();
        //        WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)0.00;

        //        WordApplication.Selection.TypeText("Our office will contact you to make sure that your pet has successfully completed the quarantine. An" +
        //                                           " animal that successfully completes the quarantine is one that is still alive and showing no signs of illness" +
        //                                           " or strange behavior." + Environment.NewLine);

        //    if (ownerVictimSame)
        //    {
        //        WordApplication.Selection.TypeText("If your pet has a current rabies vaccination: Fill out the Pet Owner Section of the enclosed Rabies " +
        //                                           "Vaccination & Quarantine Release form and send it to us by mail, " +
        //                                           "fax at 216-676-1316, or email at sshort@ccbh.net. Please be sure to check the box for " +
        //                                           "Yes, my animal successfully completed the quarantine." + Environment.NewLine);
        //    }
        //    else
        //    {
        //        WordApplication.Selection.TypeText("If your pet has a current rabies vaccination: Contact us at 216-201-2001 ext. 1253" +
        //                                           " or at sshort@ccbh.net to provide the name of the veterinary hospital at which it was given." + Environment.NewLine);
        //    }



        //        WordApplication.Selection.TypeText("If your pet does not have a rabies vaccination: You are required to take your pet to a " +
        //                                           "veterinarian on or shortly after day 10 to receive a rabies vaccination and to have the release " +
        //                                           "form completed. Your pet must stay in quarantine until our office receives the completed release " +
        //                                           "form from the veterinarian." + Environment.NewLine);

        //    WordApplication.Selection.Range.ListFormat.RemoveNumbers();
        //    WordApplication.Selection.Font.Bold = 0;
        //    WordApplication.Selection.Range.Paragraphs.SpaceBefore = (float)10.00;
        //    #endregion

        //    #region ContactInfomration
        //        WordApplication.Selection.TypeText("Thank you for your cooperation. Please contact us at 216-201-2001 ext. 1253 with questions.");
        //        AddFooterContact();
        //    #endregion

        //}

        #endregion
    }
}
