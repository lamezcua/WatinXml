using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// Test to wait for a condition to occur
    /// </summary>
    [XmlType(TypeName = "wxTsSpin")]
    public class wxTsSpin : wxTest
    {
        [XmlElement("Condition", typeof(wxVerifier))]
        public wxVerifier condition;

        [XmlAttribute]
        public int DelayInMs;

        public wxTsSpin(string the_name, int delay)
        {
            Name = the_name;
            DelayInMs = delay;
        }

        public wxTsSpin(string name) : this(name, 500) { }

        public wxTsSpin() : this("SpinTest", 500) { }

        /// <summary>
        /// Executes action(s) until condition is true, 
        /// then executes verifications
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
                while (!condition.Verify())
                {
                    foreach (wxAction action in Actions)
                        action.Do(Wxs.Instance.Ie);
                    System.Threading.Thread.Sleep(DelayInMs);
                }
                // Execute the common actions
                foreach (wxVerifier v in Verifications)
                {
                    if (!v.Verify())
                        result = false;
                }
            }
            catch (Exception e)
            {
                Wxs.Instance.Log.Error(e.Message, e);
                throw (e);
            }
            return result;
        }
    }
}
