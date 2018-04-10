using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCancerProject.Core;
using TheCancerProject.Data.DAO;

namespace TheCancerProject.ThePages.Create
{
    public partial class PresentingComplaints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          

            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.PresentedComplaints), ddlPresentingComplaints);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.Cause), ddlCause);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.Complications), ddlComplications);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.Care), ddlCare);

            #region displays the values from DB (including Listbox values)
            //long theID = 1;
            //Complaints theComp = new ComplaintsDAO().Retrieve(theID);
            //TxtDuration.Value = theComp.DurationOfComplaints;
            //txtHistoryOfComplaints.Value = theComp.HistoryOfPresentingComplaints;
            //WebObjects.displayStoredSelectedListBoxValues(theComp.TheComplaints, ddlPresentingComplaints);
            //WebObjects.displayStoredSelectedListBoxValues(theComp.TheComplications, ddlComplications);
            //WebObjects.displayStoredSelectedListBoxValues(theComp.TheCause, ddlCause);
            //WebObjects.displayStoredSelectedListBoxValues(theComp.TheCare, ddlCare);
            #endregion

            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheComplaints != null)
            {
                TxtDuration.Value = patient.TheComplaints.DurationOfComplaints;
                txtHistoryOfComplaints.Value = patient.TheComplaints.HistoryOfPresentingComplaints;
                WebObjects.displayStoredSelectedListBoxValues(patient.TheComplaints.TheComplaints, ddlPresentingComplaints);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheComplaints.TheComplications, ddlComplications);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheComplaints.TheCause, ddlCause);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheComplaints.TheCare, ddlCare);
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Complaints complaintToReplace = new Complaints(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {                    
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }

                string presentedComplaints = WebObjects.selectedListBoxValues(ddlPresentingComplaints);
                string cause = WebObjects.selectedListBoxValues(ddlCause);
                string complications = WebObjects.selectedListBoxValues(ddlComplications);
                string care = WebObjects.selectedListBoxValues(ddlCare);

                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.Complaints theComplaint = new Core.Complaints();
                //theBiodata = theBiodataList.First();
                theComplaint.DurationOfComplaints = (string.IsNullOrWhiteSpace(TxtDuration.Value)) ?TxtDuration.Value : TxtDuration.Value.Trim();
                theComplaint.HistoryOfPresentingComplaints = (string.IsNullOrWhiteSpace(txtHistoryOfComplaints.Value)) ? txtHistoryOfComplaints.Value : txtHistoryOfComplaints.Value.Trim();
                theComplaint.TheComplaints = presentedComplaints;
                theComplaint.TheCause = cause;
                theComplaint.TheComplications = complications;
                theComplaint.TheCare = care;
                theComplaint.DateCreated = DateTime.Now;
                theComplaint.DateUpdated = DateTime.Now;
                theComplaint.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata :null, TheHospital = (thePatient != null) ? thePatient.TheHospital :null, TheBreastAndAxillaryExamination = (thePatient != null) ?thePatient.TheBreastAndAxillaryExamination :null, TheComplaints = theComplaint, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission :null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ?thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ?thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                
                if(thePatient != null)  //HINT:Manually Create
                thePatient.TheComplaints = theComplaint; 
                else
                   thePatient = thePatientToSave;
                

                if (thePatientToVerify == null) //nothing in session
                {
                    ComplaintsDAO.Save(theComplaint);
                    PatientDAO.Save(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheComplaints != null && thePatientToVerify.TheComplaints.Id <= 0)//HINT:Manually Create
                {
                    ComplaintsDAO.Save(theComplaint);
                    complaintToReplace = new ComplaintsDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheComplaints = complaintToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheComplaints != null && thePatientToVerify.TheComplaints.Id > 0 && thePatientToVerify.TheComplaints != theComplaint)//HINT:Manually Create
                {
                    theComplaint.Id = thePatient.TheComplaints.Id; //HINT:Manually Create
                    ComplaintsDAO.Update(theComplaint);
                    complaintToReplace = new ComplaintsDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheComplaints = complaintToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else if (thePatientToVerify.TheComplaints != null && thePatientToVerify.TheComplaints == theComplaint)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/Start/Login.aspx';});</script>", false);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + errorMessage.Replace("\n", "").Replace("\r", "") + @""", function(){});</script>", false);
                }

            }


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);
            //HtmlTextWriter writer = new HtmlTextWriter(sw);
            //Renderer(writer);
            CreatePDFDocument();
        }
        //protected void Renderer(HtmlTextWriter writer)
        //{
        //    MemoryStream mem = new MemoryStream();
        //    StreamWriter twr = new StreamWriter(mem);
        //    HtmlTextWriter myWriter = new HtmlTextWriter(twr);
        //    base.Render(myWriter);
        //    myWriter.Flush();
        //    myWriter.Dispose();
        //    StreamReader strmRdr = new StreamReader(mem);
        //    strmRdr.BaseStream.Position = 0;
        //    string pageContent = strmRdr.ReadToEnd();
        //    strmRdr.Dispose();
        //    mem.Dispose();
        //    writer.Write(pageContent);
        //    CreatePDFDocument(pageContent);


        //}
        //protected override void Render(HtmlTextWriter writer)
        //{
        //    MemoryStream mem = new MemoryStream();
        //    StreamWriter twr = new StreamWriter(mem);
        //    HtmlTextWriter myWriter = new HtmlTextWriter(twr);
        //    base.Render(myWriter);
        //    myWriter.Flush();
        //    myWriter.Dispose();
        //    StreamReader strmRdr = new StreamReader(mem);
        //    strmRdr.BaseStream.Position = 0;
        //    string pageContent = strmRdr.ReadToEnd();
        //    strmRdr.Dispose();
        //    mem.Dispose();
        //    writer.Write(pageContent);
        //    CreatePDFDocument(pageContent);


        //}
        //public void CreatePDFDocument(string strHtml)
        //{

        //    string strFileName = HttpContext.Current.Server.MapPath("test.pdf");
        //    // step 1: creation of a document-object 
        //    Document document = new Document();
        //    // step 2: 
        //    // we create a writer that listens to the document 
        //    PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
        //    StringReader se = new StringReader(strHtml);
        //    HTMLWorker obj = new HTMLWorker(document);
        //    document.Open();
        //    //document.Add(se);
        //    obj.Parse(se);
        //    document.Close();
        //    ShowPdf(strFileName);



        //}
        public void CreatePDFDocument()
        {
            // Create a Document object
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            //... Step 3: Add elements to the document! ...
            //...

            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            var orderInfoTable = new PdfPTable(2);
            orderInfoTable.HorizontalAlignment = 0;
            orderInfoTable.SpacingBefore = 10;
            orderInfoTable.SpacingAfter = 10;
            orderInfoTable.DefaultCell.Border = 0;
            orderInfoTable.SetWidths(new int[] { 1, 4 });

            string presentedComplaints = WebObjects.selectedListBoxValues(ddlPresentingComplaints);
            orderInfoTable.AddCell(new Phrase("Complaints:", boldTableFont));
            foreach (var item in presentedComplaints.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                orderInfoTable.AddCell(item);
            }            
            orderInfoTable.AddCell(new Phrase("Duration:", boldTableFont));
            orderInfoTable.AddCell((TxtDuration.Value));

            document.Add(orderInfoTable);

            // Close the Document - this saves the document contents to the output stream
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename=Receipt-{0}.pdf", DateTime.Now.ToShortDateString()));
            //Response.Write(output);
            Response.BinaryWrite(output.ToArray());
            //Response.WriteFile(output.ToString());
        }
        public void ShowPdf(string strFileName)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
            Response.ContentType = "application/pdf";
            Response.WriteFile(strFileName);
            Response.Flush();
            Response.Clear();
        }


    }
        
    }   


