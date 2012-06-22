using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class SupplierManager
    {
        public static int Add(Supplier supplier)
        {
            return SupplierDataMapper.Add(supplier);
        }

        public static void Update(Supplier supplier)
        {
            SupplierDataMapper.Update(supplier);
        }

        public static void AddOtherLanguage(Supplier AddOtherLanguage)
        {
            SupplierDataMapper.AddOtherLanguage(AddOtherLanguage);
        }

        public static void Delete(int id)
        {
            SupplierDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            SupplierDataMapper.DeleteLogical(id);
        }

        public static List<Supplier> GetSuppliers(int portalID, int languageID)
        {
            return SupplierDataMapper.GetSuppliers(portalID, languageID);
        }

        public static Supplier GetSupplier(int id, int portalID, int languageID)
        {
            return SupplierDataMapper.GetSupplier(id, portalID, languageID);
        }
    }
}