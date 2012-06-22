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
    public partial class SitePathXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SitePathXSL_UC_Load);
        }
        #endregion

        #region SitePathXSL_UC_Load
        void SitePathXSL_UC_Load(object sender, EventArgs e)
        {
            LoadSitePath();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadSitePath
        void LoadSitePath()
        {
            if (base.XSLTemplateID > 0)
            {
                string PageTitle = string.Empty;
                Menu currentMenu = null;
                int MenuId = 0;
                int.TryParse(Request.QueryString[CMSConfig.QueryString.MenuID], out MenuId);
                if (MenuId > 0)
                {
                    currentMenu = MenuManager.GetMenu(MenuId);
                }
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

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                if (currentMenu == null)
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddExtensionObject("CMS:UserControl", this);

                    xmlSitePath.DocumentContent = MenuManager.GetDefaultSitePath(PageTitle);
                    xmlSitePath.TransformSource = xslPath;
                    xmlSitePath.TransformArgumentList = arguments;
                    xmlSitePath.DataBind();
                }
                else
                {
                    string menuCategoryPath = CMSWebHelper.GetMenuPathByCategory(currentMenu.CategoryID);
                    menuCategoryPath = MenuManager.GetMenuCategoryXMLPath(menuCategoryPath, currentMenu.CategoryID);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(menuCategoryPath);

                    string sitePath = string.Empty;

                    XmlNode xmlNode = xmlDoc.SelectSingleNode("descendant-or-self::* [@ID=" + currentMenu.ID.ToString() + "]");
                    if (xmlNode != null)
                    {
                        XmlDocument xmlDocSitePath = new XmlDocument();
                        XmlElement xmlEle = xmlDocSitePath.CreateElement("Menus");
                        xmlDocSitePath.AppendChild(xmlEle);
                        GetParentNode(xmlEle, xmlNode);
                        sitePath = xmlDocSitePath.OuterXml;
                    }

                    if (string.IsNullOrEmpty(sitePath))
                    {
                        sitePath = MenuManager.GetDefaultSitePath(PageTitle);
                    }

                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddExtensionObject("CMS:UserControl", this);

                    xmlSitePath.DocumentContent = sitePath;
                    xmlSitePath.TransformSource = xslPath;
                    xmlSitePath.TransformArgumentList = arguments;
                    xmlSitePath.DataBind();
                }
            }
        }
        #endregion

        #region GetParentNode
        void GetParentNode(XmlElement xmlRoot, XmlNode xmlNode)
        {
            if (xmlNode.ParentNode != null && xmlNode.ParentNode.Name != "Menus")
                GetParentNode(xmlRoot, xmlNode.ParentNode);

            XmlElement xmlCurrent = xmlRoot.OwnerDocument.CreateElement("Menu");
            XmlAttribute xmlAtt = xmlRoot.OwnerDocument.CreateAttribute("ID");
            xmlAtt.Value = xmlNode.Attributes["ID"].Value;
            xmlCurrent.Attributes.Append(xmlAtt);

            xmlAtt = xmlRoot.OwnerDocument.CreateAttribute("Name");
            xmlAtt.Value = xmlNode.Attributes["Name"].Value;
            xmlCurrent.Attributes.Append(xmlAtt);

            xmlAtt = xmlRoot.OwnerDocument.CreateAttribute("URL");
            xmlAtt.Value = xmlNode.Attributes["URL"].Value;
            xmlCurrent.Attributes.Append(xmlAtt);

            xmlRoot.AppendChild(xmlCurrent);
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