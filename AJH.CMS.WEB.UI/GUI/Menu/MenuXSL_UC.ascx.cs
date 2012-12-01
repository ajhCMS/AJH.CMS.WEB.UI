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
    public partial class MenuXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Menu_UC_Load);
        }
        #endregion

        #region Menu_UC_Load
        void Menu_UC_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadMenu
        void LoadMenu()
        {
            int menuID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.MenuID], out menuID);

            if (base.XSLTemplateID > 0 && base.ContainerValue > 0)
            {
                string menuCategoryPath = CMSWebHelper.GetMenuPathByCategory(base.ContainerValue);
                menuCategoryPath = MenuManager.GetMenuCategoryXMLPath(menuCategoryPath, base.ContainerValue, CMSContext.LanguageID);

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(menuCategoryPath);

                XmlAttribute xmlAtt = xmlDoc.CreateAttribute("CurrentMenu");
                xmlAtt.Value = menuID.ToString();
                if (xmlDoc.ChildNodes.Count > 1 && xmlDoc.ChildNodes[1] != null)
                {
                    xmlDoc.ChildNodes[1].Attributes.Append(xmlAtt);
                }

                xmlMenu.DocumentContent = xmlDoc.OuterXml;
                xmlMenu.TransformSource = xslPath;
                xmlMenu.TransformArgumentList = arguments;
                xmlMenu.DataBind();
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Category> menuCategories = CategoryManager.GetCategorys(ModuleID, PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < menuCategories.Count; i++)
            {
                items.Add(menuCategories[i].ID.ToString(), menuCategories[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}