using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Configuration;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.GUI.ECommerce.Customer
{
    public partial class CustomerLogin_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FrmCustomerLogin_Load);
            this.loginCustomer.Authenticate += new AuthenticateEventHandler(loginCustomer_Authenticate);
        }

        #region loginUser_Authenticate
        void loginCustomer_Authenticate(object sender, AuthenticateEventArgs e)
        {
            AJH.CMS.Core.Entities.User user = UserManager.GetUserWithValidation(loginCustomer.UserName, loginCustomer.Password);
            if (user != null)
            {
                UserManager.LoginIn(user, true);
                Response.Redirect("~/Default.aspx");
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
        #endregion

        #region FrmLogin_Load
        void FrmCustomerLogin_Load(object sender, EventArgs e)
        {
            //this.Header.DataBind();
            if (CMSContext.CurrentUserID > 0)
            {
                upnlLogin.Visible = false;
                Response.Redirect("~/Default.aspx");
            }
        }
        #endregion

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            loginCustomer.Focus();
        }
        #endregion
        #endregion
        #endregion

    }
}