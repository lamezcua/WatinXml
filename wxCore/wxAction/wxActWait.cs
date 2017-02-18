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
    public class wxActWait : wxAction
    {
        /// <summary>
        /// The number of seconds to wait. If less than one it will use the 
        /// condition
        /// </summary>
        [XmlElement]
        public int waitSeconds;
        /// <summary>
        ///  The timeout. Defaults to 30 seconds. It waits until the condition 
        /// to be true, or times out.
        /// </summary>
        [XmlElement]
        public int timeOut;

        public wxActWait() : this("", 1) { }

        public wxActWait(string name, int secondsToWait)
            : base(name)
        {
            waitSeconds = secondsToWait;
            timeOut = 30; // the deafult timeout
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("wxActWait {0} seconds ", waitSeconds);
        }

        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            if (waitSeconds != 0)
                System.Threading.Thread.Sleep(waitSeconds * 1000);
            else
            {
                if (veryfier == null)
                {
                    throw new ApplicationException("No verifier was defined");
                }
                int counter = 0;
                while (!veryfier.Verify())
                {
                    System.Threading.Thread.Sleep(1000);
                    if (++counter >= timeOut)
                    {
                        break;
                    }
                }
            }
        }
    }
}