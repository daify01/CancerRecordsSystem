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
    public partial class EventsOnAdmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlInitialDiagnosis.DataSource = TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer;
            //ddlInitialDiagnosis.DataTextField = "Key";
            //ddlInitialDiagnosis.DataValueField = "Value";
            //ddlInitialDiagnosis.DataBind();
            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheEventsOnAdmission != null)
            {
                txtDailyUpdatesAndManagement.Value = patient.TheEventsOnAdmission.DailyUpdates;
                txtChemotherapyRegimen.Value = patient.TheEventsOnAdmission.ChemotherapyRegimen;
                txtRadiotherapyRegimen.Value = patient.TheEventsOnAdmission.RadiotherapyRegimen;
                txtComplicationsManagedOnAdmission.Value = patient.TheEventsOnAdmission.ComplicationsManagedOnAdmission;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Core.EventsOnAdmission entityToReplace = new Core.EventsOnAdmission(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/Procedures.aspx", false);
                }
                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.EventsOnAdmission theEventsOnAdmission = new Core.EventsOnAdmission();
                theEventsOnAdmission.DailyUpdates = (string.IsNullOrWhiteSpace(txtDailyUpdatesAndManagement.Value)) ? txtDailyUpdatesAndManagement.Value : txtDailyUpdatesAndManagement.Value.Trim();
                theEventsOnAdmission.ChemotherapyRegimen = (string.IsNullOrWhiteSpace(txtChemotherapyRegimen.Value)) ? txtChemotherapyRegimen.Value : txtChemotherapyRegimen.Value.Trim();
                theEventsOnAdmission.RadiotherapyRegimen = (string.IsNullOrWhiteSpace(txtRadiotherapyRegimen.Value)) ? txtRadiotherapyRegimen.Value : txtRadiotherapyRegimen.Value.Trim();
                theEventsOnAdmission.ComplicationsManagedOnAdmission = (string.IsNullOrWhiteSpace(txtComplicationsManagedOnAdmission.Value)) ? txtComplicationsManagedOnAdmission.Value : txtComplicationsManagedOnAdmission.Value.Trim();
                theEventsOnAdmission.DateCreated = DateTime.Now;
                theEventsOnAdmission.DateUpdated = DateTime.Now;
                theEventsOnAdmission.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = theEventsOnAdmission, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if (thePatient != null)  //HINT:Manually Create
                    thePatient.TheEventsOnAdmission = theEventsOnAdmission;
                else
                    thePatient = thePatientToSave;

                if (thePatientToVerify == null)
                {
                    EventsOnAdmissionDAO.Save(theEventsOnAdmission);
                    PatientDAO.Save(thePatientToSave);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Procedures.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheEventsOnAdmission != null && thePatientToVerify.TheEventsOnAdmission.Id <= 0)
                {
                    EventsOnAdmissionDAO.Save(theEventsOnAdmission);
                    entityToReplace = new EventsOnAdmissionDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheEventsOnAdmission = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Procedures.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheEventsOnAdmission != null && thePatientToVerify.TheEventsOnAdmission.Id > 0 && thePatientToVerify.TheEventsOnAdmission != theEventsOnAdmission)//HINT:Manually Create
                {
                    theEventsOnAdmission.Id = thePatient.TheEventsOnAdmission.Id; //HINT:Manually Create
                    EventsOnAdmissionDAO.Update(theEventsOnAdmission);
                    entityToReplace = new EventsOnAdmissionDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheEventsOnAdmission = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Procedures.aspx", false);
                }
                else if (thePatientToVerify.TheEventsOnAdmission != null && thePatientToVerify.TheEventsOnAdmission == theEventsOnAdmission)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/Procedures.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/ThePages/Create/EventsOnAdmission.aspx';});</script>", false);
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
    }
}