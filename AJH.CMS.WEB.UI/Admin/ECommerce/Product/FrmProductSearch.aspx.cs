
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;
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
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            base.OnInit(e);
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            FillProducts(-1);
            upnlProductSearch.Update();
        }

        void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillProducts(e.NewPageIndex);
            upnlProductSearch.Update();
        }

        void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditProduct":
                    {
                        Response.Redirect((CMSConfig.CMSAdminPages.GetProcutDetailsPage()) + "&" + CMSConfig.QueryString.ProductID + "=" + e.CommandArgument);
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
            ReflectDDL();

            if (!IsPostBack)
            {
                PerformSettings();
                //FillProducts(-1);
            }
        }

        #region Methods

        private void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvProduct.ClientID + "','Are you sure to delete this item(s)?');";
        }

        private void FillProducts(int pageIndex)
        {
            //Search :
            gvProduct.DataSource = new List<Product>();
            int catalogId = -1;
            int.TryParse(cddlCatalogs.SelectedValue, out catalogId);

            string productName = string.Empty;
            if (!string.IsNullOrEmpty(txtProductName.Text))
                productName = txtProductName.Text;

            List<Product> products = ProductManager.SearchProducts(catalogId, productName, CMSContext.PortalID, CMSContext.LanguageID);

            if (pageIndex > -1)
                gvProduct.PageIndex = pageIndex;

            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        #region ReflectDDL
        void ReflectDDL()
        {
            if (Request.Params[ddlCatalogs.UniqueID] != null)
                cddlCatalogs.SelectedValue = Request.Params[ddlCatalogs.UniqueID];
        }


        #endregion
        #endregion
    }
}