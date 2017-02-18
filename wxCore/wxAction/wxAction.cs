using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Action base class
    /// </summary>
    [XmlType]
    [XmlInclude(typeof(wxActSubmit))]
    [XmlInclude(typeof(wxActGoTo))]
    [XmlInclude(typeof(wxActText))]
    [XmlInclude(typeof(wxActSelect))]
    [XmlInclude(typeof(wxActFileUpload))]
    [XmlInclude(typeof(wxActLink))]
    [XmlInclude(typeof(wxActClick))]
    [XmlInclude(typeof(wxActWait))]
    [XmlInclude(typeof(wxActWaitUntil))]
    [XmlInclude(typeof(wxActGetTestInfo))]    
    public abstract class wxAction
    {
        public wxAction(string action_name)
        {
            name = action_name;
        }

        public wxAction () : this("") {}

        protected wxVerifier veryfier;

        public override string ToString()
        {
            return String.Format("Action {0}", name);
        }

        protected string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [Obsolete]
        public void SetVeryfier(wxVerifier v)
        {
            veryfier = v;
        }

        public abstract void Do(IE ie);
    }


   
  
}
