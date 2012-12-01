
namespace AJH.CMS.Core.Entities
{
    public class Product : IEntity
    {
        public int SupplierID
        {
            get;
            set;
        }

        public string Ean13OrJan
        {
            set;
            get;
        }

        public string UPC
        {
            set;
            get;
        }

        public string Location
        {
            set;
            get;
        }

        public bool IsDownloadable
        {
            set;
            get;
        }

        public bool IsDeleted
        {
            set;
            get;
        }

        public bool DisplayOnSaleIcon
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

        public decimal AdditionalShippingCost
        {
            set;
            get;
        }

        public int ManufacturarID
        {
            set;
            get;
        }

        public bool IsEnabled
        {
            set;
            get;
        }

        public int TaxID
        {
            set;
            get;
        }

        public int ModuleID
        {
            set;
            get;
        }

        public string DisplayTextInStockText
        {
            set;
            get;
        }

        public string DisplayTextInBackOrderText
        {
            set;
            get;
        }

        public string Description
        {
            set;
            get;
        }

        public string ShortDescription
        {
            set;
            get;
        }

        public string SizeChart
        {
            set;
            get;
        }

        public string Tags
        {
            set;
            get;
        }

        public int Order
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

        public Product()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PortalID = 0;
            this.LanguageID = 0;
            this.SupplierID = 0;
            this.Ean13OrJan = string.Empty;
            this.UPC = string.Empty;
            this.Location = string.Empty;
            this.DisplayOnSaleIcon = false;
            this.InitialStock = 0;
            this.MinimumQuantity = 0;
            this.AdditionalShippingCost = 0;
            this.ManufacturarID = 0;
            this.IsEnabled = false;
            this.TaxID = 0;
            this.ModuleID = 0;
            this.ShortDescription = string.Empty;
            this.DisplayTextInStockText = string.Empty;
            this.DisplayTextInBackOrderText = string.Empty;
            this.Description = string.Empty;
            this.SizeChart = string.Empty;
            this.Tags = string.Empty;
            this.Order = 0;
        }
    }
}