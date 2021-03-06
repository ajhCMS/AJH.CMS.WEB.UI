﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class MenuManager
    {
        public static int Add(Menu menu)
        {
            if (menu.ParentObjectID > 0)
            {
                Menu menu2 = GetMenu(menu.ParentObjectID, menu.LanguageID);
                if (menu2 != null)
                    throw new Exception("Menu is exists in the same language, please choose another language");
            }
            return MenuDataMapper.Add(menu);
        }

        public static void Update(Menu menu)
        {
            MenuDataMapper.Update(menu);
        }

        public static void Delete(int ID)
        {
            MenuDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            MenuDataMapper.DeleteLogical(ID);
        }

        public static List<Menu> GetMenus()
        {
            return MenuDataMapper.GetMenus();
        }

        public static List<Menu> GetMenusByCategoryAndLanguage(int CategoryID, int languageID)
        {
            return MenuDataMapper.GetMenusByCategoryAndLanguage(CategoryID, languageID);
        }

        public static List<Menu> GetMenusParentObjByCategory(int categoryID)
        {
            return MenuDataMapper.GetMenusParentObjByCategory(categoryID);
        }

        public static List<Menu> GetMenusByPage(int PageID)
        {
            return MenuDataMapper.GetMenusByPage(PageID);
        }

        public static List<Menu> GetMenus(int PortalID, int LanguageID)
        {
            return MenuDataMapper.GetMenusByCategoryAndLanguage(PortalID, LanguageID);
        }

        public static List<Menu> GetMenus(int ParentID, int PortalID, int LanguageID)
        {
            return MenuDataMapper.GetMenus(ParentID, PortalID, LanguageID);
        }

        public static Menu GetMenu(int ID)
        {
            return MenuDataMapper.GetMenu(ID);
        }

        public static Menu GetMenuByIdAndLanguage(int MenuID, int languageID)
        {
            return MenuDataMapper.GetMenuByIdAndLanguage(MenuID, languageID);
        }

        public static Menu GetMenu(int parentObjID, int languageID)
        {
            return MenuDataMapper.GetMenu(parentObjID, languageID);
        }

        public static string GetDefaultSitePath(string PageTitle)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlRoot = xmlDoc.CreateElement("Menus");
            xmlDoc.AppendChild(xmlRoot);
            XmlElement xmlEle = xmlDoc.CreateElement("Menu");
            xmlRoot.AppendChild(xmlEle);
            XmlAttribute xmlAtt = xmlDoc.CreateAttribute("Name");
            xmlAtt.Value = PageTitle;
            xmlEle.Attributes.Append(xmlAtt);

            return xmlDoc.OuterXml;
        }

        public static string GetMenuCategoryXMLPath(string MenuCategoryPath, int CategoryID, int languageID)
        {
            if (!File.Exists(MenuCategoryPath))
            {
                XmlDocument xmlDoc = new XmlDocument();

                XmlElement xmlRoot = xmlDoc.CreateElement("Menus");
                xmlDoc.AppendChild(xmlRoot);

                List<Menu> menus = GetMenusByCategoryAndLanguage(CategoryID, languageID);
                List<Menu> parentMenus = menus.Where(m => m.ParentID == 0).ToList();
                foreach (Menu item in parentMenus)
                {
                    XmlElement xmlEle = xmlDoc.CreateElement("Menu");
                    xmlRoot.AppendChild(xmlEle);
                    SetAttributeMenuNode(xmlEle, item);
                    SetElementChildMenu(xmlEle, menus, item.ParentObjectID == 0 ? item.ID : item.ParentObjectID);//Id Of Main Parent (PArent Of Parent Obj Id to Handle Language Issue)
                    //SetElementChildMenu(xmlEle, menus, item.MainParentID);//Id Of Main Parent (PArent Of Parent Obj Id to Handle Language Issue)
                }

                XmlWriter xmlWriter = XmlWriter.Create(MenuCategoryPath);
                xmlDoc.WriteTo(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            return MenuCategoryPath;
        }

        public static string GetMenuItemTemplateXml(int menuId, int languageId, out Menu menu)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement xmlRoot = xmlDoc.CreateElement("Menus");
            xmlDoc.AppendChild(xmlRoot);

            XmlElement menuItemElement = xmlDoc.CreateElement("Menu");
            xmlRoot.AppendChild(menuItemElement);

            menu = GetMenuByIdAndLanguage(menuId, languageId);
            if (menu != null)
            {
                SetAttributeMenuNode(menuItemElement, menu);

                XmlAttribute attr = xmlDoc.CreateAttribute("Details");
                attr.Value = menu.Details;
                menuItemElement.Attributes.Append(attr);
            }

            return xmlDoc.OuterXml;
        }

        private static void SetElementChildMenu(XmlElement xmlParent, List<Menu> menus, int ParentMenuID)
        {
            List<Menu> childsMenu = menus.Where(m => m.ParentID == ParentMenuID).ToList();
            foreach (Menu item in childsMenu)
            {
                XmlElement xmlEle = xmlParent.OwnerDocument.CreateElement("SubMenu");
                xmlParent.AppendChild(xmlEle);
                SetAttributeMenuNode(xmlEle, item);
                SetElementChildMenu(xmlEle, menus, item.ID);
            }
        }

        private static void SetAttributeMenuNode(XmlElement xmlEle, Menu menuItem)
        {
            XmlAttribute xmlAtt = xmlEle.OwnerDocument.CreateAttribute("ID");
            xmlAtt.Value = menuItem.ID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Description");
            xmlAtt.Value = menuItem.Description;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Image");
            xmlAtt.Value = menuItem.Image;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Name");
            xmlAtt.Value = menuItem.Name;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("PageID");
            xmlAtt.Value = menuItem.PageID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("ParentID");
            xmlAtt.Value = menuItem.ParentID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            switch (menuItem.MenuType)
            {
                case Enums.CMSEnums.MenuType.Static:
                    NameValueCollection valueCollection = HttpUtility.ParseQueryString(menuItem.URL);
                    if (string.IsNullOrEmpty(valueCollection[CMSConfig.QueryString.MenuID]))
                    {
                        if (menuItem.URL.Contains("?"))
                        {
                            menuItem.URL += "&" + CMSConfig.QueryString.MenuID + "=" + menuItem.ID;
                        }
                        else
                        {
                            menuItem.URL += "?" + CMSConfig.QueryString.MenuID + "=" + menuItem.ID;
                        }
                    }
                    break;
            }
            if (menuItem.GalleryCategoryID > 0)
            {
                if (menuItem.URL.Contains("?"))
                {
                    menuItem.URL += "&" + CMSConfig.QueryString.CategoryID + "=" + menuItem.GalleryCategoryID;
                }
                else
                {
                    menuItem.URL += "?" + CMSConfig.QueryString.CategoryID + "=" + menuItem.GalleryCategoryID;
                }
            }
            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("URL");
            xmlAtt.Value = menuItem.URL;
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("MenuType");
            xmlAtt.Value = ((int)(menuItem.MenuType)).ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("Order");
            xmlAtt.Value = menuItem.Order.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("CategoryID");
            xmlAtt.Value = menuItem.CategoryID.ToString();
            xmlEle.Attributes.Append(xmlAtt);

            xmlAtt = xmlEle.OwnerDocument.CreateAttribute("GalleryCategoryID");
            xmlAtt.Value = menuItem.GalleryCategoryID.ToString();
            xmlEle.Attributes.Append(xmlAtt);
        }
    }
}