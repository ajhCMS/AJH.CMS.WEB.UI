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
    public partial class CatalogXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Catalog_UC_Load);
        }
        #endregion

        #region Catalog_UC_Load
        void Catalog_UC_Load(object sender, EventArgs e)
        {
            LoadCatalog();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadCatalog
        void LoadCatalog()
        {
            int CatalogValue = -1;
            if (base.ContainerValue > 0)
            {
                CatalogValue = base.ContainerValue;
            }
            else
            {
                if (!string.IsNullOrEmpty(CMSConfig.QueryString.CatalogID))
                {
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.CatalogID], out CatalogValue);
                }
            }

            if (base.XSLTemplateID > 0)
            {
                string catalogPath = CMSWebHelper.GetCatalogPath();
                catalogPath = CatalogManager.GetCatalogXMLPath(catalogPath, CMSContext.PortalID, CMSContext.LanguageID);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(catalogPath);

                if (xmlDoc.ChildNodes.Count > 1)
                {
                    XmlAttribute xmlAtt = xmlDoc.CreateAttribute("CurrentCatalog");
                    xmlAtt.Value = CatalogValue.ToString();
                    xmlDoc.ChildNodes[1].Attributes.Append(xmlAtt);

                    xmlAtt = xmlDoc.CreateAttribute("LanguageID");
                    xmlAtt.Value = CMSContext.LanguageID.ToString();
                    xmlDoc.ChildNodes[1].Attributes.Append(xmlAtt);
                }

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlCatalog.DocumentContent = xmlDoc.OuterXml;
                xmlCatalog.TransformSource = xslPath;
                xmlCatalog.TransformArgumentList = arguments;
                xmlCatalog.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Catalog> catalogs = CatalogManager.GetCatalogs(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < catalogs.Count; i++)
            {
                items.Add(catalogs[i].ID.ToString(), catalogs[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}