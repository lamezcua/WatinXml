using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using WatiN.Core.Interfaces;
using System.Xml.Serialization;
using log4net;

namespace wxCore
{
    /// <summary>
    /// Scenario to test: contains a list of wxPages
    /// </summary>
    public class wxScenario
    {
        #region class members
        
        string startUrl;
        [XmlAttribute]
        public string StartUrl
        {
            get { return startUrl; }
            set
            {
                //Uri u = new Uri(startUrl);
                startUrl = value;
            }
        }

        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string connString;
        [XmlElement]
        public string ConnectionString
        {
            get { return connString; }
            set { connString = value; }
        }        
        /// <summary>
        /// The list of pages to test
        /// </summary>
        List<wxBasePage> pages = new List<wxBasePage>();
        [XmlElement("wxPage", typeof(wxBasePage))]
        public List<wxBasePage> Pages
        {
            get { return pages; }
            set { pages = value; }
        }

        #endregion

        #region constructors

        public wxScenario() : this("", "", "") { }
        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="scenarioName">The name</param>
        /// <param name="theStartPage">Url to start with</param>
        public wxScenario(string scenarioName, string theStartPage, string connectionString)
        {
            Name = scenarioName;
            StartUrl = theStartPage;
            ConnectionString = connectionString;
            pages = new List<wxBasePage>();
            if (name == String.Empty)
                Wxs.Instance.Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            else
                Wxs.Instance.Log = LogManager.GetLogger(name);
            log4net.Config.XmlConfigurator.Configure();
            Wxs.Instance.ConnectionString = connString;
            
        }

        #endregion
        
        /// <summary>
        /// Main method, invokes every page to execute her tests
        /// </summary>
        public void TestPages()
        {
            using (IBrowser ie = BrowserFactory.Create(BrowserType.InternetExplorer))
            {
                Wxs.Instance.Ie = (WatiN.Core.IE)ie;
                Wxs.Instance.Ie.GoTo(startUrl);
                // IE7 dependent function!!!
                SkipCertErrorIE7();
                
                foreach (wxPage page in pages)
                {
                    try
                    {
                        page.ExecuteTests();
                    }
                    catch (Exception ex)
                    {
                        Wxs.Instance.Log.ErrorFormat("Error testing page {0}:\n{1}", page.Name, ex.Message);
                    }                   
                }
            }
            Wxs.Instance.Ie.Close();
        }
        /// <summary>
        /// IE Specific method to skip certificate error found in our test and 
        /// staging environments 
        /// </summary>
        private void SkipCertErrorIE7()
        {
            if (Wxs.Instance.Ie.Title.Contains("Certificate Error"))
            {
                Wxs.Instance.Log.Debug("Skipping certificate error page");
                Wxs.Instance.Ie.Link(Find.ByName("overridelink")).Click();
            }
        }


    }
}
