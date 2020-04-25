using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace FCam_Tool_042020
{
    public partial class frmCreateJSONLanguage : Form
    {
        List<string> lstScriptFilesPath = new List<string>();
        string indexPath = string.Empty;
        public frmCreateJSONLanguage()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            var dialog = new FolderSelectDialog
            {
                Title = "Select a folder to import"
            };
            if (!chkSelectFile.Checked)
            {
                if (dialog.Show(Handle))
                {
                    txtInputPath.Text = dialog.FileName;
                    if (!string.IsNullOrEmpty(txtTypeSearch.Text))
                    {
                        var searchType = string.Format(@"^.+\.({0})$", txtTypeSearch.Text.Trim()); // cs|js|ts|html|json
                        lstScriptFilesPath = Files.GetListFilePathInFolder(txtInputPath.Text, chkSearchSub.Checked, searchType, "*");
                    }
                    else
                    {
                        lstScriptFilesPath = Files.GetListFilePathInFolder(txtInputPath.Text, chkSearchSub.Checked);
                    }
                }
            }
            else
            {
                var indexContent = string.Empty;
                try
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                    openFileDialog1.Title = "Browse src file";
                    openFileDialog1.CheckFileExists = true;
                    openFileDialog1.CheckPathExists = true;
                    openFileDialog1.DefaultExt = "cs";
                    openFileDialog1.Filter = "cs files (*.cs)|*.cs|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.ReadOnlyChecked = true;
                    openFileDialog1.ShowReadOnly = true;
                    openFileDialog1.Multiselect = false;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        indexPath = openFileDialog1.FileName;
                        indexContent = File.ReadAllText(indexPath);
                    }
                }
                catch
                {
                    MessageBox.Show("Read index file.html error! Please try again");
                    return;
                }
            }
        }

        private void btnProgess_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstScriptFilesPath.Count; i++)
            {
                //var content = File.ReadAllText(lstScriptFilesPath[i]);
                var contentFiles = File.ReadAllLines(lstScriptFilesPath[i]);
            }
        }
    }
}
