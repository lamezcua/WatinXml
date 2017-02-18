using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WatiN.Core;

namespace CoreTest.WMDXmlWatin
{
    ///// <summary>
    ///// 
    ///// </summary>
    //public abstract class IeBaseAction
    //{
    //    protected IeBaseAction successor;


    //    public void SetSuccessor(IeBaseAction next)
    //    {
    //        successor = next;
    //    }

    //    public abstract void Do(IE ie);
    //    protected abstract object GetElement();
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public class IeSelect : IeBaseAction
    //{
    //    public string ElementName;
    //    public string SelectValue;
    //    public string SelectName;
        
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="ie"></param>
        
    //    public override void Do(IE ie)
    //    {
    //        if (SelectValue==String.Empty)
    //        {
    //            ie.SelectList(Find.ByName(ElementName))
    //                .Select(new Regex(SelectName, RegexOptions.IgnoreCase));
    //        }
    //        else
    //        {
    //            ie.SelectList(Find.ByName(ElementName)).SelectByValue(SelectValue);
    //        }            
    //    }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    protected override object GetElement()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public class IeFile : IeBaseAction
    //{
    //    public string fileName;
    //    public string ElementId;

    //    public override void Do(IE ie)
    //    {
    //        ie.FileUpload(Find.ById(ElementId)).Set(fileName);
    //    }

    //    protected override object GetElement()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public class IeAction : IeBaseAction
    //{
    //    public string attributeName;
    //    public string attributeValue;        
    //    public Element element;

    //    public IeAction(string attribute, string value, Element e)
    //    {
    //        attributeName = attribute;
    //        attributeValue = value;
    //        element = e;
    //    }

    //    public IeAction() : this("", "", null)  {  }

    //    public override void Do(IE ie)
    //    {            
    //        element.Click();
    //        //if (element is Button)
    //        //{
    //        //    Button b = element as Button;
    //        //    b.Click();
    //        //}
    //        //else if (element is CheckBox)
    //        //{
    //        //    CheckBox c = element as CheckBox;
    //        //    c.Click();
    //        //}
    //        //else if (element is RadioButton)
    //        //{
    //        //    RadioButton r = element as RadioButton;
    //        //    r.Click();
    //        //}
    //    }

    //    protected override object GetElement()
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //}
    ///// <summary>
    ///// 
    ///// </summary>
    //public class IeLink : IeBaseAction
    //{
    //    public string lnkAttributeName;
    //    public string lnkAttributeValue;

    //    public override void Do(IE ie)
    //    {
    //        ie.Link(Find.By(lnkAttributeName, lnkAttributeValue)).Click();
    //    }

    //    protected override object GetElement()
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //}
}
