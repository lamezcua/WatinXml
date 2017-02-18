using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{ 

    [XmlType(TypeName="wxPage")]
    public class wxPage : wxBasePage
    {
        public override void ExecuteTests()
        {
            //if ( Wxs.Instance.Ie.ContainsText
            Wxs.Instance.Log.InfoFormat("Page {0} started test execution", Name);
            DateTime stTime = DateTime.Now;
            foreach (wxTest test in Tests)
            {
                if (test.Test())
                    Wxs.Instance.Log.InfoFormat("Test {0} passed", test.Name);
                else
                    Wxs.Instance.Log.WarnFormat("Test {0} failed", test.Name);
            }
            TimeSpan ts = DateTime.Now - stTime;
            Wxs.Instance.Log.InfoFormat(
                "Finished page {0} test execution in {1} seconds", Name, ts.Seconds);
        }
    }
}
