﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AJH.CMS.WEB.UI
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = AJH.CMS.WEB.UI.Utilities.CMSContext.LanguageID;

        }
    }
}