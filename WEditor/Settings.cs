using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WEditor.Properties.Settings;

namespace WEditor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            tbxAnimFileContent.Text = Default.folderAddsText;
            checkBox1.Checked = Default.preOrAf;
        }

        private void btnSaveCurrent_Click(object sender, EventArgs e)
        {
            Default.folderAddsText = tbxAnimFileContent.Text;
            Default.preOrAf = checkBox1.Checked;
            Default.Save();
            this.Close();
        }
    }
}
