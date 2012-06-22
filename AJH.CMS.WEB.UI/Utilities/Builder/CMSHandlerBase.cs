using System.Web;
using System.Web.SessionState;

namespace AJH.CMS.WEB.UI
{
    public class CMSHandlerBase : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler Members

        virtual public bool IsReusable
        {
            get { return false; }
        }

        virtual public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        }

        #endregion
    }
}