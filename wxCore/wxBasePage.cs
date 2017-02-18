using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    [XmlType]
    [XmlInclude(typeof(wxPage))]
    public abstract class wxBasePage
    {
        // The method to override
        public abstract void ExecuteTests();

        protected string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// The test list
        /// </summary>        
        List<wxTest> tests = new List<wxTest>();
        [XmlElement("Test", typeof(wxTest))]
        public List<wxTest> Tests
        {
            get { return tests; }
            set { tests = value; }
        }
        /// <summary>
        /// Adds a test to test list
        /// </summary>
        /// <param name="test"></param>
        public void AddTest(wxTest test)
        {
            tests.Add(test);
        }
        /// <summary>
        /// Inserts a test on a particular position in the list
        /// </summary>
        /// <param name="test">The test to be inserted </param>
        /// <param name="zeroIndexPosition">The position (negative or positive)</param>
        /// <returns>true if sucess</returns>
        public bool InsertTest(wxTest test, int zeroIndexPosition)
        {
            if (Math.Abs(zeroIndexPosition) > tests.Count)
            {
                Wxs.Instance.Log.ErrorFormat("Error inserting test on position {0}: test count is {1}",
                    zeroIndexPosition, tests.Count);
                return false;
                //throw new IndexOutOfRangeException("Cannot insert test beyond capacity");
            }
            if (zeroIndexPosition < 0) // allow negative index insertions (like python)
                tests.Insert(tests.Count + zeroIndexPosition, test);
            else
                tests.Insert(zeroIndexPosition, test);
            return true;
        }
        /// <summary>
        /// Ie dependent skip method
        /// </summary>
        protected void SkipCertError()
        {
            if (Wxs.Instance.Ie.Title.Contains("Certificate Error"))
            {
                Wxs.Instance.Log.Debug("Skipping certificate error page");
                Wxs.Instance.Ie.Link(WatiN.Core.Find.ByName("overridelink")).Click();
            }
        }

    }
}
