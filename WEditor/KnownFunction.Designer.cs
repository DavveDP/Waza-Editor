
namespace WEditor
{
    partial class KnownFunction
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
            this.lbxFunctionList = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCopySelected = new System.Windows.Forms.Button();
            this.lbxFunctionBytes = new System.Windows.Forms.ListBox();
            this.tbxFunctionDescription = new System.Windows.Forms.TextBox();
            this.tbxSelected = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbxFunctionList
            // 
            this.lbxFunctionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxFunctionList.FormattingEnabled = true;
            this.lbxFunctionList.Items.AddRange(new object[] {
            "0x3c Move (TailWhip)",
            "0x24 Move (Pound)",
            "0x21 Change Background",
            "0x39 (Tackle)",
            "0x22 Fade Pkmn Color",
            "0x3d (whirlwind)",
            "0x28 Vanish Pkmn(whirlwind)",
            "0x3e (whirlwind)",
            "0x2a shrink pkmn(bind)",
            "0x34 (bind)",
            "0x12 (Night Shade)",
            "0x11 (Night Shade)",
            "0x45 Mosaic (Transform)",
            "0x10 Flash",
            "0x13 Splash"});
            this.lbxFunctionList.Location = new System.Drawing.Point(10, 10);
            this.lbxFunctionList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbxFunctionList.Name = "lbxFunctionList";
            this.lbxFunctionList.Size = new System.Drawing.Size(138, 368);
            this.lbxFunctionList.TabIndex = 0;
            this.lbxFunctionList.SelectedIndexChanged += new System.EventHandler(this.lbxFunctionList_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(338, 358);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopySelected
            // 
            this.btnCopySelected.Location = new System.Drawing.Point(338, 11);
            this.btnCopySelected.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCopySelected.Name = "btnCopySelected";
            this.btnCopySelected.Size = new System.Drawing.Size(95, 20);
            this.btnCopySelected.TabIndex = 2;
            this.btnCopySelected.Text = "Copy Selected";
            this.btnCopySelected.UseVisualStyleBackColor = true;
            this.btnCopySelected.Click += new System.EventHandler(this.btnCopySelected_Click);
            // 
            // lbxFunctionBytes
            // 
            this.lbxFunctionBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxFunctionBytes.FormattingEnabled = true;
            this.lbxFunctionBytes.Items.AddRange(new object[] {
            "0x3c 0x3 0x2 0x1 0xc ",
            "0x24 0x5 0x1 0x0 0x1 0x2 0x108 ",
            "0x21 0x5 0x0 0x1 0xc 0x0 0x0",
            "0x39 0x4 0x2 0xe 0xfffffff8 0x102 ",
            "0x22 0x6 0x8 0x0 0x2 0x84c 0xe 0x0",
            "0x3d 0x2 0x8 0x14",
            "0x28 0x2 0x8 0x1",
            "0x3e 0x1 0x8",
            "0x2a 0x8 0x108 0x64 0x46 0x64 0x64 0x64 0x1 0x50005",
            "0x34 0x3 0x3 0x18 0x102",
            "0x12 0x0",
            "0x11 0x0",
            "0x45 0x4 0x0 0x1 0x0 0x0",
            "0x10 0x0",
            "0x13 0x0"});
            this.lbxFunctionBytes.Location = new System.Drawing.Point(152, 10);
            this.lbxFunctionBytes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbxFunctionBytes.Name = "lbxFunctionBytes";
            this.lbxFunctionBytes.Size = new System.Drawing.Size(183, 368);
            this.lbxFunctionBytes.TabIndex = 3;
            this.lbxFunctionBytes.SelectedIndexChanged += new System.EventHandler(this.lbxFunctionBytes_SelectedIndexChanged);
            // 
            // tbxFunctionDescription
            // 
            this.tbxFunctionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFunctionDescription.Location = new System.Drawing.Point(339, 59);
            this.tbxFunctionDescription.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbxFunctionDescription.Multiline = true;
            this.tbxFunctionDescription.Name = "tbxFunctionDescription";
            this.tbxFunctionDescription.ReadOnly = true;
            this.tbxFunctionDescription.Size = new System.Drawing.Size(129, 294);
            this.tbxFunctionDescription.TabIndex = 4;
            // 
            // tbxSelected
            // 
            this.tbxSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSelected.Location = new System.Drawing.Point(339, 37);
            this.tbxSelected.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbxSelected.Name = "tbxSelected";
            this.tbxSelected.Size = new System.Drawing.Size(129, 20);
            this.tbxSelected.TabIndex = 5;
            // 
            // KnownFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 384);
            this.Controls.Add(this.tbxSelected);
            this.Controls.Add(this.tbxFunctionDescription);
            this.Controls.Add(this.lbxFunctionBytes);
            this.Controls.Add(this.btnCopySelected);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbxFunctionList);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "KnownFunction";
            this.Text = "KnownFunction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxFunctionList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopySelected;
        private System.Windows.Forms.ListBox lbxFunctionBytes;
        private System.Windows.Forms.TextBox tbxFunctionDescription;
        private System.Windows.Forms.TextBox tbxSelected;
    }
}