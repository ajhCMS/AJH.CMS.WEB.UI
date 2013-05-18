using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using System.Web.UI.HtmlControls;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.WEB.UI.GUI.ECommerce.Order
{
    public partial class AddOrder_UC : CMSUserControlBase
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
            //string strValue = Page.Request.Form["hdColor"].ToString();
            if (CheckForCreateUser())
            {
                Response.Redirect("~/Login.aspx");
            }
            if (CMSContext.CombinationID > 0)
            {


                int OrderID = 0;
                int OrderDetailsID = 0;
                int productValue = -1;
                int OrderProductDetails = 0;
                if (!string.IsNullOrEmpty(CMSConfig.QueryString.ProductID))
                {
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.ProductID], out productValue);
                }

                if (productValue != -1)
                    OrderID = AddOrder(productValue);

                if (OrderID > 0)
                    OrderDetailsID = AddOrderDetails(OrderID, productValue);

                if (OrderDetailsID > 0)
                {
                    List<Group> Groups =
                    GroupManager.GetGroupsByCombinationID(CMSContext.CombinationID, CMSContext.PortalID, CMSContext.LanguageID);

                    foreach (Group oGroup in Groups)
                    {
                        if (!oGroup.IsDeleted)
                        {
                            List<AJH.CMS.Core.Entities.Attribute> Attributes = AttributeManager.GetAttributesByCombinationAndGroupID(CMSContext.CombinationID, oGroup.ID, CMSContext.LanguageID);
                            foreach (AJH.CMS.Core.Entities.Attribute oAttribute in Attributes)
                            {
                                if (!oAttribute.IsDeleted)
                                {
                                    OrderProductDetails = AddOrderProductDetails(productValue, OrderDetailsID, CMSContext.CombinationID, oGroup.ID, oAttribute.ID);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Add Order Load

        void AddOrder_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            CMS.Core.Entities.Order oOrderCheck = OrderManager.GetOrderByCustomerID(CMSContext.CurrentUserID).FirstOrDefault();
            if (oOrderCheck == null)
            {
                CMS.Core.Entities.Order oOrder = new Core.Entities.Order();
                oOrder.LanguageID = CMSContext.LanguageID;
                oOrder.ORDER_CUSTOMER_ID = CMSContext.CurrentUserID;
                oOrder.ORDER_STATUS = 1;
                oOrder.ORDER_TOTAL_AMOUNT = 1; // from textbox in XSL
                oOrder.PortalID = CMSContext.PortalID;
                oOrder.ORDER_MODIFICATION_DATE = DateTime.Now;
                return OrderManager.Add(oOrder);
            }
            else
            {
                CMS.Core.Entities.Order oOrderUpdate = oOrderCheck;
                oOrderUpdate.ORDER_MODIFICATION_DATE = DateTime.Now;
                OrderManager.Update(oOrderUpdate);
                return oOrderCheck.ID;
            }
        }

        private int AddOrderDetails(int OrderID, int ProductID)
        {
            CMS.Core.Entities.OrderDetails oOrderDetails = new Core.Entities.OrderDetails();
            oOrderDetails.LanguageID = CMSContext.LanguageID;
            oOrderDetails.PortalID = CMSContext.PortalID;
            oOrderDetails.ORDER_DETAILS_AMOUNT = 1;  // from textbox in XSL
            oOrderDetails.ORDER_DETAILS_CATEGORY_ID = 1;//check it
            oOrderDetails.ORDER_DETAILS_ORDER_ID = OrderID;
            oOrderDetails.ORDER_DETAILS_PRODUCT_ID = ProductID;
            oOrderDetails.ORDER_DETAILS_STATUS = 1;

            return OrderDetailsManager.Add(oOrderDetails);
        }

        private int AddOrderProductDetails(int ProductID, int OrderDetailsID, int CombinationProductID, int GroupID, int AttributeID)
        {
            CMS.Core.Entities.OrderProductDetails oOrderProductDetails = new Core.Entities.OrderProductDetails();
            oOrderProductDetails.LanguageID = CMSContext.LanguageID;
            oOrderProductDetails.ORD_PRO_DET_COMBINATION_ID = CombinationProductID;
            oOrderProductDetails.ORD_PRO_DET_DETAILS_ID = OrderDetailsID;
            oOrderProductDetails.ORD_PRO_DET_PRODUCT_ID = ProductID;
            oOrderProductDetails.ORD_PRO_DET_XREF_PRODUCT_DETAILS = 1;
            oOrderProductDetails.PortalID = CMSContext.PortalID;
            oOrderProductDetails.ORD_PRO_DET_ATTRIBUTE_ID = GroupID;  // from select in XSL
            oOrderProductDetails.ORD_PRO_DET_GROUP_ID = AttributeID;  // from select in XSL
            return OrderPrdouctDetailsManager.Add(oOrderProductDetails);

        }
        #endregion
    }
}