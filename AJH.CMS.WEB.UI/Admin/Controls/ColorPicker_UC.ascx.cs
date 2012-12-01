
namespace AJH.CMS.WEB.UI.Admin
{
    public partial class ColorPicker_UC : System.Web.UI.UserControl
    {
        #region Properties

        public string SelectedColor
        {
            get
            {
                return txtColor.Text;
            }
            set
            {
                txtColor.Text = value;
                cpeColor.SelectedColor = value;
            }
        }

        #endregion
    }
}