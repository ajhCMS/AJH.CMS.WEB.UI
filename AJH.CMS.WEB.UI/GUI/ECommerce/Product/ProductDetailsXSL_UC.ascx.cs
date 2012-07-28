using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;
using System.Xml;
using System.Text.RegularExpressions;

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
        }
        #endregion

        #region Product_UC_Load
        void Product_UC_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }
        #endregion

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