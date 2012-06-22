using System.IO;
using System.Web;
using System.Web.UI;
using AJH.CMS.Core.Configuration;
using AJH.CMS.WEB.UI.Utilities.Builder;

namespace AJH.CMS.WEB.UI.Services
{
    /// <summary>
    /// Summary description for frmGalleryServiceXsl
    /// </summary>
    public class frmGalleryServiceXsl : CMSHandlerBase
    {
        #region ProcessRequest
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.Clear();
            context.Response.ContentType = "text/HTML";

            int CategoryID = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.CategoryID], out CategoryID);

            int XslID = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.XslID], out XslID);

            int PageSize = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.PageSize], out PageSize);

            int PageNumber = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.PageNumber], out PageNumber);

            if (PageNumber <= 0)
                PageNumber = 1;

            if (PageSize <= 0)
                PageSize = AJH.CMS.Core.Configuration.CMSConfig.ConstantManager.DefaultPageSize;

            CMSPageExecute page = new CMSPageExecute();
            Control control = page.LoadControl("~/Services/Gallery/GalleryXSL_UC.ascx");
            page.Controls.Add(control);
            (control as GalleryXSL_UC).SetItems(PageNumber, PageSize, CategoryID, XslID);

            StringWriter stringWriter = new StringWriter();
            context.Server.Execute(page, stringWriter, false);

            context.Response.Write((control as GalleryXSL_UC)._TotalItems.ToString() + stringWriter.ToString());
        }
        #endregion
    }
}