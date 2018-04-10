using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheCancerProject.Data.DAO;

namespace TheCancerProject.ThePages.Create
{
    public partial class Investigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ibtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                {
                    try
                    {
                        TheCancerProject.Core.Investigation investigation = new TheCancerProject.Core.Investigation();
                        System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        Byte[] img = br.ReadBytes((Int32)fs.Length);

                        investigation.Image = img;
                        investigation.Summary = txtSummary.Text;
                        investigation.DateCreated = DateTime.Now;
                        InvestigationDAO.Save(investigation);

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

        }

        protected void btnViewImage_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (IsImageFile((HttpPostedFile)FileUpload1.PostedFile))
                {
                    try
                    {
                        System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        Byte[] img = br.ReadBytes((Int32)fs.Length);

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
    }
}