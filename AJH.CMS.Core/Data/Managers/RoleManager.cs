using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class RoleManager
    {
        public static int Add(Role role)
        {
            Role role2 = GetRole(role.Name);
            if (role2 != null)
                throw new Exception("There is another role has the same Name, please choose another Name");

            return RoleDataMapper.Add(role);
        }

        public static void Update(Role role)
        {
            Role role2 = GetRole(role.Name);
            if (role2 != null && role2.ID != role.ID)
                throw new Exception("There is another role has the same Name, please choose another Name");

            RoleDataMapper.Update(role);
        }

        public static void Delete(int ID)
        {
            FormRoleManager.Delete(-1, ID);
            DeleteRoleUser(ID, -1);
            RoleDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            FormRoleManager.Delete(-1, ID);
            DeleteRoleUser(ID, -1);
            RoleDataMapper.DeleteLogical(ID);
        }

        public static List<Role> GetRoles()
        {
            return RoleDataMapper.GetRoles();
        }

        public static List<Role> GetRolesNotInForm(int FormID)
        {
            return RoleDataMapper.GetRolesNotInForm(FormID);
        }

        public static Role GetRole(int ID)
        {
            return RoleDataMapper.GetRoleById(ID);
        }

        public static Role GetRole(string RoleName)
        {
            return RoleDataMapper.GetRoleByRoleName(RoleName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleID">By default: -1</param>
        /// <param name="UserID">By default: -1</param>
        public static void DeleteRoleUser(int RoleID, int UserID)
        {
            RoleDataMapper.DeleteRoleUser(RoleID, UserID);
        }

        public static void AddRoleUser(int RoleID, int UserID)
        {
            RoleDataMapper.AddRoleUser(RoleID, UserID);
        }
    }
}