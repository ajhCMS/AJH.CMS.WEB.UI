using System;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FrmLogin_Load);
            this.loginUser.Authenticate += new System.Web.UI.WebControls.AuthenticateEventHandler(loginUser_Authenticate);
        }
        #endregion

        #region FrmLogin_Load
        void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Header.DataBind();
            if (CMSContext.CurrentUserID > 0)
            {
                Response.Redirect(CMSConfig.CMSAdminPages.GetAdminLandingPage(), true);
            }
        }
        #endregion

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            loginUser.Focus();
        }
        #endregion

        #region loginUser_Authenticate
        void loginUser_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            AJH.CMS.Core.Entities.User user = UserManager.GetUserWithValidation(loginUser.UserName, loginUser.Password);
            if (user != null)
            {
                UserManager.LoginIn(user, true);
                Response.Redirect(CMSConfig.CMSAdminPages.GetAdminLandingPage(), true);
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
        #endregion

        #endregion
    }
}