using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;
using AJH.CMS.Core.Configuration;

namespace AJH.CMS.WEB.UI
{
    public partial class MenuItemTemplateXSL_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MenuItemTemplateXSL_UC_Load);
        }
        #endregion


        #region MenuItemTemplateXSL_UC_Load

        void MenuItemTemplateXSL_UC_Load(object sender, EventArgs e)
        {
            LoadMenuItem();
        }

        #endregion

        #endregion

        #region Methods

        #region LoadMenu
        void LoadMenuItem()
        {
            int menuID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.MenuID], out menuID);

            if (base.XSLTemplateID > 0 && menuID > 0)
            {
                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(base.XSLTemplateID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, base.XSLTemplateID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlMenu.DocumentContent = MenuManager.GetMenuItemTemplateXml(menuID, CMSContext.LanguageID);
                xmlMenu.TransformSource = xslPath;
                xmlMenu.TransformArgumentList = arguments;
                xmlMenu.DataBind();
            }
        }
        #endregion

        #endregion
    }
}