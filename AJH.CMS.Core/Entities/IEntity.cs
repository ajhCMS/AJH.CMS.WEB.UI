
namespace AJH.CMS.Core.Entities
{
    public interface IEntity
    {
        int ID
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        int PortalID
        {
            get;
            set;
        }

        int LanguageID
        {
            get;
            set;
        }
    }
}