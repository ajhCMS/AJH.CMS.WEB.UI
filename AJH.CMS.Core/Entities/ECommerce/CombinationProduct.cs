using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class CombinationProduct : IEntity
    {
        public int ProductID
        {
            set;
            get;
        }

        public string ProductReference
        {
            set;
            get;
        }

        public string ProductEAN13
        {
            set;
            get;
        }

        public string ProductUPC
        {
            set;
            get;
        }

        public int SupplierRefernce
        {
            set;
            get;
        }

        public string Location
        {
            set;
            get;
        }

        public decimal WholesalePrice
        {
            set;
            get;
        }

        public int ImpactOnPrice
        {
            set;
            get;
        }

        public int ImpactOnWeight
        {
            set;
            get;
        }

        public int InitialStock
        {
            set;
            get;
        }

        public int MinimumQuantity
        {
            set;
            get;
        }

        public bool IsDefault
        {
            set;
            get;
        }

        public string Color
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public int ModuleID
        {
            set;
            get;
        }

        #region IEntity Members

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int PortalID
        {
            get;
            set;
        }

        public int LanguageID
        {
            get;
            set;
        }

        #endregion

        public CombinationProduct()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.ProductID = 0;
            this.ProductReference = string.Empty;
            this.ProductEAN13 = string.Empty;
            this.ProductUPC = string.Empty;
            this.SupplierRefernce = 0;
            this.Location = string.Empty;
            this.WholesalePrice = 0;
            this.ImpactOnPrice = 0;
            this.ImpactOnWeight = 0;
            this.InitialStock = 0;
            this.MinimumQuantity = 0;
            this.IsDefault = false;
            this.Color = string.Empty;
            this.IsDeleted = false;
            this.ModuleID = 0;
        }
    }
}