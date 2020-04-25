using System;
using System.Windows.Forms;

namespace FCam_Tool_042020
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCreateJSONLanguage frm = new frmCreateJSONLanguage();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCheckLanguages frm = new frmCheckLanguages();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmGenControllerFromSP frm = new frmGenControllerFromSP();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmGetSPFromSrc frm = new frmGetSPFromSrc();
            frm.Show();
        }
    }
}
