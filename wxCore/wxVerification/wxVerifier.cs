using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// Verifier base class 
    /// </summary>
    [XmlType]
    [XmlInclude(typeof(wxVfDb))]
    [XmlInclude(typeof(wxVfPopUp))]
    [XmlInclude(typeof(wxVfText))]
    [XmlInclude(typeof(wxVfTitle))]
    [Serializable]
    public abstract class wxVerifier
    {
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// The text to verify
        /// </summary>
        private string text;
        [XmlElement]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public wxVerifier() : this("", "") { }

        public wxVerifier(string theName, string textToVerify)
        {
            name = theName;
            text = textToVerify;
        }

        public override string ToString()
        {
            return String.Format("Verification \"{0}\"", name);
        }
        /// <summary>
        /// The main method to be implemented by the derived classes
        /// </summary>
        /// <returns></returns>
        /// 
        //[Test] TODO: Implement the NuNIt
        public abstract bool Verify();
    }
}
