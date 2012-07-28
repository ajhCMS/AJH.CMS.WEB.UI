using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Data;
using System.Xml;
using System.Xml.Xsl;

namespace AJH.CMS.WEB.UI
{
    public partial class ProductSitePath : CMSUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(ProductSitePath_Load);
            base.OnInit(e);
        }

        void ProductSitePath_Load(object sender, EventArgs e)
        {
            FillSitePath();
        }

        private void FillSitePath()
        {
            int productValue = -1;
            if (!string.IsNullOrEmpty(CMSConfig.QueryString.ProductID))
            {
                int.TryParse(Request.QueryString[CMSConfig.QueryString.ProductID], out productValue);
            }

            string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
            xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Root");

            xmlDoc.AppendChild(rootElement);

            if (productValue > 0)
            {
                Product product = ProductManager.GetProduct(productValue, CMSContext.PortalID, CMSContext.LanguageID);
                if (product != null)
                {
                    XmlElement productelement = xmlDoc.CreateElement("Element");
                    XmlElement homeElement = xmlDoc.CreateElement("Element");

                    XmlAttribute attr = xmlDoc.CreateAttribute("Name");
                    attr.Value = Resources.CMSSetupResource.Home;
                    homeElement.Attributes.Append(attr);

                    attr = xmlDoc.CreateAttribute("Type");
                    attr.Value = "Home";
                    homeElement.Attributes.Append(attr);

                    rootElement.AppendChild(homeElement);

                    attr = xmlDoc.CreateAttribute("ID");
                    attr.Value = product.ID.ToString();
                    productelement.Attributes.Append(attr);

                    attr = xmlDoc.CreateAttribute("Name");
                    attr.Value = product.Name;
                    productelement.Attributes.Append(attr);

                    attr = xmlDoc.CreateAttribute("Type");
                    attr.Value = "Product";
                    productelement.Attributes.Append(attr);

                    //Fill Catalogs :
                    List<Catalog> productCatalogs = CatalogManager.GetCatalogsByProductID(product.ID, CMSContext.PortalID, CMSContext.LanguageID);
                    if (productCatalogs != null && productCatalogs.Count > 0)
                    {
                        FillCatalogsXML(productCatalogs.FirstOrDefault(), xmlDoc, rootElement);
                    }

                    rootElement.AppendChild(productelement);

                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddExtensionObject("CMS:UserControl", this);


                    xmlProduct.DocumentContent = xmlDoc.OuterXml;
                    xmlProduct.TransformSource = xslPath;
                    xmlProduct.TransformArgumentList = arguments;
                    xmlProduct.DataBind();
                }
            }
        }

        private void FillCatalogsXML(Catalog catalog, XmlDocument xmlDoc, XmlElement rootElement)
        {
            if (catalog != null)
            {
                if (catalog.ParentCalalogID > 0)
                {
                    Catalog parentCatalog = CatalogManager.GetCatalog(catalog.ParentCalalogID, CMSContext.LanguageID);
                    if (parentCatalog != null)
                        FillCatalogsXML(parentCatalog, xmlDoc, rootElement);
                }

                XmlElement catalogElement = xmlDoc.CreateElement("Element");
                rootElement.AppendChild(catalogElement);

                XmlAttribute attr = xmlDoc.CreateAttribute("ID");
                attr.Value = catalog.ID.ToString();
                catalogElement.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("Name");
                attr.Value = catalog.Name;
                catalogElement.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("Type");
                attr.Value = "Catalog";
                catalogElement.Attributes.Append(attr);
            }
        }

    }
}