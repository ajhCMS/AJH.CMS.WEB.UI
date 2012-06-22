using System;
using System.Collections.Generic;
using System.ComponentModel;
using AJH.CMS.Core.Data;
using AJH.CMS.Core.Entities;
using AJH.CMS.WEB.UI.Utilities;

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