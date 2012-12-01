using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AJH.CMS.WEB.UI.Controls
{
    public partial class Editor_UC : System.Web.UI.UserControl
    {
        #region Properties

        public string Text
        {
            get
            {
                return txtContent.Content;
            }
            set
            {
                txtContent.Content = value;
            }
        }
        public Unit Width
        {
            get
            {
                return txtContent.Width;
            }
            set
            {
                txtContent.Width = value;
            }
        }
        public Unit Height
        {
            get
            {
                return txtContent.Height;
            }
            set
            {
                txtContent.Height = value;
            }
        }
        public EditorFilters ContentFilters
        {
            get
            {
                return txtContent.ContentFilters;
            }
            set
            {
                txtContent.ContentFilters = value;
            }
        }
        public EditModes EditModes
        {
            get
            {
                return txtContent.EditModes;
            }
            set
            {
                txtContent.EditModes = value;
                switch (value)
                {
                    case Telerik.Web.UI.EditModes.Html:
                        txtContent.ToolsFile = "~/Controls/Editor_HTML.xml";
                        break;
                }
            }
        }
        public string UploadPath
        {
            get
            {
                if (ViewState["UploadPath"] != null)
                    return ViewState["UploadPath"].ToString();
                return AJH.CMS.WEB.UI.Utilities.CMSContext.VirtualPortalFolder;
            }
            set
            {
                ViewState["UploadPath"] = value;
            }
        }
        public bool IsRequired
        {
            get
            {
                return rfvDetails.Enabled;
            }
            set
            {
                rfvDetails.Enabled = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return rfvDetails.ErrorMessage;
            }
            set
            {
                rfvDetails.ErrorMessage = value;
            }
        }
        public string ValidationGroup
        {
            get
            {
                return rfvDetails.ValidationGroup;
            }
            set
            {
                rfvDetails.ValidationGroup = value;
            }
        }
        public string ErrorText
        {
            get
            {
                return rfvDetails.Text;
            }
            set
            {
                rfvDetails.Text = value;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Editor_UC_Load);
        }
        #endregion

        #region Editor_UC_Load
        void Editor_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] paths = { UploadPath };
                txtContent.SetPaths(paths, EditorFileTypes.All, EditorFileOptions.All);
            }
        }
        #endregion

        #endregion
    }
}