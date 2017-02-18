using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Goes to specified url
    /// </summary>
    public class wxActGoTo : wxAction
    {
        /// <summary>
        /// The url to go to
        /// </summary>
        [XmlElement]
        public string url;

        public wxActGoTo(string ActionName, string urlToGo)
            : base(ActionName)
        {
            url = urlToGo;
        }

        public override string ToString()
        {
            return String.Format("GoToAction : {0}", url);
        }
        
        public wxActGoTo() : this("", "") { }
        /// <summary>
        /// Sends the Browser to the specified url, if url does not start with 
        /// http, it sends to BaseUrl + "/" + url
        /// </summary>
        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            string fullUrl;
            if (url.StartsWith("http"))
                fullUrl = url;
            else
                fullUrl = Wxs.Instance.BaseUrl + "/" + url; // Relative path (relative to baseurl)

            try
            {
                ie.GoTo(fullUrl);
                Wxs.Instance.Log.Debug(
                    String.Format("GoTo wxTestPage {0} action executed", fullUrl));
            }
            catch
            {
                Wxs.Instance.Log.Error("Error going to page : " + fullUrl);
                throw;
            }
            
        }
    }
}
