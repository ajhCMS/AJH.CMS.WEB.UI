using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class CountriesManager
    {
        public static List<Countries> GetAllCountries()
        {
            return CountriesDataMapper.GetAllCountries();
        }
    }
}
