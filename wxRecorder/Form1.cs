using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wxRecorder
{
    public partial class frmRecorder : Form
    {
        bool isRecording = false;
        RecordedScenario rScenario;
        public frmRecorder()
        {
            InitializeComponent();
            rScenario = new RecordedScenario();
        }
        #region RecorderButtons

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnTrash_Click(object sender, EventArgs e)
        {

        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            
            if (IeBrowser.Document != null)
            {
                lblStatus.Text = "Rcording started!";
                isRecording = true;
                IeBrowser.Document.Click += new System.Windows.Forms.HtmlElementEventHandler(Document_Click);
                IeBrowser.Document.LosingFocus += new HtmlElementEventHandler(Document_LosingFocus);
                rScenario.Initialize(IeBrowser.Document);
                btnSave.Enabled = false;
                btnTrash.Enabled = false;
                btnRecord.Enabled = false;
                btnStopRec.Enabled = true;
            }
            else
                lblStatus.Text = "Cannot start recording on empty document!";
        }


        private void btnStopRec_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                isRecording = false;
                this.IeBrowser.Document.Click -= new System.Windows.Forms.HtmlElementEventHandler(Document_Click);
                btnSave.Enabled = true;
                btnTrash.Enabled = true;
                btnRecord.Enabled = true;
                btnStopRec.Enabled = false;
            }
            else
                lblStatus.Text = "Cannot stop recording: never started!";
        }

        #endregion
        
        #region Browser Buttons
        void cboUrl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                GoTo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GoTo();
        }

        private void btnStopLoad_Click(object sender, EventArgs e)
        {
            IeBrowser.Stop();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            IeBrowser.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            IeBrowser.GoForward();
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        private void GoTo()
        {
            if ( cboUrl.Text.Trim().Length < 1)
                return;
            string url = parseUrl(cboUrl.Text);
            try
            {
                Uri u = new Uri(url);
                IeBrowser.Url = u;
                IeBrowser.Navigate(u);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string parseUrl(string text)
        {
            if (text.StartsWith("http"))
                return text;
            else
                return "http://" + text;
        }

        #region Browser Events
        private void IeBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            rScenario.Completed(IeBrowser.Document);
        }

        void Document_Click(object sender, System.Windows.Forms.HtmlElementEventArgs e)
        {
            if ((isRecording)
                && (sender is HtmlDocument)
                && (e.EventType == "click"))
            {
                HtmlDocument doc = sender as HtmlDocument;
                rScenario.AddAction(doc.ActiveElement);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Document_LosingFocus(object sender, HtmlElementEventArgs e)
        {
            string toto = e.EventType;
        }

        #endregion
    }
}
