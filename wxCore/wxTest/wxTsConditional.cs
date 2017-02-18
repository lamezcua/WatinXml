using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// Executes the actions (1:n) on the list if the condtion is true
    /// If the condition returns false, skips the actions 
    /// The common actions (if any) are executed regardless. 
    /// After the common actions executes the verifiers (if any)
    /// </summary>
    [XmlType(TypeName = "wxTsConditional")]
    public class wxTsConditional : wxTest
    {
        [XmlElement("CommonActions", typeof(wxAction))]
        public List<wxAction> commonActions;
        [XmlElement("Condition", typeof(wxVerifier))]
        public wxVerifier condition;

        public wxTsConditional(string the_name)
        {
            Name = the_name;
            commonActions = new List<wxAction>();
        }

        public wxTsConditional() : this("") { }

        /// <summary>
        /// Executes the actions on the action list and then 
        /// the verifications on the verification list
        /// </summary>
        /// <returns>True if ALL the verifications pass</returns>
        public override bool Test()
        {
            if (Actions.Count == 0)
            {
                string message = "Action list cannot be empty";
                Wxs.Instance.Log.Error("Error on wxTsConditional " + Name + " -> " + message);
                throw new ArgumentNullException(message);
            }
            if (condition == null)
            {
                string message = "Condition cannot be empty";
                Wxs.Instance.Log.Error("Error on wxTsConditional " + Name + " -> " + message);
                throw new ArgumentNullException(message);
            }
            bool result = true;
            try
            {
                if (condition.Verify())
                {
                    Wxs.Instance.Log.InfoFormat("Condition [{0}] found!", condition.Name);
                    foreach (wxAction action in Actions)
                    {
                        action.Do(Wxs.Instance.Ie);
                    }
                }
                // Execute the common actions
                if (commonActions.Count > 0)
                {
                    foreach (wxAction altAction in commonActions)
                    {
                        altAction.Do(Wxs.Instance.Ie);
                    }
                }
                foreach (wxVerifier v in Verifications)
                {
                    if (!v.Verify())
                        result = false;
                }
            }
            catch (Exception e)
            {
                Wxs.Instance.Log.Error(e.Message, e);
                //throw (e);
            }
            return result;
        }
    }
}
