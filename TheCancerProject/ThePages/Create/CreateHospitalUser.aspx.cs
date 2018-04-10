using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCancerProject.Core;
using TheCancerProject.Data.DAO;
using TheCancerProject.Logic;

namespace TheCancerProject.ThePages
{
    public partial class CreateHospitalUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IList<Hospital> hospital = HospitalDAO.RetrieveAll().Where(x => !string.IsNullOrWhiteSpace(x.Name) && !x.Name.Equals("SuperAdminHospital")).ToList();
                DropDownHospital.DataSource = hospital;
                DropDownHospital.DataValueField = "Id";
                DropDownHospital.DataTextField = "Name";
                DropDownHospital.DataBind();

                DropDownRole.DataSource = Enum.GetNames(typeof(UserRole));
                DropDownRole.DataBind();
            }
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
                if (string.IsNullOrWhiteSpace(TextBoxNameUName.Value))
                    throw new Exception("User Name field is required");
                if (string.IsNullOrWhiteSpace(TextBoxNamePhone.Value))
                    throw new Exception("Phone No. field is required");
                if (!string.IsNullOrWhiteSpace(DropDownRole.SelectedItem.Text) && !DropDownRole.SelectedItem.Text.Equals("HospitalUser"))
                    throw new Exception("HopsitalUser user role must be selected here");
                string userName = TextBoxNameUName.Value.Trim();
                //string superAdminHospitalName = "SuperAdminHospital";
                Hospital selectedHospital = new HospitalDAO().Retrieve(Convert.ToInt32(DropDownHospital.SelectedValue));
                IList<HospitalUser> adminUserList = new HospitalUserDAO().RetrieveUser(userName, UserRole.HospitalUser, selectedHospital);


                if (adminUserList.Count == 0)
                {
                    //create headquarters branch for user
                    Hospital hospital = new Hospital();
                    //if (theHospitalList == null && theHospitalList.Count <= 0)
                    //{
                    //    hospital.Name = "SuperAdminHospital";
                    //    hospital.Address = "Mars";
                    //    hospital.PrimaryContactEmail = "NONE";
                    //    hospital.PrimaryContactNumber = "NONE";
                    //    HospitalDAO.Save(hospital);
                    //}

                    //User user =Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IUserDb>();
                    HospitalUser user = new HospitalUser();
                    user.FirstName = TextBoxNameFName.Value;
                    user.LastName = TextBoxNameLName.Value;
                    user.OtherNames = TextBoxNameONames.Value;
                    user.Email = TextBoxNameEmail.Value;
                    user.UserName = TextBoxNameUName.Value;
                    user.Phone = TextBoxNamePhone.Value;
                    user.UserRole = (UserRole)Enum.Parse(typeof(UserRole), DropDownRole.SelectedValue);
                    user.TheHospital = selectedHospital;
                    //user.Branch.Id = branch.Id;
                    //user.Branch.BranchName = branch.BranchName;

                    HospitalUserLogic userLogic = new HospitalUserLogic();
                    user.Password = userLogic.HashPassword(userLogic.CreatePassword());
                    user.IsFirstLogin = true;       //update this field to false once user changes password successfully

                    user.DateCreated = DateTime.Now;
                    HospitalDAO.Save(hospital);
                    userLogic.SendMail(user.Email, user.Password);
                    HospitalUserDAO.Save(user);
                    //Response.Redirect("../Start/Login.aspx");
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", "<script type='text/javascript'>alertify.alert('Message', '" + "UserName Already Exists for this Hospital!" + "', function(){});</script>", false);
                }


                TextBoxNameFName.Value = String.Empty;
                TextBoxNameLName.Value = String.Empty;
                TextBoxNameONames.Value = String.Empty;
                //BranchTextbox.Text = String.Empty;
                TextBoxNameEmail.Value = String.Empty;
                //RoleTextBox.Text = String.Empty;
                TextBoxNameUName.Value = String.Empty;
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