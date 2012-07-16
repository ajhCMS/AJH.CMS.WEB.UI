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
    public partial class CatalogSitePath : CMSUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(CatalogSitePath_Load);
            base.OnInit(e);
        }

        void CatalogSitePath_Load(object sender, EventArgs e)
        {
            FillSitePath();
        }

        private void FillSitePath()
        {
            int CatalogValue = -1;
            if (!string.IsNullOrEmpty(CMSConfig.QueryString.CatalogID))
            {
                int.TryParse(Request.QueryString[CMSConfig.QueryString.CatalogID], out CatalogValue);
            }

            string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
            xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Root");

            xmlDoc.AppendChild(rootElement);

            if (CatalogValue > 0)
            {
                Catalog Catalog = CatalogManager.GetCatalog(CatalogValue, CMSContext.LanguageID);
                if (Catalog != null)
                {
                    FillCatalogsXML(Catalog, xmlDoc, rootElement);

                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddExtensionObject("CMS:UserControl", this);


                    xmlCatalog.DocumentContent = xmlDoc.OuterXml;
                    xmlCatalog.TransformSource = xslPath;
                    xmlCatalog.TransformArgumentList = arguments;
                    xmlCatalog.DataBind();
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