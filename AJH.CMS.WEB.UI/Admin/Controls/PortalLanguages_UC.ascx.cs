using System;
using System.Collections.Generic;
using System.ComponentModel;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class PortalLanguages_UC : System.Web.UI.UserControl
    {
        #region Properties

        public int SelectedLanguageID
        {
            set
            {
                hdnPortalLanguageSelect.Value = value.ToString();
            }
            get
            {
                int selectedLanguageID = -1;
                if (!int.TryParse(hdnPortalLanguageSelect.Value, out selectedLanguageID))
                    selectedLanguageID = -1;

                return selectedLanguageID;
            }
        }

        [Category("Behavior")]
        [Description("ValidationGroup")]
        [DefaultValue("")]
        public string ValidationGroup
        {
            set
            {
                cvPortalLanguageSelect.ValidationGroup = value;
            }
            get
            {
                return cvPortalLanguageSelect.ValidationGroup;
            }
        }

        public event EventHandler OnSelectLanguage;

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(PortalLanguages_UC_Load);
            this.dlstPortalLanguages.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(dlstPortalLanguages_ItemCommand);
            base.OnInit(e);
        }
        #endregion

        #region PortalLanguages_UC_Load
        void PortalLanguages_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PerformSettings();
                FillPortalLanguages();
            }
        }
        #endregion

        #region dlstPortalLanguages_ItemCommand
        void dlstPortalLanguages_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "PortalLanguageSelect":
                    SelectedLanguageID = Convert.ToInt32(e.CommandArgument);
                    if (OnSelectLanguage != null)
                        OnSelectLanguage(null, null);
                    break;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            cvPortalLanguageSelect.Attributes.Add("hdnPortalLanguageSelect", hdnPortalLanguageSelect.ClientID);
        }
        #endregion

        #region FillPortalLanguages
        private void FillPortalLanguages()
        {
            List<Language> portalLanguages = LanguageManager.GetLanguages(CMSContext.PortalID);
            dlstPortalLanguages.DataSource = portalLanguages;
            dlstPortalLanguages.DataBind();
        }
        #endregion

        #endregion
    }
}