using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class FormUserManager
    {
        public static int Add(FormUser formUser)
        {
            List<FormUser> formsUsers2 = GetFormsUsers(formUser.FormID, formUser.UserID);
            if (formsUsers2 != null && formsUsers2.Count > 0)
                throw new Exception("This user already exists, please choose another user");

            return FormUserDataMapper.Add(formUser);
        }

        public static void Update(FormUser formUser)
        {
            List<FormUser> formsUsers2 = GetFormsUsers(formUser.FormID, formUser.UserID);
            if (formsUsers2 != null && formsUsers2.Count > 0 && formsUsers2[0].ID != formUser.ID)
                throw new Exception("This user already exists, please choose another user");

            FormUserDataMapper.Update(formUser);
        }

        public static void Delete(int ID)
        {
            FormUserDataMapper.Delete(ID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormID">By default -1</param>
        /// <param name="UserID">By default -1</param>
        public static void Delete(int FormID, int UserID)
        {
            FormUserDataMapper.Delete(FormID, UserID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormID">By default -1</param>
        /// <param name="UserID">By default -1</param>
        /// <returns></returns>
        public static List<FormUser> GetFormsUsers(int FormID, int UserID)
        {
            return FormUserDataMapper.GetFormsUsers(FormID, UserID);
        }

        public static FormUser GetFormUser(int ID)
        {
            return FormUserDataMapper.GetFormUserById(ID);
        }
    }
}