using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wxCapture
{
    public partial class frmCapture : Form
    {
        CapturedScenario capturedScenario;
        public frmCapture()
        {
            InitializeComponent();
            capturedScenario = new CapturedScenario();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgExport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    capturedScenario.Export(dlgExport.FileName);
                    lblStatus.Text = String.Format("Exported to file: {0}", dlgExport.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Error exporting to file " + dlgExport.FileName);
                    lblStatus.Text = "Error exporting to file " + dlgExport.FileName;
                }
            }
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            capturedScenario.Clear();
            tvTests.Nodes.Clear();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CapturePage();           
        }

        void CapturePage()
        {
            if (IeBrowser.Document != null)
            {
                capturedScenario.CapturePage(IeBrowser.Document, tvTests);
                lblStatus.Text = "Page captured!";
            }
            else
                lblStatus.Text = "Invalid page!";
        }

        /// <summary>
        /// 
        /// </summary>
        private void GoTo()
        {
            if (cboUrl.Text.Trim().Length < 1)
                return;
            string url = parseUrl(cboUrl.Text);
            try
            {
                Uri u = new Uri(url);
                lblStatus.Text = " Loading page ..... ";
                this.Refresh();
                IeBrowser.Url = u;
                IeBrowser.Navigate(u);
                btnCapture.Enabled = false;             
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
        
        #region BrowserButtons
        void cboUrl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                GoTo();
        }     
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GoTo();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
             IeBrowser.GoBack();
        }
        private void btnStopLoad_Click(object sender, EventArgs e)
        {
            IeBrowser.Stop();
            btnCapture.Enabled = true;
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            IeBrowser.GoForward();
        }
        #endregion

        #region TreeView 

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapturePage();
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTests.SelectedNode != null)
            {
                try
                {
                    capturedScenario.Remove(tvTests.SelectedNode, tvTests);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing node! --->   " + ex.Message);
                }
            }
            ////////////////////////// OLD VERSION /////////////////////////
            //try
            //{
            //    switch (tvTests.SelectedNode.Level)
            //    {
            //        case 0: // page
            //            capturedScenario.Remove(tvTests.SelectedNode);
            //            tvTests.Nodes.Remove(tvTests.SelectedNode);
            //            break;
            //        case 1: // test 
            //            capturedScenario.Remove(tvTests.SelectedNode);
            //            tvTests.Nodes.Remove(tvTests.SelectedNode);
            //            break;
            //        case 2: // Action.....
            //            capturedScenario.Remove(tvTests.SelectedNode);
            //            tvTests.Nodes.Remove(tvTests.SelectedNode);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error removing node! --->   " + ex.Message);
            //}
            ////////////////////////// OLD VERSION /////////////////////////
            
        }     

        private void removeAllButSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvTests.SelectedNode != null)
            {
                try
                {
                    capturedScenario.RemoveAllBut(tvTests.SelectedNode, tvTests);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing node! --->   " + ex.Message);
                }
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capturedScenario.Clear();
            tvTests.Nodes.Clear();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            tvTests.ExpandAll();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvTests.CollapseAll();
        }
        
        #endregion

        private void IeBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            lblStatus.Text = "Page loaded";
            cboUrl.Text = e.Url.ToString();
            btnCapture.Enabled = true;
        }
    }
}
