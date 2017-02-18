using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Verifies a pop up exists and that contains certain text
    /// </summary>
    [XmlType]
    public class wxVfPopUp : wxVerifier
    {
        private string title;
        [XmlAttribute]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
     
        public wxVfPopUp() : this("", "","") { }

        public wxVfPopUp(string name, string popTitle, string popText)
            : base(name, popText)
        {
            title = popTitle;
        }

        public override bool Verify()
        {
            bool retValue = false;
            try
            {
                IE iepop = IE.AttachToIE(Find.ByTitle(new Regex(title)));
                if (iepop.ContainsText(Text))
                {
                    Wxs.Instance.Log.InfoFormat("Test : {0} passed", Text);
                    retValue = true;
                }
                else
                {
                    Wxs.Instance.Log.WarnFormat("Test : {0} failed", Text);
                }
                iepop.Close();
            }
            catch (Exception ex)
            {
                Wxs.Instance.Log.ErrorFormat("Error: Exception {0} thrown executing Popup Test {1}!", ex.Message, Name);
                return false;
            }
            return retValue;
        }
    }
}
