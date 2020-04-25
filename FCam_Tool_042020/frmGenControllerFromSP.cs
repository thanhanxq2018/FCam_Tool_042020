using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCam_Tool_042020
{
    public partial class frmGenControllerFromSP : Form
    {
        public frmGenControllerFromSP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGetSPFromSrc frm = new frmGetSPFromSrc();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGenControllerFromSP frm = new frmGenControllerFromSP();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCheckLanguages frm = new frmCheckLanguages();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCreateJSONLanguage frm = new frmCreateJSONLanguage();
            frm.Show();
        }
    }
}
