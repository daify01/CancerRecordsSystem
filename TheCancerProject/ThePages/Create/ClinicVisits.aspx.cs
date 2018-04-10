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
    public partial class ClinicVisits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Core.ClinicVisits entityToReplace = new Core.ClinicVisits(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
                }
                if (string.IsNullOrWhiteSpace(dateAppointmentDate.Value))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Please Enter a valid Date Of Birth" + "', function(){location = '/ThePages/Create/Biodata.aspx';});</script>", false);
                    }
                }
                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.ClinicVisits theClinicVisits = new Core.ClinicVisits();
                theClinicVisits.AppointmentDate = Convert.ToDateTime(dateAppointmentDate.Value);
                theClinicVisits.MedicalSummaryAfterVisit = txtSummary.Value;
                theClinicVisits.DateCreated = DateTime.Now;
                theClinicVisits.DateUpdated = DateTime.Now;
                theClinicVisits.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = theClinicVisits, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if (thePatient != null)  //HINT:Manually Create
                    thePatient.TheClinicVisits = theClinicVisits;
                else
                    thePatient = thePatientToSave;

                if (thePatientToVerify == null)
                {
                    ClinicVisitsDAO.Save(theClinicVisits);
                    PatientDAO.Save(thePatientToSave);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheClinicVisits != null && thePatientToVerify.TheClinicVisits.Id <= 0)
                {
                    ClinicVisitsDAO.Save(theClinicVisits);
                    entityToReplace = new ClinicVisitsDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheClinicVisits = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheClinicVisits != null && thePatientToVerify.TheClinicVisits.Id > 0 && thePatientToVerify.TheClinicVisits != theClinicVisits)//HINT:Manually Create
                {
                    theClinicVisits.Id = thePatient.TheClinicVisits.Id; //HINT:Manually Create
                    ClinicVisitsDAO.Update(theClinicVisits);
                    entityToReplace = new ClinicVisitsDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheClinicVisits = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
                }
                else if (thePatientToVerify.TheClinicVisits != null && thePatientToVerify.TheClinicVisits == theClinicVisits)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/ThePages/Create/Diagnosis.aspx';});</script>", false);
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
        protected void btnFinsih_Click(object sender, EventArgs e)
        {
            WebObjects.ClearAllSessionObjects();
            Response.Redirect("~/ThePages/View/ViewListOfPatients.aspx", false);
        }
    }
}