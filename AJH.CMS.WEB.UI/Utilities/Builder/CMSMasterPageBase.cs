using System.Web.UI;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI
{
    public class CMSMasterPageBase : MasterPage
    {
        public string GetCssLanguage(string englishCss, string arabicCss)
        {
            string cssLanguage = string.Empty;

            if (CMSContext.LanguageID == 1)
                cssLanguage = englishCss;
            else
                cssLanguage = arabicCss;

            string linkRel = "<link rel=\"stylesheet\" type=\"text/css\" href=\"" + cssLanguage + "\" />";

            return linkRel;
        }
    }
}