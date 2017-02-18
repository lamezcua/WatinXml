using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Submits the first form of the document
    /// </summary>
    public class wxActSubmit : wxAction
    {
        public wxActSubmit(string ActionName)
            : base(ActionName)
        {

        }

        public wxActSubmit() : this("") { }

        public override string ToString()
        {
            return ("SubmitForm Action");
        }
        
        /// <summary>
        /// Submits the first form of the document
        /// </summary>
        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                Wxs.Instance.Ie.Forms[0].Submit();
                Wxs.Instance.Log.Debug("First Form submitted");
            }
            catch
            {
                Wxs.Instance.Log.Error("Error submitting first form : ");
                throw;
            }
        }
    }
}
