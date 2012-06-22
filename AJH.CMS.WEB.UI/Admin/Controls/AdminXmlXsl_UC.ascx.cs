using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using AJH.CMS.Core.Data;

namespace AJH.CMS.WEB.UI.Admin
{
    public partial class AdminXmlXsl_UC : System.Web.UI.UserControl
    {
        #region Properties

        public string DocumentSource
        {
            get;
            set;
        }

        public string TransformSource
        {
            get;
            set;
        }

        public List<string> AttributeKeyValue
        {
            get;
            set;
        }

        public List<string> AttributeDataValue
        {
            get;
            set;
        }

        public string KeyControlValue
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region LoadXml
        public void LoadXml()
        {
            StringWriter sw = null;
            sw = CacheManager.GetObject(KeyControlValue) as StringWriter;

            if (sw == null)
            {
                sw = new StringWriter();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(MapPath(DocumentSource));

                if (xmlDoc.ChildNodes.Count > 1 && AttributeKeyValue != null && AttributeKeyValue.Count > 0)
                {
                    for (int i = 0; i < AttributeKeyValue.Count; i++)
                    {
                        XmlAttribute xmlAtt = xmlDoc.CreateAttribute(AttributeKeyValue[i]);
                        xmlAtt.Value = AttributeDataValue[i];
                        xmlDoc.ChildNodes[1].Attributes.Append(xmlAtt);
                    }
                }

                XslCompiledTransform xsl = new XslCompiledTransform();
                xsl.Load(MapPath(TransformSource));

                XsltArgumentList xslarg = new XsltArgumentList();
                xslarg.AddExtensionObject("CMS:UserControl", this);

                xsl.Transform(xmlDoc, xslarg, sw);
                sw.Close();

                CacheManager.AddObject(KeyControlValue, sw);
            }

            dvXML.InnerHtml = sw.ToString();
        }
        #endregion

        #endregion
    }
}