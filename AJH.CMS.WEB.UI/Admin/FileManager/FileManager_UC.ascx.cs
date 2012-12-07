using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FileManager_UC : System.Web.UI.UserControl
    {
        #region Properties

        public string[] UploadPaths
        {
            get
            {
                return fexpManager.Configuration.UploadPaths;
            }
            set
            {
                fexpManager.Configuration.UploadPaths = value;
            }
        }

        public string[] ViewPaths
        {
            get
            {
                return fexpManager.Configuration.ViewPaths;
            }
            set
            {
                fexpManager.Configuration.ViewPaths = value;
            }
        }

        public string[] DeletePaths
        {
            get
            {
                return fexpManager.Configuration.DeletePaths;
            }
            set
            {
                fexpManager.Configuration.DeletePaths = value;
            }
        }

        public string[] SearchPatterns
        {
            get
            {
                return fexpManager.Configuration.SearchPatterns;
            }
            set
            {
                fexpManager.Configuration.SearchPatterns = value;
            }
        }

        public int MaxUploadFileSize
        {
            get
            {
                return fexpManager.Configuration.MaxUploadFileSize;
            }
            set
            {
                fexpManager.Configuration.MaxUploadFileSize = value;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FileManager_UC_Load);
        }
        #endregion

        #region FileManager_UC_Load
        void FileManager_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PerformSettings();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        protected void PerformSettings()
        {
            fexpManager.VisibleControls = Telerik.Web.UI.FileExplorer.FileExplorerControls.All;
            fexpManager.EnableOpenFile = true;
            fexpManager.DisplayUpFolderItem = true;
        }
        #endregion

        #endregion
    }
}