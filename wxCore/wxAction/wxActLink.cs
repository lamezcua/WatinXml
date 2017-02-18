using System;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    /// <summary>
    /// Clicks on the specified link
    /// </summary>
    //  [XmlType]
    public class wxActLink : wxAction
    {
        /// <summary>
        /// Link Attribute Name (url, innertext, id, name etc.)
        /// </summary>
        [XmlElement]
        public string lnkAttributeName;
        /// <summary>
        /// The value of the attibute to use
        /// </summary>
        [XmlElement]
        public string lnkAttributeValue;

        public wxActLink(string ActionName, string attributeName , string attributeValue )
            : base(ActionName)
        {
            lnkAttributeValue = attributeValue;
            lnkAttributeName = attributeName;
        }

        public wxActLink():this("","","") { }

        public override string ToString()
        {
            return String.Format("LinkAction : {0}", lnkAttributeValue);
        }

        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                if (lnkAttributeValue.Contains("*"))
                {
                    lnkAttributeValue = lnkAttributeValue.Replace("*", String.Empty);
                    ie.Link(Find.By(lnkAttributeName,
                        new Regex(lnkAttributeValue))).Click();
                }
                else
                    ie.Link(Find.By(lnkAttributeName, lnkAttributeValue)).Click();
                Wxs.Instance.Log.Debug(
                    String.Format("Link {0}[{1}] clicked", lnkAttributeName, lnkAttributeValue));
            }
            catch (Exception e)
            {
                Wxs.Instance.Log.Error("Error Clicking Link : " + name, e);
            }
        }
    }
}
