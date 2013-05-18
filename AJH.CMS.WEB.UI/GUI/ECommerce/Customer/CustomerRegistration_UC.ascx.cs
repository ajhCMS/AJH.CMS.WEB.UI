using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Enums;
using AJH.CMS.Core.Data;

namespace AJH.CMS.WEB.UI.GUI.ECommerce.Customer
{
    public partial class CustomerRegistration_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Customer_UC_Load);
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckForCreateUser())
                { 
                    throw new Exception("You Are Already Logged In");
                }
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
                customer.CUSTOMER_BIRTHDAY = ucAjaxDate.SelectedDateTime.Value;
                customer.CUSTOMER_CITY = txtCity.Text;
                customer.CUSTOMER_FNAME = txtfname.Text;
                customer.CUSTOMER_HOME_PHONE = txtHoemPhone.Text;
                customer.CUSTOMER_LNAME = txtlname.Text;
                customer.CUSTOMER_MOBILE_PHONE = txtMobile.Text;
                customer.CUSTOMER_ZIP_CODE = txtZip.Text;
                customer.CUSTOMER_GENDER = (CMSEnums.Gender)Convert.ToInt32(rblGender.SelectedValue);
                customer.CUSTOMER_NEWSLETTER = (CMSEnums.AccessType)Convert.ToInt32(rblnewsletter.SelectedValue);
                customer.CUSTOMER_OPT_IN = (CMSEnums.AccessType)Convert.ToInt32(rblOptIn.SelectedValue);
                customer.CUSTOMER_STATUS = (CMSEnums.AccessType)Convert.ToInt32(rblstauts.SelectedValue);
                customer.CUSTOMER_COUNTRY = Convert.ToInt32(ddlCountry.SelectedValue);
                customer.CUSTOMER_USER_ID = Ref_UserID;
                customer.CUSTOMER_EDUCATION = txtEducation.Text;
                customer.CUSTOMER_POSITION = txtposition.Text;
                customer.CUSTOMER_LOCATION = txtLocation.Text;

                CustomerManager.Add(customer);

                UserManager.LoginIn(user, true);

                Response.Redirect("~/Default.aspx");

            }
            catch (Exception ex)
            {
                dvProblems.Visible = true;
                dvProblems.InnerText = ex.Message;

            }
        }
        #endregion

        #region ManageCustomer_UC_Load
        void Customer_UC_Load(object sender, EventArgs e)
        {

            dvProblems.Visible = false;
            if (!IsPostBack)
            {
                if (!CheckForCreateUser())
                {
                    pnlCustomer.Visible = false;
                    dvProblems.InnerText = "You Are Already Logged In";
                    dvProblems.Visible = true;
                }
                PerformSettings();
            }
        }
        #endregion

        #endregion


        #region Methods

        #region PerformSettings
        void PerformSettings()
        {
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

            ddlCountry.SelectedIndex = -1;
            rblGender.SelectedIndex = 2;
            rblnewsletter.SelectedIndex = 0;
            rblOptIn.SelectedIndex = 0;
            rblstauts.SelectedIndex = 0;
        }
        #endregion

        bool CheckForCreateUser()
        {
            if (CMSContext.CurrentUserID > 0)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}