using System;
using System.Xml.Serialization;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace wxCore
{
    /// <summary>
    /// Waits the number of seconds defined, 
    /// if zero it waits until the verification
    /// is true (waits for a condition)
    /// </summary>
    public class wxActWaitUntil : wxAction
    {
        /// <summary>
        /// The number of seconds to wait. If less than one it will use the 
        /// condition
        /// </summary>
        [XmlElement]
        public string condition;

        [XmlElement]
        public int timeOut;

        public wxActWaitUntil() : this("", "") { }

        public wxActWaitUntil(string name, string conditionToWaitFor)
            : base(name)
        {
            condition = conditionToWaitFor;
            timeOut = 30; // Timeout in seconds
        }

        public override string ToString()
        {
            return String.Format("wxActWaitUntil {0} ", condition);
        }

        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            int numCycles = 0;
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                if (ie.ContainsText(condition))
                {
                    return;
                }
                if (numCycles > timeOut * 2) // convert to seconds
                {
                    string message = string.Format("Timeout ({1} s) reached, condition {0} not met",
                        condition, timeOut);
                    Wxs.Instance.Log.Error(message);
                    throw new ApplicationException(message);
                }
            }
        }
    }
}
