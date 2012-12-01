using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class TaxManager
    {
        public static int Add(Tax tax)
        {
            return TaxDataMapper.Add(tax);
        }

        public static void Update(Tax tax)
        {
            TaxDataMapper.Update(tax);
        }

        public static void Delete(int id)
        {
            TaxDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            TaxDataMapper.DeleteLogical(id);
        }
        public static List<Tax> GetTaxs(int portalID)
        {
            return TaxDataMapper.GetTaxes(portalID);
        }

        public static Tax GetTax(int id, int portalID)
        {
            return TaxDataMapper.GetTax(id, portalID);
        }
    }
}