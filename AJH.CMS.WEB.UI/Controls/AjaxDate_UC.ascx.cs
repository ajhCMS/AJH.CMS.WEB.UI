using System;

namespace AJH.CMS.WEB.UI.Controls
{
    public partial class AjaxDate_UC : System.Web.UI.UserControl
    {
        #region Properties
        public DateTime? SelectedDateTime
        {
            get
            {
                return ceDate.SelectedDate;
            }
            set
            {
                ceDate.SelectedDate = value;
                if (value != null)
                {
                    txtDate.Text = value.Value.ToString(ceDate.Format);
                }
                else
                {
                    txtDate.Text = string.Empty;
                }
            }
        }

        public bool IsRequired
        {
            get
            {
                return rfvDate.Visible && rfvDate.Enabled;
            }
            set
            {
                rfvDate.Visible = rfvDate.Enabled = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return rfvDate.ErrorMessage;
            }
            set
            {
                rfvDate.ErrorMessage = value;
            }
        }

        public string ErrorText
        {
            get
            {
                return rfvDate.Text;
            }
            set
            {
                rfvDate.Text = value;
            }
        }

        public string Format
        {
            get
            {
                return ceDate.Format;
            }
            set
            {
                ceDate.Format = value;
            }
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(AjaxDate_Load);
        }
        #endregion

        #region AjaxDate_Load
        void AjaxDate_Load(object sender, EventArgs e)
        {
            if (IsRequired)
            {
                if (string.IsNullOrEmpty(txtDate.Attributes["readonly"]))
                    txtDate.Attributes.Add("readonly", "readonly");
            }
            SetCalendarExtenderValue();
        }
        #endregion

        #endregion

        #region Methods

        #region SetCalendarExtenderValue
        void SetCalendarExtenderValue()
        {
            try
            {
                string dateTime = txtDate.Text;
                ceDate.SelectedDate = DateTime.ParseExact(txtDate.Text, ceDate.Format, null);
            }
            catch
            {
                ceDate.SelectedDate = null;
            }
        }
        #endregion

        #endregion
    }
}