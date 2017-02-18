using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    /// <summary>
    /// Select value using index or a value (REGEX)
    /// </summary>
    public class wxActSelect : wxAction
    {
        [XmlElement]
        public string attributeName;
        [XmlElement]
        public string attributeValue;
        [XmlElement]
        public string valueToSet;

        [XmlElement] private readonly int selectIndex = -1;

        public wxActSelect(string actionName, string AttributeName, string AttributeValue, string ValueToSet)
            : base(actionName)
        {
            attributeValue = AttributeValue;
            attributeName = AttributeName;
            valueToSet = ValueToSet;
        }

        

        public wxActSelect(string actionName, string AttributeName, string AttributeValue, int indexToChoose)
            : base(actionName)
        {
            attributeValue = AttributeValue;
            attributeName = AttributeName;
            valueToSet = String.Empty;
            selectIndex = indexToChoose;
        }

        public wxActSelect(string actionName, string AttributeName, string AttributeValue)
            : this(actionName, AttributeName, AttributeValue, -1)
        {
        }


        public wxActSelect() : this("", "", "", "") { }

        public override string ToString()
        {
            if (valueToSet == String.Empty) // Use index
                return String.Format("SelectAction index : {0}", selectIndex);
            else
                return String.Format("SelectAction value : {0}", valueToSet);
        }

        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                if (valueToSet == String.Empty) // Use index
                {
                    SelectList s = ie.SelectList(Find.By(attributeName, attributeValue));
                    System.Collections.Specialized.StringCollection contents = s.AllContents;
                    if (selectIndex >= 0)
                    {
                        if ((selectIndex >= 0) || (contents.Count > selectIndex))
                        {
                            s.Select(contents[selectIndex]);
                        }
                        else
                        {
                            throw new IndexOutOfRangeException(
                                String.Format(
                                    "Unable to set the select action {0} to value {1}, only {2} values available",
                                    attributeValue, selectIndex, contents.Count));
                        }
                    }
                    else // Select last if index is negative  the default
                    {
                        s.Select(contents[contents.Count - 1]);
                    }
                }
                // locate the select box using the element id and pick the select value
                else
                {
                    if (attributeValue.Contains("*"))
                    {
                        attributeValue = attributeValue.Replace("*", String.Empty);
                        if (valueToSet.Contains("*"))
                        {
                            valueToSet = valueToSet.Replace("*", String.Empty);
                            ie.SelectList(Find.By(attributeName,
                                new Regex(attributeValue))).Select(new Regex(valueToSet));
                        }
                        else
                        {
                            ie.SelectList(Find.By(attributeName,
                                new Regex(attributeValue))).Select(valueToSet);
                        }
                    }
                    if (valueToSet.Contains("*"))
                    {
                        valueToSet = valueToSet.Replace("*", String.Empty);
                        ie.SelectList(Find.By(attributeName, attributeValue)).Select(new Regex(valueToSet));
                    }
                    else
                        ie.SelectList(Find.By(attributeName, attributeValue)).Select(valueToSet);
                }
            }
            catch (Exception e)
            {
                Wxs.Instance.Log.Error("Error On Select list action", e);
                throw;
            }
        }
    }
}