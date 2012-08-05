using System;
using System.Net.Mail;
using AJH.CMS.Core.Configuration;
using AJH.CMS.WEB.UI.Utilities;
using System.IO;

namespace AJH.CMS.WEB.UI
{
    public partial class Career_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnSend.Click += new EventHandler(btnSend_Click);
        }
        #endregion

        #region btnSend_Click
        void btnSend_Click(object sender, EventArgs e)
        {
            string message = "<table><tr><td>Name:</td><td>" + Server.HtmlEncode(txtName.Text) + "</td></tr>";
            message += "<tr><td>Email:</td>" + "<td>" + Server.HtmlEncode(txtEmail.Text) + "</td></tr>";
            message += "<tr><td>Contact Number:</td>" + "<td>" + Server.HtmlEncode(txtContactNumber.Text) + "</td></tr>";
            message += "<tr><td>Department:</td>" + "<td>" + Server.HtmlEncode(ddlDepatment.SelectedValue) + "</td></tr>";
            message += "<tr><td>Cover Letter:</td>" + "<td>" + Server.HtmlEncode(txtCoverLetter.Text) + "</td></tr>";

            string fileName = Guid.NewGuid().ToString();
            string extension = string.Empty;

            if (fupResume.PostedFile != null && fupResume.PostedFile.ContentLength > 0)
            {
                extension = Path.GetExtension(fupResume.PostedFile.FileName);
                fileName += extension;

                fupResume.SaveAs(Server.MapPath("~/Portals/Portal" + CMSContext.PortalID + "/Uploads/Upload/" + fileName));
            }

            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.EmailInfo2);
            mail.To.Add(CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.EmailInfo2);

            mail.Subject = Server.HtmlEncode("New Career Application");
            mail.Body = message;

            mail.Priority = MailPriority.High;

            Attachment attachment = new Attachment(Server.MapPath("~/Portals/Portal" + CMSContext.PortalID + "/Uploads/Upload/" + fileName));
            mail.Attachments.Add(attachment);

            SmtpClient smtp = new SmtpClient();

            try
            {
                smtp.Send(mail);
            }
            catch { }
            finally
            {
            }

            pnlContactUs.Visible = false;
            dvMessage.Visible = true;
        }
        #endregion

        #endregion
    }
}