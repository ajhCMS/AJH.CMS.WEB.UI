﻿using System.Collections.Generic;

namespace AJH.CMS.Core.Data
{
    public static class AttributeManager
    {
        public static int Add(AJH.CMS.Core.Entities.Attribute attribute)
        {
            return AttributeDataMapper.Add(attribute);
        }

        public static void Update(AJH.CMS.Core.Entities.Attribute attribute)
        {
            AttributeDataMapper.Update(attribute);
        }

        public static void AddOtherLanguage(AJH.CMS.Core.Entities.Attribute attribute)
        {
            AttributeDataMapper.AddOtherLanguage(attribute);
        }

        public static void Delete(int id)
        {
            AttributeDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            AttributeDataMapper.DeleteLogical(id);
        }

        public static List<AJH.CMS.Core.Entities.Attribute> GetAttributes(int languageID)
        {
            return AttributeDataMapper.GetAttributes(languageID);
        }

        public static AJH.CMS.Core.Entities.Attribute GetAttribute(int id, int languageID)
        {
            return AttributeDataMapper.GetAttribute(id, languageID);
        }

        public static List<AJH.CMS.Core.Entities.Attribute> GetAttributesByCombinationID(int combinationID, int languageID)
        {
            return AttributeDataMapper.GetAttributesByCombinationID(combinationID, languageID);
        }

        public static List<AJH.CMS.Core.Entities.Attribute> GetAttributesByGroupID(int groupID, int languageID)
        {
            return AttributeDataMapper.GetAttributesByGroupID(groupID, languageID);
        }
    }
}