
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Configuration;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Entities;
using System.Collections.Generic;
namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FrmProductSearch : CMSAdminPageBase
    {
        protected override void OnInit(System.EventArgs e)
        {
            this.Load += new System.EventHandler(FrmProductSearch_Load);
            this.ibtnDelete.Click += new System.Web.UI.ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnAdd.Click += new System.Web.UI.ImageClickEventHandler(ibtnAdd_Click);
            this.gvProduct.RowCommand += new GridViewCommandEventHandler(gvProduct_RowCommand);
            this.gvProduct.PageIndexChanging += new GridViewPageEventHandler(gvProduct_PageIndexChanging);
            base.OnInit(e);
        }

        void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillProducts(gvProduct.PageIndex);
            upnlProductSearch.Update();
        }

        void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditProduct":
                    {
                        Response.Redirect((CMSConfig.CMSAdminPages.GetProcutDetailsPage()) + "&" + CMSConfig.QueryString.ProdcutID + "=" + e.CommandArgument);
                        break;
                    }
                default:
                    break;
            }
        }

        void ibtnAdd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect(CMSConfig.CMSAdminPages.GetProcutDetailsPage());
        }

        void ibtnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            for (int i = 0; i < gvProduct.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvProduct.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvProduct.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int productID = Convert.ToInt32(hdnID.Value);
                        ProductManager.DeleteLogical(productID);
                    }
                }
            }

            FillProducts(-1);
            upnlProductSearch.Update();
        }

        void FrmProductSearch_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                PerformSettings();
                FillProducts(-1);
            }
        }

        #region Methods

        private void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvProduct.ClientID + "','Are you sure to delete this item(s)?');";
        }

        private void FillProducts(int pageIndex)
        {
            List<Product> products = ProductManager.GetProducts(CMSContext.PortalID, CMSContext.LanguageID);

            if (pageIndex > -1)
                gvProduct.PageIndex = pageIndex;

            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        #endregion
    }
}