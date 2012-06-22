using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class FormRoleManager
    {
        public static int Add(FormRole formRole)
        {
            List<FormRole> formsRoles2 = GetFormsRoles(formRole.FormID, formRole.RoleID);
            if (formsRoles2 != null && formsRoles2.Count > 0)
                throw new Exception("This role already exists, please choose another role");

            return FormRoleDataMapper.Add(formRole);
        }

        public static void Update(FormRole formRole)
        {
            List<FormRole> formsRoles2 = GetFormsRoles(formRole.FormID, formRole.RoleID);
            if (formsRoles2 != null && formsRoles2.Count > 0 && formsRoles2[0].ID != formRole.ID)
                throw new Exception("This role already exists, please choose another role");

            FormRoleDataMapper.Update(formRole);
        }

        public static void Delete(int ID)
        {
            FormRoleDataMapper.Delete(ID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormID">By default -1</param>
        /// <param name="RoleID">By default -1</param>
        public static void Delete(int FormID, int RoleID)
        {
            FormRoleDataMapper.Delete(FormID, RoleID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormID">By default -1</param>
        /// <param name="RoleID">By default -1</param>
        /// <returns></returns>
        public static List<FormRole> GetFormsRoles(int FormID, int RoleID)
        {
            return FormRoleDataMapper.GetFormsRoles(FormID, RoleID);
        }

        public static List<FormRole> GetFormsRolesByUserID(int UserID)
        {
            return FormRoleDataMapper.GetFormsRolesByUserID(UserID);
        }

        public static FormRole GetFormRole(int ID)
        {
            return FormRoleDataMapper.GetFormRoleById(ID);
        }
    }
}