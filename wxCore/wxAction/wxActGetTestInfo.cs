using System;
using System.Collections.Generic;
using System.Text;
using WatiN.Core;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// navigates to test page and gathers the data from that page
    /// names the file as follows: PATH\spid_UserName.txt
    /// where path is an attribute. Defaults to C:\\
    /// </summary>
    public class wxActGetTestInfo : wxAction
    {
        string path;
        [XmlAttribute]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie">The navigator to operate</param>
        public override void Do(IE ie)
        {
            if (ie == null)
                ie = Wxs.Instance.Ie;
            if ((path == null) || (path == String.Empty))
                path = "C:\\";
            string[] splt = ie.Url.Split(new char[] { '/' });
            if (splt.Length < 3)
                throw new ApplicationException("Invalid url to retrive test page");
            ie.GoTo(splt[0] + "//" + splt[2] + "/test.aspx");
            if (ie.ContainsText("Session State"))
            {
                Dictionary<String, String> valuesToSave = new Dictionary<string, string>();
                string[] lines = ie.Text.Split(new char[] { '\n' });
                foreach (string line in lines)
                {
                    string[] splLine = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (splLine.Length == 2)
                    {
                        string key = splLine[0].Replace("+", String.Empty);
                        key = key.Replace("|", " ").Trim();
                        string value = splLine[1].Trim();
                        if (!valuesToSave.ContainsKey(key))
                            valuesToSave.Add(key, value);
                    }
                }
                string fileName;
                if ((valuesToSave.ContainsKey("UserName")) & valuesToSave.ContainsKey("SponsorID"))
                    fileName = String.Format("{0}\\{2}_{1}.txt", path, valuesToSave["UserName"], valuesToSave["SponsorID"]);
                else if (valuesToSave.ContainsKey("PersonID"))
                    fileName = String.Format("{0}\\{1}.txt", path, valuesToSave["PersonID"]);
                else
                    fileName = String.Format("{0}\\{1}.txt", path, Name);
                Wxs.Instance.Log.InfoFormat("Saving test page results to file : {0}", fileName);
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("Test executed on {0}", DateTime.Now.ToString("g"));
                    sw.WriteLine("On : {0}\n\t\t***************", Wxs.Instance.Ie.Url);
                    foreach (KeyValuePair<string, string> kvp in valuesToSave)
                        sw.WriteLine(kvp.Key + " = " + kvp.Value);

                }
                ie.Back();
            }

            else
            {
                Wxs.Instance.Log.Error("Test page not available?");
            }
        }
    }
}
