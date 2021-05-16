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
    public partial class KnownFunction : Form
    {
        public KnownFunction()
        {
            InitializeComponent();
        }

        private void lbxFunctionList_SelectedIndexChanged(object sender, EventArgs e)//Read Description
        {
            lbxFunctionBytes.SelectedIndex = lbxFunctionList.SelectedIndex;
            tbxFunctionDescription.Text = GetDescription(lbxFunctionList.SelectedIndex);
            tbxSelected.Text = lbxFunctionBytes.SelectedItem.ToString();
        }

        private void lbxFunctionBytes_SelectedIndexChanged(object sender, EventArgs e)//Read
        {
            lbxFunctionList.SelectedIndex = lbxFunctionBytes.SelectedIndex;
        }

        private string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return "Move sprite like tail whip";
                case 1:
                    return "Move sprite like pound\r\n https://bulbapedia.bulbagarden.net/wiki/File:Pound_IV.png";
                case 2:
                    return "Change Back Ground\r\n0x0 : Little Dark\r\n0x84c : Red\r\n0x7f77 : White\r\n0x33ff : Black";
                case 3:
                    return "Used Tackle - you should use this cmd with Cmd_1";
                case 4:
                    return "Used Fire Punch and more\r\nnumber next to 0x22 is a count of arguments\r\n 0x84c is color";
                case 5:
                    return "Used whirlwind\r\n https://bulbapedia.bulbagarden.net/wiki/File:Whirlwind_IV.png";
                case 6:
                    return "Used whirlwind\r\n(Vanish Pkmn)\r\n https://bulbapedia.bulbagarden.net/wiki/File:Whirlwind_IV.png";
                case 7:
                    return "Used whirlwind\r\n https://bulbapedia.bulbagarden.net/wiki/File:Whirlwind_IV.png";
                case 8:
                    return "Used bind - you should use this cmd with Cmd_1\r\nshrink pokemon\r\n https://bulbapedia.bulbagarden.net/wiki/File:Bind_IV.png";
                case 9:
                    return "Used bind - you should use this cmd with Cmd_1\r\n https://bulbapedia.bulbagarden.net/wiki/File:Bind_IV.png";
                case 10:
                    return "Change Pkmn Color\r\nuse with cmd_1\r\n https://bulbapedia.bulbagarden.net/wiki/File:Night_Shade_IV.png";
                case 11:
                    return "Attck Pkmn to Big like night shade\r\n https://bulbapedia.bulbagarden.net/wiki/File:Night_Shade_IV.png";
                case 12:
                    return "Make mosaic like transform\r\nuse with cmd_1\r\n https://bulbapedia.bulbagarden.net/wiki/File:Transform_IV.png";
                case 13:
                    return "Flash anim\r\n https://bulbapedia.bulbagarden.net/wiki/File:Flash_IV.png";
                case 14:
                    return "Splash\r\n https://bulbapedia.bulbagarden.net/wiki/File:Splash_IV.png";
                default:
                    return "Error";
            }
        }

        private void btnCopySelected_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxSelected.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
