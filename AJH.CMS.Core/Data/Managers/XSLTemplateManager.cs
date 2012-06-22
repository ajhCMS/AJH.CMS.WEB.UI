using System.Collections.Generic;
using System.IO;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class XSLTemplateManager
    {
        public static int Add(XSLTemplate xslTemplate)
        {
            return XSLTemplateDataMapper.Add(xslTemplate);
        }

        public static void Update(XSLTemplate xslTemplate)
        {
            XSLTemplateDataMapper.Update(xslTemplate);
        }

        public static void Delete(int ID)
        {
            XSLTemplateDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            XSLTemplateDataMapper.DeleteLogical(ID);
        }

        public static List<XSLTemplate> GetXSLTemplates()
        {
            return XSLTemplateDataMapper.GetXSLTemplates();
        }

        public static List<XSLTemplate> GetXSLTemplates(int ModuleID, int PortalID, int LanguageID)
        {
            return XSLTemplateDataMapper.GetXSLTemplates(ModuleID, PortalID, LanguageID);
        }

        public static List<XSLTemplate> GetXSLTemplates(int PortalID, int LanguageID)
        {
            return XSLTemplateDataMapper.GetXSLTemplates(PortalID, LanguageID);
        }

        public static XSLTemplate GetXSLTemplate(int ID)
        {
            return XSLTemplateDataMapper.GetXSLTemplateById(ID);
        }

        public static string GetXSLTemplatePath(string XslPath, int XslID)
        {
            if (!File.Exists(XslPath))
            {
                string xslContent = string.Empty;
                XSLTemplate xslTemplate = GetXSLTemplate(XslID);
                if (xslTemplate != null)
                    xslContent = xslTemplate.Details;

                StreamWriter streamWriter = new StreamWriter(XslPath, false);
                streamWriter.Write(xslContent);
                streamWriter.Flush();
                streamWriter.Close();
            }
            return XslPath;
        }
    }
}