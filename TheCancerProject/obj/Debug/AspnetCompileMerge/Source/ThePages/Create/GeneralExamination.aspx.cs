using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCancerProject.ThePages.Create
{
    public partial class GeneralExamination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.GeneralExam), ddlGeneralExam);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.Texture), ddlTexture);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.LocationOfLesion), ddlLocationOfLesion);
            WebObjects.EnumToListBox(typeof(TheCancerProject.Core.QuadrantLocated), ddlQuadrantLocated);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            bool doNotSaveInDB = false;
            if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
            {
                if (doNotSaveInDB)
                    Response.Redirect("~/ThePages/Create/BreastAndAxillaryExamination.aspx", false);
            }
            string generalExam = WebObjects.selectedListBoxValues(ddlGeneralExam);
            string s = string.Empty;

        }
    }
}