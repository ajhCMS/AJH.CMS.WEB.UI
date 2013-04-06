using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.WEB.UI.Admin.ECommerce.Customer
{
    public partial class ManageCustomer_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ManageCustomer_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvCustomer.RowCommand += new GridViewCommandEventHandler(gvCustomer_RowCommand);
            this.gvCustomer.PageIndexChanging += new GridViewPageEventHandler(gvCustomer_PageIndexChanging);
        }
        #endregion

        #region gvUser_PageIndexChanging
        void gvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillUCustomers(e.NewPageIndex);
            ExitMode();
            upnlCustomerItem.Update();
        }
        #endregion

        #region gvUser_RowCommand
        void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            switch (e.CommandName)
            {
                case "EditCustomer":
                    int CustomerID = 0;
                    int.TryParse(e.CommandArgument.ToString(), out CustomerID);

                    if (CustomerID > 0)
                    {
                        ViewState[CMSViewStateManager.CustomerID] = CustomerID;
                        BeginEditMode();
                        upnlCustomerItem.Update();
                    }
                    break;
            }
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvCustomer.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvCustomer.Rows[i].FindControl("chkItem");
                if (chkItem != null && chkItem.Checked)
                {
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvCustomer.Rows[i].FindControl("hdnID");
                    if (hdnID != null && !string.IsNullOrEmpty(hdnID.Value))
                    {
                        int UserID = Convert.ToInt32(hdnID.Value);
                        CustomerManager.Delete(UserID);
                    }
                }
            }
            FillUCustomers(-1);
            ExitMode();
            upnlCustomerItem.Update();
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            BeginAddMode();
            upnlCustomerItem.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CustomerID] != null)
            {
                try
                {
                    CMS.Core.Entities.Customer customer = CustomerManager.GetCustomer(Convert.ToInt32(ViewState[CMSViewStateManager.CustomerID]));
                    if (customer != null)
                    {
                        CMS.Core.Entities.User user = UserManager.GetUser(customer.CUSTOMER_USER_ID);
                        if (user != null)
                        {
                            user.IsDeleted = false;
                            
                            user.IsActive = true;
                            user.LanguageID = CMSContext.LanguageID;
                            user.Password = txtPassword.Text;
                            user.PortalID = CMSContext.PortalID;
                            UserManager.Update(user);

                            customer.CUSTOMER_ADDRESS1 = txtAddress1.Text;
                            customer.CUSTOMER_ADDRESS2 = txtAddress2.Text;
                            customer.CUSTOMER_ADDRESS3 = txtAddress3.Text;
                            customer.CUSTOMER_CITY = txtCity.Text;
                            customer.CUSTOMER_FNAME = txtfname.Text;
                            customer.CUSTOMER_HOME_PHONE = txtHoemPhone.Text;
                            customer.CUSTOMER_LNAME = txtlname.Text;
                            customer.CUSTOMER_MOBILE_PHONE = txtMobile.Text;
                            customer.CUSTOMER_ZIP_CODE = txtZip.Text;
                            customer.CUSTOMER_BIRTHDAY = ucAjaxDate.SelectedDateTime.Value;
                            customer.CUSTOMER_GENDER = (CMSEnums.Gender)Convert.ToInt32(rblGender.SelectedValue);
                            customer.CUSTOMER_NEWSLETTER = (CMSEnums.AccessType)Convert.ToInt32(rblnewsletter.SelectedValue);
                            customer.CUSTOMER_OPT_IN = (CMSEnums.AccessType)Convert.ToInt32(rblOptIn.SelectedValue);
                            customer.CUSTOMER_STATUS = (CMSEnums.AccessType)Convert.ToInt32(rblstauts.SelectedValue);
                            customer.CUSTOMER_COUNTRY = Convert.ToInt32(ddlCountry.SelectedValue);

                            CustomerManager.Update(customer);

                            FillUCustomers(-1);
                            upnlCustomer.Update();
                        }
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.Visible = true;
                    dvProblems.InnerText = ex.Message;
                    upnlCustomer.Update();
                }
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CMS.Core.Entities.User user = new Core.Entities.User();
                user.CreationDate = DateTime.Now;
                user.ID = 0;
                user.Email = txtEmail.Text;
                user.IsActive = true;
                user.IsDeleted = false;
                user.LanguageID = CMSContext.LanguageID;
                user.Password = txtPassword.Text;
                user.PortalID = CMSContext.PortalID;
                int Ref_UserID = UserManager.Add(user);

                CMS.Core.Entities.Customer customer = new Core.Entities.Customer();
                customer.CUSTOMER_ADDRESS1 = txtAddress1.Text;
                customer.CUSTOMER_ADDRESS2 = txtAddress2.Text;
                customer.CUSTOMER_ADDRESS3 = txtAddress3.Text;
                customer.CUSTOMER_CITY = txtCity.Text;
                customer.CUSTOMER_FNAME = txtfname.Text;
                customer.CUSTOMER_HOME_PHONE = txtHoemPhone.Text;
                customer.CUSTOMER_LNAME = txtlname.Text;
                customer.CUSTOMER_MOBILE_PHONE = txtMobile.Text;
                customer.CUSTOMER_ZIP_CODE = txtZip.Text;
                customer.CUSTOMER_BIRTHDAY = ucAjaxDate.SelectedDateTime.Value;
                customer.CUSTOMER_GENDER = (CMSEnums.Gender)Convert.ToInt32(rblGender.SelectedValue);
                customer.CUSTOMER_NEWSLETTER = (CMSEnums.AccessType)Convert.ToInt32(rblnewsletter.SelectedValue);
                customer.CUSTOMER_OPT_IN = (CMSEnums.AccessType)Convert.ToInt32(rblOptIn.SelectedValue);
                customer.CUSTOMER_STATUS = (CMSEnums.AccessType)Convert.ToInt32(rblstauts.SelectedValue);
                customer.CUSTOMER_COUNTRY = Convert.ToInt32(ddlCountry.SelectedValue);
                customer.CUSTOMER_USER_ID = Ref_UserID;
                CustomerManager.Add(customer);

                BeginAddMode();
                FillUCustomers(-1);
                upnlCustomer.Update();
            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;
                upnlCustomer.Update();
            }
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ViewState[CMSViewStateManager.CustomerID] != null)
            {
                BeginEditMode();
            }
            else
            {
                BeginAddMode();
            }
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            ExitMode();
        }
        #endregion

        #region ManageCustomer_UC_Load
        void ManageCustomer_UC_Load(object sender, EventArgs e)
        {
            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                PerformSettings();
                FillUCustomers(0);
                ExitMode();
            }
        }
        #endregion

        #endregion

        
        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
            ibtnDelete.OnClientClick = "return ConfirmOperation('" + gvCustomer.ClientID + "','Are you sure to delete this item(s)?');";

            ddlCountry.DataSource = CountriesManager.GetAllCountries();
            ddlCountry.Items.Add("[Select]");
            ddlCountry.DataTextField = "COUNTRY_NAME";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();

            rblstauts.DataSource = rblnewsletter.DataSource = rblOptIn.DataSource = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.AccessType));
            rblstauts.DataTextField = rblnewsletter.DataTextField = rblOptIn.DataTextField = "key";
            rblstauts.DataValueField = rblnewsletter.DataValueField = rblOptIn.DataValueField = "value";
            rblstauts.DataBind();
            rblnewsletter.DataBind();
            rblOptIn.DataBind();

            rblGender.DataSource = CMSWebHelper.GetEnumDataSource(Resources.CMSSetupResource.ResourceManager, typeof(CMSEnums.Gender));
            rblGender.DataTextField = "key";
            rblGender.DataValueField = "value";
            rblGender.DataBind();
        }
        #endregion

        #region FillcUSTOMERS
        void FillUCustomers(int PageIndex)
        {
            if (PageIndex > -1) 
            gvCustomer.PageIndex = PageIndex;
            gvCustomer.DataSource = CustomerManager.GetCustomers();
            gvCustomer.DataBind();
        }
        #endregion

        #region ExitMode
        void ExitMode()
        {
            BeginAddMode();
            pnlCustomer.Visible = false;
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            ViewState.Remove(CMSViewStateManager.CustomerID);
            pnlCustomer.Visible = true;
            trEmail.Visible = true;
            trPassword.Visible = true;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtfname.Text = string.Empty;
            txtHoemPhone.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtPassword.Text = string.Empty;
            //txtuserName.Text = string.Empty;
            ucAjaxDate.SelectedDateTime = DateTime.UtcNow;
            txtZip.Text = string.Empty;
            rblGender.SelectedIndex = 0;
            rblnewsletter.SelectedIndex = 1;
            rblOptIn.SelectedIndex = 1;
            rblstauts.SelectedIndex = 0;
            ddlCountry.SelectedIndex = -1;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            pnlCustomer.DefaultButton = btnSave.ID;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode()
        {
            if (ViewState[CMSViewStateManager.CustomerID] != null)
            {
                CMS.Core.Entities.Customer customer = CustomerManager.GetCustomer(Convert.ToInt32(ViewState[CMSViewStateManager.CustomerID]));
                if (customer != null)
                {
                    pnlCustomer.Visible = true;
                    txtAddress1.Text = customer.CUSTOMER_ADDRESS1;
                    txtAddress2.Text = customer.CUSTOMER_ADDRESS2;
                    txtAddress3.Text = customer.CUSTOMER_ADDRESS3;
                    txtCity.Text = customer.CUSTOMER_CITY;
                    trEmail.Visible = false;
                    trPassword.Visible = false;
                    txtfname.Text = customer.CUSTOMER_FNAME;
                    txtHoemPhone.Text = customer.CUSTOMER_HOME_PHONE;
                    txtlname.Text = customer.CUSTOMER_LNAME;
                    txtMobile.Text = customer.CUSTOMER_MOBILE_PHONE;
                    txtPassword.Text = string.Empty;
                    //txtuserName.Text = string.Empty;
                    txtZip.Text = customer.CUSTOMER_ZIP_CODE;
                    rblGender.SelectedIndex = (int)customer.CUSTOMER_GENDER;
                    rblnewsletter.SelectedIndex = (int)customer.CUSTOMER_NEWSLETTER;
                    rblOptIn.SelectedIndex = (int)customer.CUSTOMER_OPT_IN;
                    rblstauts.SelectedIndex = (int)customer.CUSTOMER_STATUS;
                    ddlCountry.SelectedValue = customer.CUSTOMER_COUNTRY.ToString();
                    ucAjaxDate.SelectedDateTime = customer.CUSTOMER_BIRTHDAY;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    pnlCustomer.DefaultButton = btnUpdate.ID;
                }
            }
        }
        #endregion

        #endregion
    }
}