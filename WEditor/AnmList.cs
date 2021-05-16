using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEditor
{
    public partial class AnimList : Form
    {
        public AnimList()
        {
            InitializeComponent();
        }

        private void AnimList_Load(object sender, EventArgs e)//load
        {
            cbxSelectedAnimFile.SelectedIndex = 0;
        }

        private void cbxSelectedAnimFile_SelectedIndexChanged(object sender, EventArgs e)//changed
        {
            listBox1.SelectedIndex = cbxSelectedAnimFile.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//changed
        {
            cbxSelectedAnimFile.SelectedIndex = listBox1.SelectedIndex;
        }

        private void btnSaveCurrent_Click(object sender, EventArgs e)//close button
        {
            this.Close();
        }
    }
}
