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
    public partial class LoginPage : System.Web.UI.Page
    {
        private Core.Hospital TheHospital
        {
            get
            {
                return Session["::Hospital::"] as Core.Hospital;
            }
            set
            {
                Session["::Hospital::"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = TextBoxNameUserName.Value;
            string password = TextBoxNamePassword.Value;
            Hospital theHospital = !string.IsNullOrWhiteSpace(DropDownHospital.SelectedValue) ? new HospitalDAO().Retrieve(Convert.ToInt64(DropDownHospital.SelectedValue)) : null;
            IList<HospitalUser> user = theHospital != null ? new HospitalUserDAO().RetrieveByLoginDetails(theHospital, userName, password) : null;
            if (user != null)
            {
                TheHospital = user.FirstOrDefault().TheHospital;
            }
            else
            {
                TheHospital = null;
            }
            if (!IsPostBack)
            {
                IList<Hospital> hospital = HospitalDAO.RetrieveAll();
                DropDownHospital.DataSource = hospital;
                DropDownHospital.DataValueField = "Id";
                DropDownHospital.DataTextField = "Name";
                DropDownHospital.DataBind();
            }
        }
        protected void searchsubmit_OnServerClick(object sender, EventArgs e)
        {
            string userName = TextBoxNameUserName.Value;
            string password = TextBoxNamePassword.Value;
            Hospital theHospital = !string.IsNullOrWhiteSpace(DropDownHospital.SelectedValue) ? new HospitalDAO().Retrieve(Convert.ToInt64(DropDownHospital.SelectedValue)) : null;
            IList<HospitalUser> user = theHospital != null ? new HospitalUserDAO().RetrieveByLoginDetails(theHospital, userName, password) : null;
            if (user.Count == 1)
            {
                Session["HospitalUser"] = user;
                Response.Redirect("Biodata.aspx");
                //Session.RemoveAll();
            }
            else if (user.Count > 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + "Access Denied: Multiple Users with same credentials exist for the selected Hospital" + @""", function(){});</script>", false);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + "Invalid Login Credentials" + @""", function(){});</script>", false);
            }

            //Response.Write("<script type='text/javascript'>alertify.alert('Message', '" + "Invalid Login Details" + "', function(){location = '/';});</script>");
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message", @"<script type='text/javascript'>alertify.alert('Message', """ + "Invalid Login Credentials" + @""", function(){});</script>", false);
            //InvalidCredentialsMessage.Visible = true;
        }
    }
}