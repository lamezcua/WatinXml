using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using WatiN.Core;

namespace wxCore
{
    /// <summary>
    /// Drives the Specified File Upload html element 
    /// </summary>
    public class wxActFileUpload : wxAction
    {
        /// <summary>
        /// The name of the file to upload
        /// </summary>
        [XmlElement]        
        public string fileName;
        /// <summary>
        /// The ID of the FILE element to use
        /// </summary>
        [XmlElement]
        public string elementId;

        public wxActFileUpload(string theName, string fileUploadId, string FileName) : base(theName)
        {
            elementId = fileUploadId;
            fileName = FileName;
        }

        public wxActFileUpload():this("","","") { }

        public override string ToString()
        {
            return String.Format("FileUpload : {0}", fileName);
        }
        
        /// <summary>
        /// This is different, you must provide the element id
        /// </summary>
        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            try
            {
                WatiN.Core.FileUpload fi = ie.FileUpload(Find.ById(elementId));
                fi.Set(fileName);
                fi.Click();
                Wxs.Instance.Log.Debug(
                    String.Format("File [{0}] uploaded with uploader [{1}]", fileName, elementId));
            }
            catch (Exception e)
            {
                Wxs.Instance.Log.Error("Error on FileUpload : " + name, e);
            }
        }
    }
}