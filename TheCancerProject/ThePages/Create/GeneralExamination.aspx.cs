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
    public partial class GeneralExamination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.GeneralExam), ddlGeneralExam);
            //WebObjects.EnumToListBox(typeof(TheCancerProject.Core.Texture), ddlTexture);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.LocationOfLesion), ddlLocationOfLesion);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.QuadrantLocated), ddlQuadrantLocated);

            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheGeneralExamination != null)
            {
                txtWeight.Value = patient.TheGeneralExamination.Weight;
                txtHeight.Value = patient.TheGeneralExamination.Height;
                txtBMI.Value = patient.TheGeneralExamination.BMI;
                txtBSA.Value = patient.TheGeneralExamination.BSA;
                txtTemperature.Value = patient.TheGeneralExamination.Temperature;
                txtShape.Value = patient.TheGeneralExamination.Shape;
                txtOtherObservations.Value = patient.TheGeneralExamination.OtherObservations;
                txtColorOfSkinArea.Value = patient.TheGeneralExamination.ColorOfSkinArea;
                txtBloodPressure.Value = patient.TheGeneralExamination.BloodPressure;
                txtRespiratoryRate.Value = patient.TheGeneralExamination.RespiratoryRate;
                txtHeartSounds.Value = patient.TheGeneralExamination.HeartSounds;
                txtPulseRRate.Value = patient.TheGeneralExamination.PulseRate;
                ddlSymmetry.SelectedValue = Enum.GetName(typeof(Symmetry), SessionObjects.ThePatient.TheGeneralExamination.TheSymmetry);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheGeneralExamination.TheGeneralExam, ddlGeneralExam);
                //WebObjects.displayStoredSelectedListBoxValues(patient.TheGeneralExamination.TheTexture, ddlTexture);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheGeneralExamination.TheLocationOfLesion, ddlLocationOfLesion);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheGeneralExamination.QuadrantLocated, ddlQuadrantLocated);
            }
        }
        
        //protected void txtBMI_Click(object sender, EventArgs e)
        //{
        //    int height, weight = 0;
        //    if (!string.IsNullOrWhiteSpace(txtWeight.Value) && int.TryParse(txtWeight.Value, out weight) && !string.IsNullOrWhiteSpace(txtHeight.Value) && int.TryParse(txtHeight.Value, out height))
        //    {
        //        txtBMI.Value = (weight / height).ToString();
        //    }
        //}
        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            float height, weight = 0;
            Core.GeneralExamination entityToReplace = new Core.GeneralExamination(); //HINT:Manually Create
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
                }

                string generalExam = WebObjects.selectedListBoxValues(ddlGeneralExam);
                //string Texture = WebObjects.selectedListBoxValues(ddlTexture);
                string locationOfLesion = WebObjects.selectedListBoxValues(ddlLocationOfLesion);
                string quadrantLocated = WebObjects.selectedListBoxValues(ddlQuadrantLocated);

                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.GeneralExamination theGeneralExam = new Core.GeneralExamination();
                theGeneralExam.TheGeneralExam = generalExam;
                //theGeneralExam.TheTexture = Texture;
                theGeneralExam.TheLocationOfLesion = locationOfLesion;
                theGeneralExam.QuadrantLocated = quadrantLocated;
                theGeneralExam.TheSymmetry = (Core.Symmetry)Enum.Parse(typeof(Core.Symmetry), ddlSymmetry.SelectedValue);
                theGeneralExam.Weight = (string.IsNullOrWhiteSpace(txtWeight.Value)) ? txtWeight.Value : txtWeight.Value.Trim();
                theGeneralExam.Height = (string.IsNullOrWhiteSpace(txtHeight.Value)) ? txtHeight.Value : txtHeight.Value.Trim();
                if (!string.IsNullOrWhiteSpace(txtWeight.Value) && float.TryParse(txtWeight.Value, out weight) && !string.IsNullOrWhiteSpace(txtHeight.Value) && float.TryParse(txtHeight.Value, out height))
                {
                    txtBMI.Value = (weight / height).ToString();
                    txtBSA.Value = Math.Sqrt(((height * 100) * weight) / 3600).ToString();
                }
                else
                {
                    txtBMI.Value = string.Empty;
                    txtBSA.Value = string.Empty;
                }
                theGeneralExam.BMI = (string.IsNullOrWhiteSpace(txtBMI.Value)) ? txtBMI.Value : txtBMI.Value.Trim();
                theGeneralExam.BSA = (string.IsNullOrWhiteSpace(txtBSA.Value)) ? txtBSA.Value : txtBSA.Value.Trim();
                theGeneralExam.Temperature = (string.IsNullOrWhiteSpace(txtTemperature.Value)) ? txtTemperature.Value : txtTemperature.Value.Trim();
                theGeneralExam.Shape = (string.IsNullOrWhiteSpace(txtShape.Value)) ? txtShape.Value : txtShape.Value.Trim();
                theGeneralExam.OtherObservations = (string.IsNullOrWhiteSpace(txtOtherObservations.Value)) ? txtOtherObservations.Value : txtOtherObservations.Value.Trim();
                theGeneralExam.ColorOfSkinArea = (string.IsNullOrWhiteSpace(txtColorOfSkinArea.Value)) ? txtColorOfSkinArea.Value : txtColorOfSkinArea.Value.Trim();
                theGeneralExam.BloodPressure = (string.IsNullOrWhiteSpace(txtBloodPressure.Value)) ? txtBloodPressure.Value : txtBloodPressure.Value.Trim();
                theGeneralExam.RespiratoryRate = (string.IsNullOrWhiteSpace(txtRespiratoryRate.Value)) ? txtRespiratoryRate.Value : txtRespiratoryRate.Value.Trim();
                theGeneralExam.HeartSounds = (string.IsNullOrWhiteSpace(txtHeartSounds.Value)) ? txtHeartSounds.Value : txtHeartSounds.Value.Trim();
                theGeneralExam.PulseRate = (string.IsNullOrWhiteSpace(txtPulseRRate.Value)) ? txtPulseRRate.Value : txtPulseRRate.Value.Trim();
                theGeneralExam.DateCreated = DateTime.Now;
                theGeneralExam.DateUpdated = DateTime.Now; 
                theGeneralExam.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = theGeneralExam, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if (thePatient != null)  //HINT:Manually Create
                    thePatient.TheGeneralExamination = theGeneralExam;
                else
                    thePatient = thePatientToSave;

                if (thePatientToVerify == null)
                {
                    GeneralExamDAO.Save(theGeneralExam);
                    PatientDAO.Save(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheGeneralExamination != null && thePatientToVerify.TheGeneralExamination.Id <= 0)
                {
                    GeneralExamDAO.Save(theGeneralExam);
                    entityToReplace = new GeneralExamDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheGeneralExamination = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheGeneralExamination != null && thePatientToVerify.TheGeneralExamination.Id > 0 && thePatientToVerify.TheGeneralExamination != theGeneralExam)//HINT:Manually Create
                {
                    theGeneralExam.Id = thePatient.TheGeneralExamination.Id; //HINT:Manually Create
                    GeneralExamDAO.Update(theGeneralExam);
                    entityToReplace = new GeneralExamDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheGeneralExamination = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
                }
                else if (thePatientToVerify.TheGeneralExamination != null && thePatientToVerify.TheGeneralExamination == theGeneralExam)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
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
    }
}