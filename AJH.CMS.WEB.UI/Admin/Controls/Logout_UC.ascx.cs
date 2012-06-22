using System;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class Logout_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Logout_UC_Load);
            this.lbtnLogout.Click += new EventHandler(lbtnLogout_Click);
        }
        #endregion

        #region lbtnLogout_Click
        void lbtnLogout_Click(object sender, EventArgs e)
        {
            UserManager.LogOut();
            Response.Redirect(CMSConfig.CMSAdminPages.GetAdminLoginPage(), true);
        }
        #endregion

        #region Logout_UC_Load
        void Logout_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = UserManager.GetCurrentUser();
                if (user != null)
                    lblUserName.Text = user.Name;
            }
        }
        #endregion

        #endregion
    }
}