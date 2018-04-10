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
    public partial class BreastAndAxillaryExamination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.AxillaryLymphNodes), ddlAxillaryLymphNodes);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.SupraclavicularNodes), ddlSupraClavicularNodes);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.AnteriorChestWallNodules), ddlAnteriorChestWallNodules);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.LocationOfLesions), ddlLocationOfLesions);

            Patient patient = SessionObjects.ThePatient;
            if (patient != null && patient.TheBreastAndAxillaryExamination != null)
            {
                chkElevated.Checked = patient.TheBreastAndAxillaryExamination.Elevated;
                chkDeviated.Checked = patient.TheBreastAndAxillaryExamination.Deviated;
                chkCracks.Checked = patient.TheBreastAndAxillaryExamination.Cracks;
                chkFissure.Checked = patient.TheBreastAndAxillaryExamination.Fissure;
                chkUlcer.Checked = patient.TheBreastAndAxillaryExamination.Ulcer;
                chkScales.Checked = patient.TheBreastAndAxillaryExamination.Scale;
                chkDischarge.Checked = patient.TheBreastAndAxillaryExamination.Discharge;
                txtFindingsUnderBreast.Value = patient.TheBreastAndAxillaryExamination.FindingsUnderBreast;
                txtFindingsWithArmsOnHips.Value = patient.TheBreastAndAxillaryExamination.FindingsUnderArms;
                txtNumberOfLesions.Value = patient.TheBreastAndAxillaryExamination.NumberOfLesions;
                txtSize.Value = patient.TheBreastAndAxillaryExamination.Size;
                txtAreolaColour.Value = patient.TheBreastAndAxillaryExamination.AreolaColor;
                txtSurface.Value = patient.TheBreastAndAxillaryExamination.Surface;
                //chkFissures.Checked = patient.TheBreastAndAxillaryExamination.Elevated;
                ddlBreastWithLesion.SelectedValue = Enum.GetName(typeof(BreastWithLesion), SessionObjects.ThePatient.TheBreastAndAxillaryExamination.TheBreastWithLesion);
                ddlTemperature.SelectedValue = Enum.GetName(typeof(Temperature), SessionObjects.ThePatient.TheBreastAndAxillaryExamination.TheTemperature);
                ddlAppearance.SelectedValue = Enum.GetName(typeof(Appearance), SessionObjects.ThePatient.TheBreastAndAxillaryExamination.Appearance);
                ddlTypeOfDischarge.SelectedValue = Enum.GetName(typeof(TypeOfDischarge), SessionObjects.ThePatient.TheBreastAndAxillaryExamination.TypeOfDischarge);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheBreastAndAxillaryExamination.TheAxillaryLymphNodes, ddlAxillaryLymphNodes);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheBreastAndAxillaryExamination.TheSupraclavicularNodes, ddlSupraClavicularNodes);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheBreastAndAxillaryExamination.TheAnteriorChestWallNodules, ddlAnteriorChestWallNodules);
                WebObjects.displayStoredSelectedListBoxValues(patient.TheBreastAndAxillaryExamination.TheLocationOfLesions, ddlLocationOfLesions);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            Core.BreastAndAxillaryExamination entityToReplace = new Core.BreastAndAxillaryExamination(); //HINT:Manually Create

            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if (doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
                }

                string axillaryLymphNodes = WebObjects.selectedListBoxValues(ddlAxillaryLymphNodes);
                string anteriorChestWallNodules = WebObjects.selectedListBoxValues(ddlSupraClavicularNodes);
                string supraClavicularNodes = WebObjects.selectedListBoxValues(ddlAnteriorChestWallNodules);
                string locationOfLesions = WebObjects.selectedListBoxValues(ddlLocationOfLesions);

                //TheCancerProject.Core.Complaints theComplaintInSession = (thePatient!=null) ?thePatient.TheComplaints : null;
                TheCancerProject.Core.BreastAndAxillaryExamination theBreastAndAxillaryExamination = new Core.BreastAndAxillaryExamination();
                theBreastAndAxillaryExamination.TheAxillaryLymphNodes = axillaryLymphNodes;
                theBreastAndAxillaryExamination.TheAnteriorChestWallNodules = anteriorChestWallNodules;
                theBreastAndAxillaryExamination.TheSupraclavicularNodes = supraClavicularNodes;
                theBreastAndAxillaryExamination.TheLocationOfLesions = locationOfLesions;
                theBreastAndAxillaryExamination.TheBreastWithLesion = (Core.BreastWithLesion)Enum.Parse(typeof(Core.BreastWithLesion), ddlBreastWithLesion.SelectedValue);
                theBreastAndAxillaryExamination.TheTemperature = (Core.Temperature)Enum.Parse(typeof(Core.Temperature), ddlTemperature.SelectedValue);
                theBreastAndAxillaryExamination.Appearance = (Core.Appearance)Enum.Parse(typeof(Core.Appearance), ddlAppearance.SelectedValue);
                theBreastAndAxillaryExamination.TypeOfDischarge = (Core.TypeOfDischarge)Enum.Parse(typeof(Core.TypeOfDischarge), ddlTypeOfDischarge.SelectedValue);
                theBreastAndAxillaryExamination.FindingsUnderBreast = (string.IsNullOrWhiteSpace(txtFindingsUnderBreast.Value)) ? txtFindingsUnderBreast.Value : txtFindingsUnderBreast.Value.Trim();
                theBreastAndAxillaryExamination.FindingsUnderArms = (string.IsNullOrWhiteSpace(txtFindingsWithArmsOnHips.Value)) ? txtFindingsWithArmsOnHips.Value : txtFindingsWithArmsOnHips.Value.Trim();
                theBreastAndAxillaryExamination.NumberOfLesions = (string.IsNullOrWhiteSpace(txtNumberOfLesions.Value)) ? txtNumberOfLesions.Value : txtNumberOfLesions.Value.Trim();
                theBreastAndAxillaryExamination.Size = (string.IsNullOrWhiteSpace(txtSize.Value)) ? txtSize.Value : txtSize.Value.Trim();
                theBreastAndAxillaryExamination.AreolaColor = (string.IsNullOrWhiteSpace(txtAreolaColour.Value)) ? txtAreolaColour.Value : txtAreolaColour.Value.Trim();
                theBreastAndAxillaryExamination.Surface = (string.IsNullOrWhiteSpace(txtSurface.Value)) ? txtSurface.Value : txtSurface.Value.Trim();
                theBreastAndAxillaryExamination.Elevated = chkElevated.Checked;
                theBreastAndAxillaryExamination.Deviated = chkDeviated.Checked;
                theBreastAndAxillaryExamination.Cracks = chkCracks.Checked;
                theBreastAndAxillaryExamination.Fissure = chkFissure.Checked;
                theBreastAndAxillaryExamination.Ulcer = chkUlcer.Checked;
                theBreastAndAxillaryExamination.Scale = chkScales.Checked;
                theBreastAndAxillaryExamination.Discharge = chkDischarge.Checked;
                theBreastAndAxillaryExamination.DateCreated = DateTime.Now;
                theBreastAndAxillaryExamination.DateUpdated = DateTime.Now;
                theBreastAndAxillaryExamination.UniqueID = SessionObjects.PatientUniqueID; //HINT:Manually Create
                Patient thePatientToSave = new Patient { TheBiodata = (thePatient != null) ? thePatient.TheBiodata : null, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = theBreastAndAxillaryExamination, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };

                if(thePatient != null)  //HINT:Manually Create
                    thePatient.TheBreastAndAxillaryExamination = theBreastAndAxillaryExamination;
                else
                    thePatient = thePatientToSave;
                if (thePatientToVerify == null) //nothing in session
                {
                    B_And_A_ExamDAO.Save(theBreastAndAxillaryExamination);
                    PatientDAO.Save(thePatientToSave);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID); //HINT:Manually Create
                    SessionObjects.ThePatient = thePatient; //HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheBreastAndAxillaryExamination != null && thePatientToVerify.TheBreastAndAxillaryExamination.Id <= 0)
                {
                    B_And_A_ExamDAO.Save(theBreastAndAxillaryExamination);
                    entityToReplace = new B_And_A_ExamDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheBreastAndAxillaryExamination = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheBreastAndAxillaryExamination != null && thePatientToVerify.TheBreastAndAxillaryExamination.Id > 0 && thePatientToVerify.TheBreastAndAxillaryExamination != theBreastAndAxillaryExamination)//HINT:Manually Create
                {
                    theBreastAndAxillaryExamination.Id = thePatient.TheBreastAndAxillaryExamination.Id; //HINT:Manually Create
                    B_And_A_ExamDAO.Update(theBreastAndAxillaryExamination);
                    entityToReplace = new B_And_A_ExamDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    thePatient.TheBreastAndAxillaryExamination = entityToReplace;//HINT:Manually Create
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);//HINT:Manually Create
                    SessionObjects.ThePatient = thePatient;//HINT:Manually Create
                    Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
                }
                else if (thePatientToVerify.TheBreastAndAxillaryExamination != null && thePatientToVerify.TheBreastAndAxillaryExamination == theBreastAndAxillaryExamination)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/ThePages/Create/BreastAndAxillaryExamination.aspx';});</script>", false);
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