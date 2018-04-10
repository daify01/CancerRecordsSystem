using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCancerProject.Core;
using TheCancerProject.Data.DAO;

namespace TheCancerProject.ThePages
{
    public partial class Biodata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Patient patient = SessionObjects.ThePatient;
                if (patient != null && patient.TheBiodata != null)
                {
                    txtAddress.Value = SessionObjects.ThePatient.TheBiodata.Address;
                    txtFirstName.Value = SessionObjects.ThePatient.TheBiodata.FirstName;
                    txtHospitalNumber.Value = SessionObjects.ThePatient.TheBiodata.HospitalNumber;
                    txtLastName.Value = SessionObjects.ThePatient.TheBiodata.LastName;
                    txtNextOfKinName.Value = SessionObjects.ThePatient.TheBiodata.NextOfKinName;
                    txtNextofKinPhone.Value = SessionObjects.ThePatient.TheBiodata.NextOfKinPhone;
                    txtOccupation.Value = SessionObjects.ThePatient.TheBiodata.Occupation;
                    txtPhone.Value = SessionObjects.ThePatient.TheBiodata.PhoneNumber;
                    txtOtherNames.Value = SessionObjects.ThePatient.TheBiodata.OtherNames;
                    ddlReligion.SelectedValue = Enum.GetName(typeof(Religion), SessionObjects.ThePatient.TheBiodata.Religion);
                    ddlSex.SelectedValue = Enum.GetName(typeof(Sex), SessionObjects.ThePatient.TheBiodata.Sex);
                    ddlTitle.SelectedValue = Enum.GetName(typeof(Title), SessionObjects.ThePatient.TheBiodata.Title);
                    ddlStates.SelectedValue = Enum.GetName(typeof(State), SessionObjects.ThePatient.TheBiodata.StateOfResidence);
                    ddlMaritalStatus.SelectedValue = Enum.GetName(typeof(MaritalStatus), SessionObjects.ThePatient.TheBiodata.MaritalStatus);
                    ddlRelationship.SelectedValue = Enum.GetName(typeof(Relationship), SessionObjects.ThePatient.TheBiodata.NextOfKinRelationship);
                    dateDateofBirth.Value = patient.TheDiagnoses.AdmissionDate.Value.ToString("yyyy-MM-dd");
                }
            }            
        }
        

        protected void btnNext_Click(object sender, EventArgs e)
        {
            TheCancerProject.Core.Patient thePatient = SessionObjects.ThePatient;
            TheCancerProject.Core.Patient thePatientToVerify = SessionObjects.ThePatient;
            TheCancerProject.Core.Biodata theBiodataToReplace = new Core.Biodata();
            string uniqueID = string.Empty;
            if (thePatient == null || string.IsNullOrWhiteSpace(thePatient.UniqueID))
            {
                uniqueID = new PatientDAO().CreateUniqueID();
            }
            else if (thePatient != null && !string.IsNullOrWhiteSpace(thePatient.UniqueID))
            {
                uniqueID = thePatient.UniqueID;
            }            
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if(doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                if (string.IsNullOrWhiteSpace(dateDateofBirth.Value))
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Please Enter a valid Date Of Birth" + "', function(){location = '/ThePages/Create/Biodata.aspx';});</script>", false);
                    }
                }
                //List<TheCancerProject.Core.Biodata> theBiodataList = new BiodataDAO().RetrieveByHospitalAndHospitalNumber(SessionObjects.TheHospital, SessionObjects.HospitalNumber);
                TheCancerProject.Core.Biodata theBiodata = new Core.Biodata();
                //theBiodata = theBiodataList.First();
                theBiodata.DateOfBirth = Convert.ToDateTime(dateDateofBirth.Value);
                theBiodata.Age = Convert.ToString((DateTime.Now.Year - theBiodata.DateOfBirth.Year));
                theBiodata.TheHospital = (SessionObjects.TheHospital != null) ? SessionObjects.TheHospital : null;
                theBiodata.Address = txtAddress.Value;
                theBiodata.FirstName = txtFirstName.Value;
                theBiodata.HospitalNumber = txtHospitalNumber.Value;
                theBiodata.LastName = txtLastName.Value;
                theBiodata.NextOfKinName = txtNextOfKinName.Value;
                theBiodata.NextOfKinPhone = txtNextofKinPhone.Value;
                theBiodata.Occupation = txtOccupation.Value;
                theBiodata.PhoneNumber = txtPhone.Value;
                theBiodata.OtherNames = txtOtherNames.Value;
                theBiodata.Religion = (Religion)Enum.Parse(typeof(Religion), ddlReligion.SelectedValue, true);
                theBiodata.Sex = (Sex)Enum.Parse(typeof(Sex), ddlSex.SelectedValue);
                theBiodata.Title = (Title)Enum.Parse(typeof(Title), ddlTitle.SelectedValue);
                theBiodata.StateOfResidence = (State)Enum.Parse(typeof(State), ddlStates.SelectedValue);
                theBiodata.MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), ddlMaritalStatus.SelectedValue);
                theBiodata.NextOfKinRelationship = (Relationship)Enum.Parse(typeof(Relationship), ddlRelationship.SelectedValue);
                theBiodata.DateCreated = DateTime.Now;
                theBiodata.DateUpdated = DateTime.Now;
                theBiodata.UniqueID = uniqueID;
                
                Patient thePatientToSave = new Patient { TheBiodata = theBiodata, TheHospital = (thePatient != null) ? thePatient.TheHospital : null, TheBreastAndAxillaryExamination = (thePatient != null) ? thePatient.TheBreastAndAxillaryExamination : null, TheComplaints = (thePatient != null) ? thePatient.TheComplaints : null, TheEventsOnAdmission = (thePatient != null) ? thePatient.TheEventsOnAdmission : null, TheGeneralExamination = (thePatient != null) ? thePatient.TheGeneralExamination : null, ThePreliminaryExamination = (thePatient != null) ? thePatient.ThePreliminaryExamination : null, LastUserAdministeringTreatment = (thePatient != null) ? thePatient.LastUserAdministeringTreatment : null, TheClinicVisits = (thePatient != null) ? thePatient.TheClinicVisits : null, TheInvestigation = (thePatient != null) ? thePatient.TheInvestigation : null, TheProcedures = (thePatient != null) ? thePatient.TheProcedures : null, TheDiagnoses = (thePatient != null) ? thePatient.TheDiagnoses : null, UniqueID = uniqueID, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                //thePatient.TheBiodata = theBiodata;                
                SessionObjects.TheBiodata = theBiodata;
                SessionObjects.PatientUniqueID = uniqueID;
                //thePatient = thePatientToSave;
                //SessionObjects.ThePatient = thePatient;
                if (thePatient != null)
                    thePatient.TheBiodata = theBiodata;
                else
                    thePatient = thePatientToSave;

                if (thePatientToVerify == null) //nothing in session
                {
                    BiodataDAO.Save(theBiodata);
                    PatientDAO.Save(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);
                    SessionObjects.ThePatient = thePatient;
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheBiodata != null && thePatientToVerify.TheBiodata.Id <= 0)
                {
                    BiodataDAO.Save(theBiodata);
                    theBiodataToReplace = new BiodataDAO().RetrieveByUniqueID(uniqueID); // Take newly saved biodata, so that the ID can be available during update query below
                    thePatient.TheBiodata = theBiodataToReplace;
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);
                    SessionObjects.ThePatient = thePatient;
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (thePatientToVerify != null && thePatientToVerify.Id > 0 && thePatientToVerify.TheBiodata != null && thePatientToVerify.TheBiodata.Id > 0 && thePatientToVerify.TheBiodata != theBiodata)
                {
                    theBiodata.Id = thePatient.TheBiodata.Id;
                    BiodataDAO.Update(theBiodata);
                    theBiodataToReplace = new BiodataDAO().RetrieveByUniqueID(uniqueID); // Take newly saved biodata, so that the ID can be available during update query below
                    thePatient.TheBiodata = theBiodataToReplace;
                    PatientDAO.Update(thePatient);
                    thePatient = new PatientDAO().RetrieveByUniqueID(SessionObjects.PatientUniqueID);
                    SessionObjects.ThePatient = thePatient;
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (thePatientToVerify.TheBiodata != null && thePatientToVerify.TheBiodata == theBiodata)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Unknown error encountered. Kindly contact admin!!!" + "', function(){location = '/ThePages/Create/Biodata.aspx';});</script>", false);
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