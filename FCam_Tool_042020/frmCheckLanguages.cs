using FCam_Tool_042020.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility;

namespace FCam_Tool_042020
{
    public partial class frmCheckLanguages : Form
    {
        private string jsonENPath = "../../Data/JSON/Language/lang-en.json";
        private string jsonVNPath = "../../Data/JSON/Language/lang-vn.json";
        private string jsonKHPath = "../../Data/JSON/Language/lang-kh.json";
        List<string> lstScriptFilesPath = new List<string>();
        string indexPath = string.Empty;
        public frmCheckLanguages()
        {
            InitializeComponent();
            toolTip1.SetToolTip(txtInputPath, "Path to html, js, ts file contain translate");
            toolTip1.SetToolTip(btnProgess, "B1. Gen file key value B2.Check invalid translate in src file");
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
            #region B1. Gen file hoac Object chua key-value language

            GenFileKeyValue(jsonENPath);
            #endregion

            #region B2. Check error
            var lstKQ = new List<string>();
            var src = File.ReadAllLines("../../Data/JSON/Language/KeyValue/Result_.txt");
            var pattern = "{{\\s*(\"|')((\\w{1,}.\\w{1,}(.\\w{1,}|)))(\"|')\\s*|\\s*translate\\s*";
            var pattern2 = "{{\\s*(\\w{1,}.\\w{1,}(.\\w{1,}|))\\s*\\|\\s*translate\\s*";
            var result = string.Empty;
            for (int i = 0; i < lstScriptFilesPath.Count; i++)
            {
                var content2 = File.ReadAllLines(lstScriptFilesPath[i]);
                lstKQ.Add(lstScriptFilesPath[i]);
                for (int j = 0; j < content2.Length; j++)
                {
                    if (content2[j].Contains("translate") &&
                        content2[j].Contains("{{") &&
                        content2[j].Contains(".") &&
                        content2[j].Contains("|") &&
                        content2[j].Contains("}}")) //&& Regex.IsMatch(content2[j], pattern)
                    {
                        var valueCheck = content2[j].Replace("\"", "").Replace("'", "").Replace("\\", "");
                        if (Regex.IsMatch(valueCheck, pattern2))
                        {
                            var value = Regex.Match(valueCheck, pattern2).Groups[1].Value.ToString();
                            var count = 0;
                            foreach (var item in src)
                            {
                                var valueSrc = item.Replace("\"", "").Replace("'", "").Replace("\\", "");
                                if (value.Trim().ToLower() == valueSrc.Trim().ToLower())
                                {
                                    count++;
                                }
                            }
                            if (count == 0)
                            {
                                result += "Error:" + lstScriptFilesPath[i] + ": Line " + i + "\r\n\t==> " + value + "\r\n";
                            }
                        }
                    }
                }
            }

            CopyToNotepad(result);
            #endregion
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        // Gen file Key-Value from file json language
        public void GenFileKeyValue(string paths)
        {

            //
            var file = ReadFileJson(paths);
            var content = new List<string>();
            for (int z = 0; z < file.Count(); z++)
            {
                var result = file[z].GenString();
                content.AddRange(result);
            }

            var date = "";//DateTime.Now.ToString("ddMMyyyyHHmmss");
            var path = "../../Data/JSON/Language/KeyValue/Result_" + date + ".txt";
            File.WriteAllLines(path, content);
        }

        private void CopyToNotepad(string clipboard_string)
        {
            // dont use Clipboard.SetText as it might fail if clipboard is occupied by some other process
            // try this method with retry count of at least 2
            Clipboard.SetDataObject(clipboard_string, false, 2, 10);

            // start notepad and paste to it
            Process p = Process.Start("notepad.exe");
            p.WaitForInputIdle(10000);
            SendKeys.Send("^V");
        }

        private void btnCheck3File_Click(object sender, EventArgs e)
        {
            var en = ReadFileJson(jsonENPath);
            var vn = ReadFileJson(jsonVNPath);
            var kh = ReadFileJson(jsonKHPath);

            var contentEN = new List<string>();
            var contentVN = new List<string>();
            var contentKH = new List<string>();
            for (int i = 0; i < en.Count(); i++)
            {
                var result = en[i].GenString();
                contentEN.AddRange(result);
            }
            for (int i = 0; i < vn.Count(); i++)
            {
                var result = vn[i].GenString();
                contentVN.AddRange(result);
            }
            for (int i = 0; i < kh.Count(); i++)
            {
                var result = kh[i].GenString();
                contentKH.AddRange(result);
            }

            var res = "";
            if (contentVN.Count != contentKH.Count || contentVN.Count != contentEN.Count || contentEN.Count != contentKH.Count) res = "Kich thuoc 3 file khac nhau. (can format truoc khi check)";
            for(int i = 0; i < contentVN.Count(); i++)
            {
                var b = contentVN[i].Replace("\"", "").Replace("\\", "");
                if (contentVN[i].Replace("\\\"", "").Replace("\\", "") != contentEN[i].Replace("\\\"", "").Replace("\\", "") || 
                   contentVN[i].Replace("\\\"", "").Replace("\\", "") != contentKH[i].Replace("\\\"", "").Replace("\\", ""))
                {
                    res += "===> Error: Line " + i + "\r\n\t vn: " + contentVN[i] + "\r\n\t en: " + contentEN[i] + "\r\n\t kh: " + contentKH[i] + Environment.NewLine;
                }
            }

            if(string.IsNullOrEmpty(res))
            {
                MessageBox.Show("3 file json đồng bộ, không có lỗi");
            } else
            {
                CopyToNotepad(res);
            }
        }

        private List<JSON> ReadFileJson(string paths)
        {
            var regexKeyWithSub = "\\s*\\\"(\\w{1,})\\\"\\s*:\\s*\\{"; //"\"(\\w{1,})\"\\s*:\\s*{\\s*\\r\\n";
            var regexKey2 = "\\s*\\\"(\\w{1,})\\\":\\s*\\\"";
            var a = File.ReadAllLines(paths);

            var file = new List<JSON>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Contains("\": {")) // ": {
                {
                    var json = new JSON() { KeyLv0 = string.Empty, KeyLv1 = new List<string>(), KeyLv1HasSub = new List<SubKeyLv1>() };
                    var keyLv0 = Regex.Match(a[i], regexKeyWithSub).Groups[1].Value.ToString();
                    json.KeyLv0 = keyLv0;
                    var countBracer = 1; // Lv1
                    while (countBracer != 0 && i < a.Length - 1)
                    {
                        i++;
                        if (a[i].Contains("\": {"))
                        {
                            var keyLv1WithSub = Regex.Match(a[i], regexKeyWithSub).Groups[1].Value.ToString();
                            var lstKeyLv1HasSub = new SubKeyLv1() { KeyLv1 = keyLv1WithSub, KeyLv2 = new List<string>() };
                            i++;
                            countBracer++; // Lv2
                            while (countBracer >= 2)
                            {
                                if (a[i].Trim() == "}," || a[i].Trim() == "}")
                                {
                                    countBracer--;
                                }
                                var keyLv2 = Regex.Match(a[i], regexKey2).Groups[1].Value.ToString();
                                if (!string.IsNullOrEmpty(keyLv2))
                                {
                                    lstKeyLv1HasSub.KeyLv2.Add(keyLv2);
                                }
                                i++;
                            }
                            json.KeyLv1HasSub.Add(lstKeyLv1HasSub);
                        }
                        else
                        {
                            var keyLv1 = Regex.Match(a[i], regexKey2).Groups[1].Value.ToString();
                            if (!string.IsNullOrEmpty(keyLv1))
                            {
                                json.KeyLv1.Add(keyLv1);
                            }
                        }
                        if (a[i].Trim() == "}," || a[i].Trim() == "}")
                        {
                            countBracer--;
                        }
                    }
                    file.Add(json);
                }
            }

            return file;
        }
    }
}
