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
                }
            }            
        }
        

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                bool doNotSaveInDB = false;
                if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
                {
                    if(doNotSaveInDB)
                        Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }

                List<TheCancerProject.Core.Biodata> theBiodataList = new BiodataDAO().RetrieveByHospitalAndHospitalNumber(SessionObjects.TheHospital, SessionObjects.HospitalNumber);
                TheCancerProject.Core.Biodata theBiodata = new Core.Biodata();
                //theBiodata = theBiodataList.First();
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
                Patient thePatient = new Patient { TheBiodata = theBiodata, TheHospital = null, TheBreastAndAxillaryExamination = null, TheComplaints = null, TheEventsOnAdmission = null, TheGeneralExamination = null, ThePreliminaryExamination = null, LastUserAdministeringTreatment= null, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                //thePatient.TheBiodata = theBiodata;                
                SessionObjects.TheBiodata = theBiodata;
                if (theBiodataList == null || theBiodataList.Count <= 0)
                {
                    BiodataDAO.Save(theBiodata);
                    PatientDAO.Save(thePatient); 
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (theBiodataList != null && theBiodataList.FirstOrDefault() != theBiodata)
                {
                    BiodataDAO.Update(theBiodata);
                    PatientDAO.Update(thePatient);
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (theBiodataList != null && theBiodataList.FirstOrDefault() == theBiodata)
                {
                    //If it's the same data, don't save or update, just redirect
                    Response.Redirect("~/ThePages/Create/PresentingComplaints.aspx", false);
                }
                else if (theBiodataList != null && theBiodataList.Count > 1)
                {
                    if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Multiple Biodata Exists for this patient. Kindly contact admin!!!" + "', function(){location = '/Start/Login.aspx';});</script>", false);
                    }
                }
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