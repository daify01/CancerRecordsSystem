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
    public partial class Investigation2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //For Test
            //List<TheCancerProject.Core.Investigation> investigationHistoryForPatient = new List<TheCancerProject.Core.Investigation>();
            //investigationHistoryForPatient = new InvestigationDAO().RetrieveByPatientHospitalNumber("8215");
            //GridView1.DataSource = investigationHistoryForPatient;
            //GridView1.DataBind();
            //End

            //Patient patient = SessionObjects.ThePatient;
            string patientUniqueID = SessionObjects.PatientUniqueID;
            List<TheCancerProject.Core.Investigation> investigationHistoryForPatient = new List<TheCancerProject.Core.Investigation>();
            investigationHistoryForPatient = new InvestigationDAO().RetrieveByPatientUniqueID(patientUniqueID);
            //if (patient != null && patient.TheBiodata != null && !string.IsNullOrWhiteSpace(patient.TheBiodata.HospitalNumber))
            //{
            //    investigationHistoryForPatient = new InvestigationDAO().RetrieveByPatientHospitalNumber(patient.TheBiodata.HospitalNumber);
            //}
            GridView1.DataSource = investigationHistoryForPatient;
            GridView1.DataBind();
        }
        protected string GetPopupURL(object id)
        {
            string url = string.Empty;

            TheCancerProject.Core.Investigation theInvestigation = new InvestigationDAO().Retrieve(Convert.ToInt64(id));
            var img = theInvestigation.Image;
            string base64String = Convert.ToBase64String(img, 0, img.Length);
            string strImage = "data:image/png;base64," + base64String;
            //strImage = strImage.Replace("~", "..");
            string openPopUpJS = @"javascript:window.open('ImagePopup.aspx?PId=" + strImage + "',null,'left=45px,top=15px, width=300px, height=300px,status=no, resizable= yes, scrollbars=yes, toolbar=no, location=no,menubar=no');";
            //img.Attributes.Add("onClick", "javascript:window.open('image.aspx?PId=" + strImage + "',null,'left=45px,top=15px, width=300px, height=300px,status=no, resizable= yes, scrollbars=yes, toolbar=no, location=no,menubar=no');");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "message",openPopUpJS, false);
            
            return url;
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label IdLabel = (Label)(row.FindControl("IdNo"));
                long ID = Convert.ToInt64(IdLabel.Text);
                HyperLink link = (HyperLink)row.FindControl("lnkViewImage");
                TheCancerProject.Core.Investigation theInvestigation = new InvestigationDAO().Retrieve(Convert.ToInt64(ID));
                var img = theInvestigation.Image;
                string base64String = Convert.ToBase64String(img, 0, img.Length);
                string strImage = "data:image/png;base64," + base64String;
                //strImage = strImage.Replace("~", "..");
                //link.Attributes.Add("onClick", "javascript:window.open('ImagePopup.aspx?PId=" + strImage + "',null,'left=45px,top=15px, width=400px, height=400px,status=no, resizable= yes, scrollbars=yes, toolbar=no, location=no,menubar=no');");
                link.Attributes.Add("onClick", "javascript:window.open('ImagePopup.aspx?PId=" + "FromInvestigationsPage" + "',null,'left=45px,top=15px, width=400px, height=400px,status=no, resizable= yes, scrollbars=yes, toolbar=no, location=no,menubar=no');");
                SessionObjects.ImageUrl = strImage;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                switch (e.CommandName)
                {
                    case "EnableDisable":
                        break;

                }
            }
        }
        protected void ibtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    HttpPostedFile theFile = FileUpload1.PostedFile;
                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    if (theFile.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".bmp", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            TheCancerProject.Core.Investigation investigation = new TheCancerProject.Core.Investigation();
                            Patient patient = SessionObjects.ThePatient;
                            //System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
                            //System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                            //Byte[] img = br.ReadBytes((Int32)fs.Length);
                            byte[] img = new byte[FileUpload1.PostedFile.ContentLength];

                            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.InputStream.Position == 0)
                            {
                                FileUpload1.PostedFile.InputStream.Read(img, 0, FileUpload1.PostedFile.ContentLength);
                            }

                            investigation.Image = img;
                            investigation.Summary = txtSummary.Text;
                            investigation.DateCreated = DateTime.Now;
                            investigation.DateUpdated = DateTime.Now;
                            investigation.PatientHospitalNumber = (patient != null && patient.TheBiodata != null) ? patient.TheBiodata.HospitalNumber : null;
                            //investigation.UniqueID = (patient != null) ? patient.UniqueID : null;
                            //investigation.UniqueID = SessionObjects.PatientUniqueID;
                            investigation.UniqueID = null;
                            investigation.PatientUniqueID = SessionObjects.PatientUniqueID;
                            InvestigationDAO.Save(investigation);


                            string base64String = Convert.ToBase64String(img, 0, img.Length);
                            imgPicture.ImageUrl = "data:image/png;base64," + base64String;
                            imgPicture.Visible = true;

                            lblDateUploaded.Visible = true;
                            lblDateUploaded.Text += investigation.DateCreated.ToString("dd/MM/yyyy");
                            Response.Redirect("~/ThePages/Create/Investigation2.aspx", false);  //Refresh Page after succesful save, so gridview of investigations can load recently saved record
                            //Do Not Store Investigation in Patient entity. Implement a way to link list of investigations to a patient.
                        }
                        catch (Exception ex)
                        {
                            lblErrorMsg.Text = "Error Occurred, Cannot Upload!";
                            throw;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                        lblErrorMsg.Text = "Invalid File, Cannot Upload!";
                    }
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Please select a File";
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

        //protected void ibtnRemove_Click(object sender, ImageClickEventArgs e)
        //{
        //    imgPicture.ImageUrl = "~/Images/ghost_person.jpg";
        //}


        protected bool IsImageFile(HttpPostedFile file)
        {
            bool isImage = false;
            System.IO.FileStream fs = new System.IO.FileStream(file.FileName,
              System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer = br.ReadByte();
            fileclass = buffer.ToString();
            buffer = br.ReadByte();
            fileclass += buffer.ToString();
            br.Close();
            fs.Close();

            //only allow images    jpg       gif     bmp     png      
            String[] fileType = { "255216", "7173", "6677", "13780" };
            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    isImage = true;
                    break;
                }
            }
            return isImage;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ThePages/Create/ClinicVisits.aspx", false);
        }

        protected void btnViewImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    HttpPostedFile theFile = FileUpload1.PostedFile;
                    //if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                    if (theFile.FileName.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".bmp", StringComparison.InvariantCultureIgnoreCase) || theFile.FileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            //System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
                            //System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                            //Byte[] img = br.ReadBytes((Int32)fs.Length);
                            byte[] img = new byte[FileUpload1.PostedFile.ContentLength];

                            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.InputStream.Position == 0)
                            {
                                FileUpload1.PostedFile.InputStream.Read(img, 0, FileUpload1.PostedFile.ContentLength);
                            }

                            string base64String = Convert.ToBase64String(img, 0, img.Length);
                            imgPicture.ImageUrl = "data:image/png;base64," + base64String;
                            imgPicture.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            lblErrorMsg.Text = "Error Occurred, Cannot Upload!";
                            throw;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                        lblErrorMsg.Text = "Invalid File, Cannot Upload!";
                    }
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Please select a File";
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