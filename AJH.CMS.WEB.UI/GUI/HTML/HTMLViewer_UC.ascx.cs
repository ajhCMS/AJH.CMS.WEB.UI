using System;
using System.Collections.Generic;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public partial class HTMLViewer_UC : CMSUserControlBase
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(HTMLViewer_UC_Load);
        }
        #endregion

        #region HTMLViewer_UC_Load
        void HTMLViewer_UC_Load(object sender, EventArgs e)
        {
            LoadHTML();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadHTML
        void LoadHTML()
        {
            if (base.ContainerValue > 0)
            {
                HtmlBlock htmlBlock = HtmlBlockManager.GetHtmlBlock(base.ContainerValue);
                if (htmlBlock != null)
                {
                    dvHtml.InnerHtml = htmlBlock.Details;
                    dvHtml.Visible = true;
                }
            }
        }
        #endregion

        #region GetContainerValue
        public override Dictionary<string, string> GetContainerValue(int ModuleID, int PortalID, int LanguageID)
        {
            List<HtmlBlock> htmlBlocks = HtmlBlockManager.GetHtmlBlocks(PortalID, LanguageID);

            Dictionary<string, string> items = new Dictionary<string, string>();
            for (int i = 0; i < htmlBlocks.Count; i++)
            {
                items.Add(htmlBlocks[i].ID.ToString(), htmlBlocks[i].Name);
            }
            return items;
        }
        #endregion

        #endregion
    }
}