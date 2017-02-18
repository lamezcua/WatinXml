using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxCore;
using System.Windows.Forms;

namespace wxRecorder
{
    internal class RecordedScenario
    {
        wxScenario scenario;
        wxPage currentPage;
        wxTsSimple currentTest;

        internal RecordedScenario()
        {
            //scenario = new wxScenario();
            //currentPage = new wxPage();
            //currentTest = new wxTsSimple();

        }

        /// <summary>
        /// called when we start a new recording
        /// </summary>
        /// <param name="HtmlPage"></param>
        internal bool Initialize(HtmlDocument HtmlPage)
        {
            currentPage = new wxPage();
            currentPage.Name = "First Auto-Page";
            currentTest = new wxTsSimple("Automatic test");
            scenario = new wxScenario();
            if (HtmlPage != null)
            {
                string name = String.Format("Scenario Recorded on {0}", DateTime.Now.ToLongTimeString());
                scenario = new wxScenario();
                scenario.Name = String.Format("Page {0} captured on ", HtmlPage.Title, DateTime.Now.ToString("R"));
                scenario.StartUrl = HtmlPage.Url.ToString();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds an action to global test (inside global page)
        /// </summary>
        /// <param name="element"></param>
        internal void AddAction(HtmlElement element)
        {
            wxAction action = WxFactory.GetWxAction(element);
            if (action != null)
                currentTest.AddAction(action);
        }

        internal void Completed(HtmlDocument htmlDocument)
        {
            currentPage.AddTest(currentTest);
            currentTest = new wxTsSimple("Next Test");
        }
    }
}
            
