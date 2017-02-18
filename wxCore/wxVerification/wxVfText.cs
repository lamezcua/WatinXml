using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Verifies certain text exists on the page 
    /// </summary>
    [XmlType]
    [Serializable]
    public class wxVfText : wxVerifier
    {
        public wxVfText() : this("", "") { }


        public wxVfText(string test_name, string validation_text)
            : base(test_name,validation_text)
        {}

  
        public override bool Verify()
        {
            try
            {
                if (Wxs.Instance.Ie.ContainsText(Text))
                {
                    Wxs.Instance.Log.InfoFormat("Test Text [{0}]: passed : {1} found!", Name, Text);
                    return true;
                }
                else
                {
                    Wxs.Instance.Log.WarnFormat("Test Text [{0}]: failed : {1} not found!", Name, Text);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Wxs.Instance.Log.ErrorFormat("Error: Exception {0} thrown executing Text Test {1}!", ex.Message, Name);
                return false;
            }
        }
    }
}
