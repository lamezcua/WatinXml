using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace wxCore
{
    public static class WxSerialize
    {
        /// <summary>
        /// Deserializes an xml file in to a Test wxTestPage object
        /// </summary>
        /// <param name="fname">The source file</param>
        /// <returns>The Scenario object</returns>
        public static wxBasePage DeserializePage(string fname)
        {
            XmlSerializer x = new XmlSerializer(typeof(wxBasePage));
            wxBasePage page;
            using (TextReader t = new StreamReader(fname))
            {
                page = (wxPage)x.Deserialize(t);
            }
            return page;
        }
        /// <summary>
        /// Deserializes an xml file in to a scenario object
        /// </summary>
        /// <param name="fname">The source file</param>
        /// <returns>The Scenario object</returns>
        public static wxScenario DeserializeScenario(string fname)
        {
            XmlSerializer x = new XmlSerializer(typeof(wxScenario));
            wxScenario sTest;
            using (TextReader t = new StreamReader(fname))
            {
                sTest = (wxScenario)x.Deserialize(t);
            }
            return sTest;
        }
        /// <summary>
        ///  Serializes a Scenario object into an XML file
        /// </summary>
        /// <param name="filename">The output file</param>
        /// <param name="scenario">Object source </param>
        public static void Serialize(string filename, wxScenario scenario)
        {
            XmlSerializer x = new XmlSerializer(typeof(wxScenario));
            using (TextWriter writer = new StreamWriter(filename))
            {
                x.Serialize(writer, scenario);
            }
        }
        /// <summary>
        ///  Serializes a basePage object into an XML file
        /// </summary>
        /// <param name="filename">Output file</param>
        /// <param name="page">The object to serialize</param>
        public static void Serialize(string filename, wxBasePage page)
        {
            XmlSerializer x = new XmlSerializer(typeof(wxBasePage));
            using (TextWriter writer = new StreamWriter(filename))
            {
                x.Serialize(writer, page);
            }
        }
    }
}
