using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ManageGallery_UC : System.Web.UI.UserControl
    {
        #region Properties

        private int SelectedParentGalleryObjID
        {
            set
            {
                ViewState[CMSViewStateManager.SelectedParentGalleryObjID] = value;
            }
            get
            {
                int selectedParentGalleryObjID = -1;
                if (ViewState[CMSViewStateManager.SelectedParentGalleryObjID] != null)
                    selectedParentGalleryObjID = Convert.ToInt32(ViewState[CMSViewStateManager.SelectedParentGalleryObjID]);

                return selectedParentGalleryObjID;
            }
        }

        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageGallery_UC_Load);
            this.ibtnSearchCategory.Click += new ImageClickEventHandler(ibtnSearchCategory_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.dlsGallery.ItemCommand += new DataListCommandEventHandler(dlsGallery_ItemCommand);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ddlGalleryItemType.SelectedIndexChanged += new EventHandler(ddlGalleryItemType_SelectedIndexChanged);
            this.btnAddExit.Click += new EventHandler(btnAddExit_Click);
            this.btnAddReset.Click += new EventHandler(btnAddReset_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSaveOtherLanguage.Click += new EventHandler(btnSaveOtherLanguage_Click);
            this.btnUpdateOtherLanguage.Click += new EventHandler(btnUpdateOtherLanguage_Click);
            this.ucPortalLanguage.OnSelectLanguage += new EventHandler(ucPortalLanguage_OnSelectLanguage);
            this.ibtnPublish.Click += new ImageClickEventHandler(ibtnPublish_Click);
            this.ibtnUnPublish.Click += new ImageClickEventHandler(ibtnUnPublish_Click);
        }
        #endregion

        #region ibtnSearchCategory_Click
        void ibtnSearchCategory_Click(object sender, ImageClickEventArgs e)
        {
            int CategoryID = 0;
            int.TryParse(cddSearchCategory.SelectedValue, out CategoryID);
            if (CategoryID > 0)
            {
                ViewState[CMSViewStateManager.CategoryID] = CategoryID;
                FillGallerys();
            }
            else
            {
                ExitGrid();
            }
            ExitMode();
            upnlGallery.Update();
            upnlGalleryItem.Update();
            upnlGalleryAdd.Update();
        }
        #endregion

        #region btnUpdateOtherLanguage_Click
        void btnUpdateOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                if (ucPortalLanguage.SelectedLanguageID > 0 && SelectedParentGalleryObjID > 0)
                {
                    try
                    {
                        CMS.Core.Entities.Gallery gallery =
                            GalleryManager.GetGalleryByParentObjIdAndLanguageId(SelectedParentGalleryObjID, ucPortalLanguage.SelectedLanguageID);

                        if (gallery != null)
                        {
                            gallery.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                            gallery.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                            gallery.Description = txtDescription.Text;
                            gallery.Details = txtDetails.Text;
                            gallery.IsDeleted = false;
                            gallery.KeyWords = string.Empty;
                            gallery.Name = txtName.Text;
                            gallery.Order = Convert.ToInt32(txtOrderNumber.Text);
                            gallery.Summary = txtSummary.Text;
                            gallery.PortalID = CMSContext.PortalID;
                            gallery.SEOName = string.Empty;
                            GalleryManager.Update(gallery);
                        }
                    }
                    catch (Exception ex)
                    {
                        dvProblems.Visible = true;
                        dvProblems.InnerText = ex.ToString();
                        upnlGallery.Update();
                    }
                }
            }
        }
        #endregion

        #region ucPortalLanguage_OnSelectLanguage
        void ucPortalLanguage_OnSelectLanguage(object sender, EventArgs e)
        {
            if (ucPortalLanguage.SelectedLanguageID > 0)
            {
                if (ucPortalLanguage.SelectedLanguageID == CMSContext.LanguageID)
                    BeginEditMode();
                else
                    BeginEditModeOtherLanguage();
            }
            else
            {
                BeginAddMode();
                upnlGalleryItem.Update();
            }
        }
        #endregion

        #region btnSaveOtherLanguage_Click
        void btnSaveOtherLanguage_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Gallery gallery = GalleryManager.GetGallery(SelectedParentGalleryObjID);
                    if (gallery != null)
                    {
                        gallery.ID = 0;
                        gallery.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                        gallery.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        gallery.Description = txtDescription.Text;
                        gallery.Details = txtDetails.Text;
                        gallery.IsDeleted = false;
                        gallery.KeyWords = string.Empty;
                        gallery.LanguageID = CMSContext.LanguageID;
                        gallery.Name = txtName.Text;
                        gallery.Order = Convert.ToInt32(txtOrderNumber.Text);
                        gallery.Summary = txtSummary.Text;
                        gallery.PortalID = CMSContext.PortalID;
                        gallery.SEOName = string.Empty;

                        if (ucPortalLanguage.SelectedLanguageID > 0)
                            gallery.LanguageID = ucPortalLanguage.SelectedLanguageID;

                        gallery.ParentObjectID = SelectedParentGalleryObjID;

                        GalleryManager.Add(gallery);

                        BeginAddModeOtherLanguage();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGallery.Update();
                }
            }
        }
        #endregion

        #region btnAdd_Click
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Gallery gallery = new Core.Entities.Gallery();
                    gallery.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                    gallery.ID = 0;
                    gallery.IsDeleted = false;
                    gallery.LanguageID = CMSContext.LanguageID;
                    gallery.GalleryItemType = (CMSEnums.GalleryItemType)Convert.ToInt32(cddGalleryItemType.SelectedValue);
                    gallery.GalleryType = CMSEnums.GalleryType.Photo;
                    gallery.Name = txtAddName.Text;
                    gallery.Order = 0;
                    gallery.PortalID = CMSContext.PortalID;
                    gallery.URL = txtAddURL.Text;
                    gallery.CreatedBy = CMSContext.CurrentUserID;
                    switch (gallery.GalleryItemType)
                    {
                        case CMSEnums.GalleryItemType.Internal:
                            List<string> FilesUpload = ucSWFUpload.GetFilesName();
                            if (FilesUpload != null && FilesUpload.Count > 0)
                            {
                                for (int i = 0; i < FilesUpload.Count; i++)
                                {
                                    gallery.Name = Path.GetFileNameWithoutExtension(FilesUpload[i]);
                                    gallery.File = FilesUpload[i];
                                    GalleryManager.Add(gallery);
                                }

                            }
                            break;
                        case CMSEnums.GalleryItemType.External:
                            GalleryManager.Add(gallery);
                            break;
                    }

                    BeginAddMode();
                    FillGallerys();
                    upnlGallery.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGallery.Update();
                }
            }
        }
        #endregion

        #region btnAddReset_Click
        void btnAddReset_Click(object sender, EventArgs e)
        {
            BeginAddMode();
        }
        #endregion

        #region ddlGalleryItemType_SelectedIndexChanged
        void ddlGalleryItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int GalleryItemType = 0;
            int.TryParse(cddGalleryItemType.SelectedValue, out GalleryItemType);
            switch ((CMSEnums.GalleryItemType)GalleryItemType)
            {
                case CMSEnums.GalleryItemType.Internal:
                    trAddName.Visible = false;
                    trAddURL.Visible = false;
                    trMultiUpload.Visible = true;
                    btnAdd.Attributes.Add("style", "display:none");
                    break;
                case CMSEnums.GalleryItemType.External:
                    trAddName.Visible = true;
                    trAddURL.Visible = true;
                    trMultiUpload.Visible = false;
                    btnAdd.Attributes.Remove("style");
                    break;
            }
        }
        #endregion

        #region btnAddExit_Click
        void btnAddExit_Click(object sender, EventArgs e)
        {
            ExitMode();
        }
        #endregion

        #region dlsGallery_ItemCommand
        void dlsGallery_ItemCommand(object source, DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditGallery":
                    int GalleryID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out GalleryID);

                    if (GalleryID > 0)
                    {
                        ViewState[CMSViewStateManager.GalleryID] = GalleryID;
                        SelectedParentGalleryObjID = GalleryID;

                        BeginEditMode();
                        upnlGalleryItem.Update();
                        upnlGalleryAdd.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < dlsGallery.Items.Count; i++)
            {
                if (dlsGallery.Items[i].ItemType == ListItemType.Item || dlsGallery.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkItem = (CheckBox)dlsGallery.Items[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)dlsGallery.Items[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int GalleryID = Convert.ToInt32(hdnID.Value);
                            GalleryManager.DeleteLogical(GalleryID);
                        }
                    }
                }
            }
            FillGallerys();
            ExitMode();
            upnlGalleryItem.Update();
            upnlGalleryAdd.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlGalleryItem.Update();
            upnlGalleryAdd.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.GalleryID] != null)
            {
                try
                {
                    CMS.Core.Entities.Gallery gallery = GalleryManager.GetGallery(Convert.ToInt32(ViewState[CMSViewStateManager.GalleryID]));
                    if (gallery != null)
                    {
                        gallery.CreationDate = ucAjaxDate.SelectedDateTime.Value;
                        gallery.CategoryID = Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]);
                        gallery.Description = txtDescription.Text;
                        gallery.Details = txtDetails.Text;
                        gallery.IsDeleted = false;
                        gallery.KeyWords = string.Empty;
                        gallery.LanguageID = CMSContext.LanguageID;
                        gallery.Name = txtName.Text;
                        gallery.Order = Convert.ToInt32(txtOrderNumber.Text);
                        gallery.Summary = txtSummary.Text;
                        gallery.PortalID = CMSContext.PortalID;
                        gallery.SEOName = string.Empty;
                        GalleryManager.Update(gallery);

                        FillGallerys();
                        upnlGallery.Update();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.ToString();
                    upnlGallery.Update();
                }
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.GalleryID] != null)
            {
                BeginEditMode();
            }
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
        }
        #endregion

        #region ManageGallery_UC_Load
        void ManageGallery_UC_Load(object sender, EventArgs e)
        {
            ReflectDDL();
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                ExitGrid();
                ExitMode();
            }
        }
        #endregion

        #region ibtnUnPublish_Click

        void ibtnUnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < dlsGallery.Items.Count; i++)
            {
                if (dlsGallery.Items[i].ItemType == ListItemType.Item || dlsGallery.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkItem = (CheckBox)dlsGallery.Items[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)dlsGallery.Items[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int galleryID = Convert.ToInt32(hdnID.Value);
                            PublishManager.DeleteByObjectIDAndModuleId(galleryID, (int)AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery);
                        }
                    }
                }
            }
            FillGallerys();
            ExitMode();
            upnlGalleryItem.Update();
            upnlGalleryAdd.Update();
        }

        #endregion

        #region ibtnPublish_Click

        void ibtnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < dlsGallery.Items.Count; i++)
            {
                if (dlsGallery.Items[i].ItemType == ListItemType.Item || dlsGallery.Items[i].ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkItem = (CheckBox)dlsGallery.Items[i].FindControl("chkItem");
                    if (chkItem != null && chkItem.Checked)
                    {
                        HtmlInputHidden hdnID = (HtmlInputHidden)dlsGallery.Items[i].FindControl("hdnID");
                        if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                        {
                            int galleryID = Convert.ToInt32(hdnID.Value);
                            PublishManager.Add(PrepareNewPublish(galleryID));
                        }
                    }
                }
            }
            FillGallerys();
            ExitMode();
            upnlGalleryItem.Update();
            upnlGalleryAdd.Update();
        }

        #endregion

        #endregion

        #region Methods

        #region FillGallerys
        private void FillGallerys()
        {
            dlsGallery.DataSource =
                GalleryManager.GetParentObjGallerysByCategoryID(Convert.ToInt32(ViewState[CMSViewStateManager.CategoryID]), CMSEnums.GalleryType.Photo);

            dlsGallery.DataBind();
            pnlView.Visible = true;
        }
        #endregion

        #region ExitGrid
        void ExitGrid()
        {
            ViewState.Remove(CMSViewStateManager.CategoryID);
            pnlView.Visible = false;
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlGalleryAdd.Visible = false;
        }
        #endregion

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + dlsGallery.ClientID + "','Are you sure to delete this item(s)?');";
            ibtnPublish.OnClientClick = "return ConfirmOperation('" + dlsGallery.ClientID + "','Are you sure to publish this item(s)?');";
            ibtnUnPublish.OnClientClick = "return ConfirmOperation('" + dlsGallery.ClientID + "','Are you sure to unpublish this item(s)?');";

            cddSearchCategory.Category = CMSConfig.ConstantManager.CategoryCategory + (int)CMSEnums.Modules.Gallery;
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                ViewState.Remove(CMSViewStateManager.SelectedParentGalleryObjID);
                ViewState.Remove(CMSViewStateManager.GalleryID);
                pnlGalleryItem.Visible = false;
                txtDescription.Text = string.Empty;
                txtDetails.Text = string.Empty;
                txtName.Text = string.Empty;
                txtOrderNumber.Text = "0";
                txtSummary.Text = string.Empty;
                txtOrderNumber.Text = "0";
                ucAjaxDate.SelectedDateTime = DateTime.Now;
                ucSWFUpload.BeginAddMode();

                pnlGalleryAdd.Visible = true;
                cddGalleryItemType.SelectedValue = ((int)CMSEnums.GalleryItemType.Internal).ToString();
                txtAddName.Text = string.Empty;
                txtAddURL.Text = string.Empty;
                trAddName.Visible = false;
                trAddURL.Visible = false;
                trMultiUpload.Visible = true;

                ucPortalLanguage.Visible = false;
                ucPortalLanguage.SelectedLanguageID = -1;

                btnSaveOtherLanguage.Visible = false;

                trIsPublished.Visible = true;
                cbIsPublished.Checked = false;

                btnAdd.Attributes.Add("style", "display:none");
                Session.Remove(CMSConfig.ConstantManager.FileUploadKey);
            }
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null && ViewState[CMSViewStateManager.GalleryID] != null)
            {
                ucPortalLanguage.SelectedLanguageID = -1;

                CMS.Core.Entities.Gallery gallery = GalleryManager.GetGallery(Convert.ToInt32(ViewState[CMSViewStateManager.GalleryID]));
                if (gallery != null)
                {
                    pnlGalleryItem.Visible = true;
                    SelectedParentGalleryObjID = gallery.ID;
                    txtDescription.Text = gallery.Description;
                    txtDetails.Text = gallery.Details;
                    txtName.Text = gallery.Name;
                    txtOrderNumber.Text = gallery.Order.ToString();
                    txtSummary.Text = gallery.Summary;
                    ucAjaxDate.SelectedDateTime = gallery.CreationDate;

                    ucPortalLanguage.SelectedLanguageID = gallery.LanguageID;
                    ucPortalLanguage.Visible = true;

                    btnSaveOtherLanguage.Visible = false;
                    btnUpdateOtherLanguage.Visible = false;

                    trIsPublished.Visible = false;

                    pnlGalleryAdd.Visible = false;
                    cddGalleryItemType.SelectedValue = ((int)CMSEnums.GalleryItemType.Internal).ToString();
                    txtAddName.Text = string.Empty;
                    txtAddURL.Text = string.Empty;
                    btnUpdate.Visible = true;
                }
            }
        }
        #endregion

        #region BeginEditModeOtherLanguage
        void BeginEditModeOtherLanguage()
        {
            if (ViewState[CMSViewStateManager.CategoryID] != null)
            {
                if (ucPortalLanguage.SelectedLanguageID > 0 && SelectedParentGalleryObjID > 0)
                {
                    CMS.Core.Entities.Gallery gallery =
                        GalleryManager.GetGalleryByParentObjIdAndLanguageId(SelectedParentGalleryObjID, ucPortalLanguage.SelectedLanguageID);

                    if (gallery != null)
                    {
                        pnlGalleryItem.Visible = true;
                        txtDescription.Text = gallery.Description;
                        txtDetails.Text = gallery.Details;
                        txtName.Text = gallery.Name;
                        txtOrderNumber.Text = gallery.Order.ToString();
                        txtSummary.Text = gallery.Summary;
                        ucAjaxDate.SelectedDateTime = gallery.CreationDate;

                        ucPortalLanguage.Visible = true;
                        ucPortalLanguage.SelectedLanguageID = gallery.LanguageID;

                        btnSaveOtherLanguage.Visible = false;

                        pnlGalleryAdd.Visible = false;
                        btnUpdate.Visible = false;
                        btnUpdateOtherLanguage.Visible = true;
                        btnSaveOtherLanguage.Visible = false;

                        cddGalleryItemType.SelectedValue = ((int)CMSEnums.GalleryItemType.Internal).ToString();
                        txtAddName.Text = string.Empty;
                        txtAddURL.Text = string.Empty;

                        trIsPublished.Visible = false;
                    }
                    else
                    {
                        BeginAddModeOtherLanguage();
                    }
                }
            }
        }
        #endregion

        #region BeginAddModeOtherLanguage
        private void BeginAddModeOtherLanguage()
        {
            ViewState.Remove(CMSViewStateManager.GalleryID);
            pnlGalleryItem.Visible = true;
            txtDescription.Text = string.Empty;
            txtDetails.Text = string.Empty;
            txtName.Text = string.Empty;
            txtOrderNumber.Text = string.Empty;
            txtSummary.Text = string.Empty;
            ucAjaxDate.SelectedDateTime = DateTime.Now;

            ucPortalLanguage.Visible = true;

            btnSaveOtherLanguage.Visible = true;

            pnlGalleryAdd.Visible = false;
            cddGalleryItemType.SelectedValue = ((int)CMSEnums.GalleryItemType.Internal).ToString();
            txtAddName.Text = string.Empty;
            txtAddURL.Text = string.Empty;

            trIsPublished.Visible = false;

            btnUpdate.Visible = false;
        }
        #endregion

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlSearchCategory.UniqueID] != null)
                cddSearchCategory.SelectedValue = Request.Params[ddlSearchCategory.UniqueID];
            if (Request.Params[ddlGalleryItemType.UniqueID] != null)
                cddGalleryItemType.SelectedValue = Request.Params[ddlGalleryItemType.UniqueID];
        }
        #endregion

        #region GetGalleryFile
        protected string GetGalleryFile(Gallery gallery)
        {
            switch (gallery.GalleryType)
            {
                case CMSEnums.GalleryType.Document:
                    return "~/App_Themes/Image/Document.png";
                case CMSEnums.GalleryType.Photo:
                    if (gallery.GalleryItemType == CMSEnums.GalleryItemType.Internal)
                        return CMSWebHelper.GetGalleryThumbnailFile(gallery.File);
                    else
                        return gallery.URL;
                case CMSEnums.GalleryType.Video:
                    return "~/App_Themes/Image/Video.png";
            }
            return "~/App_Themes/Image/UnknowType.png";
        }
        #endregion

        #region PrepareNewPublish
        private Publish PrepareNewPublish(int galleryID)
        {
            Publish publish = new Publish
            {
                CreatedBy = CMSContext.CurrentUserID,
                LanguageID = CMSContext.LanguageID,
                ModuleID = AJH.CMS.Core.Enums.CMSEnums.Modules.Gallery,
                ObjectID = galleryID,
                PortalID = CMSContext.PortalID,
                PublishType = CMSEnums.PublishType.PublishNow,
            };

            return publish;

        }
        #endregion

        #endregion
    }
}