using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace wxCore
{
    public static class WxFactory
    {
        /// <summary>
        /// Returns an action: parses the element and returns the marching 
        /// wxAction 
        /// </summary>
        /// <param name="inputElement">The input element to parse</param>
        /// <returns> The wxAction that matches the input html element or 
        /// null if no match can be established
        /// </returns>
        public static wxAction GetWxAction(HtmlElement inputElement)
        {
            string identifier = "";
            string value = "";        
            if (!String.IsNullOrEmpty(inputElement.Name.Trim()))
            {
                identifier = "name";
                value = inputElement.Name;
            }
            else if (inputElement.Id != null)
            {
                identifier = "id";
                value = inputElement.Id;
            }
            else
                identifier = String.Empty;
            // Now return the right type of action 
            switch (inputElement.TagName)
            {
                case "INPUT":
                    if (inputElement.OuterHtml.Contains("type=checkbox")) // Capture CheckBoxes
                        return GetCheckBox(inputElement, identifier, value);
                    else if (inputElement.OuterHtml.Contains("type=radio")) // Capture Radios
                        return GetRadio(inputElement, identifier, value);
                    else if ((inputElement.OuterHtml.Contains("type=image")) ||
                     (inputElement.OuterHtml.Contains("type=button")) ||
                     (inputElement.OuterHtml.Contains("type=submit")))
                        return GetButton(inputElement, identifier, value);
                    else
                        return GetText(inputElement, identifier, value);
                case "SELECT":
                    return GetSelectAction(inputElement, identifier, value);
                case "A":
                    return GetLink(inputElement, identifier, value);
                default:
                    return null;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputElement"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetText(HtmlElement inputElement, string identifier, string value)
        {
            int a = 1;
            HTMLInputElementClass iElement = inputElement.DomElement as HTMLInputElementClass;		
            if (iElement.type =="hidden")
                return null;
            if (iElement.readOnly == true)
                a = 2;
            string valueToSet = String.Empty;
            if (iElement.IHTMLInputElement_value != null)
                valueToSet = iElement.IHTMLInputElement_value;
            return new wxActText("", identifier, value, valueToSet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputElement"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetLink(HtmlElement inputElement, string identifier, string value)
        {
            string name="Captured Link";
            HTMLAnchorElement iElement = inputElement.DomElement as HTMLAnchorElement;
            if (inputElement.OuterHtml.Contains("wmPopupOpen"))
                name = "PopUp LINK";
            //if (iElement.target == null)
            //    return null;
            if (identifier == String.Empty)
            {
                identifier = "innertext";
                value = inputElement.InnerText;
            }
            return new wxActLink("", identifier, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputElement"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetSelectAction(HtmlElement inputElement, string identifier, string value)
        {
            string valueToSet = String.Empty;
            string[] splt = inputElement.InnerHtml.Split(new string[] { "<OPTION", "</OPTION>" }
                                    , StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splt)
            {
                string[] spt2 = s.Split(new char[] { '>' });
                if (spt2.Length == 2)
                {                    
                    if (spt2[0].Contains("elected"))
                        valueToSet = spt2[1];
                }
            }
            return new wxActSelect("CapturedAction", identifier, value, valueToSet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetButton(HtmlElement element, string identifier, string value)
        {
            if (identifier == String.Empty)
            {
                HTMLInputElementClass iElement = element.DomElement as HTMLInputElementClass;
                if (iElement.src != null)
                {
                    identifier = "src";
                    value = iElement.src;
                }
                else
                    return null; // we give up: no name, nor id nor src
            }
            return new wxActClick("Capt Button", identifier, value, ClickableType.Button);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetRadio(HtmlElement element, string identifier, string value)
        {
            if (identifier == String.Empty)
            {
                HTMLInputElementClass iElement = element.DomElement as HTMLInputElementClass;
                //if (iElement != null)
                //    isChecked = iElement.IHTMLOptionButtonElement_status;
                //else
                //    isChecked = false; // TODO Does this make sense?
            }
            return new wxActClick("Radio", identifier, value, ClickableType.Radio);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static wxAction GetCheckBox(HtmlElement element, string identifier, string value)
        {
            if (identifier == String.Empty)
            {
                HTMLInputElementClass iElement = element.DomElement as HTMLInputElementClass;
                identifier = "";

            }
            return new wxActClick("", identifier, value, ClickableType.Check);

        }
    }
}