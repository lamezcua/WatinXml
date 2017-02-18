using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    [XmlType(TypeName = "wxTsPop")]
    public class wxTsPop : wxTest
    {
        [XmlElement("PopAction", typeof(wxAction))]
        public wxAction popAction;
        //[XmlAttribute]
        //public string identifierType;
        //[XmlAttribute]
        //public string identifierValue;
        [XmlAttribute]
        public string UrlValue;

        public wxTsPop(string the_name, string urlToSearch)
        {
            Name = the_name;
            UrlValue = urlToSearch;
            //this.identifierType = identifierType;
            //this.identifierValue = identifierValue;
        }

        public wxTsPop() : this("", "") { }

        public override bool Test()
        {
            if (popAction == null)
                throw new ApplicationException("Popup action cannot be empty");
            if (Actions.Count < 1)
                throw new ApplicationException("Action list cannot be empty");
            bool retValue = true;
            IE iepop;
            try
            {
                popAction.Do(Wxs.Instance.Ie);
                if (UrlValue.Contains("*"))
                    iepop = IE.AttachToIE(Find.ByUrl(new Regex(UrlValue.Replace("*", String.Empty))));
                else
                    iepop = IE.AttachToIE(Find.ByUrl(UrlValue));
                Wxs.Instance.Log.InfoFormat("Attached to it! {0}", iepop.Text);
                foreach (wxAction action in Actions)
                {
                    action.Do(iepop);
                }
                foreach (wxVerifier ver in Verifications)
                {
                    if (ver.Verify())
                        Wxs.Instance.Log.InfoFormat("Verification {0} passed", ver.Name);
                    else
                    {
                        retValue = false;
                        Wxs.Instance.Log.WarnFormat("Verification {0} failed!", ver.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Wxs.Instance.Log.ErrorFormat("Error on PopTest {0}: {1}", Name, ex.Message);
                return false;
            }
            iepop.Close();
            return retValue;
        }
    }
}
