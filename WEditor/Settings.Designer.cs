﻿namespace WEditor
{
    partial class Settings
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
            this.btnSaveCurrent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAnimFileContent = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSaveCurrent
            // 
            this.btnSaveCurrent.Location = new System.Drawing.Point(270, 86);
            this.btnSaveCurrent.Name = "btnSaveCurrent";
            this.btnSaveCurrent.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCurrent.TabIndex = 0;
            this.btnSaveCurrent.Text = "OK";
            this.btnSaveCurrent.UseVisualStyleBackColor = true;
            this.btnSaveCurrent.Click += new System.EventHandler(this.btnSaveCurrent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unpack Folder Name";
            // 
            // tbxAnimFileContent
            // 
            this.tbxAnimFileContent.Location = new System.Drawing.Point(168, 13);
            this.tbxAnimFileContent.Name = "tbxAnimFileContent";
            this.tbxAnimFileContent.Size = new System.Drawing.Size(177, 22);
            this.tbxAnimFileContent.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Add Above Name After";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 121);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbxAnimFileContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveCurrent);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAnimFileContent;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}