using System;
using System.Net.Mail;
using AJH.CMS.Core.Configuration;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class ContactUs_UC : CMSUserControlBase
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
            message += "<tr><td>Subject:</td>" + "<td>" + Server.HtmlEncode(txtSubject.Text) + "</td></tr>";
            message += "<tr><td>Message:</td>" + "<td>" + Server.HtmlEncode(txtMessage.Text) + "</td></tr>";

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.EmailInfo);
            mail.To.Add(CoreConfigurationManager._CoreConfigSectionHandler.CustomerElement.EmailAdmin);

            if (cbSendCopyToYourSelf.Checked)
                mail.To.Add(txtEmail.Text);

            mail.Subject = Server.HtmlEncode(txtSubject.Text);
            mail.Body = message;

            mail.Priority = MailPriority.High;

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