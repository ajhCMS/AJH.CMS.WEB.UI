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
    public partial class MenuParentChildXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MenuParentChildXSL_UC_Load);
        }
        #endregion

        #region MenuParentChildXSL_UC_Load
        void MenuParentChildXSL_UC_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadMenu
        void LoadMenu()
        {
            if (base.XSLTemplateID > 0)
            {
                string PageTitle = string.Empty;
                Menu currentMenu = null;
                int MenuId = base.ContainerValue;

                if (MenuId <= 0)
                    int.TryParse(Request.QueryString[CMSConfig.QueryString.MenuID], out MenuId);

                if (MenuId > 0)
                    currentMenu = MenuManager.GetMenu(MenuId);
                else
                {
                    CMSPageBase cmsPage = this.Page as CMSPageBase;
                    if (cmsPage != null)
                    {
                        CMS.Core.Entities.Page currentPage = cmsPage._CurrentPage;
                        if (currentPage != null)
                        {
                            PageTitle = currentPage.Title;
                            List<Menu> menus = MenuManager.GetMenusByPage(currentPage.ID);
                            if (menus.Count > 0)
                            {
                                currentMenu = menus[0];
                            }
                        }
                    }
                }

                if (currentMenu == null)
                {
                    return;
                }
                else
                {
                    string menuCategoryPath = CMSWebHelper.GetMenuPathByCategory(currentMenu.CategoryID);
                    menuCategoryPath = MenuManager.GetMenuCategoryXMLPath(menuCategoryPath, currentMenu.CategoryID, CMSContext.LanguageID);

                    string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                    xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(menuCategoryPath);

                    XmlNode xmlNode = null;
                    if (currentMenu.ParentID == 0)
                        xmlNode = xmlDoc.ChildNodes.Item(1);
                    else
                        xmlNode = xmlDoc.SelectSingleNode("descendant-or-self::* [@ID=" + currentMenu.ParentID.ToString() + "]");
                    if (xmlNode == null)
                        return;

                    XmlAttribute xmlAtt = xmlDoc.CreateAttribute("CurrentMenu");
                    xmlAtt.Value = currentMenu.ID.ToString();
                    xmlNode.Attributes.Append(xmlAtt);

                    xmlAtt = xmlDoc.CreateAttribute("CurrentParentMenu");
                    xmlAtt.Value = currentMenu.ParentID.ToString();
                    xmlNode.Attributes.Append(xmlAtt);

                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddExtensionObject("CMS:UserControl", this);

                    xmlMenu.DocumentContent = xmlNode.OuterXml;
                    xmlMenu.TransformSource = xslPath;
                    xmlMenu.TransformArgumentList = arguments;
                    xmlMenu.DataBind();
                }
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<Menu> menuItems = MenuManager.GetMenus(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < menuItems.Count; i++)
            {
                items.Add(menuItems[i].ID.ToString(), menuItems[i].ID.ToString() + ": " + menuItems[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}