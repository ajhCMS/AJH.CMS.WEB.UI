using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using AJH.CMS.WEB.UI.Utilities;

namespace AJH.CMS.WEB.UI.Controls.SWFUpload
{
    /// <summary>
    /// Summary description for frmSWFUpload
    /// </summary>
    public class frmSWFUpload : IHttpHandler, IRequiresSessionState
    {
        #region Methods

        #region ProcessRequest
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (CMSContext.UserID > 0)
                {
                    if (context.Request.Files.Count > 0)
                    {
                        // get the current file
                        HttpPostedFile uploadFile = context.Request.Files[0];
                        // if there was a file uploded
                        if (uploadFile.ContentLength > 0)
                        {
                            // save the file to the upload directory

                            //use this if testing from a classic style upload, ie. 

                            // <form action="Upload.axd" method="post" enctype="multipart/form-data">
                            //    <input type="file" name="fileUpload" />
                            //    <input type="submit" value="Upload" />
                            //</form>

                            // this is because flash sends just the filename, where the above 
                            //will send the file path, ie. c:\My Pictures\test1.jpg
                            //you can use Test.thm to test this page.
                            //string filename = uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf("\\"));
                            //uploadFile.SaveAs(string.Format("{0}{1}{2}", tempFile, "Upload\\", filename));

                            // use this if using flash to upload
                            string uploadFileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadFile.FileName);
                            string virtualPath = CMSContext.VirtualUploadFolder + uploadFileName;
                            Stream InputStream = uploadFile.InputStream;
                            try
                            {
                                //Uncomment the line to use resize the image
                                //if (uploadFile.ContentType.ToLower().Contains("image"))
                                {
                                    uploadFile.SaveAs(context.Server.MapPath(virtualPath));
                                    //InputStream = CMSUpload.SaveJPGWithCompressionSetting(InputStream, context.Server.MapPath(virtualPath));
                                    string virtualThumbnailPath = CMSContext.VirtualUploadThumbnailFolder + uploadFileName;
                                    CMSUpload.CreateThumbnail(InputStream, context.Server.MapPath(virtualThumbnailPath));
                                }
                                //else
                                //{
                                //    uploadFile.SaveAs(context.Server.MapPath(virtualPath));
                                //}
                            }
                            catch
                            {
                                uploadFile.SaveAs(context.Server.MapPath(virtualPath));
                            }
                            // HttpPostedFile has an InputStream also.  You can pass this to 
                            // a function, or business logic. You can save it a database:

                            //byte[] fileData = new byte[uploadFile.ContentLength];
                            //uploadFile.InputStream.Write(fileData, 0, fileData.Length);
                            // save byte array into database.

                            // something I do is extract files from a zip file by passing
                            // the inputStream to a function that uses SharpZipLib found here:
                            // http://www.icsharpcode.net/OpenSource/SharpZipLib/
                            // and then save the files to disk.                    

                            context.Response.Write(uploadFileName);
                        }
                    }
                }
                else
                {
                    throw new Exception("Access denied");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write(ex.Message);
                context.Response.End();
            }
        }
        #endregion

        #endregion

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}