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
    public partial class Procedures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheProcedures != null)
            {
                txtProceduresDone.Value = patient.TheEventsOnAdmission.DailyUpdates;
                txtPostOpOrders.Value = patient.TheEventsOnAdmission.ChemotherapyRegimen;
                txtDischargeMedicationsWithDoses.Value = patient.TheEventsOnAdmission.RadiotherapyRegimen;
                ddlDischargeState.SelectedValue = Enum.GetName(typeof(DischargeState), SessionObjects.ThePatient.TheProcedures.DischargeState);
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Core.Procedures entityToReplace = new Core.Procedures(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/Diagnosis.aspx", false);
                }
                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.Procedures theProcedures = new Core.Procedures();
                theProcedures.PostOpOrders = (string.IsNullOrWhiteSpace(txtProceduresDone.Value)) ? txtProceduresDone.Value : txtProceduresDone.Value.Trim();
                theProcedures.ProceduresDone = (string.IsNullOrWhiteSpace(txtPostOpOrders.Value)) ? txtPostOpOrders.Value : txtPostOpOrders.Value.Trim();
                theProcedures.ProceduresDone = (string.IsNullOrWhiteSpace(txtProceduresDone.Value)) ? txtProceduresDone.Value : txtProceduresDone.Value.Trim();
                theProcedures.DischargeState = (Core.DischargeState)Enum.Parse(typeof(Core.DischargeState), ddlDischargeState.SelectedValue);
                theProcedures.DateCreated = DateTime.Now;
                theProcedures.DateUpdated = DateTime.Now;
                theProcedures.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = theProcedures, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if (thePatient != null)  //HINT:Manually Create
                    thePatient.TheProcedures = theProcedures;
                else
                    thePatient = thePatientToSave;

                if (thePatientToVerify == null)
                {
                    ProceduresDAO.Save(theProcedures);
                    PatientDAO.Save(thePatientToSave);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Diagnosis.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheProcedures != null && thePatientToVerify.TheProcedures.Id <= 0)
                {
                    ProceduresDAO.Save(theProcedures);
                    entityToReplace = new ProceduresDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheProcedures = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Diagnosis.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheProcedures != null && thePatientToVerify.TheProcedures.Id > 0 && thePatientToVerify.TheProcedures != theProcedures)//HINT:Manually Create
                {
                    theProcedures.Id = thePatient.TheProcedures.Id; //HINT:Manually Create
                    ProceduresDAO.Update(theProcedures);
                    entityToReplace = new ProceduresDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheProcedures = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Diagnosis.aspx", false);
                }
                else if (thePatientToVerify.TheProcedures != null && thePatientToVerify.TheProcedures == theProcedures)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/Diagnosis.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/ThePages/Create/Procedures.aspx';});</script>", false);
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