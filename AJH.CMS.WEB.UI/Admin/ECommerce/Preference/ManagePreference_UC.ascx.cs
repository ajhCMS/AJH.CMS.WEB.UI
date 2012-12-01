using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManagePreference_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageTax_UC_Load);

            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        #endregion

        #region btnSave_Click

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in cblstPreferneces.Items)
                {
                    Preference preference = PreferenceManager.GetPreference(item.Value);
                    if (preference != null)
                    {
                        PreferenceManager.UpdatePreference(preference.ID, item.Selected);
                    }
                    else
                    {
                        preference = new Preference
                        {
                            IsEnabled = item.Selected,
                            Name = item.Value,
                            PortalID = CMSContext.PortalID,
                        };

                        PreferenceManager.Add(preference);
                    }
                }

                FillPreferencesList();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlPreferenceItem.Update();
            }
        }

        #endregion

        #region ManageTax_UC_Load

        void ManageTax_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPreferencesList();
            }
        }

        #endregion

        #endregion

        #region Methods

        private void FillPreferencesList()
        {
            List<Preference> portalPreferences = PreferenceManager.GetPreferences(CMSContext.PortalID);
            if (portalPreferences != null && portalPreferences.Count > 0)
            {
                foreach (ListItem item in cblstPreferneces.Items)
                {
                    foreach (Preference preference in portalPreferences)
                    {
                        if (string.Equals(preference.Name, item.Value))
                            item.Selected = preference.IsEnabled;
                    }
                }
            }
        }

        #endregion
    }
}