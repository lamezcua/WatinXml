namespace wxRecorder
{
    partial class frmRecorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecorder));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvRecording = new System.Windows.Forms.TreeView();
            this.tsRecorder = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnTrash = new System.Windows.Forms.ToolStripButton();
            this.btnRecord = new System.Windows.Forms.ToolStripButton();
            this.btnStopRec = new System.Windows.Forms.ToolStripButton();
            this.IeBrowser = new System.Windows.Forms.WebBrowser();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cboUrl = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnStopLoad = new System.Windows.Forms.ToolStripButton();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnForward = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tsRecorder.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(675, 22);
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
            this.splitContainer1.Panel1.Controls.Add(this.tvRecording);
            this.splitContainer1.Panel1.Controls.Add(this.tsRecorder);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.IeBrowser);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(675, 642);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvRecording
            // 
            this.tvRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRecording.Location = new System.Drawing.Point(0, 25);
            this.tvRecording.Name = "tvRecording";
            this.tvRecording.Size = new System.Drawing.Size(189, 613);
            this.tvRecording.TabIndex = 1;
            // 
            // tsRecorder
            // 
            this.tsRecorder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnTrash,
            this.btnRecord,
            this.btnStopRec});
            this.tsRecorder.Location = new System.Drawing.Point(0, 0);
            this.tsRecorder.Name = "tsRecorder";
            this.tsRecorder.Size = new System.Drawing.Size(189, 25);
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
            this.btnSave.Text = "toolStripButton6";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTrash.Image = ((System.Drawing.Image)(resources.GetObject("btnTrash.Image")));
            this.btnTrash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(23, 22);
            this.btnTrash.Text = "toolStripButton7";
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(23, 22);
            this.btnRecord.Text = "toolStripButton8";
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStopRec
            // 
            this.btnStopRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopRec.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRec.Image")));
            this.btnStopRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.Size = new System.Drawing.Size(23, 22);
            this.btnStopRec.Text = "toolStripButton5";
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);
            // 
            // IeBrowser
            // 
            this.IeBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IeBrowser.Location = new System.Drawing.Point(0, 25);
            this.IeBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.IeBrowser.Name = "IeBrowser";
            this.IeBrowser.Size = new System.Drawing.Size(474, 613);
            this.IeBrowser.TabIndex = 1;
            this.IeBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.IeBrowser_DocumentCompleted);            
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboUrl,
            this.btnRefresh,
            this.btnStopLoad,
            this.btnBack,
            this.btnForward});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(474, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // cboUrl
            // 
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(250, 25);
            this.cboUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUrl_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "toolStripButton4";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStopLoad
            // 
            this.btnStopLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLoad.Image")));
            this.btnStopLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopLoad.Name = "btnStopLoad";
            this.btnStopLoad.Size = new System.Drawing.Size(23, 22);
            this.btnStopLoad.Text = "toolStripButton1";
            this.btnStopLoad.Click += new System.EventHandler(this.btnStopLoad_Click);
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "toolStripButton3";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(23, 22);
            this.btnForward.Text = "toolStripButton2";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // frmRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 664);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecorder";
            this.Text = "wxRecorder";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tsRecorder.ResumeLayout(false);
            this.tsRecorder.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }    

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip tsRecorder;
        private System.Windows.Forms.ToolStripButton btnStopRec;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnTrash;
        private System.Windows.Forms.WebBrowser IeBrowser;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnStopLoad;
        private System.Windows.Forms.ToolStripComboBox cboUrl;
        private System.Windows.Forms.ToolStripButton btnForward;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.TreeView tvRecording;
        private System.Windows.Forms.ToolStripButton btnRecord;
    }
}

