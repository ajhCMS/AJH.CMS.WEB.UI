using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AJH.CMS.Core.Configuration;
using System.IO;
using AJH.CMS.WEB.UI.Utilities.Builder;
using System.Web.UI;
using AJH.CMS.Core.Entities;
using AJH.CMS.Core.Data;

namespace AJH.CMS.WEB.UI.Services
{
    /// <summary>
    /// Summary description for frmGalleryXMLFile
    /// </summary>
    public class frmGalleryXMLFile : CMSHandlerBase
    {
        #region ProcessRequest
        public override void ProcessRequest(HttpContext context)
        {
            int CategoryID = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.CategoryID], out CategoryID);

            int XslID = 0;
            int.TryParse(context.Request.QueryString[CMSConfig.QueryString.XslID], out XslID);

            IList<Gallery> galleries = GalleryManager.GetParentObjGallerysByCategoryID(CategoryID, Core.Enums.CMSEnums.GalleryType.Photo).Where(g => g.IsPublished).ToList();

            string xmlGallery = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><settings autoRotate=\"1\" autoRotateSpeed=\"4\" useSubtitle=\"1\"";
            xmlGallery += " useTooltip=\"0\" useSecondCaption=\"1\" useThiredCaption=\"1\" spanX=\"400\" spanY=\"40\" centerX=\"500\" centerY=\"360\" distanceValue=\"0\"";
            xmlGallery += " perspectiveRatio=\"0.74\" minimumscale=\".15\" turningspeed=\"2\" rotationKind=\"1\" useFocalBlur=\"1\" focalBlurValue=\".6\" useMotionBlur=\"1\"";
            xmlGallery += " motionBlurValue=\".25\" useFadeOnMouseOver=\"1\" mouseOverAlphaValue=\".5\" useReflection=\"1\" reflectionAlphaValue=\".5\"/>";

            xmlGallery += "<photos>";

            for (int i = 0; i < galleries.Count; i++)
            {
                xmlGallery += "<photo imageURL=\"Portals/Portal1/Uploads/Upload/" + galleries[i].File + "\" linkData=\"#\" linkType=\"URL\" linkTarget=\"_self\" captionText=\"Design - PinnacleCAD\" captionText2=\"Totally Integrated Design to Production LGS Solution! \"  captionText3=\" \" enableButtonWhenInFront=\"1\"/>";
            }
            xmlGallery += "</photos>";

            context.Response.Clear();
            context.Response.ContentType = "text/xml";
            context.Response.Write(xmlGallery);
            context.Response.Flush();
        }
        #endregion
    }
}