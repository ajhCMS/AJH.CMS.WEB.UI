using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;

namespace AJH.CMS.WEB.UI.GUI.ECommerce.Order
{
    public partial class AddOrder_UC : System.Web.UI.UserControl
    {
        #region Event
        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(AddOrder_UC_Load);
            this.btnAddtoChart.Click += new EventHandler(btnAddtoChart_Click);
            base.OnInit(e);

        }

        #region Add Order to Chart

        void btnAddtoChart_Click(object sender, EventArgs e)
        {
            int OrderID=0;
            int OrderDetailsID = 0;
            int productValue = -1;
            if (!string.IsNullOrEmpty(CMSConfig.QueryString.ProductID))
            {
                int.TryParse(Request.QueryString[CMSConfig.QueryString.ProductID], out productValue);
            }

            if (productValue != -1 )
               OrderID  = AddOrder(productValue);

            if (OrderID > 0)
                OrderDetailsID = AddOrderDetails(OrderID, productValue);
        }
        
        #endregion

        #region Add Order Load

        void AddOrder_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CheckForCreateUser())
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        #endregion

        #endregion
        #endregion

        #region Method
        bool CheckForCreateUser()
        {
            if (CMSContext.CurrentUserID > 0)
            {
                return false;
            }
            return true;
        }

        protected int AddOrder(int ProductID)
        {
            CMS.Core.Entities.Order oOrder = new Core.Entities.Order();
            oOrder.LanguageID = CMSContext.LanguageID;
            oOrder.ORDER_CUSTOMER_ID = CMSContext.CurrentUserID;
            oOrder.ORDER_STATUS = 1;
            oOrder.ORDER_TOTAL_AMOUNT = 1;
            oOrder.PortalID = CMSContext.PortalID;

            return OrderManager.Add(oOrder);
        }

        private int AddOrderDetails(int OrderID,int ProductID)
        {
            CMS.Core.Entities.OrderDetails oOrderDetails = new Core.Entities.OrderDetails();
            oOrderDetails.LanguageID = CMSContext.LanguageID;
            oOrderDetails.PortalID = CMSContext.PortalID;
            oOrderDetails.ORDER_DETAILS_AMOUNT = 1;
            oOrderDetails.ORDER_DETAILS_CATEGORY_ID = 1;//check it
            oOrderDetails.ORDER_DETAILS_ORDER_ID=OrderID;
            oOrderDetails.ORDER_DETAILS_PRODUCT_ID=ProductID;
            oOrderDetails.ORDER_DETAILS_STATUS=1;
           
            return OrderDetailsManager.Add(oOrderDetails);
        }

       
        #endregion
    }
}