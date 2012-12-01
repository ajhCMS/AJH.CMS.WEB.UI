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
    public partial class CatalogDetailsXSL_UC : CMSUserControlBase
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
                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                Catalog catalog = CatalogManager.GetCatalog(CatalogValue, CMSContext.LanguageID);

                if (catalog == null)
                    return;

                XmlDocument xmlDoc = CatalogManager.GenerateCatalogXmlDoc(catalog);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlCatalog.DocumentContent = xmlDoc.OuterXml;
                xmlCatalog.TransformSource = xslPath;
                xmlCatalog.TransformArgumentList = arguments;
                xmlCatalog.DataBind();

                this.Page.Title = catalog.Name;
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