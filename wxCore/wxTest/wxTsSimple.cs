using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// A simple test class, executes all the actions (1:n) on the list 
    /// then executes the verifiers (0:n)
    /// </summary>
    [XmlType (TypeName = "wxTsSimple")]
    public class wxTsSimple : wxTest
    {

        public wxTsSimple(string the_name)
        {
            Name = the_name;            
        }

        public wxTsSimple() : this("") { }

        /// <summary>
        /// Executes the actions on the action list and then 
        /// the verifications on the verification list
        /// </summary>
        /// <returns>True if ALL the verifications pass</returns>
        public override bool Test()
        {
            if (Actions.Count == 0 )
            {
                Wxs.Instance.Log.Error("Test withouth valid actions!");
                throw new ArgumentNullException("Action list cannot be empty");
            }
            bool result = true;
            try
            {
                DateTime stTime = DateTime.Now;
                foreach (wxAction action in Actions)
                {
                    action.Do(Wxs.Instance.Ie);  
                }
                Wxs.Instance.Log.WarnFormat("Actions executed on {0:N}ms", (DateTime.Now - stTime).TotalMilliseconds);
                foreach (wxVerifier v in Verifications)
                {
                    if (!v.Verify())
                    {
                        result = false;
                        Wxs.Instance.Log.WarnFormat("Verification {0} failed on test {1}", v.ToString(), Name);
                    }
                }
            }
            catch(Exception e)
            {
                Wxs.Instance.Log.Error(e.Message, e);
                throw (e);
            }
            return result;
        }
    }
}
