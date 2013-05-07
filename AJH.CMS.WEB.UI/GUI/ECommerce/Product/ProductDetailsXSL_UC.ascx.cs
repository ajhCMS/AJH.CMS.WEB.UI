using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Xsl;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class ProductDetailsXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Product_UC_Load);
            this.ddlCombinations.SelectedIndexChanged += new EventHandler(ddlCombinations_SelectedIndexChanged);
        }
        #endregion

        #region Product_UC_Load
        void Product_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productValue = -1;
                if (base.ContainerValue > 0)
                {
                    productValue = base.ContainerValue;
                }
                else
                {
                    if (!string.IsNullOrEmpty(CMSConfig.QueryString.ProductID))
                    {
                        int.TryParse(Request.QueryString[CMSConfig.QueryString.ProductID], out productValue);
                    }
                }


                Product product = ProductManager.GetProduct(productValue, CMSContext.PortalID, CMSContext.LanguageID);
                    List<CombinationProduct> CombinationProducts = CombinationProductManager.GetCombinationProductsByProductId(product.ID, CMSContext.LanguageID);
                    ddlCombinations.DataSource = CombinationProducts;
                    ddlCombinations.DataTextField = "ProductReference";
                    ddlCombinations.DataValueField = "ID";
                    ddlCombinations.DataBind();
                    if (ddlCombinations.Items.Count > 0)
                    {
                        ddlCombinations.SelectedIndex = 0;
                        ddlCombinations_SelectedIndexChanged(null, null);
                    }
                
            }
                LoadProduct();
            
        }
        #endregion

         void ddlCombinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGroups();
        }

        #endregion

        #region Methods

        #region LoadProduct
        void LoadProduct()
        {
            int productValue = -1;
            if (base.ContainerValue > 0)
            {
                productValue = base.ContainerValue;
            }
            else
            {
                if (!string.IsNullOrEmpty(CMSConfig.QueryString.ProductID))
                {
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.ProductID], out productValue);
                }
            }

            if (base.XSLTemplateID > 0)
            {
                Product product = ProductManager.GetProduct(productValue, CMSContext.PortalID, CMSContext.LanguageID);

                if (product == null)
                    return;

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XmlDocument xmlDoc = new XmlDocument();

                XmlElement root = xmlDoc.CreateElement("Products");
                xmlDoc.AppendChild(root);

                XmlElement productElement = xmlDoc.CreateElement("Product");
                XmlAttribute attr = xmlDoc.CreateAttribute("ID");
                attr.Value = product.ID.ToString();
                productElement.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("Name");
                attr.Value = product.Name;
                productElement.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("Description");
                attr.Value = product.Description;
                productElement.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("Details");
                attr.Value = product.SizeChart;
                productElement.Attributes.Append(attr);

                List<ProductImage> productImages =
                    ProductImageManager.GetProductImagesByProductID(product.ID, CMSContext.LanguageID);

               

                if (productImages != null && productImages.Count > 0)
                    for (int i = 0; i <= productImages.Count - 1; i++)
                    {
                        XmlElement productImageElement = xmlDoc.CreateElement("Image");
                        XmlAttribute imageAttr = xmlDoc.CreateAttribute("ID");

                        imageAttr.Value = productImages[i].ID.ToString();
                        productImageElement.Attributes.Append(imageAttr);

                        imageAttr = xmlDoc.CreateAttribute("ImageCaption");
                        imageAttr.Value = productImages[i].ImageCaption;
                        productImageElement.Attributes.Append(imageAttr);

                        imageAttr = xmlDoc.CreateAttribute("Image");
                        imageAttr.Value = productImages[i].Image;
                        productImageElement.Attributes.Append(imageAttr);

                        imageAttr = xmlDoc.CreateAttribute("IsCoverImage");
                        imageAttr.Value = productImages[i].IsCoverImage.ToString();
                        productImageElement.Attributes.Append(imageAttr);

                        productElement.AppendChild(productImageElement);
                    }

                root.AppendChild(productElement);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlProduct.DocumentContent = xmlDoc.OuterXml;
                xmlProduct.TransformSource = xslPath;
                xmlProduct.TransformArgumentList = arguments;
                xmlProduct.DataBind();

                this.Page.Title = product.Name;
            }
        }
        #endregion

        #region LoadGroups
        void LoadGroups()
        {
            if (base.XSLTemplateID > 0)
            {
                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XmlDocument xmlDoc = new XmlDocument();

                XmlElement root = xmlDoc.CreateElement("Products");
                xmlDoc.AppendChild(root);


                CombinationProduct oCombinationProduct
                 = CombinationProductManager.GetCombinationProduct(Convert.ToInt32(ddlCombinations.SelectedValue), CMSContext.LanguageID);
                /// Load Groups
                
                List<Group> Groups =
                    GroupManager.GetGroupsByCombinationID(oCombinationProduct.ID, CMSContext.PortalID, CMSContext.LanguageID);

                foreach (Group oGroup in Groups)
                {
                    if (!oGroup.IsDeleted)
                    {

                        XmlElement groupElement = xmlDoc.CreateElement("Group");
                        XmlAttribute GroupAttr = xmlDoc.CreateAttribute("ID");
                        GroupAttr.Value = oGroup.ID.ToString();
                        groupElement.Attributes.Append(GroupAttr);

                        GroupAttr = xmlDoc.CreateAttribute("Name");
                        GroupAttr.Value = oGroup.Name;
                        groupElement.Attributes.Append(GroupAttr);

                        GroupAttr = xmlDoc.CreateAttribute("PublicName");
                        GroupAttr.Value = oGroup.PublicName;

                        groupElement.Attributes.Append(GroupAttr);
                        root.AppendChild(groupElement);

                        /// Load Group Attributes
                        /// 
                        List<AJH.CMS.Core.Entities.Attribute> Attributes = AttributeManager.GetAttributesByCombinationAndGroupID( oCombinationProduct.ID,oGroup.ID, CMSContext.LanguageID);
                        foreach (AJH.CMS.Core.Entities.Attribute oAttribute in Attributes)
                        {
                            if (!oAttribute.IsDeleted)
                            {
                                XmlElement AttributesElement = xmlDoc.CreateElement("Attribute");
                                XmlAttribute AttributesAttr = xmlDoc.CreateAttribute("ID");
                                AttributesAttr.Value = oAttribute.ID.ToString();
                                AttributesElement.Attributes.Append(AttributesAttr);

                                AttributesAttr = xmlDoc.CreateAttribute("Name");
                                AttributesAttr.Value = oAttribute.Name;

                                AttributesElement.Attributes.Append(AttributesAttr);
                                groupElement.AppendChild(AttributesElement);
                            }
                        }
                    }

                }

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlGroup.DocumentContent = xmlDoc.OuterXml;
                xmlGroup.TransformSource = xslPath;
                xmlGroup.TransformArgumentList = arguments;
                xmlGroup.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Product> products = ProductManager.GetProducts(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < products.Count; i++)
            {
                items.Add(products[i].ID.ToString(), products[i].Name);
            }
            return items;
        }
        #endregion



        #endregion
    }
}