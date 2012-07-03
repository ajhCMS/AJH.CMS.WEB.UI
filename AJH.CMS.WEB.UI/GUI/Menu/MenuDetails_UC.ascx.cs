using System;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class MenuDetails_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MenuDetails_UC_Load);
        }
        #endregion

        #region MenuDetails_UC_Load
        void MenuDetails_UC_Load(object sender, EventArgs e)
        {
            LoadMenuDetails();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadMenuDetails
        void LoadMenuDetails()
        {
            int menuID = 0;
            int.TryParse(Request.QueryString[CMSConfig.QueryString.MenuID], out menuID);
            if (menuID > 0)
            {
                Menu menu = MenuManager.GetMenu(menuID);
                if (menu != null)
                {
                    lblMenuTitle.Text = menu.Name;
                    dvMenuDetails.InnerHtml = menu.Details;
                    this.Page.Title = menu.Name;
                }
            }
        }
        #endregion

        #endregion
    }
}