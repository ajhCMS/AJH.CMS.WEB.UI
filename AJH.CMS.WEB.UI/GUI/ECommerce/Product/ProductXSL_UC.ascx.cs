using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;
using System.Xml;

namespace AJH.CMS.WEB.UI
{
    public partial class ProductXSL_UC : CMSUserControlBase
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
            int catalogValue = -1;
            if (base.ContainerValue > 0)
            {
                catalogValue = base.ContainerValue;
            }
            else
            {
                if (!string.IsNullOrEmpty(CMSConfig.QueryString.CatalogID))
                {
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.CatalogID], out catalogValue);
                }
            }

            if (base.XSLTemplateID > 0)
            {
                List<Product> products = ProductManager.GetProductsByCatalogID(catalogValue, CMSContext.PortalID, CMSContext.LanguageID);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XmlDocument xmlDoc = new XmlDocument();

                XmlElement root = xmlDoc.CreateElement("Products");
                xmlDoc.AppendChild(root);

                if (products != null && products.Count > 0)
                    foreach (Product product in products)
                    {
                        XmlElement productElement = xmlDoc.CreateElement(product.Name);
                        XmlAttribute attr = xmlDoc.CreateAttribute("ID");
                        attr.Value = product.ID.ToString();
                        productElement.Attributes.Append(attr);

                        attr = xmlDoc.CreateAttribute("Name");
                        attr.Value = product.Name.ToString();
                        productElement.Attributes.Append(attr);

                        List<ProductImage> productImages =
                            ProductImageManager.GetProductImagesByProductID(product.ID, CMSContext.LanguageID);

                        if (productImages != null && productImages.Count > 0)
                            for (int i = 0; i <= productImages.Count - 1; i++)
                            {
                                XmlElement productImageElement = xmlDoc.CreateElement("Image" + productImages[i].ID.ToString());
                                XmlAttribute imageAttr = xmlDoc.CreateAttribute("ID");

                                imageAttr.Value = productImages[i].ID.ToString();
                                productImageElement.Attributes.Append(imageAttr);

                                imageAttr = xmlDoc.CreateAttribute("ImageCaption");
                                imageAttr.Value = productImages[i].ImageCaption;
                                productImageElement.Attributes.Append(imageAttr);

                                imageAttr = xmlDoc.CreateAttribute("Image");
                                imageAttr.Value = productImages[i].Image;
                                productImageElement.Attributes.Append(imageAttr);

                                productElement.AppendChild(productImageElement);
                            }
                    }

                if (xmlDoc.ChildNodes.Count > 1)
                {
                    XmlAttribute xmlAtt = xmlDoc.CreateAttribute("CurrentCatalog");
                    xmlAtt.Value = catalogValue.ToString();
                    xmlDoc.ChildNodes[1].Attributes.Append(xmlAtt);
                }

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlProduct.DocumentContent = xmlDoc.OuterXml;
                xmlProduct.TransformSource = xslPath;
                xmlProduct.TransformArgumentList = arguments;
                xmlProduct.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Catalog> Catalogs = CatalogManager.GetCatalogs(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < Catalogs.Count; i++)
            {
                items.Add(Catalogs[i].ID.ToString(), Catalogs[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}