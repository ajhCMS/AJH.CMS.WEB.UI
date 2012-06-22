using System;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Entities
{
    public class ProductPrice
    {
        public int ID
        {
            get;
            set;
        }

        public int CurrencyID
        {
            get;
            set;
        }

        public int CountryID
        {
            set;
            get;
        }

        public int FromDay
        {
            set;
            get;
        }

        public int FromSecond
        {
            set;
            get;
        }

        public int ToDay
        {
            set;
            get;
        }

        public int ToSecond
        {
            set;
            get;
        }

        public int StartAt
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public decimal Value
        {
            set;
            get;
        }

        public decimal DiscountValue
        {
            set;
            get;
        }

        public decimal DiscountType
        {
            set;
            get;
        }

        public decimal ProductID
        {
            set;
            get;
        }

        public ProductPrice()
        {
            this.ID = 0;
            this.CurrencyID = 0;
            this.CountryID = 0;
            this.FromDay = 0;
            this.FromSecond = 0;
            this.ToDay = 0;
            this.ToSecond = 0;
            this.StartAt = 0;
            this.Value = 0;
            this.DiscountValue = 0;
            this.DiscountType = 0;
            this.ProductID = 0;
            this.IsDeleted = false;
        }
    }
}