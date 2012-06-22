using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class ProductImage
    {
        public int ID
        {
            get;
            set;
        }

        public int ProductID
        {
            get;
            set;
        }

        public string Image
        {
            set;
            get;
        }

        public bool IsCoverImage
        {
            set;
            get;
        }

        public string ImageCaption
        {
            set;
            get;
        }

        public int ModuleID
        {
            set;
            get;
        }

        public int LanguageID
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public ProductImage()
        {
            this.ID = 0;
            this.ProductID = 0;
            this.Image = string.Empty;
            this.IsCoverImage = false;
            this.ImageCaption = string.Empty;
            this.ModuleID = 0;
            this.LanguageID = 0;
            this.IsDeleted = false;
        }
    }
}