using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// Verify that the page title contains specified text
    /// </summary>
    [XmlType]
    [Serializable]
    public class wxVfTitle : wxVerifier
    {
        public wxVfTitle() : this("", "") { }

        public wxVfTitle(string test_name, string validation_text)

            : base(test_name, validation_text)
        { }


        public override bool Verify()
        {
            try
            {
                if (Wxs.Instance.Ie.Title.Contains(Text))
                {
                    Wxs.Instance.Log.InfoFormat("Test Title [{0}]: passed : {1} found!", Name, Text);
                    return true;
                }
                else
                {
                    Wxs.Instance.Log.WarnFormat("Test Title [{0}]: failed : {1} not found!", Name, Text);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Wxs.Instance.Log.ErrorFormat("Error: Exception {0} thrown executing Test Title {1}!", ex.Message, Name);
                return false;
            }
        }
    }
}