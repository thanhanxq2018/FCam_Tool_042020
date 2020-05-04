namespace FCam_Tool_042020
{
    partial class frmCreateJSONLanguage
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
            this.txtTypeSearch = new System.Windows.Forms.TextBox();
            this.btnProgess = new System.Windows.Forms.Button();
            this.chkSearchSub = new System.Windows.Forms.CheckBox();
            this.chkSelectFile = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTypeSearch
            // 
            this.txtTypeSearch.Location = new System.Drawing.Point(363, 18);
            this.txtTypeSearch.Name = "txtTypeSearch";
            this.txtTypeSearch.Size = new System.Drawing.Size(141, 20);
            this.txtTypeSearch.TabIndex = 29;
            // 
            // btnProgess
            // 
            this.btnProgess.Location = new System.Drawing.Point(510, 70);
            this.btnProgess.Name = "btnProgess";
            this.btnProgess.Size = new System.Drawing.Size(69, 23);
            this.btnProgess.TabIndex = 28;
            this.btnProgess.Text = "Progess";
            this.btnProgess.UseVisualStyleBackColor = true;
            // 
            // chkSearchSub
            // 
            this.chkSearchSub.AutoSize = true;
            this.chkSearchSub.Checked = true;
            this.chkSearchSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchSub.Location = new System.Drawing.Point(178, 20);
            this.chkSearchSub.Name = "chkSearchSub";
            this.chkSearchSub.Size = new System.Drawing.Size(115, 17);
            this.chkSearchSub.TabIndex = 26;
            this.chkSearchSub.Text = "Search sub folder?";
            this.chkSearchSub.UseVisualStyleBackColor = true;
            // 
            // chkSelectFile
            // 
            this.chkSelectFile.AutoSize = true;
            this.chkSelectFile.Location = new System.Drawing.Point(84, 21);
            this.chkSelectFile.Name = "chkSelectFile";
            this.chkSelectFile.Size = new System.Drawing.Size(78, 17);
            this.chkSelectFile.TabIndex = 27;
            this.chkSelectFile.Text = "Select file?";
            this.chkSelectFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Type";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(23, 49);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(61, 13);
            this.lblPath.TabIndex = 25;
            this.lblPath.Text = "Folder Path";
            // 
            // txtInputPath
            // 
            this.txtInputPath.Location = new System.Drawing.Point(84, 43);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.Size = new System.Drawing.Size(420, 20);
            this.txtInputPath.TabIndex = 23;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(510, 41);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(69, 23);
            this.btnBrowser.TabIndex = 22;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // frmCreateJSONLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 221);
            this.Controls.Add(this.txtTypeSearch);
            this.Controls.Add(this.btnProgess);
            this.Controls.Add(this.chkSearchSub);
            this.Controls.Add(this.chkSelectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.btnBrowser);
            this.Name = "frmCreateJSONLanguage";
            this.Text = "frmCreateJSONLanguage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTypeSearch;
        private System.Windows.Forms.Button btnProgess;
        private System.Windows.Forms.CheckBox chkSearchSub;
        private System.Windows.Forms.CheckBox chkSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtInputPath;
        private System.Windows.Forms.Button btnBrowser;
    }
}