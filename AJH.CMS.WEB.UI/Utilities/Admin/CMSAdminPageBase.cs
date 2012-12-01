using System.Web.SessionState;
using System.Web.UI;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public class CMSAdminPageBase : Page, IRequiresSessionState
    {
        #region Events

        #region OnInit
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            if (CMSContext.CurrentUser == null)
            {
                UserManager.LogOut();
                Response.Redirect(CMSConfig.CMSAdminPages.GetAdminLoginPage(), true);
            }

            if (!IsPostBack)
            {
                //Localy to avoid Access Denied :)
                if (!UserManager.CheckIfHasAccessCMS(Request.Url.AbsolutePath))
                {
                    Response.Redirect(CMSConfig.CMSAdminPages.GetAdminAccessDenied(), true);
                }
            }
            this.Load += new System.EventHandler(CMSAdminPageBase_Load);
        }
        #endregion

        #region CMSAdminPageBase_Load
        void CMSAdminPageBase_Load(object sender, System.EventArgs e)
        {
            this.Header.DataBind();
        }
        #endregion

        #endregion
    }
}