using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxCore;
using System.Windows.Forms;

namespace wxRecorder.wxHtml
{
    public abstract class XmlHtmlBase
    {
        private string name = String.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string id = String.Empty;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private Control mControl;
        public Control TheControl
        {
            get { return mControl; }
            set { mControl = value; }
        }
        private wxAction action;
        public wxAction TheAction
        {
            get { return action; }
            set { action = value; }
        }
        /// <summary>
        /// Constructor parses the HtmlElement for name or id 
        /// </summary>
        /// <param name="element"></param>
        protected XmlHtmlBase(HtmlElement element)
        {
            string s = element.OuterHtml;
            //id = String.Empty;
            //name = String.Empty;
            if (element.Name != null)
                name = element.Name;
            if (element.Id != null)
                id = element.Id;

        }

        public abstract wxAction GetAction();
    }
}