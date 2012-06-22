using System;
using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class FormManager
    {
        public static int Add(Form form)
        {
            Form form2 = GetForm(form.Code);
            if (form2 != null)
                throw new Exception("There is another form has the same code, please choose another code");

            return FormDataMapper.Add(form);
        }

        public static void Update(Form form)
        {
            Form form2 = GetForm(form.Code);
            if (form2 != null && form2.ID != form.ID)
                throw new Exception("There is another form has the same e-mail, please choose another code");

            FormDataMapper.Update(form);
        }

        public static void Delete(int ID)
        {
            FormUserManager.Delete(ID, -1);
            FormRoleManager.Delete(ID, -1);
            FormDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            FormUserManager.Delete(ID, -1);
            FormRoleManager.Delete(ID, -1);
            FormDataMapper.DeleteLogical(ID);
        }

        public static List<Form> GetForms()
        {
            return FormDataMapper.GetForms();
        }

        public static Form GetForm(int ID)
        {
            return FormDataMapper.GetFormById(ID);
        }

        public static Form GetForm(string FormCode)
        {
            return FormDataMapper.GetFormByFormCode(FormCode);
        }
    }
}