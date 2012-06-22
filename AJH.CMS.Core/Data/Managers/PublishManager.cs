using System.Collections.Generic;
using System.IO;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;
using System;

namespace AJH.CMS.Core.Data
{
    public static class PublishManager
    {
        public static int Add(Publish publish)
        {
            if (publish.PublishType == CMSEnums.PublishType.PublishNow)
            {
                publish.FromDate = DateTime.Now;
                publish.ToDate = DateTime.Now.AddYears(100);
            }
            return PublishDataMapper.Add(publish);
        }

        public static void Update(Publish publish)
        {
            PublishDataMapper.Update(publish);
        }

        public static void Delete(int ID)
        {
            PublishDataMapper.Delete(ID);
        }

        public static void DeleteByObjectIDAndModuleId(int objectID, int moduleID)
        {
            PublishDataMapper.DeleteByObjectIDAndModuleId(objectID, moduleID);
        }

        public static List<Publish> GetPublishs()
        {
            return PublishDataMapper.GetPublishs();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModuleID">By default: -1</param>
        /// <param name="PortalID"></param>
        /// <param name="LanguageID">By default: -1</param>
        /// <returns></returns>
        public static List<Publish> GetPublishs(int ModuleID, int PortalID, int LanguageID)
        {
            return PublishDataMapper.GetPublishs(ModuleID, PortalID, LanguageID);
        }

        public static Publish GetPublish(int ID)
        {
            return PublishDataMapper.GetPublishById(ID);
        }
    }
}