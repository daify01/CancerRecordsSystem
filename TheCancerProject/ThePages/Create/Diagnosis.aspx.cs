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
    public partial class Diagnosis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlInitialDiagnosis.DataSource = TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer;
            ddlInitialDiagnosis.DataTextField = "Value";
            ddlInitialDiagnosis.DataValueField = "Key";
            ddlInitialDiagnosis.DataBind();

            ddlFinalDiagnosis.DataSource = TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer;
            ddlFinalDiagnosis.DataTextField = "Value";
            ddlFinalDiagnosis.DataValueField = "Key";
            ddlFinalDiagnosis.DataBind();

            //dateAdmissionDate.Value = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");

            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheDiagnoses != null)
            {
                txtPlan.Value = patient.TheDiagnoses.ThePlan;
                dateAdmissionDate.Value = (patient.TheDiagnoses.AdmissionDate.HasValue) ? patient.TheDiagnoses.AdmissionDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                dateDischargeDate.Value = (patient.TheDiagnoses.DischargeDate.HasValue) ? patient.TheDiagnoses.DischargeDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                ddlInitialDiagnosis.SelectedValue = (!string.IsNullOrWhiteSpace(patient.TheDiagnoses.InitialDiagnosis)) ?TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer.Where(x => x.Key.Trim().Equals(patient.TheDiagnoses.InitialDiagnosis.Trim())).FirstOrDefault().Value : string.Empty;
                ddlFinalDiagnosis.SelectedValue = (!string.IsNullOrWhiteSpace(patient.TheDiagnoses.FinalDiagnosis)) ? TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer.Where(x => x.Key.Trim().Equals(patient.TheDiagnoses.FinalDiagnosis.Trim())).FirstOrDefault().Value : string.Empty;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Core.Diagnosis entityToReplace = new Core.Diagnosis(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                DateTime? admDate = null;
                DateTime? dischrgDate = null;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);
                }
                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.Diagnosis theDiagnoses = new Core.Diagnosis();
                theDiagnoses.ThePlan = (string.IsNullOrWhiteSpace(txtPlan.Value)) ? txtPlan.Value : txtPlan.Value.Trim();
                theDiagnoses.AdmissionDate = (!string.IsNullOrWhiteSpace(dateAdmissionDate.Value)) ?Convert.ToDateTime(dateAdmissionDate.Value) : admDate;
                theDiagnoses.DischargeDate = (!string.IsNullOrWhiteSpace(dateDischargeDate.Value)) ?Convert.ToDateTime(dateDischargeDate.Value) : dischrgDate;
                theDiagnoses.InitialDiagnosis = ddlInitialDiagnosis.SelectedValue;
                theDiagnoses.FinalDiagnosis = ddlFinalDiagnosis.SelectedValue;
                theDiagnoses.DateCreated = DateTime.Now;
                theDiagnoses.DateUpdated = DateTime.Now;
                theDiagnoses.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = theDiagnoses, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if (thePatient != null)  //HINT:Manually Create
                    thePatient.TheDiagnoses = theDiagnoses;
                else
                    thePatient = thePatientToSave;
                
                if (thePatientToVerify == null)
                {
                    DiagnosisDAO.Save(theDiagnoses);
                    PatientDAO.Save(thePatientToSave);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheDiagnoses != null && thePatientToVerify.TheDiagnoses.Id <= 0)
                {
                    DiagnosisDAO.Save(theDiagnoses);
                    entityToReplace = new DiagnosisDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheDiagnoses = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheDiagnoses != null && thePatientToVerify.TheDiagnoses.Id > 0 && thePatientToVerify.TheDiagnoses != theDiagnoses)//HINT:Manually Create
                {
                    theDiagnoses.Id = thePatient.TheDiagnoses.Id; //HINT:Manually Create
                    DiagnosisDAO.Update(theDiagnoses);
                    entityToReplace = new DiagnosisDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheDiagnoses = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);
                }
                else if (thePatientToVerify.TheDiagnoses != null && thePatientToVerify.TheDiagnoses == theDiagnoses)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);
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
        protected void ddlInitialDiagnosis_IndexChanged(Object sender, EventArgs e)
        {
            //lblInitialDiagnosis.Text = ddlInitialDiagnosis.SelectedValue.ToString();
        }

        protected void ddlFinalDiagnosis_IndexChanged(Object sender, EventArgs e)
        {
            //lblInitialDiagnosis.Text = ddlInitialDiagnosis.SelectedValue.ToString();
        }

    }
}