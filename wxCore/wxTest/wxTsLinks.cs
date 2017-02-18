using System;
using System.Collections.Generic;
using WatiN.Core;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// This tests all the popup type links (like in registration page reg3.aspx)
    /// not veryu general and will likely be killed
    /// 
    /// </summary>
    [XmlType(TypeName = "LinkTest")]
    public class wxTsLinks : wxTest
    {
        private List<Link> pageLinks = new List<Link>();
        public wxTsLinks(string the_name)
        {
            Name = the_name;
            popUpIdentifier = "wmPopupOpen"; // default value for popups
        }

        public wxTsLinks() : this("") { }

        private string popUpIdentifier;
        [XmlElement]
        public string PopUpIdentifier
        {
            get { return popUpIdentifier; }
            set { popUpIdentifier = value; }
        }

        public override bool Test()
        {
            bool result = true;
            try
            {
                Wxs.Instance.Log.Info(String.Format("Start all links verification on page" + Wxs.Instance.Ie.Url));
                foreach (Link link in Wxs.Instance.Ie.Links)
                {
                    Wxs.Instance.Log.Info(String.Format("Clicked on {0}",link));
                    link.Click();
                    if (!link.OuterHtml.Contains(popUpIdentifier))
                        Wxs.Instance.Ie.Back();
                }
            }
            catch(Exception e)
            {
                Wxs.Instance.Log.Error(e.Message, e);
                throw (e);
            }
            return result;
        }
    }
}
