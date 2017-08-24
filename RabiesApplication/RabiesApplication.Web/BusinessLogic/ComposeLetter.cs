using System;
using System.Linq;
using System.Text;
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
        private Animal Animal;
        private PetOwner PetOwner;

        public ComposeLetter(Bite bite)
        {
            Document = WordApplication.Documents.Add();
            Bite = bite;
            Animal = bite.Animals.First(a => a.IsVictim.Equals(false));
            PetOwner = Animal.PetOwner;
        }

        private void AddHeaderImage()
        {
            Section firstSection = Document.Sections.First;
            firstSection.PageSetup.TopMargin = (float)100.00;
            HeaderFooter header = firstSection.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
            header.Shapes.AddPicture(HeaderImage,Top:-30);
            
        }

        private void PrintAddress()
        {
            
        }

        private void PrintAddress(string firstname,string lastname,string addressline1,string addressline2,string city,string state, int? zip)
        {
            #region Date
                WordApplication.Selection.TypeText(DateTime.Now.ToShortDateString() + Environment.NewLine);
            #endregion

            #region Address

            StringBuilder stringBuilder = new StringBuilder();
            if (firstname!=null)
            {
                stringBuilder.Append("Name : ");
                stringBuilder.Append(firstname);
                stringBuilder.Append(lastname);
                stringBuilder.Append(Environment.NewLine);
            }
            if (addressline1!=null)
            {
                stringBuilder.Append("Address : ");
                stringBuilder.Append(addressline1);
                stringBuilder.Append(addressline2);
                stringBuilder.Append("\t\t\t");
                stringBuilder.Append("Animal Quarantine Order");
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(city);
                stringBuilder.Append(state);
                stringBuilder.Append(zip);
                stringBuilder.Append(Environment.NewLine);

            }


            string address = stringBuilder.ToString();
                //string address = "Name" + Environment.NewLine
                //                + "Address" + "\t\t\t" + " ANIMAL QUARANTINE ORDER " + Environment.NewLine
                //                + "City,State,Zip" + Environment.NewLine;

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

        #region InitialLetters
        public void TenDayQuarantineLetterSame()
        {
            AddHeaderImage();

            PrintAddress();

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

            PrintAddress(
                firstname:PetOwner.FirstName
                ,lastname:PetOwner.LastName
                ,addressline1:PetOwner.Addressline1
                ,addressline2:PetOwner.Addressline2
                ,city:PetOwner.City.CityName
                ,state:PetOwner.State.StateName
                ,zip:PetOwner.Zipcode
                );

            #region Greeting
            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
            #endregion

            #region FirstParagraph

            string firstparagraph;
            
                firstparagraph = "Our office has received a report that your pet "+ Animal.Name +" bit someone on "+  Bite.BiteDate.Value.Date.ToString("D") +"." +  Environment.NewLine;
            


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

        public void WildUnknowAnimal()
        {
            AddHeaderImage();
            PrintAddress();

            #region Greeting
            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
            #endregion

            string firstParagraph =
                "As part of our Rabies Prevention Program, The Cuyahoga County Board of Health investigates all reported" +
                "animal bites and potential rabies exposures. We were notified you were bitten by a [animal] on [date]." +
                " Every effort should be made to locate the animal so that it can be properly quarantined or tested for rabies." + Environment.NewLine;

            string secondParagraph =
                "Please contact us upon receiving this letter to provide any additional information you may have regarding the whereabouts of the " +
                "animal. If the animal is a stray, it may be possible for your local animal control office to capture it and submit it to our office" +
                " for rabies testing. If the animal belongs to someone, then our office can contact the owner to verify the health of the animal" +
                " and its rabies vaccination record. If the animal belong to you, then you will simply be required to quarantine the animal for 10 days and then" +
                " provide proof of a rabies vaccination." + Environment.NewLine;

            string thirdParagraph =
                "Rabies is aninfectious disease that is fatal once symptoms begin. The risk for rabies can be controlled by minimizing animal bites" +
                " and exposires and by keeping pets vaccinatied againt the virus. The board of Health recommends that you seek the necessary medical treatment to help prevent" +
                " potential infection. You should also consult with your physician to discuss the risks associated with your potential rabies exposure and whether post-" +
                "exposure prophylaxis should be administered." + Environment.NewLine;

            string fourthParagraph = 
                "Thank you for your cooperation in this matter." + Environment.NewLine;

            WordApplication.Selection.TypeText(firstParagraph);
            WordApplication.Selection.TypeText(secondParagraph);
            WordApplication.Selection.TypeText(thirdParagraph);
            WordApplication.Selection.TypeText(fourthParagraph);

            AddFooterContact();
        }

        public void SixMonthQuarantine()
        {
            AddHeaderImage();
            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:");

            string firstParagraph =
                "Our office has received a report that your pet [Name] was bitten,scratched, or otherwise exposed to [an opossum] on [Date]." + Environment.NewLine;

            string secondParagarph =
                "Ohio law* requires us to follow up on this report because [opossums] can carry rabies and pass it on dogs, who can then pass it to people" +
                ". Rabies is a very serious disease that will almost always kill people if they don't receive immediate medical help after being exposed." + Environment.NewLine;

            string thirdParagraph =
                "Because the [opossum] cannot be tested for rabies, and because your pet does not have an up to date rabies vaccination, Ohio law* required that your pet" +
                " be euthanized by a veterinarian and send for rabies testing OR that it be quarantined for 6 months, starting the day of the incident." + Environment.NewLine;

            WordApplication.Selection.TypeText("");
            WordApplication.Selection.TypeText("To properly quarantine your pet, your must do these things:"+ Environment.NewLine);
            WordApplication.Selection.TypeText("Contact your veterinarian to arrange for a rabies vaccination to be given to your pet immediately." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet confined at home or at an approved kennel." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet away from people and other animals." + Environment.NewLine);
            WordApplication.Selection.TypeText("Watch your pet to be sure it stays healthy." + Environment.NewLine);
            WordApplication.Selection.TypeText("If your pet starts to show signs of illness or strange behaviour, immediately call your vet and our office." + Environment.NewLine);

            WordApplication.Selection.TypeText("");
            WordApplication.Selection.TypeText("After the 6 month quarantine:" + Environment.NewLine);            
            WordApplication.Selection.TypeText("If your pet successfully completes the quarantine, please fill out the Rabies Vaccination & Quarantine " +
                                               "Release form. An animal that successfully completes the quarantine is one that is still alive and showing no signs " +
                                               "of illness or strange behaviour." + Environment.NewLine);
            WordApplication.Selection.TypeText("Check the box for Yes, my animal successfully compelted the quarantine period." + Environment.NewLine);
            WordApplication.Selection.TypeText("Complete the rabies vaccination information." + Environment.NewLine);
            WordApplication.Selection.TypeText("Sign and date the form." + Environment.NewLine);
            WordApplication.Selection.TypeText("Send the form to our office by mail, fax or email." + Environment.NewLine);

            WordApplication.Selection.TypeText("Thank you for your cooperation. Please contact me with any questions or concers that you may have.");

            AddFooterContact();

        }

        public void TenDayQuarantineShelter()
        {
            AddHeaderImage();
            PrintAddress();

            WordApplication.Selection.TypeText("Dear Shelter Staff:");

            string firstParagraph =
                    "Our office has received a report that [Name] bit or scratched someone on [Date]" + Environment.NewLine;

            string secondParagraph =
                "Ohio law* requires us to follow up on this report because dogs, cats, and other animals can carry rabies and pass it on to people and animals through a bite or " +
                "scratch. Rabies is a very serious disease. There is no treatment once symptoms begin and the disease can kill you." + Environment.NewLine;

            WordApplication.Selection.TypeText(firstParagraph);
            WordApplication.Selection.TypeText(secondParagraph);

            WordApplication.Selection.TypeText("");
            WordApplication.Selection.TypeText("Ohio law* says that:" + Environment.NewLine);
            WordApplication.Selection.TypeText("You must quarantine the animal for 10 days, starting the day of the incident, and" + Environment.NewLine);
            WordApplication.Selection.TypeText("You must show proof that the animal has a current rabies vaccination from a licensed veterinarian." + Environment.NewLine);


            WordApplication.Selection.TypeText("To quarantine the animal, you must do there things:" + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep the animal isolated at your shelter or at an approved kennel." + Environment.NewLine);
            WordApplication.Selection.TypeText("Watch the animal to be sure it stays healthy. If the animal starts to show signs of illness or strange " +
                                               "behavior, please call your veterinarian and our office immediately." + Environment.NewLine);
            WordApplication.Selection.TypeText("If the animal is euthanized or dies, then it must be tested for rabies. Contact your veterinarian " +
                                               "and our office to determine the procedures for testing" + Environment.NewLine);


            WordApplication.Selection.TypeText("At the end of the 10 days:" + Environment.NewLine);
            WordApplication.Selection.TypeText("Our office will contact you to make sure that your pet has successfully completed the quarantine. An" +
                                               " animal that successfully completes the quarantine is one that is still alive and showing no signs of illness or strange behaviour." + Environment.NewLine);
            WordApplication.Selection.TypeText("If the animal has a current rabies vaccination: Complete the Pet Owner Section of the enclosed Rabies Vaccination & Quarantine Release" +
                                               " form and send it to us by mail, fax at 216-676-1316, or email at sshort@ccbh.net. Please be sure to check the box for Yes, my animal successfully" +
                                               " completed the quarantine." + Environment.NewLine);
            WordApplication.Selection.TypeText("If the animal does not have a current rabies vaccination. You are required to have the animal examined by a veterinarian on or shortly " +
                                               "after day 10 to receive a rabies vaccination and to have the release form completed. The animal must stay in quarantine until our " +
                                               "office receives the completed release form from the veterinarian" + Environment.NewLine);

            WordApplication.Selection.TypeText("Thank you for your cooperation and please contact me if you have any questions or concerns." + Environment.NewLine);
            
            AddFooterContact();

        }

        public void FourFiveDayQuarantine()
        {
            AddHeaderImage();
            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or MS.:"+Environment.NewLine);

            WordApplication.Selection.TypeText("Our office has received a report that your pet [name] was bitten, scratched, or otherwise exposed to a [raccoon] on [date]."+Environment.NewLine);

            WordApplication.Selection.TypeText("Ohio law* requires us to follow up on this report because [raccoons] can carry rabies and pass it on to pets through a bite, scratch, or other exposure. Pets can then pass" +
                                               " it to people. Rabies is a very serious disease that will almost kill people if they don't receive immediate medical help after being exposed." + Environment.NewLine);

            WordApplication.Selection.TypeText("Because the [raccon] cannot be tested for rabies, Ohio law* requires you to quarantine your pet for 45 days, starting the day of the incident." + Environment.NewLine);

            WordApplication.Selection.TypeText("To properly quarantine your pet, you must do these things:" + Environment.NewLine);
            WordApplication.Selection.TypeText("" + Environment.NewLine);
            WordApplication.Selection.TypeText("Contact your veterinarian to arrange for a rabies vaccination to be given to your pet immediately." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet confined at home or at an approval kennel." + Environment.NewLine);
            WordApplication.Selection.TypeText("Keep your pet away from people and other animals." + Environment.NewLine);
            WordApplication.Selection.TypeText("Watch your pet to be sure it stays healthy." + Environment.NewLine);
            WordApplication.Selection.TypeText("If your pet starts to show signs of illness or strange behaviour, immediately call your vet and our office." + Environment.NewLine);

            WordApplication.Selection.TypeText("After the 45 day quarantine:" + Environment.NewLine);
            WordApplication.Selection.TypeText("If your pet successfully completes the quarantine, please fill out the Rabies Vaccination & Quarantine Release form." +
                                               " An animal that successfully completes the quarantine is one that is still alive and showing no signs of illness or strange behavior." + Environment.NewLine);
            WordApplication.Selection.TypeText("Check the box for Yes, my animal successfully completed the quarantine period." + Environment.NewLine);
            WordApplication.Selection.TypeText("Complete the rabies vaccination information." + Environment.NewLine);
            WordApplication.Selection.TypeText("Sign and date the form." + Environment.NewLine);
            WordApplication.Selection.TypeText("Send the form to our office by mail, fax or email." + Environment.NewLine);
            WordApplication.Selection.TypeText("Thank you for your coorperation. Please contact me with any questions or concerns that you may have." + Environment.NewLine);
            
            AddFooterContact();

        }
#endregion

        #region  FollowUpLetters

        public void NonCompliance_OwnerVictimDifferent_No_Quarantine_No_Vaccination()
        {
            AddHeaderImage();
            PrintAddress();
            WordApplication.Selection.TypeText("Dear Mr. or Ms.:"+Environment.NewLine);

            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name“] " +
                                               "successfully completed the 10 day quarantine, nor have we received " +
                                               "verification of a " +
                                               "current rabies vaccination, following " +
                                               "the biting incident that occurred on [00/00/0000.]  " +
                                               "We have made several attempts to obtain this information from you, " +
                                               "and have also explained that, by law, " +
                                               "the pet must remain in quarantine until it has been " +
                                               "officially released by the Board of Health." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet has a current rabies vaccination, please contact " +
                                               "our office immediately to make arrangements for us to see it." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet does not have a current rabies vaccination, then you are required take it to a " +
                                               "veterinarian to have one given and to have the Rabies Vaccination & Quarantine Release " +
                                               "Form completed and submitted to our office. These items must be completed by [00/00/0000.]" + Environment.NewLine);

            WordApplication.Selection.TypeText("Please contact me with any questions at 216-201-2001 ext. 1253 or at sshort@ccbh.net.");
            WordApplication.Selection.TypeText("Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);
            WordApplication.Selection.TypeText("Sincerely,"+Environment.NewLine);
            AddFooterContact();
        }

        public void NonCompliance_OwnerVictimDifferent_No_Quarantine()
        {
            AddHeaderImage();

            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);

            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name“] successfully completed the 10 day quarantine, " +
                                               "following the biting incident that occurred on [00/00/0000].  We have made several attempts to obtain this " +
                                               "information from you, and have also explained that, by law, the pet must remain " +
                                               "in quarantine until it has been officially released by the Board of Health." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet has a current rabies vaccination, please contact our office immediately to make arrangements for us to see it." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet does not have a current rabies vaccination, then you are required take it to a veterinarian to have one given " +
                                               "and to have the Rabies Vaccination & Quarantine Release Form completed and submitted to our office. " +
                                               "These items must be completed by [00/00/0000]." + Environment.NewLine);

            WordApplication.Selection.TypeText("Please contact me with any questions at 216-201-2001 ext. 1253 or at sshort@ccbh.net.");
            WordApplication.Selection.TypeText("Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);
            WordApplication.Selection.TypeText("Sincerely," + Environment.NewLine);
            AddFooterContact();

        }

        public void NonCompliance_OwnerVictimDifferent_No_Vaccine()
        {
            AddHeaderImage();

            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);

            
            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name”] received a rabies vaccination, following the biting incident " +
                                               "that occurred on [00/00/0000].  We have made several attempts to obtain this information from you, and have also explained that, by law, " +
                                               "the pet must remain in quarantine until a rabies vaccination is administered." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet has a current rabies vaccination, please contact me with the name of the veterinary hospital that gave it." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet does not have a current rabies vaccination, then you are required take it to a veterinarian to have one given and to have " +
                                               "the Rabies Vaccination & Quarantine Release Form completed " +
                                               "and submitted to our office. These items must be completed by [00/00/0000]" + Environment.NewLine);

            WordApplication.Selection.TypeText("Please contact me at 216-201-2001 ext. 1253 or at sshort@ccbh.net with any questions you might have.");
            WordApplication.Selection.TypeText("Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);
            WordApplication.Selection.TypeText("Sincerely," + Environment.NewLine);
            AddFooterContact();
        }

        public void NonComplaince_OwnerVictimSame_No_Quarantine_No_Vaccine()
        {
            AddHeaderImage();

            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);


            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name”] successfully completed the required 10 day quarantine, " +
                                               "nor have we received verification of a current rabies vaccination, following the biting incident that occurred on [00/00/0000].  " +
                                               "We have made several attempts to obtain this information from you, and have also explained that, " +
                                               "by law, the pet must remain in quarantine until a rabies vaccination is administered." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet has a current rabies vaccination, then please complete the Pet Owner Section of the enclosed Rabies " +
                                               "Vaccination & Quarantine Release Form and submit it to our office." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet does not have a current rabies vaccination, then you are required to take it to a veterinarian to have one " +
                                               "administered and to have the Rabies Vaccination and Quarantine Release Form completed." + Environment.NewLine);

            WordApplication.Selection.TypeText("The completed Rabies Vaccination and Quarantine Release Form must be received by our office by [00/00/0000]. Please contact me at 216-201-2001 ext. 1253 or at sshort@ccbh.net with any questions you might have.");

            WordApplication.Selection.TypeText("Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);

            WordApplication.Selection.TypeText("Sincerely," + Environment.NewLine);

            AddFooterContact();
        }

        public void NonComplaince_OwnerVictimSame_No_Quarantine()
        {
            AddHeaderImage();

            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);

            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name”] has successfully completed the 10 day quarantine, " +
                                               "following the biting incident that occurred on [00/00/0000].  " +
                                               "We have made several attempts to contact you and to obtain this information from you." + Environment.NewLine);

            WordApplication.Selection.TypeText("Please complete and submit the Pet Owner section of the enclosed Rabies Vaccination & Quarantine Release Form to our office by fax, mail, " +
                                               "or email at sshort@ccbh.net.  The completed release form must be received by our office by [00/00/0000]. Please contact me with any questions or concerns.  " +
                                               "Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);

            WordApplication.Selection.TypeText("Sincerely," + Environment.NewLine);

            AddFooterContact();
        }

        public void NonCompliance_OwnerVictimSame_No_Vaccine()
        {
            AddHeaderImage();

            PrintAddress();

            WordApplication.Selection.TypeText("Dear Mr. or Ms.:" + Environment.NewLine);
            WordApplication.Selection.TypeText("Our office has not received verification that your pet [“Name”] has a current rabies vaccination, following the biting " +
                                               "incident that occurred on [00/00/0000.]  We have made several attempts to obtain this information from you," +
                                               " and have also explained that, by law, the pet must remain in quarantine until a rabies vaccination is administered." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet has a current rabies vaccination, then please complete the Pet Owner Section of the enclosed Rabies " +
                                               "Vaccination & Quarantine Release Form and submit it to our office." + Environment.NewLine);

            WordApplication.Selection.TypeText("If your pet does not have a current rabies vaccination, then you are required to take it to a veterinarian " +
                                               "to have one administered and to have the Rabies Vaccination and Quarantine Release Form completed." + Environment.NewLine);


            WordApplication.Selection.TypeText("The completed Rabies Vaccination and Quarantine Release Form must be received by our office by [00/00/0000.] " +
                                               "Please contact me at 216-201-2001 ext. 1253 or at sshort@ccbh.net with any questions you might have. " +
                                               "Failure to comply with the requirements set forth in this letter may result in legal action." + Environment.NewLine);

            WordApplication.Selection.TypeText("Sincerely," + Environment.NewLine);
            AddFooterContact();
        }
        //NonCompliance

        #endregion



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
