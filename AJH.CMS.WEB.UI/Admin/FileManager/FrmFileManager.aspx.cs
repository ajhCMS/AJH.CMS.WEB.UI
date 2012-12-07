
namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FrmFileManager : CMSAdminPageBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(FrmFileManager_Load);
        }
        #endregion

        #region FrmFileManager_Load
        void FrmFileManager_Load(object sender, System.EventArgs e)
        {
            string PortalFolder = AJH.CMS.WEB.UI.Utilities.CMSContext.VirtualPortalFolder.Replace(@"\", "/");
            ucFileManager.UploadPaths = new string[] { PortalFolder };
            ucFileManager.DeletePaths = new string[] { PortalFolder };
            ucFileManager.ViewPaths = new string[] { PortalFolder };
        }
        #endregion

        #endregion
    }
}