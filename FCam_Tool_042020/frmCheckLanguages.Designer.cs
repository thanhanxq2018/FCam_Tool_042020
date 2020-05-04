namespace FCam_Tool_042020
{
    partial class frmCheckLanguages
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
            this.chkSelectFile = new System.Windows.Forms.CheckBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.chkSearchSub = new System.Windows.Forms.CheckBox();
            this.btnProgess = new System.Windows.Forms.Button();
            this.txtTypeSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCheck3File = new System.Windows.Forms.Button();
            this.btnCheckNotTran = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkSelectFile
            // 
            this.chkSelectFile.AutoSize = true;
            this.chkSelectFile.Location = new System.Drawing.Point(67, 13);
            this.chkSelectFile.Name = "chkSelectFile";
            this.chkSelectFile.Size = new System.Drawing.Size(78, 17);
            this.chkSelectFile.TabIndex = 19;
            this.chkSelectFile.Text = "Select file?";
            this.chkSelectFile.UseVisualStyleBackColor = true;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(6, 41);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(61, 13);
            this.lblPath.TabIndex = 18;
            this.lblPath.Text = "Folder Path";
            // 
            // txtInputPath
            // 
            this.txtInputPath.Location = new System.Drawing.Point(67, 35);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.Size = new System.Drawing.Size(420, 20);
            this.txtInputPath.TabIndex = 17;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(493, 33);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(69, 23);
            this.btnBrowser.TabIndex = 16;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // chkSearchSub
            // 
            this.chkSearchSub.AutoSize = true;
            this.chkSearchSub.Checked = true;
            this.chkSearchSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchSub.Location = new System.Drawing.Point(161, 12);
            this.chkSearchSub.Name = "chkSearchSub";
            this.chkSearchSub.Size = new System.Drawing.Size(115, 17);
            this.chkSearchSub.TabIndex = 19;
            this.chkSearchSub.Text = "Search sub folder?";
            this.chkSearchSub.UseVisualStyleBackColor = true;
            // 
            // btnProgess
            // 
            this.btnProgess.Location = new System.Drawing.Point(67, 61);
            this.btnProgess.Name = "btnProgess";
            this.btnProgess.Size = new System.Drawing.Size(147, 23);
            this.btnProgess.TabIndex = 20;
            this.btnProgess.Text = "Check  translate not exist";
            this.btnProgess.UseVisualStyleBackColor = true;
            this.btnProgess.Click += new System.EventHandler(this.btnProgess_Click);
            // 
            // txtTypeSearch
            // 
            this.txtTypeSearch.Location = new System.Drawing.Point(346, 10);
            this.txtTypeSearch.Name = "txtTypeSearch";
            this.txtTypeSearch.Size = new System.Drawing.Size(141, 20);
            this.txtTypeSearch.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Type";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // btnCheck3File
            // 
            this.btnCheck3File.Location = new System.Drawing.Point(246, 61);
            this.btnCheck3File.Name = "btnCheck3File";
            this.btnCheck3File.Size = new System.Drawing.Size(117, 23);
            this.btnCheck3File.TabIndex = 22;
            this.btnCheck3File.Text = "Check 3 file json";
            this.btnCheck3File.UseVisualStyleBackColor = true;
            this.btnCheck3File.Click += new System.EventHandler(this.btnCheck3File_Click);
            // 
            // btnCheckNotTran
            // 
            this.btnCheckNotTran.Location = new System.Drawing.Point(386, 61);
            this.btnCheckNotTran.Name = "btnCheckNotTran";
            this.btnCheckNotTran.Size = new System.Drawing.Size(176, 23);
            this.btnCheckNotTran.TabIndex = 23;
            this.btnCheckNotTran.Text = "Check Vietnamese not translated";
            this.btnCheckNotTran.UseVisualStyleBackColor = true;
            // 
            // frmCheckLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 129);
            this.Controls.Add(this.btnCheckNotTran);
            this.Controls.Add(this.btnCheck3File);
            this.Controls.Add(this.txtTypeSearch);
            this.Controls.Add(this.btnProgess);
            this.Controls.Add(this.chkSearchSub);
            this.Controls.Add(this.chkSelectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.btnBrowser);
            this.Name = "frmCheckLanguages";
            this.Text = "frmCheckMultilanguage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSelectFile;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtInputPath;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.CheckBox chkSearchSub;
        private System.Windows.Forms.Button btnProgess;
        private System.Windows.Forms.TextBox txtTypeSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCheck3File;
        private System.Windows.Forms.Button btnCheckNotTran;
    }
}