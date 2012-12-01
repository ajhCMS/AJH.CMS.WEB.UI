using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageAttribute_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageAttribute_UC_Load);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.gvAttribute.RowCommand += new GridViewCommandEventHandler(gvAttribute_RowCommand);
            this.gvAttribute.PageIndexChanging += new GridViewPageEventHandler(gvAttribute_PageIndexChanging);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
        }

        void gvAttribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillAttributes(e.NewPageIndex);
            ExitMode();
            upnlAttribute.Update();
            upnlAttributeItem.Update();
        }

        void gvAttribute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditAttribute":
                    int AttributeID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out AttributeID);

                    if (AttributeID > 0)
                    {
                        ViewState[CMSViewStateManager.AttributeID] = AttributeID;
                        BeginEditMode();
                        upnlAttributeItem.Update();
                    }
                    break;
            }
        }

        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.AttributeID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    // Update Info Except Language Info :

                    AJH.CMS.Core.Entities.Attribute attribute =
                        AttributeManager.GetAttribute(Convert.ToInt32(ViewState[CMSViewStateManager.AttributeID]), CMSContext.LanguageID);

                    if (attribute != null)
                    {
                        AttributeManager.Update(attribute);
                        //SaveLanguage Info Only :
                        AJH.CMS.Core.Entities.Attribute langAttribute = new AJH.CMS.Core.Entities.Attribute
                        {
                            ID = Convert.ToInt32(ViewState[CMSViewStateManager.AttributeID]),
                            Name = txtName.Text,
                            GroupID = Convert.ToInt32(ddlGroup.SelectedValue),
                            LanguageID = ucPortalLanguage.SelectedLanguageID,
                            ModuleID = (int)CMSEnums.ECommerceModule.Attribute,
                        };

                        AttributeManager.AddOtherLanguage(langAttribute);
                        BeginAddMode();
                        FillAttributes(-1);
                        upnlAttribute.Update();
                        upnlAttributeItem.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlAttribute.Update();
                }
            }
        }

        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.AttributeID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    BeginEditModeOtherLanguage();
                    upnlAttributeItem.Update();

                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlAttribute.Update();

                }
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.AttributeID] != null && ucPortalLanguage.SelectedLanguageID > 0)
            {
                try
                {
                    AJH.CMS.Core.Entities.Attribute attribute =
                        AttributeManager.GetAttribute(Convert.ToInt32(ViewState[CMSViewStateManager.AttributeID]), CMSContext.LanguageID);

                    if (attribute != null)
                    {
                        attribute.Name = txtName.Text;
                        attribute.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                        attribute.LanguageID = ucPortalLanguage.SelectedLanguageID;
                        attribute.ModuleID = (int)CMSEnums.ECommerceModule.Attribute;

                        AttributeManager.Update(attribute);
                        FillAttributes(-1);
                        upnlAttribute.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlAttribute.Update();
                }

            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
            upnlAttribute.Update();
            upnlAttributeItem.Update();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.AttributeID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AJH.CMS.Core.Entities.Attribute attribute = new AJH.CMS.Core.Entities.Attribute();

                attribute.IsDeleted = false;
                attribute.LanguageID = CMSContext.LanguageID;
                attribute.PortalID = CMSContext.PortalID;
                attribute.Name = txtName.Text;
                attribute.GroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                attribute.ModuleID = (int)CMSEnums.ECommerceModule.Attribute;

                AttributeManager.Add(attribute);

                BeginAddMode();

                FillAttributes(-1);
                upnlAttribute.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.ToString();
                upnlAttribute.Update();
            }
        }

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvAttribute.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvAttribute.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvAttribute.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int AttributeID = Convert.ToInt32(hdnID.Value);
                        AttributeManager.DeleteLogical(AttributeID);
                    }
                }
            }
            FillAttributes(-1);
            ExitMode();
            upnlAttributeItem.Update();
        }
        #endregion

        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlAttributeItem.Update();
        }
        #endregion

        #region ManageAttribute_UC_Load
        void ManageAttribute_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillAttributes(-1);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvAttribute.ClientID + "','Are you sure to delete this item(s)?');";
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ucPortalLanguage.SelectedLanguageID = -1;
            ViewState.Remove(CMSViewStateManager.AttributeID);
            pnlAttributeItem.Visible = true;
            txtName.Text = string.Empty;
            cddGroup.SelectedValue = "0";

            ucPortalLanguage.Visible = false;
            ucPortalLanguage.SelectedLanguageID = -1;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnSaveOtherLanguage.Visible = false;

            pnlAttributeItem.Visible = true;

            pnlAttributeItem.DefaultButton = btnSave.ID;
        }
        #endregion

        private void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.AttributeID] != null)
            {
                AJH.CMS.Core.Entities.Attribute attribute =
                    AttributeManager.GetAttribute(Convert.ToInt32(ViewState[CMSViewStateManager.AttributeID]), CMSContext.LanguageID);
                if (attribute != null)
                {
                    pnlAttributeItem.Visible = true;
                    ucPortalLanguage.Visible = true;
                    ucPortalLanguage.SelectedLanguageID = attribute.LanguageID;

                    txtName.Text = attribute.Name;
                    cddGroup.SelectedValue = attribute.GroupID.ToString();

                    btnSave.Visible = false;
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
        }

        private void BeginEditModeOtherLanguage()
        {
            AJH.CMS.Core.Entities.Attribute attribute =
                AttributeManager.GetAttribute(Convert.ToInt32(ViewState[CMSViewStateManager.AttributeID]), ucPortalLanguage.SelectedLanguageID);
            if (attribute != null)
            {
                pnlAttributeItem.Visible = true;
                ucPortalLanguage.Visible = true;
                txtName.Text = attribute.Name;
                cddGroup.SelectedValue = attribute.GroupID.ToString();

                btnSave.Visible = false;

                if (string.IsNullOrEmpty(attribute.Name))
                {
                    btnSaveOtherLanguage.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnSaveOtherLanguage.Visible = false;
                    btnUpdate.Visible = true;
                }

            }
        }

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlAttributeItem.Visible = false;
        }
        #endregion

        #region FillAttributes
        private void FillAttributes(int PageIndex)
        {
            if (PageIndex > -1)
                gvAttribute.PageIndex = PageIndex;

            List<CMS.Core.Entities.Attribute> attributes =
                AttributeManager.GetAttributes(CMSContext.LanguageID);

            gvAttribute.DataSource = attributes;
            gvAttribute.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #endregion
    }
}