using System;
using System.Collections.Generic;
using System.Web;
using AJH.CMS.Core.Configuration;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Enums;

namespace AJH.CMS.Core.Data
{
    public static class UserManager
    {
        public static int Add(User user)
        {
            user.Name = user.Email;

            User user2 = GetUser(user.Email);
            if (user2 != null)
                throw new Exception("There is another user has the same e-mail, please choose another e-mail");

            return UserDataMapper.Add(user);
        }

        public static void Update(User user)
        {
            user.Name = user.Email;

            User user2 = GetUser(user.Email);
            if (user2 != null && user2.ID != user.ID)
                throw new Exception("There is another user has the same e-mail, please choose another e-mail");

            UserDataMapper.Update(user);
        }

        public static void Delete(int ID)
        {
            FormUserManager.Delete(-1, ID);
            RoleManager.DeleteRoleUser(-1, ID);
            UserDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            FormUserManager.Delete(-1, ID);
            RoleManager.DeleteRoleUser(-1, ID);
            UserDataMapper.DeleteLogical(ID);
        }

        public static void UpdateActive(int ID, bool IsActive)
        {
            UserDataMapper.UpdateActive(ID, IsActive);
        }

        public static List<User> GetUsers()
        {
            return UserDataMapper.GetUsers();
        }

        public static List<User> GetUsers(int RoleID)
        {
            return UserDataMapper.GetUsers(RoleID);
        }

        public static List<User> GetUsersNotInRole(int RoleID)
        {
            return UserDataMapper.GetUsersNotInRole(RoleID);
        }

        public static List<User> GetUsersNotInForm(int FormID)
        {
            return UserDataMapper.GetUsersNotInForm(FormID);
        }

        public static User GetUser(int ID)
        {
            return UserDataMapper.GetUserById(ID);
        }

        public static User GetUser(string UserName)
        {
            return UserDataMapper.GetUserByUserName(UserName);
        }

        public static User GetUserWithValidation(string UserName, string Password)
        {
            User user = GetUser(UserName);
            if (user != null && user.Password == Password && user.IsActive)
                return user;
            return null;
        }

        public static User GetCurrentUser()
        {
            User user = null;
            if (HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentUserKey] != null)
                user = HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentUserKey] as User;
            return user;
        }

        public static void LoginIn(User user, bool WithRoles)
        {
            if (user != null)
            {
                HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentUserKey] = user;

                if (WithRoles)
                {
                    List<FormUser> formsUser = FormUserManager.GetFormsUsers(-1, user.ID);
                    Dictionary<string, CMSEnums.AccessType> formsUserAccess = new Dictionary<string, CMSEnums.AccessType>();
                    for (int i = 0; i < formsUser.Count; i++)
                    {
                        formsUserAccess.Add(formsUser[i].FormCode, formsUser[i].AccessType);
                    }
                    HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentFormKey] = formsUserAccess;

                    List<FormRole> formsRoles = FormRoleManager.GetFormsRolesByUserID(user.ID);
                    HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentRoleKey] = formsRoles;
                }
            }
        }

        public static void LogOut()
        {
            HttpContext.Current.Session.Remove(CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentFormKey);
            HttpContext.Current.Session.Remove(CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentRoleKey);
            HttpContext.Current.Session.Remove(CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentUserKey);
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }

        public static bool CheckIfHasAccessCMS(string FormCode)
        {
            Dictionary<string, CMSEnums.AccessType> formsUserAccess = HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentFormKey] as Dictionary<string, CMSEnums.AccessType>;
            if (formsUserAccess != null)
            {
                if (formsUserAccess.ContainsKey(FormCode))
                {
                    CMSEnums.AccessType AccessType = formsUserAccess[FormCode];
                    return AccessType == CMSEnums.AccessType.Allow;
                }
            }

            List<FormRole> formsRoles = HttpContext.Current.Session[CoreConfigurationManager._CoreConfigSectionHandler.SecurityElement.SessionCurrentRoleKey] as List<FormRole>;
            if (formsRoles != null)
            {
                for (int i = 0; i < formsRoles.Count; i++)
                {
                    if (formsRoles[i].FormCode == FormCode)
                    {
                        return formsRoles[i].AccessType == CMSEnums.AccessType.Allow;
                    }
                }
            }

            return false;
        }
    }
}