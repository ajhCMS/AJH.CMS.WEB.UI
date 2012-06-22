using System.Collections.Generic;
using System.IO;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class StyleManager
    {
        public static int Add(Style style)
        {
            return StyleDataMapper.Add(style);
        }

        public static void Update(Style style)
        {
            StyleDataMapper.Update(style);
        }

        public static void Delete(int ID)
        {
            StyleDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            StyleDataMapper.DeleteLogical(ID);
        }

        public static List<Style> GetStyles()
        {
            return StyleDataMapper.GetStyles();
        }

        public static List<Style> GetStyles(int PortalID, int LanguageID)
        {
            return StyleDataMapper.GetStyles(PortalID, LanguageID);
        }

        public static Style GetStyle(int ID)
        {
            return StyleDataMapper.GetStyleById(ID);
        }

        public static void UpdateStyleFile(string StyleFilePath, Style style)
        {
            if (!string.IsNullOrEmpty(StyleFilePath) && style != null)
            {
                StreamWriter streamWriter = new StreamWriter(StyleFilePath, false);
                streamWriter.Write(style.Details);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}