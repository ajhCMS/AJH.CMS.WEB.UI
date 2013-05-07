using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class GroupManager
    {
        public static int Add(Group group)
        {
            return GroupDataMapper.Add(group);
        }

        public static void Update(Group group)
        {
            GroupDataMapper.Update(group);
        }

        public static void AddOtherLanguage(Group group)
        {
            GroupDataMapper.AddOtherLanguage(group);
        }

        public static void Delete(int id)
        {
            GroupDataMapper.Delete(id);
        }

        public static void DeleteLogical(int id)
        {
            GroupDataMapper.DeleteLogical(id);
        }

        public static List<Group> GetGroups(int portalID, int languageID)
        {
            return GroupDataMapper.GetGroups(portalID, languageID);
        }

        public static List<Group> GetGroupsByCombinationID(int CobinationID, int portalID, int languageID)
        {
            return GroupDataMapper.GetGroupsByCombinationID(CobinationID,portalID, languageID);
        }

        public static Group GetGroup(int id, int languageID)
        {
            return GroupDataMapper.GetGroup(id, languageID);
        }
    }
}