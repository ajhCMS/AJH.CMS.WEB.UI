using System;
using System.Web.UI;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Services
{
    public partial class GalleryXSL_UC : UserControl
    {
        #region Properties
        int _CategoryID
        {
            get;
            set;
        }

        int _XslID
        {
            get;
            set;
        }

        int _PageSize
        {
            get;
            set;
        }

        int _PageNumber
        {
            get;
            set;
        }

        public int _TotalItems
        {
            get;
            set;
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(GalleryXSL_UC_Load);
        }
        #endregion

        #region GalleryXSL_UC_Load
        void GalleryXSL_UC_Load(object sender, EventArgs e)
        {
            LoadGallery();
        }
        #endregion

        #endregion

        #region Methods

        #region LoadGallery
        void LoadGallery()
        {
            if (_XslID > 0 && _CategoryID > 0)
            {
                int TotalCount = 0;
                string galleryXML = GalleryManager.GetGallerysPublishXML(_CategoryID, Core.Enums.CMSEnums.GalleryType.Photo, _PageNumber, _PageSize, ref TotalCount);
                _TotalItems = TotalCount;

                string xslPath = CMSWebHelper.GetXSLTemplateFilePath(_XslID);
                xslPath = XSLTemplateManager.GetXSLTemplatePath(xslPath, _XslID);

                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("CMS:UserControl", this);

                xmlGallery.DocumentContent = galleryXML;
                xmlGallery.TransformSource = xslPath;
                xmlGallery.TransformArgumentList = arguments;
                xmlGallery.DataBind();
            }
        }
        #endregion

        #region SetItems
        public void SetItems(int PageNumber, int PageSize, int CategoryID, int XslID)
        {
            _PageNumber = PageNumber;
            _PageSize = PageSize;
            _CategoryID = CategoryID;
            _XslID = XslID;
        }
        #endregion

        #endregion
    }
}