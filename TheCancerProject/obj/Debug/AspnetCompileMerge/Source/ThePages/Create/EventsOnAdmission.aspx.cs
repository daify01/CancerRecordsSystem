using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCancerProject.ThePages.Create
{
    public partial class EventsOnAdmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlInitialDiagnosis.DataSource = TheCancerProject.Core.Utilities.Dictionaries.initialOrFinalDiagnosisForBreastCancer;
            ddlInitialDiagnosis.DataTextField = "Key";
            ddlInitialDiagnosis.DataValueField = "Value";
            ddlInitialDiagnosis.DataBind();
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

        }
        protected void ddlInitialDiagnosis_IndexChanged(Object sender, EventArgs e)
        {
            //lblInitialDiagnosis.Text = ddlInitialDiagnosis.SelectedValue.ToString();
        }
    }
}