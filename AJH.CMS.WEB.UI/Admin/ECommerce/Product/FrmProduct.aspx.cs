
namespace AJH.CMS.WEB.UI.Admin
{
    public partial class FrmProduct : CMSAdminPageBase
    {
        protected override void OnInit(System.EventArgs e)
        {

            this.Load += new System.EventHandler(FrmProduct_Load);
            base.OnInit(e);
        }

        void FrmProduct_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}