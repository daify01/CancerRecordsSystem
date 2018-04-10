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
    public partial class CreateHospital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void searchsubmit_OnServerClick(object sender, EventArgs e)
        {

            //var userDB = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUserDb>();

            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNameFName.Value))
                    throw new Exception("First Name field is required");
                if (string.IsNullOrWhiteSpace(TextBoxNameLName.Value))
                    throw new Exception("Last Name field is required");
                if (string.IsNullOrWhiteSpace(TextBoxNameEmail.Value))
                    throw new Exception("Email field is required");
                    throw new Exception("User Name field is required");
                if (string.IsNullOrWhiteSpace(TextBoxNamePhone.Value))
                    throw new Exception("Phone No. field is required");
                string name = (!string.IsNullOrWhiteSpace(TextBoxNameFName.Value)) ? TextBoxNameFName.Value.Trim() : string.Empty;
                IList<Hospital> theHospitalList = new HospitalDAO().RetrieveByName(name);

                if (theHospitalList.Count <= 0)
                {
                    //create headquarters branch for user
                    Hospital hospital = new Hospital();
                    hospital.Name = name;
                    hospital.Address = TextBoxNameLName.Value;
                    hospital.PrimaryContactEmail = TextBoxNameEmail.Value;
                    hospital.PrimaryContactNumber = TextBoxNamePhone.Value;
                    HospitalDAO.Save(hospital);
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "UserName Already Exists!" + "', function(){});</script>", false);
                }


                TextBoxNameFName.Value = String.Empty;
                TextBoxNameLName.Value = String.Empty;
                TextBoxNameEmail.Value = String.Empty;
                TextBoxNamePhone.Value = String.Empty;

                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "message"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "Admin Saved Successfully" + "', function(){location = '/Start/Login.aspx';});</script>", false);
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