using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using TheCancerProject.Core;
using TheCancerProject.Data.DAO;

namespace TheCancerProject.ThePages.View
{
    public partial class ViewListOfPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "DownloadPDF":
                        long itemId = Convert.ToInt64(e.CommandArgument);
                        try
                        {
                            CreatePDFDocument(itemId);
                        }
                        catch (Exception ex)
                        {
                            string errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                            {
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + errorMessage.Replace("\n", "").Replace("\r", "") + @""", function(){});</script>", false);
                            }
                        }
                        break;
                    default:
                        break;
                }
                GridView1.DataBind();
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
        private void BindGrid()
        {
            List<TheCancerProject.Core.Patient> patientList = new List<TheCancerProject.Core.Patient>();
            patientList = PatientDAO.RetrieveAll().ToList();
            //if (patient != null && patient.TheBiodata != null && !string.IsNullOrWhiteSpace(patient.TheBiodata.HospitalNumber))
            //{
            //    investigationHistoryForPatient = new InvestigationDAO().RetrieveByPatientHospitalNumber(patient.TheBiodata.HospitalNumber);
            //}
            GridView1.DataSource = patientList;
            GridView1.DataBind();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        public bool CreatePDFDocument(long patientID)
        {
            bool result = false;
            try
            {
                //long thePatientID = Convert.ToInt64(patientID);
                Patient thePatient = new PatientDAO().Retrieve(patientID);
                if (thePatient == null)
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "No Data Exists For This Patiend. Kindly contact admin for confirmation." + "', function(){location = '/Start/Login.aspx';});</script>", false);
                    }
                }
                // Create a Document object
                var document = new Document(PageSize.A4, 50, 50, 25, 25);

                // Create a new PdfWriter object, specifying the output stream
                var output = new MemoryStream();
                var writer = PdfWriter.GetInstance(document, output);

                // Open the Document for writing
                document.Open();

                
                //... Step 3: Add elements to the document! ...
                //...

                var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK);
                var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE);
                var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

                document.Add(new Paragraph("PATIENT DATA SUMMARY", titleFont));
                document.Add(Chunk.NEWLINE);

                var orderInfoTable = new PdfPTable(2);
                orderInfoTable.HorizontalAlignment = 0;
                orderInfoTable.SpacingBefore = 10;
                orderInfoTable.SpacingAfter = 10;
                orderInfoTable.DefaultCell.Border = 0;
                //orderInfoTable.SetWidths(new int[] { 1, 8 });

                //string presentedComplaints = WebObjects.selectedListBoxValues(ddlPresentingComplaints);
                //orderInfoTable.AddCell(new Phrase("Complaints:", boldTableFont));
                //foreach (var item in presentedComplaints.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    orderInfoTable.AddCell(item);
                //}
                document.Add(new Paragraph("BIODATA", subTitleFont));
                //orderInfoTable.AddCell(new Phrase("INVESTIGATION:", subTitleFont));
                if (thePatient.TheBiodata != null)
                {
                    orderInfoTable.AddCell(new Phrase("Title:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(Title), thePatient.TheBiodata.Title));
                    orderInfoTable.AddCell(new Phrase("First Name:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.FirstName);
                    orderInfoTable.AddCell(new Phrase("Last Name:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.LastName);
                    orderInfoTable.AddCell(new Phrase("Date of Birth:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.DateOfBirth.ToString("yyyy-MM-dd"));
                    orderInfoTable.AddCell(new Phrase("Age:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.Age);
                    orderInfoTable.AddCell(new Phrase("Other Names:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.OtherNames);
                    orderInfoTable.AddCell(new Phrase("Hospital Number:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.HospitalNumber);
                    orderInfoTable.AddCell(new Phrase("Sex:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(Sex), thePatient.TheBiodata.Sex));
                    orderInfoTable.AddCell(new Phrase("Address:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.Address);
                    orderInfoTable.AddCell(new Phrase("State of Residence:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(State), thePatient.TheBiodata.StateOfResidence));
                    orderInfoTable.AddCell(new Phrase("Religion:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(Religion), thePatient.TheBiodata.Religion));
                    orderInfoTable.AddCell(new Phrase("Occupation:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.Occupation);
                    orderInfoTable.AddCell(new Phrase("Marital Status:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(MaritalStatus), thePatient.TheBiodata.MaritalStatus));
                    orderInfoTable.AddCell(new Phrase("Phone Number:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.PhoneNumber);
                    orderInfoTable.AddCell(new Phrase("Next of Kin Relationship:", boldTableFont));
                    orderInfoTable.AddCell(Enum.GetName(typeof(Relationship), thePatient.TheBiodata.NextOfKinRelationship));
                    orderInfoTable.AddCell(new Phrase("Next of Kin Name:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.NextOfKinName);
                    orderInfoTable.AddCell(new Phrase("Next of Kin Phone:", boldTableFont));
                    orderInfoTable.AddCell(thePatient.TheBiodata.NextOfKinPhone);
                    document.Add(orderInfoTable);
                }
                document.Add(new Paragraph("HISTORY", subTitleFont));
                //orderInfoTable.AddCell(new Phrase("HISTORY:", subTitleFont));
                var orderInfoTableForHistory = new PdfPTable(2);
                orderInfoTableForHistory.HorizontalAlignment = 0;
                orderInfoTableForHistory.SpacingBefore = 10;
                orderInfoTableForHistory.SpacingAfter = 10;
                orderInfoTableForHistory.DefaultCell.Border = 0;
                if (thePatient.ThePreliminaryExamination != null)
                {
                    orderInfoTableForHistory.AddCell(new Phrase("Past Medical History:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.MedicalHistory);
                    orderInfoTableForHistory.AddCell(new Phrase("Past Surgical History:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.PastSurgicalHistory);
                    orderInfoTableForHistory.AddCell(new Phrase("Parity:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.Parity);
                    orderInfoTableForHistory.AddCell(new Phrase("Menarche:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.Menarche);
                    orderInfoTableForHistory.AddCell(new Phrase("Duration Of Menses (days):", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.DurationOfMenses);
                    orderInfoTableForHistory.AddCell(new Phrase("Length of Menstrual Cycle (days):", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.LengthOfMestrualCycle);
                    orderInfoTableForHistory.AddCell(new Phrase("Routine Medications:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.RoutineMedications);
                    orderInfoTableForHistory.AddCell(new Phrase("Allergic Reactions:", boldTableFont));
                    orderInfoTableForHistory.AddCell(thePatient.ThePreliminaryExamination.AllergicReactions);
                    document.Add(orderInfoTableForHistory);
                }

                document.Add(new Paragraph("COMPLAINTS", subTitleFont));
                //orderInfoTable.AddCell(new Phrase("HISTORY:", subTitleFont));
                var orderInfoTableForComplaints = new PdfPTable(2);
                orderInfoTableForComplaints.HorizontalAlignment = 0;
                orderInfoTableForComplaints.SpacingBefore = 10;
                orderInfoTableForComplaints.SpacingAfter = 10;
                orderInfoTableForComplaints.DefaultCell.Border = 0;
                if (thePatient.TheComplaints != null)
                {
                    orderInfoTableForComplaints.AddCell(new Phrase("Duration of Complaints (days):", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.DurationOfComplaints);
                    orderInfoTableForComplaints.AddCell(new Phrase("History of Presenting Complaints:", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.HistoryOfPresentingComplaints);
                    orderInfoTableForComplaints.AddCell(new Phrase("Complaints:", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.TheComplaints);
                    orderInfoTableForComplaints.AddCell(new Phrase("Cause:", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.TheCause);
                    orderInfoTableForComplaints.AddCell(new Phrase("Complications:", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.TheComplications);
                    orderInfoTableForComplaints.AddCell(new Phrase("Care:", boldTableFont));
                    orderInfoTableForComplaints.AddCell(thePatient.TheComplaints.TheCare);
                    document.Add(orderInfoTableForComplaints);
                }

                document.Add(new Paragraph("EXAMINATION", subTitleFont));
                //orderInfoTable.AddCell(new Phrase("EXAMINATION:", subTitleFont));
                var orderInfoTableForExamination = new PdfPTable(2);
                orderInfoTableForExamination.HorizontalAlignment = 0;
                orderInfoTableForExamination.SpacingBefore = 10;
                orderInfoTableForExamination.SpacingAfter = 10;
                orderInfoTableForExamination.DefaultCell.Border = 0;
                if (thePatient.TheBreastAndAxillaryExamination != null)
                {
                }
                if (thePatient.TheGeneralExamination != null)
                {
                    orderInfoTableForExamination.AddCell(new Phrase("General Exam:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.TheGeneralExam);
                    orderInfoTableForExamination.AddCell(new Phrase("Weight (kg):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.Weight);
                    orderInfoTableForExamination.AddCell(new Phrase("Height (m):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.Height);
                    orderInfoTableForExamination.AddCell(new Phrase("BMI(kg/m^2):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.BMI);
                    orderInfoTableForExamination.AddCell(new Phrase("BSA(m^2):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.BSA);
                    orderInfoTableForExamination.AddCell(new Phrase("Temperature:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.Temperature);
                    //orderInfoTableForExamination.AddCell(new Phrase("Texture:", boldTableFont));
                    //orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.TheTexture);
                    orderInfoTableForExamination.AddCell(new Phrase("Location of Lesion:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.TheLocationOfLesion);
                    orderInfoTableForExamination.AddCell(new Phrase("Other Observations:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.OtherObservations);
                    orderInfoTableForExamination.AddCell(new Phrase("Symmetry:", boldTableFont));
                    orderInfoTableForExamination.AddCell(Enum.GetName(typeof(Symmetry), thePatient.TheGeneralExamination.TheSymmetry));
                    orderInfoTableForExamination.AddCell(new Phrase("Shape:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.Shape);
                    orderInfoTableForExamination.AddCell(new Phrase("Quadrant Located:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.QuadrantLocated);
                    orderInfoTableForExamination.AddCell(new Phrase("Color of Skin Area:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.ColorOfSkinArea);
                    orderInfoTableForExamination.AddCell(new Phrase("Blood Pressure:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.BloodPressure);
                    orderInfoTableForExamination.AddCell(new Phrase("Respiratory Rate (Cyc/min):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.RespiratoryRate);
                    orderInfoTableForExamination.AddCell(new Phrase("Heart Sounds:", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.HeartSounds);
                    orderInfoTableForExamination.AddCell(new Phrase("Pulse Rate (b/min):", boldTableFont));
                    orderInfoTableForExamination.AddCell(thePatient.TheGeneralExamination.PulseRate);
                    document.Add(orderInfoTableForExamination);
                }
                document.Add(new Paragraph("DIAGNOSIS", subTitleFont));
                //orderInfoTable.AddCell(new Phrase("DIAGNOSIS:", subTitleFont));
                var orderInfoTableForDiagnosis = new PdfPTable(2);
                orderInfoTableForDiagnosis.HorizontalAlignment = 0;
                orderInfoTableForDiagnosis.SpacingBefore = 10;
                orderInfoTableForDiagnosis.SpacingAfter = 10;
                orderInfoTableForDiagnosis.DefaultCell.Border = 0;
                if (thePatient.TheDiagnoses != null)
                {
                    string initialDiagnosis = (!string.IsNullOrWhiteSpace(thePatient.TheDiagnoses.InitialDiagnosis)) ? TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer.Where(x => x.Key.Trim().Equals(thePatient.TheDiagnoses.InitialDiagnosis.Trim())).FirstOrDefault().Value : string.Empty;
                    string finalDiagnosis = (!string.IsNullOrWhiteSpace(thePatient.TheDiagnoses.FinalDiagnosis)) ? TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer.Where(x => x.Key.Trim().Equals(thePatient.TheDiagnoses.FinalDiagnosis.Trim())).FirstOrDefault().Value : string.Empty;
                    string admissionDate = (thePatient.TheDiagnoses.AdmissionDate.HasValue) ? thePatient.TheDiagnoses.AdmissionDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    string dischargeDate = (thePatient.TheDiagnoses.DischargeDate.HasValue) ? thePatient.TheDiagnoses.DischargeDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    orderInfoTableForDiagnosis.AddCell(new Phrase("Initial Diagnosis:", boldTableFont));
                    orderInfoTableForDiagnosis.AddCell(initialDiagnosis);
                    orderInfoTableForDiagnosis.AddCell(new Phrase("Plan:", boldTableFont));
                    orderInfoTableForDiagnosis.AddCell(thePatient.TheDiagnoses.ThePlan);
                    orderInfoTableForDiagnosis.AddCell(new Phrase("Admission Date:", boldTableFont));
                    orderInfoTableForDiagnosis.AddCell(admissionDate);
                    orderInfoTableForDiagnosis.AddCell(new Phrase("Discharge Date:", boldTableFont));
                    orderInfoTableForDiagnosis.AddCell(dischargeDate);
                    orderInfoTableForDiagnosis.AddCell(new Phrase("Final Diagnosis:", boldTableFont));
                    orderInfoTableForDiagnosis.AddCell(finalDiagnosis);
                    document.Add(orderInfoTableForDiagnosis);
                }
                if (thePatient.TheInvestigation != null)
                {
                }
                //orderInfoTable.AddCell(new Phrase("Duration:", boldTableFont));
                //orderInfoTable.AddCell((TxtDuration.Value));

                

                // Close the Document - this saves the document contents to the output stream
                document.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}_{1}.pdf", (thePatient != null && thePatient. TheBiodata != null) ? thePatient.TheBiodata.Name : "PATIENT", DateTime.Now.ToShortDateString()));
                //Response.Write(output);
                Response.BinaryWrite(output.ToArray());
                //Response.WriteFile(output.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + errorMessage.Replace("\n", "").Replace("\r", "") + @""", function(){});</script>", false);
                }
            }
            return result;          
        }
    }
}