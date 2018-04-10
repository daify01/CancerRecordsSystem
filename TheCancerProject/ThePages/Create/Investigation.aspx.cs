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
                            InvestigationDAO.Save(investigation);


                            string base64String = Convert.ToBase64String(img, 0, img.Length);
                            imgPicture.ImageUrl = "data:image/png;base64," + base64String;
                            imgPicture.Visible = true;

                            lblDateUploaded.Visible = true;
                            lblDateUploaded.Text += investigation.DateCreated.ToString("dd/MM/yyyy");
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

        protected void btnAddNewInvestigation_Click(object sender, EventArgs e)
        {
            int fileUploadIndex = pnlImage.Controls.OfType<FileUpload>().ToList().Count + 1;
            int buttonIndex = pnlImage.Controls.OfType<Button>().ToList().Count + 1;
            int imageIndex = pnlImage.Controls.OfType<Image>().ToList().Count + 1;
            int textBoxIndex = pnlImage.Controls.OfType<TextBox>().ToList().Count + 1;
            int labelIndex = pnlImage.Controls.OfType<Label>().ToList().Count + 1;

            pnlImage.Controls.Add(new LiteralControl(@"<div class=""col-md-5"">"));
            pnlImage.Controls.Add(new LiteralControl(@"<label for=""summary"">UPLOAD A PHOTO</label>"));
            this.CreateFileUploadControl("FileUpload1" + fileUploadIndex);
            this.CreateViewImageButtonControl("viewImage" + buttonIndex);
            this.CreateImageControl("imgPicture" + imageIndex);
            pnlImage.Controls.Add(new LiteralControl("</div>"));
            pnlImage.Controls.Add(new LiteralControl(@"<div class=""col-md-7"">"));
            pnlImage.Controls.Add(new LiteralControl("<br />"));
            pnlImage.Controls.Add(new LiteralControl("<br />"));
            this.CreateTextBoxControl("txtSummary" + textBoxIndex);
            pnlImage.Controls.Add(new LiteralControl("<br />"));
            this.CreateLabelControl("lblDateUploaded" + labelIndex);
            pnlImage.Controls.Add(new LiteralControl("</div>"));
            pnlImage.Controls.Add(new LiteralControl(""));
            pnlImage.Controls.Add(new LiteralControl("<br />"));
            pnlImage.Controls.Add(new LiteralControl(""));
            //this.createLiteral(@"<div class=""col - md - 3"">", pnlImage);
            pnlImage.Controls.Add(new LiteralControl(@"<div class=""col-md-3"">"));
            //this.createLiteral("</div>", pnlImage);
            pnlImage.Controls.Add(new LiteralControl("</div>"));            
            this.CreateSaveEntriesButtonControl("saveEntries" + (buttonIndex + 1));
        }

        private void CreateTextBoxControl(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            txt.TextMode = TextBoxMode.MultiLine;
            txt.Columns = 100;
            txt.Rows = 20;
            pnlImage.Controls.Add(txt);            
        }

        private void CreateFileUploadControl(string id)
        {
            FileUpload fUpload = new FileUpload();
            fUpload.ID = id;
            pnlImage.Controls.Add(fUpload);
        }

        private void CreateViewImageButtonControl(string id)
        {
            Button viewImage = new Button();
            viewImage.ID = id;
            viewImage.CssClass = "btn btn-flat btn-primary";
            viewImage.Text = "View Image";
            pnlImage.Controls.Add(viewImage);
        }

        private void CreateSaveEntriesButtonControl(string id)
        {
            Button saveEntries = new Button();
            saveEntries.ID = id;
            saveEntries.CssClass = "btn btn-flat btn-primary col-md-6";
            saveEntries.Text = "Save Entries";
            pnlImage.Controls.Add(saveEntries);
        }
        private void CreateImageControl(string id)
        {
            Image image = new Image();
            image.ID = id;
            image.ImageUrl = "~/dist/img/DefualtUploadImage.png";
            image.Visible = true;
            image.Height = 400;
            image.Width = 400;
            viewImage.Text = "View Image";
            pnlImage.Controls.Add(image);
        }

        private void CreateLabelControl(string id)
        {
            Label label = new Label();
            label.ID = id;
            label.Text = "Date Uploaded: ";
            pnlImage.Controls.Add(label);
        }

        private void createLiteral(string text, Panel panel)
        {
            Literal lt = new Literal();
            // lt.Text = "<br />";
            lt.Text = text;
            panel.Controls.Add(lt);
        }
    }
}