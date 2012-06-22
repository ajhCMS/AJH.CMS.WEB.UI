using System.Collections.Generic;
using AJH.CMS.Core.Entities;

namespace AJH.CMS.Core.Data
{
    public static class HtmlBlockManager
    {
        public static int Add(HtmlBlock htmlBlock)
        {
            return HtmlBlockDataMapper.Add(htmlBlock);
        }

        public static void Update(HtmlBlock htmlBlock)
        {
            HtmlBlockDataMapper.Update(htmlBlock);
        }

        public static void Delete(int ID)
        {
            HtmlBlockDataMapper.Delete(ID);
        }

        public static void DeleteLogical(int ID)
        {
            HtmlBlockDataMapper.DeleteLogical(ID);
        }

        public static List<HtmlBlock> GetHtmlBlocks()
        {
            return HtmlBlockDataMapper.GetHtmlBlocks();
        }

        public static List<HtmlBlock> GetHtmlBlocks(int PortalID, int LanguageID)
        {
            return HtmlBlockDataMapper.GetHtmlBlocks(PortalID, LanguageID);
        }

        public static HtmlBlock GetHtmlBlock(int ID)
        {
            return HtmlBlockDataMapper.GetHtmlBlockById(ID);
        }
    }
}