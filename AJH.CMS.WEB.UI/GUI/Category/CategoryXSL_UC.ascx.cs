using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class CategoryXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(CategoryXSL_UC_Load);
        }
        #endregion

        #region CategoryXSL_UC
        void CategoryXSL_UC_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadCategory
        void LoadCategory()
        {
            if (base.XSLTemplateID > 0)
            {
                int ParentCategoryID = 0;
                if (base.ContainerValue > 0)
                {
                    ParentCategoryID = base.ContainerValue;
                }
                else
                {
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.CategoryID], out ParentCategoryID);
                }
                string categoryXML = CategoryManager.GetCategoryPublishXML(base.ModuleID, ParentCategoryID);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlCategory.DocumentContent = categoryXML;
                xmlCategory.TransformSource = xslPath;
                xmlCategory.TransformArgumentList = arguments;
                xmlCategory.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Category> categories = CategoryManager.GetCategorys(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < categories.Count; i++)
            {
                items.Add(categories[i].ID.ToString(), categories[i].Name);
            }
            return items;
        }
        #endregion

        #region GetModulesValue
        public override Dictionary<string, string> GetModulesValue(int PortalID, int LanguageID)
        {
            List<Module> modules = ModuleManager.GetModules();

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < modules.Count; i++)
            {
                items.Add(modules[i].ID.ToString(), modules[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}