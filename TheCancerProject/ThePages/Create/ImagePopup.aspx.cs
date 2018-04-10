using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheCancerProject.ThePages.Create
{
    public partial class ImagePopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string url = Request.QueryString["PId"].ToString();
            //imgPicture.ImageUrl = url;
            string requestSource = Request.QueryString["PId"].ToString();
            if (!string.IsNullOrWhiteSpace(requestSource) && requestSource.Equals("FromInvestigationsPage") && !string.IsNullOrWhiteSpace(SessionObjects.ImageUrl))
            {
                imgPicture.ImageUrl = SessionObjects.ImageUrl;
            }
            
        }
    }
}