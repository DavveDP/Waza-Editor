
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
            this.SuspendLayout();
            // 
            // lbxAnimationList
            // 
            this.lbxAnimationList.FormattingEnabled = true;
            this.lbxAnimationList.Location = new System.Drawing.Point(13, 13);
            this.lbxAnimationList.Name = "lbxAnimationList";
            this.lbxAnimationList.Size = new System.Drawing.Size(289, 420);
            this.lbxAnimationList.TabIndex = 0;
            // 
            // flpAnimationViewer
            // 
            this.flpAnimationViewer.Location = new System.Drawing.Point(309, 13);
            this.flpAnimationViewer.Name = "flpAnimationViewer";
            this.flpAnimationViewer.Size = new System.Drawing.Size(315, 258);
            this.flpAnimationViewer.TabIndex = 1;
            // 
            // AnimationDatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpAnimationViewer);
            this.Controls.Add(this.lbxAnimationList);
            this.Name = "AnimationDatabaseWindow";
            this.Text = "AnimationDatabaseWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAnimationList;
        private System.Windows.Forms.FlowLayoutPanel flpAnimationViewer;
    }
}