namespace WEditor
{
    partial class WEMainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WEMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenRom = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNarcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveRom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFunctionHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnimList = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxAnimFileContent = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveCurrent = new System.Windows.Forms.Button();
            this.cbxSelectedAnimFile = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbxRomInfo = new System.Windows.Forms.GroupBox();
            this.lbRomInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbxRomInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmTools,
            this.tsmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(683, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.BackColor = System.Drawing.Color.Transparent;
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenRom,
            this.saveNarcToolStripMenuItem,
            this.btnSaveRom,
            this.tsmQuit});
            this.tsmFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(37, 20);
            this.tsmFile.Text = "File";
            // 
            // btnOpenRom
            // 
            this.btnOpenRom.Name = "btnOpenRom";
            this.btnOpenRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.btnOpenRom.Size = new System.Drawing.Size(195, 22);
            this.btnOpenRom.Text = "Open Rom";
            this.btnOpenRom.Click += new System.EventHandler(this.btnOpenRom_Click);
            // 
            // saveNarcToolStripMenuItem
            // 
            this.saveNarcToolStripMenuItem.Enabled = false;
            this.saveNarcToolStripMenuItem.Name = "saveNarcToolStripMenuItem";
            this.saveNarcToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveNarcToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveNarcToolStripMenuItem.Text = "Pack Only Narc";
            this.saveNarcToolStripMenuItem.Click += new System.EventHandler(this.saveNarcToolStripMenuItem_Click);
            // 
            // btnSaveRom
            // 
            this.btnSaveRom.Enabled = false;
            this.btnSaveRom.Name = "btnSaveRom";
            this.btnSaveRom.Size = new System.Drawing.Size(195, 22);
            this.btnSaveRom.Text = "Save Rom";
            this.btnSaveRom.Click += new System.EventHandler(this.btnSaveRom_Click);
            // 
            // tsmQuit
            // 
            this.tsmQuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmQuit.Size = new System.Drawing.Size(195, 22);
            this.tsmQuit.Text = "Quit";
            this.tsmQuit.Click += new System.EventHandler(this.tsmQuit_Click);
            // 
            // tsmTools
            // 
            this.tsmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSettings});
            this.tsmTools.Name = "tsmTools";
            this.tsmTools.Size = new System.Drawing.Size(41, 20);
            this.tsmTools.Text = "Tool";
            // 
            // tsmSettings
            // 
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSettings.Size = new System.Drawing.Size(156, 22);
            this.tsmSettings.Text = "Settings";
            this.tsmSettings.Click += new System.EventHandler(this.tsmSettings_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.tsmFunctionHelp,
            this.tsmAnimList});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmHelp.Text = "Help";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmAbout.Size = new System.Drawing.Size(189, 22);
            this.tsmAbout.Text = "About";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // tsmFunctionHelp
            // 
            this.tsmFunctionHelp.Name = "tsmFunctionHelp";
            this.tsmFunctionHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmFunctionHelp.Size = new System.Drawing.Size(189, 22);
            this.tsmFunctionHelp.Text = "Function Help";
            this.tsmFunctionHelp.Click += new System.EventHandler(this.tsmFunctionHelp_Click);
            // 
            // tsmAnimList
            // 
            this.tsmAnimList.Name = "tsmAnimList";
            this.tsmAnimList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmAnimList.Size = new System.Drawing.Size(189, 22);
            this.tsmAnimList.Text = "Anim List";
            this.tsmAnimList.Click += new System.EventHandler(this.tsmAnimList_Click);
            // 
            // tbxAnimFileContent
            // 
            this.tbxAnimFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAnimFileContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbxAnimFileContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxAnimFileContent.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxAnimFileContent.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAnimFileContent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxAnimFileContent.Location = new System.Drawing.Point(259, 52);
            this.tbxAnimFileContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbxAnimFileContent.Multiline = true;
            this.tbxAnimFileContent.Name = "tbxAnimFileContent";
            this.tbxAnimFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxAnimFileContent.Size = new System.Drawing.Size(415, 505);
            this.tbxAnimFileContent.TabIndex = 1;
            this.tbxAnimFileContent.Visible = false;
            this.tbxAnimFileContent.WordWrap = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.Indigo;
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSaveCurrent
            // 
            this.btnSaveCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCurrent.Location = new System.Drawing.Point(559, 562);
            this.btnSaveCurrent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveCurrent.Name = "btnSaveCurrent";
            this.btnSaveCurrent.Size = new System.Drawing.Size(116, 20);
            this.btnSaveCurrent.TabIndex = 3;
            this.btnSaveCurrent.Text = "Save Current";
            this.btnSaveCurrent.UseVisualStyleBackColor = true;
            this.btnSaveCurrent.Visible = false;
            this.btnSaveCurrent.Click += new System.EventHandler(this.btnSaveCurrent_Click);
            // 
            // cbxSelectedAnimFile
            // 
            this.cbxSelectedAnimFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSelectedAnimFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSelectedAnimFile.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbxSelectedAnimFile.FormattingEnabled = true;
            this.cbxSelectedAnimFile.Location = new System.Drawing.Point(259, 27);
            this.cbxSelectedAnimFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxSelectedAnimFile.Name = "cbxSelectedAnimFile";
            this.cbxSelectedAnimFile.Size = new System.Drawing.Size(171, 21);
            this.cbxSelectedAnimFile.TabIndex = 4;
            this.cbxSelectedAnimFile.Visible = false;
            this.cbxSelectedAnimFile.SelectedIndexChanged += new System.EventHandler(this.cbxSelectedAnimFile_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(452, 27);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 20);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbxRomInfo
            // 
            this.gbxRomInfo.Controls.Add(this.lbRomInfo);
            this.gbxRomInfo.Location = new System.Drawing.Point(13, 28);
            this.gbxRomInfo.Name = "gbxRomInfo";
            this.gbxRomInfo.Size = new System.Drawing.Size(213, 119);
            this.gbxRomInfo.TabIndex = 8;
            this.gbxRomInfo.TabStop = false;
            this.gbxRomInfo.Text = "Rom Info";
            // 
            // lbRomInfo
            // 
            this.lbRomInfo.AutoSize = true;
            this.lbRomInfo.Location = new System.Drawing.Point(16, 26);
            this.lbRomInfo.Name = "lbRomInfo";
            this.lbRomInfo.Size = new System.Drawing.Size(0, 13);
            this.lbRomInfo.TabIndex = 0;
            // 
            // WEMainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(683, 604);
            this.Controls.Add(this.gbxRomInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbxSelectedAnimFile);
            this.Controls.Add(this.btnSaveCurrent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbxAnimFileContent);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "WEMainWindow";
            this.Text = "WazaEditor 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbxRomInfo.ResumeLayout(false);
            this.gbxRomInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem btnOpenRom;
        private System.Windows.Forms.ToolStripMenuItem btnSaveRom;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.TextBox tbxAnimFileContent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Button btnSaveCurrent;
        private System.Windows.Forms.ComboBox cbxSelectedAnimFile;
        private System.Windows.Forms.ToolStripMenuItem tsmTools;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmFunctionHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAnimList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem saveNarcToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxRomInfo;
        private System.Windows.Forms.Label lbRomInfo;
    }
}

