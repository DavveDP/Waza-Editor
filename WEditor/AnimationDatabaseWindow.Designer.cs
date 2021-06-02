
namespace WEditor
{
    partial class AnimationDatabaseWindow
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
            this.lbxAnimationList = new System.Windows.Forms.ListBox();
            this.flpAnimationViewer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRedownloadDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxAnimationList
            // 
            this.lbxAnimationList.FormattingEnabled = true;
            this.lbxAnimationList.Location = new System.Drawing.Point(13, 13);
            this.lbxAnimationList.Name = "lbxAnimationList";
            this.lbxAnimationList.Size = new System.Drawing.Size(289, 420);
            this.lbxAnimationList.TabIndex = 0;
            this.lbxAnimationList.SelectedIndexChanged += new System.EventHandler(this.lbxAnimationList_SelectedIndexChanged);
            // 
            // flpAnimationViewer
            // 
            this.flpAnimationViewer.Location = new System.Drawing.Point(309, 13);
            this.flpAnimationViewer.Name = "flpAnimationViewer";
            this.flpAnimationViewer.Size = new System.Drawing.Size(324, 256);
            this.flpAnimationViewer.TabIndex = 1;
            // 
            // btnRedownloadDatabase
            // 
            this.btnRedownloadDatabase.Location = new System.Drawing.Point(309, 383);
            this.btnRedownloadDatabase.Name = "btnRedownloadDatabase";
            this.btnRedownloadDatabase.Size = new System.Drawing.Size(182, 49);
            this.btnRedownloadDatabase.TabIndex = 2;
            this.btnRedownloadDatabase.Text = "Redownload Database";
            this.btnRedownloadDatabase.UseVisualStyleBackColor = true;
            this.btnRedownloadDatabase.Click += new System.EventHandler(this.btnRedownloadDatabase_Click);
            // 
            // AnimationDatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 444);
            this.Controls.Add(this.btnRedownloadDatabase);
            this.Controls.Add(this.flpAnimationViewer);
            this.Controls.Add(this.lbxAnimationList);
            this.Name = "AnimationDatabaseWindow";
            this.Text = "AnimationDatabaseWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAnimationList;
        private System.Windows.Forms.FlowLayoutPanel flpAnimationViewer;
        private System.Windows.Forms.Button btnRedownloadDatabase;
    }
}