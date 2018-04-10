using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            bool doNotSaveInDB = false;
            if (System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"] != null && Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["DoNotSaveInDB"], out doNotSaveInDB))
            {
                if (doNotSaveInDB)
                    Response.Redirect("~/ThePages/Create/EventsOnAdmission.aspx", false);
            }

            string axillaryLymphNodes = WebObjects.selectedListBoxValues(ddlAxillaryLymphNodes);
            string s = string.Empty;

        }
    }
}