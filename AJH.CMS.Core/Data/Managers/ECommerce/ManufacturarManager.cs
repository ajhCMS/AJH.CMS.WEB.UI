using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class ManufacturarManager
    {
        public static int Add(Manufacturar manufacturar)
        {
            return ManufacturarDataMapper.Add(manufacturar);
        }

        public static void Update(Manufacturar manufacturar)
        {
            ManufacturarDataMapper.Update(manufacturar);
        }

        public static void AddOtherLanguage(Manufacturar manufacturar)
        {
            ManufacturarDataMapper.AddOtherLanguage(manufacturar);
        }

        public static void Delete(int id)
        {
            ManufacturarDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            ManufacturarDataMapper.DeleteLogical(id);
        }

        public static List<Manufacturar> GetManufacturars(int portalID, int languageID)
        {
            return ManufacturarDataMapper.GetManufacturars(portalID, languageID);
        }

        public static Manufacturar GetManufacturar(int id, int portalID, int languageID)
        {
            return ManufacturarDataMapper.GetManufacturar(id, portalID, languageID);
        }
    }
}