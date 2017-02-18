namespace wxCapture
{
    partial class frmCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapture));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvTests = new System.Windows.Forms.TreeView();
            this.mnuTvTests = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllButSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRecorder = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnTrash = new System.Windows.Forms.ToolStripButton();
            this.btnCapture = new System.Windows.Forms.ToolStripButton();
            this.IeBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cboUrl = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnStopLoad = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.dlgExport = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mnuTvTests.SuspendLayout();
            this.tsRecorder.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 17);
            this.lblStatus.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvTests);
            this.splitContainer1.Panel1.Controls.Add(this.tsRecorder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.IeBrowser);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(740, 670);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvTests
            // 
            this.tvTests.ContextMenuStrip = this.mnuTvTests;
            this.tvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTests.Location = new System.Drawing.Point(0, 25);
            this.tvTests.Name = "tvTests";
            this.tvTests.Size = new System.Drawing.Size(207, 641);
            this.tvTests.TabIndex = 1;
            // 
            // mnuTvTests
            // 
            this.mnuTvTests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeSelectedToolStripMenuItem,
            this.removeAllButSelectedToolStripMenuItem,
            this.removeAllToolStripMenuItem,
            this.allToolStripMenuItem,
            this.expandAllToolStripMenuItem});
            this.mnuTvTests.Name = "mnuTvTests";
            this.mnuTvTests.Size = new System.Drawing.Size(202, 136);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addToolStripMenuItem.Text = "Add Current";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // removeAllButSelectedToolStripMenuItem
            // 
            this.removeAllButSelectedToolStripMenuItem.Name = "removeAllButSelectedToolStripMenuItem";
            this.removeAllButSelectedToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeAllButSelectedToolStripMenuItem.Text = "Remove All But Selected";
            this.removeAllButSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeAllButSelectedToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeAllToolStripMenuItem.Text = "Remove All";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.allToolStripMenuItem.Text = "Collapse All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // tsRecorder
            // 
            this.tsRecorder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnTrash,
            this.btnCapture});
            this.tsRecorder.Location = new System.Drawing.Point(0, 0);
            this.tsRecorder.Name = "tsRecorder";
            this.tsRecorder.Size = new System.Drawing.Size(207, 25);
            this.tsRecorder.TabIndex = 0;
            this.tsRecorder.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Export";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrash.Image = ((System.Drawing.Image)(resources.GetObject("btnTrash.Image")));
            this.btnTrash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(23, 22);
            this.btnTrash.Text = "Remove Page";
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(23, 22);
            this.btnCapture.Text = "Capture Page";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // IeBrowser
            // 
            this.IeBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IeBrowser.Location = new System.Drawing.Point(0, 25);
            this.IeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.IeBrowser.Name = "IeBrowser";
            this.IeBrowser.Size = new System.Drawing.Size(521, 641);
            this.IeBrowser.TabIndex = 1;
            this.IeBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.IeBrowser_DocumentCompleted);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboUrl,
            this.btnRefresh,
            this.btnBack,
            this.btnStopLoad,
            this.btnForward});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(521, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // cboUrl
            // 
            this.cboUrl.Items.AddRange(new object[] {
            "192.168.9.231/coretesteligibility"});
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(300, 25);
            this.cboUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUrl_KeyPress);
            this.cboUrl.SelectedIndexChanged += new System.EventHandler(cboUrl_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Go";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStopLoad
            // 
            this.btnStopLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLoad.Image")));
            this.btnStopLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopLoad.Name = "btnStopLoad";
            this.btnStopLoad.Size = new System.Drawing.Size(23, 22);
            this.btnStopLoad.Text = "Stop";
            this.btnStopLoad.Click += new System.EventHandler(this.btnStopLoad_Click);
            // 
            // btnForward
            // 
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(23, 22);
            this.btnForward.Text = "Forward";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // dlgExport
            // 
            this.dlgExport.DefaultExt = "xml";
            this.dlgExport.Title = "Export to xml";
            // 
            // frmCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 692);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmCapture";
            this.Text = "wxCapture";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.mnuTvTests.ResumeLayout(false);
            this.tsRecorder.ResumeLayout(false);
            this.tsRecorder.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void cboUrl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.GoTo();
        }


        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvTests;
        private System.Windows.Forms.ToolStrip tsRecorder;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnTrash;
        private System.Windows.Forms.ToolStripButton btnCapture;
        private System.Windows.Forms.WebBrowser IeBrowser;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox cboUrl;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnStopLoad;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ContextMenuStrip mnuTvTests;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem removeAllButSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog dlgExport;
    }
}

