using System;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    /// <summary>
    ///  Clicks on the specified HTML element 
    /// </summary>
    public class wxActClick : wxAction
    {
        /// <summary>
        /// Element Attribute Name 
        /// </summary>
        [XmlElement]
        public string elementAttributeName;
        /// <summary>
        /// Element Attribute Value 
        /// </summary>
        [XmlElement]
        public string elementAttributeValue;
        private ClickableType type;
        /// <summary>
        /// The type
        /// </summary>
        [XmlElement]
        public ClickableType Type
        {
            get { return type; }
            set { type = value; }
        }
        public wxActClick(string ActionName, string attributeToUse, string valueToUse, ClickableType theType)
            : base(ActionName)
        {
            elementAttributeName = attributeToUse;
            elementAttributeValue = valueToUse;
            Type = theType;
        }

        public wxActClick() : this("", "", "", ClickableType.Unknown) { }

        public override string ToString()
        {
            return String.Format("ClickAction  [{1}] : {0}", elementAttributeValue, type.ToString());
        }

        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                switch (type)
                {
                    case ClickableType.Radio:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.RadioButton(
                            Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.RadioButton(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Radio {0}[{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    case ClickableType.Check:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.CheckBox(Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.CheckBox(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Check Box {0}[{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    case ClickableType.Button:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.Button(
                                Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.Button(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Button {0}[{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    case ClickableType.TableCell:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.TableCell(
                                Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.TableCell(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Table cell {0}[{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    case ClickableType.Div:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.Div(
                                Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.Div(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Div: {0} [{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    case ClickableType.Image:
                        if (elementAttributeValue.Contains("*"))
                        {
                            elementAttributeValue = elementAttributeValue.Replace("*", String.Empty);
                            ie.Image(
                                Find.By(elementAttributeName, new Regex(elementAttributeValue))).Click();
                        }
                        else
                            ie.Image(
                                Find.By(elementAttributeName, elementAttributeValue)).Click();
                        Wxs.Instance.Log.Debug(
                            String.Format("Image {0} [{1}] clicked", elementAttributeName, elementAttributeValue));
                        break;
                    default:
                        Wxs.Instance.Log.Error("Could not execute click: type not set"); // Should I throw 
                        break;
                }
            }
            catch (WatiN.Core.Exceptions.ElementNotFoundException e)
            {
                Wxs.Instance.Log.Error(String.Format("Element not found error in test {0}", name), e);
                //throw (e);
            }
        }
    }
}