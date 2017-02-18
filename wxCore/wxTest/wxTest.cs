using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Base class for browser tests
    /// </summary>
    [XmlType]   
    [XmlInclude(typeof(wxTsSimple))]
    [XmlInclude(typeof(wxTsPop))]
    [XmlInclude(typeof(wxTsSpin))]
    [XmlInclude(typeof(wxTsConditional))]
    [XmlInclude(typeof(wxTsQuestionnaire))]
    public abstract class wxTest
    {
        /// <summary>
        /// Parametrized constructor, passes the TestName
        /// </summary>
        /// <param name="testName"></param>
        public wxTest(string testName)
        {
            name = testName;
            verifications = new List<wxVerifier>();
            actions = new List<wxAction>();
        }

        public wxTest() : this("") { }
                
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        List<wxAction> actions;
        [XmlElement("Action", typeof(wxAction))]
        public List<wxAction> Actions
        {
            get { return actions; }
            set { actions = value; }
        }
        
        List<wxVerifier> verifications;
        [XmlElement("Verification", typeof(wxVerifier))]
        public List<wxVerifier> Verifications
        {
            get { return verifications; }
            set { verifications = value; }
        }

        public override string ToString()
        {
            return string.Format("Test \"{0}\"", name);
        }

        //protected wxTest successor;
        /// <summary>
        /// Adds an action to the action list to execute
        /// </summary>
        /// <param name="action"></param>
        public void AddAction(wxAction action)
        {
            actions.Add(action);
        }
        /// <summary>
        /// Adds a verifier to list execute 
        /// </summary>
        /// <param name="verifier"></param>
        public void AddVerifier(wxVerifier verifier)
        {
            verifications.Add(verifier);
        }

        /// <summary>
        /// Abstract method to be overriden by derived classes
        /// </summary>
        /// <returns></returns>
        public abstract bool Test();
    }    
}
