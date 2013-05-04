using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.WEB.UI.GUI.ECommerce.Customer
{
    public partial class LoginStatus_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(LoginStatus_UC_Load);
            this.lnkLogin.Click += new EventHandler(lnkLogin_Click);
            this.lnkLogout.Click += new EventHandler(lnkLogout_Click);
        }

        void lnkLogout_Click(object sender, EventArgs e)
        {
            UserManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }

        void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        #endregion

        #region Load
        void LoginStatus_UC_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!CheckForCreateUser())
                {
                    UserLogged.Visible = true;
                    LoginUser.Visible = false;
                    lblUserName.Text = string.Empty;
                    User oUser = UserManager.GetCurrentUser();
                    if (oUser != null)
                        lblUserName.Text = "Welcome, " + oUser.Name + "  ";
                }
                else
                {
                    UserLogged.Visible = false;
                    LoginUser.Visible = true;
                }

            }
        }
        #endregion


        #endregion

        #region Method
        #region CheckForCreateUser

        bool CheckForCreateUser()
        {
            if (CMSContext.CurrentUserID > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #endregion
    }
}