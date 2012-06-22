using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AJH.CMS.WEB.UI.Utilities
{
    public static class CMSUpload
    {
        #region Properties
        const int ThumpnailWidth = 300;
        const int ThumpnailHeight = 300;
        #endregion

        #region CreateThumbnail
        public static void CreateThumbnail(Stream imageStream, string thumbnailName)
        {
            System.Drawing.Image originalImage = null;
            try
            {
                originalImage = System.Drawing.Image.FromStream(imageStream);
                int[] realThumbDimensions = GetProportionalThumbnailSize(originalImage.Width, originalImage.Height);

                System.Drawing.Bitmap thumbnail = null;
                System.Drawing.Image oTempThumbnail = null;
                try
                {
                    oTempThumbnail = originalImage.GetThumbnailImage(
                        realThumbDimensions[0],
                        realThumbDimensions[1],
                        null,
                        IntPtr.Zero);

                    if (realThumbDimensions[1] > ThumpnailHeight)
                        realThumbDimensions[1] = ThumpnailHeight;

                    Rectangle oRectangle = new Rectangle(0, 0, realThumbDimensions[0], realThumbDimensions[1]);
                    thumbnail = new Bitmap(oTempThumbnail);
                    thumbnail = thumbnail.Clone(oRectangle, thumbnail.PixelFormat);

                    thumbnail.Save(thumbnailName);
                }
                finally
                {
                    if (!Object.Equals(thumbnail, null)) thumbnail.Dispose();
                }
            }
            finally
            {
                if (!Object.Equals(originalImage, null)) originalImage.Dispose();
            }
        }
        #endregion

        #region GetProportionalThumbnailSize
        private static int[] GetProportionalThumbnailSize(int originalWidth, int originalHeight)
        {
            int realWidth = ThumpnailWidth;
            int realHeight = ThumpnailHeight;

            realHeight = originalHeight * ThumpnailHeight / originalWidth;
            return new int[] { realWidth, realHeight };
        }
        #endregion

        #region GetEncoderInfo
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion

        #region SaveJPGWithCompressionSetting
        public static Stream SaveJPGWithCompressionSetting(Stream imageStream, string szFileName)
        {
            Bitmap imageFile = new Bitmap(imageStream);
            try
            {
                EncoderParameters eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)90);
                ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
                imageFile.Save(szFileName, ici, eps);
            }
            catch
            {
                imageFile.Save(szFileName);
            }
            StreamReader sr = new StreamReader(szFileName);
            return sr.BaseStream;
        }
        #endregion
    }
}