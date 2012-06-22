using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using AJH.CMS.WEB.UI.Utilities;
using System.Linq;

namespace AJH.CMS.WEB.UI.Controls.SWFUpload
{
    public partial class SWFUpload_UC : System.Web.UI.UserControl
    {
        #region Properties

        [Category("Behavior")]
        [Description("The page to upload files to.")]
        [DefaultValue("")]
        public string UploadPage
        {
            get
            {
                object o = ViewState["UploadPage"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["UploadPage"] = value; }
        }

        [Category("Behavior")]
        [Description("Javascript function to call when all files are uploaded.")]
        [DefaultValue("")]
        public string OnUploadComplete
        {
            get
            {
                object o = ViewState["OnUploadComplete"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["OnUploadComplete"] = value; }
        }

        [Category("Behavior")]
        [Description("The maximum file size that can be uploaded, \"1 MB\" (0 for no limit).")]
        public string UploadFileSizeLimit
        {
            get
            {
                object o = ViewState["UploadFileSizeLimit"];
                if (o == null)
                    return "1 MB";
                return o.ToString();
            }
            set { ViewState["UploadFileSizeLimit"] = value; }
        }

        [Category("Behavior")]
        [Description("The total number of files that can be uploaded (0 for no limit).")]
        public decimal TotalFilesUploadLimit
        {
            get
            {
                object o = ViewState["TotalFilesUploadLimit"];
                if (o == null)
                    return 0;
                return (decimal)o;
            }
            set { ViewState["TotalFilesUploadLimit"] = value; }
        }

        [Category("Behavior")]
        [Description("The total number of files that can be queued (0 for no limit).")]
        public decimal TotalFilesQueueLimit
        {
            get
            {
                object o = ViewState["TotalFilesQueueLimit"];
                if (o == null)
                    return 0;
                return (decimal)o;
            }
            set { ViewState["TotalFilesQueueLimit"] = value; }
        }

        [Category("Behavior")]
        [Description("The description of file types that you want uploads restricted to (ex. Images (*.JPG;*.JPEG;*.JPE;*.GIF;*.PNG;))")]
        [DefaultValue("")]
        public string FileTypeDescription
        {
            get
            {
                object o = ViewState["FileTypeDescription"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["FileTypeDescription"] = value; }
        }

        [Category("Behavior")]
        [Description("The file types to restrict uploads to (ex. *.jpg; *.jpeg; *.jpe; *.gif; *.png;)")]
        [DefaultValue("")]
        public string FileTypes
        {
            get
            {
                object o = ViewState["FileTypes"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["FileTypes"] = value; }
        }

        [Category("Behavior")]
        [Description("Button Image Url")]
        [DefaultValue("")]
        public string ButtonImageUrl
        {
            get
            {
                object o = ViewState["ButtonImageUrl"];
                if (o == null)
                    return "~/App_Themes/Image/button_upload.png";
                return o.ToString();
            }
            set { ViewState["ButtonImageUrl"] = value; }
        }

        [Category("Behavior")]
        [Description("Button Width")]
        [DefaultValue("")]
        public string ButtonWidth
        {
            get
            {
                object o = ViewState["ButtonWidth"];
                if (o == null)
                    return "61";
                return o.ToString();
            }
            set { ViewState["ButtonWidth"] = value; }
        }

        [Category("Behavior")]
        [Description("Button Height")]
        [DefaultValue("")]
        public string ButtonHeight
        {
            get
            {
                object o = ViewState["ButtonHeight"];
                if (o == null)
                    return "22";
                return o.ToString();
            }
            set { ViewState["ButtonHeight"] = value; }
        }

        [Category("Behavior")]
        [Description("Button Text")]
        [DefaultValue("")]
        public string ButtonText
        {
            get
            {
                object o = ViewState["ButtonText"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["ButtonText"] = value; }
        }

        [Category("Behavior")]
        [Description("Button Text Style")]
        [DefaultValue("")]
        public string ButtonTextStyle
        {
            get
            {
                object o = ViewState["ButtonTextStyle"];
                if (o == null)
                    return "";
                return o.ToString();
            }
            set { ViewState["ButtonTextStyle"] = value; }
        }

        [Category("Behavior")]
        [Description("ButtonTextLeftPadding")]
        [DefaultValue("")]
        public string ButtonTextLeftPadding
        {
            get
            {
                object o = ViewState["ButtonTextLeftPadding"];
                if (o == null)
                    return "0";
                return o.ToString();
            }
            set { ViewState["ButtonTextLeftPadding"] = value; }
        }

        [Category("Behavior")]
        [Description("ButtonTextTopPadding")]
        [DefaultValue("")]
        public string ButtonTextTopPadding
        {
            get
            {
                object o = ViewState["ButtonTextTopPadding"];
                if (o == null)
                    return "0";
                return o.ToString();
            }
            set { ViewState["ButtonTextTopPadding"] = value; }
        }

        [Category("Behavior")]
        [Description("Title")]
        [DefaultValue("")]
        public string ProgressTitle
        {
            get
            {
                object o = ViewState["Title"];
                if (o == null)
                    return "Upload Queue";
                return o.ToString();
            }
            set { ViewState["Title"] = value; }
        }

        [Category("Behavior")]
        [Description("IsImage")]
        [DefaultValue("")]
        public bool IsImage
        {
            get
            {
                if (ViewState["IsImage"] != null)
                {
                    return Convert.ToBoolean(ViewState["IsImage"]);
                }
                return false;
            }
            set
            {
                ViewState["IsImage"] = value;
            }
        }

        [Category("Behavior")]
        [Description("SWFClientID")]
        [DefaultValue("")]
        public string SWFClientID
        {
            get
            {
                return "swfu" + ClientID;
            }
        }


        [Category("Behavior")]
        [Description("ValidationGroup")]
        [DefaultValue("")]
        public string ValidationGroup
        {
            get
            {
                return cvFlashUpload.ValidationGroup;
            }
            set
            {
                cvFlashUpload.ValidationGroup = value;
            }
        }

        [Category("Behavior")]
        [Description("ErrorText")]
        [DefaultValue("")]
        public string ErrorText
        {
            get
            {
                return cvFlashUpload.Text;
            }
            set
            {
                cvFlashUpload.Text = value;
            }
        }

        [Category("Behavior")]
        [Description("ErrorMessage")]
        [DefaultValue("")]
        public string ErrorMessage
        {
            get
            {
                return cvFlashUpload.ErrorMessage;
            }
            set
            {
                cvFlashUpload.ErrorMessage = value;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SWFUpload_UC_Load);
            this.lbtnRemove.Click += new EventHandler(lbtnRemove_Click);
            RegisterScripts();
        }
        #endregion

        #region lbtnRemove_Click
        void lbtnRemove_Click(object sender, EventArgs e)
        {
            BeginAddMode();
        }
        #endregion

        #region SWFUpload_UC_Load
        void SWFUpload_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PerformSettings();
            }
        }
        #endregion

        #region OnPreRender
        protected override void OnPreRender(EventArgs e)
        {
            string scriptFlash = "<script type=\"text/javascript\" language=\"javascript\">" +
            "\n" + "var " + this.SWFClientID + ";" +
                //"\n" + "window.onload = function () {" +
            "\n" + "var settings = {" +
                "\n" + "flash_url: \"" + ResolveClientUrl("~/Controls/SWFUpload/script/swfupload.swf") + "\"," +
                "\n" + "upload_url: \"" + ResolveClientUrl(UploadPage) + "\"," +
                "\n" + "post_params: { \"ASPSESSIONID\": \"" + Session.SessionID + "\" }," +
                "\n" + "file_size_limit: \"" + UploadFileSizeLimit + "\"," +
                "\n" + "file_types: \"" + FileTypes + "\"," +
                "\n" + "file_types_description: \"" + FileTypeDescription + "\"," +
                "\n" + "file_upload_limit: " + TotalFilesUploadLimit + "," +
                "\n" + "file_queue_limit: " + TotalFilesQueueLimit + "," +
                "\n" + "custom_settings: {" +
                    "\n" + "progressTarget: \"" + fsUploadProgress.ClientID + "\"," +
                    "\n" + "cancelButtonId: \"" + btnCancel.ClientID + "\"" +
                "\n" + "}," +
                "\n" + "debug: false," +

                "\n" + "// Button settings" +
                "\n" + "button_image_url: \"" + ResolveClientUrl(ButtonImageUrl) + "\"," +
                "\n" + "button_width: \"" + ButtonWidth + "\"," +
                "\n" + "button_height: \"" + ButtonHeight + "\"," +
                "\n" + "button_placeholder_id: \"" + spanButtonPlaceHolder.ClientID + "\"," +
                //"\n" + "button_text: '" + ButtonText + "'," +
                //"\n" + "button_text_style: \"" + ButtonTextStyle + "\"," +
                //"\n" + "button_text_left_padding: " + ButtonTextLeftPadding + "," +
                //"\n" + "button_text_top_padding: " + ButtonTextTopPadding + "," +

                // The event handler functions are defined in handlers.js
                "\n" + "file_queued_handler: fileQueued," +
                "\n" + "file_queue_error_handler: fileQueueError," +
                "\n" + "file_dialog_complete_handler: fileDialogComplete," +
                "\n" + "upload_start_handler: uploadStart," +
                "\n" + "upload_progress_handler: uploadProgress," +
                "\n" + "upload_error_handler: uploadError," +
                "\n" + "upload_success_handler: uploadSuccess," +
                "\n" + "upload_complete_handler: uploadComplete," +
                "\n" + "upload_cancel_handler: uploadCancel," +
                "\n" + "queue_complete_handler: queueComplete, // Queue plugin event" +
                "\n" + GetApplicationUploadComplete() +

                "\n" + "files_names_hidden_id: \"" + hdnFilesName.ClientID + "\"," +
                "\n" + "status_placeholder_id: \"" + divStatus.ClientID + "\"" +
                "\n" + "};" +
                "\n" + this.SWFClientID + " = new SWFUpload(settings);" +
                "\n" + "refreshNumber(" + this.SWFClientID + ".settings);" +
                "\n" + "</script>";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID, scriptFlash, false);

            base.OnPreRender(e);
        }
        #endregion

        #endregion

        #region Methods

        #region RegisterScripts
        void RegisterScripts()
        {

            ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/fileprogress.js"));
            ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/handlers.js"));
            ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/swfupload.js"));
            ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/swfupload.queue.js"));

            //ScriptReferenceCollection scCol = ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts;

            //ScriptReference scReference = scCol.Where(sc => sc.Path.Contains("Controls/SWFUpload/script/fileprogress.js")).FirstOrDefault();
            //if (scReference == null)
            //    ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/fileprogress.js"));

            //scReference = scCol.Where(sc => sc.Path.Contains("Controls/SWFUpload/script/handlers.js")).FirstOrDefault();
            //if (scReference == null)
            //    ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/handlers.js"));

            //scReference = scCol.Where(sc => sc.Path.Contains("Controls/SWFUpload/script/swfupload.js")).FirstOrDefault();
            //if (scReference == null)

            //    ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/swfupload.js"));

            //scReference = scCol.Where(sc => sc.Path.Contains("/Controls/SWFUpload/script/swfupload.queue.js")).FirstOrDefault();
            //if (scReference == null)
            //    ScriptManager.GetCurrent(this.Page).CompositeScript.Scripts.Add(new ScriptReference("~/Controls/SWFUpload/script/swfupload.queue.js"));
        }
        #endregion

        #region GetApplicationUploadComplete
        protected string GetApplicationUploadComplete()
        {
            if (string.IsNullOrEmpty(OnUploadComplete))
                return string.Empty;
            return "application_upload_complete: " + OnUploadComplete + ",";
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            btnCancel.Attributes.Add("onclick", SWFClientID + ".cancelQueue();return false;");
            cvFlashUpload.Attributes.Add("btnCancel", btnCancel.ClientID);
        }
        #endregion

        #region GetFilesName
        public List<string> GetFilesName()
        {
            List<string> filesName = new List<string>();

            string[] allFiles = hdnFilesName.Value.Split('|');
            for (int i = 0; i < allFiles.Length; i++)
            {
                string[] fileName = allFiles[i].Split('?');
                if (fileName.Length == 2 && !string.IsNullOrEmpty(fileName[1]))
                {
                    filesName.Add(fileName[1]);
                    continue;
                }

                if (fileName.Length == 1 && !string.IsNullOrEmpty(fileName[0]))
                {
                    filesName.Add(fileName[0]);
                    continue;
                }
            }

            return filesName;
        }
        #endregion

        #region BeginAddMode
        public void BeginAddMode()
        {
            hdnFilesName.Value = string.Empty;
            dvEditMode.Visible = false;
        }
        #endregion

        #region BeginEditMode
        public void BeginEditMode(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                hdnFilesName.Value = fileName;
                dvEditMode.Visible = true;
                imgFile.Visible = false;
                if (IsImage)
                {
                    imgFile.Visible = true;
                    imgFile.ImageUrl = CMSContext.VirtualUploadThumbnailFolder + fileName;
                }
            }
            else
            {
                BeginAddMode();
            }
        }
        #endregion

        #endregion
    }
}