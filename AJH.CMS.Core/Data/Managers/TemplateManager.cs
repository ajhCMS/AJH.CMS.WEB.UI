using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class TemplateManager
    {
        public static int Add(Template template)
        {
            return TemplateDataMapper.Add(template);
        }

        public static void Update(Template template)
        {
            TemplateDataMapper.Update(template);
        }

        public static void Delete(int ID)
        {
            TemplateDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            TemplateDataMapper.DeleteLogical(ID);
        }

        public static List<Template> GetTemplates()
        {
            return TemplateDataMapper.GetTemplates();
        }

        public static List<Template> GetTemplates(int PortalID, int LanguageID)
        {
            return TemplateDataMapper.GetTemplates(PortalID, LanguageID);
        }

        public static Template GetTemplate(int ID)
        {
            return TemplateDataMapper.GetTemplate(ID);
        }
    }
}