using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCancerProject.Core;
using TheCancerProject.Data.DAO;

namespace TheCancerProject.ThePages.Create
{
    public partial class HistoryAndPreliminaryExamination : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.PastMedicalHistory), ddlPastMedHistory);
            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.ThePreliminaryExamination != null)
            {
                txtAllergicReactions.Value = patient.ThePreliminaryExamination.AllergicReactions;
                txtDurationOfMenses.Value = patient.ThePreliminaryExamination.DurationOfMenses;
                txtLengthOfMenstrualCycle.Value = patient.ThePreliminaryExamination.LengthOfMestrualCycle;
                txtParity.Value = patient.ThePreliminaryExamination.Parity;
                txtPastSurgicalHistory.Value = patient.ThePreliminaryExamination.PastSurgicalHistory;
                txtRoutineMedications.Value = patient.ThePreliminaryExamination.RoutineMedications;
                WebObjects.displayStoredSelectedListBoxValues(patient.ThePreliminaryExamination.MedicalHistory, ddlPastMedHistory);
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/GeneralExamination.aspx", false);
                }

                string pastMedicalHistory = WebObjects.selectedListBoxValues(ddlPastMedHistory);

                //TheCancerProject.Core.PreliminaryExamination thePreliminaryExamInSession = (thePatient != null) ? thePatient.ThePreliminaryExamination : null;
                TheCancerProject.Core.PreliminaryExamination thePreliminaryExam = new Core.PreliminaryExamination();
                //theBiodata = theBiodataList.First();
                thePreliminaryExam.AllergicReactions = (string.IsNullOrWhiteSpace(txtAllergicReactions.Value)) ? txtAllergicReactions.Value : txtAllergicReactions.Value.Trim();
                thePreliminaryExam.DurationOfMenses = (string.IsNullOrWhiteSpace(txtDurationOfMenses.Value)) ? txtDurationOfMenses.Value : txtDurationOfMenses.Value.Trim();
                thePreliminaryExam.LengthOfMestrualCycle = (string.IsNullOrWhiteSpace(txtLengthOfMenstrualCycle.Value)) ? txtLengthOfMenstrualCycle.Value : txtLengthOfMenstrualCycle.Value.Trim();
                thePreliminaryExam.Parity = (string.IsNullOrWhiteSpace(txtParity.Value)) ? txtParity.Value : txtParity.Value.Trim();
                thePreliminaryExam.PastSurgicalHistory = (string.IsNullOrWhiteSpace(txtPastSurgicalHistory.Value)) ? txtPastSurgicalHistory.Value : txtPastSurgicalHistory.Value.Trim();
                thePreliminaryExam.RoutineMedications = (string.IsNullOrWhiteSpace(txtRoutineMedications.Value)) ? txtRoutineMedications.Value : txtRoutineMedications.Value.Trim();
                thePreliminaryExam.MedicalHistory = pastMedicalHistory;
                thePreliminaryExam.DateCreated = DateTime.Now;
                thePreliminaryExam.DateUpdated = DateTime.Now;
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                //thePatient.TheBiodata = theBiodata;
                //thePatient.TheComplaints = theComplaint;  
                thePatient = thePatientToSave;
                SessionObjects.ThePatient = thePatient;
                if (thePatientToVerify.ThePreliminaryExamination == null)
                {
                    PreliminaryExamDAO.Save(thePreliminaryExam);
                    PatientDAO.Save(thePatientToSave);
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else if (thePatientToVerify.ThePreliminaryExamination != null && thePatientToVerify.ThePreliminaryExamination != thePreliminaryExam)
                {
                    PreliminaryExamDAO.Save(thePreliminaryExam);
                    PatientDAO.Update(thePatientToSave);
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                else if (thePatientToVerify.ThePreliminaryExamination != null && thePatientToVerify.ThePreliminaryExamination == thePreliminaryExam)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/HistoryAndPreliminaryExamination.aspx", false);
                }
                //else if (theBiodataList != null && theBiodataList.Count > 1)
                //{
                //    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                //    {
                //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Multiple Biodata Exists for this patient. Kindly contact admin!!!" + "', function(){location = '/Start/Login.aspx';});</script>", false);
                //    }
                //}
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/Start/Login.aspx';});</script>", false);
                    }
                }
                //if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Admin Saved Successfully" + "', function(){location = '/Start/Login.aspx';});</script>", false);
                //}
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
    }
}