using System;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    /// <summary>
    /// Inputs text on a control whose property 'attributeToUse'
    /// is set to 'attributeValue' (both of them must match)
    /// </summary>
    public class wxActText : wxAction
    {
        /// <summary>
        /// The name of attribute used to locate element
        /// </summary>
        [XmlElement]
        public string txtAttributeName;  
        /// <summary>
        /// The value that the attribute is set to 
        /// </summary>
        [XmlElement]
        public string txtAttributeValue;
        [XmlElement]
        public string text;
        
        
        public wxActText(string ActionName, string attributeName, string attributeValue, string inputText) 
            : base(ActionName)
        {
            txtAttributeValue = attributeValue;
            txtAttributeName = attributeName;
            text = inputText;
        }

        public wxActText() : this("", "", "","") { }

        public override string ToString()
        {
            return String.Format("TextAction {0}: ", text);
        }


        /// <summary>
        /// Method invoked from the TestContainer [IeTest]
        /// Finds the text field and inputs the value
        /// </summary>
        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                if (txtAttributeValue.Contains("*"))
                {
                    txtAttributeValue = txtAttributeValue.Replace("*", String.Empty);
                    ie.TextField(Find.By(txtAttributeName,
                        new Regex(txtAttributeValue, RegexOptions.IgnoreCase))).TypeText(text);
                }
                else
                    ie.TextField(Find.By(txtAttributeName, txtAttributeValue)).TypeText(text);
                Wxs.Instance.Log.Debug(
                    String.Format("Text {0} entered on element {1}", text, txtAttributeName));
            }
            catch (WatiN.Core.Exceptions.ElementNotFoundException e)
            {
                Wxs.Instance.Log.Error(String.Format("Element not found error in text input {0}", name), e);
                throw;
            }
            catch (Exception genEx)
            {
                Wxs.Instance.Log.Error(genEx.Message, genEx);
            }
        }
    }
}