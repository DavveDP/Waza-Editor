using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NarcAPI;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;


namespace WEditor
{
    public partial class WEMainWindow : Form
    {
        /*Lang :
         *English - 0
         *Spanish - 1
         *Italian - 2
         *French  - 3
         *German  - 4
         *Korean  - 5
         *Japanese- 6
         */
        public enum Language
        {
            English,
            Spanish,
            Italian,
            French,
            German,
            Korean,
            Japanese,
        }
        /// =======================================
        /// To Unpack
        /// =======================================
        public static string[] unpack;
        /// =======================================
        /// Main
        /// =======================================
        HelpWEMainWindow helpForm = new HelpWEMainWindow();
        Language language;
        List<string> moveAnimNames;
        public static string workingFolder;
        private string folderPath;
        private string fileName;
        private Rom rom;

        public WEMainWindow()
        {
            InitializeComponent();

            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                if (Directory.Exists(folderPath)) { Directory.Delete(folderPath, true); }
            };
        }

        #region Other Option
        private void tsmAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }


        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WEMainWindow form1 = new WEMainWindow();
            form1.Show();
        }
        #endregion

        //==========================================================================================

        private void btnOpenRom_Click(object sender, EventArgs e)//Open
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a pokemon NDS rom";
            ofd.Filter = "NDS File(*.nds)|*.nds";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lbStatus.Text = "Loading...";
                btnOpenRom.Enabled = false;
                fileName = ofd.SafeFileName;
                folderPath = Directory.GetCurrentDirectory() + "\\" + "_ext" + "\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + "RomDatabase.xml"))
                {
                    RomDatabaseHandler.rebuildDatabase();
                }

                rom = RomDatabaseHandler.GetRomFromDatabase(GetRomId(ofd.FileName));
                UnpackROM(ofd.FileName);

                //switch (cbxLanguage.SelectedIndex)
                //{
                //    case 0:
                //        language = Language.English;
                //        break;
                //    case 1:
                //        language = Language.Spanish;
                //        break;
                //    case 2:
                //        language = Language.Italian;
                //        break;
                //    case 3:
                //        language = Language.French;
                //        break;
                //    case 4:
                //        language = Language.German;
                //        break;
                //    case 5:
                //        language = Language.Korean;
                //        break;
                //    case 6:
                //        language = Language.Japanese;
                //        break;
                //    default:
                //        language = Language.English;
                //        break;
                //}
                lbRomInfo.Text = rom.ToString();

                LoadAnimations();

                SetEnabled(true);
                lbStatus.Text = "Ready";
            }


            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Select a NDS rom";
            //ofd.Filter = "NDS File(*.nds)|*.nds";

            //if(ofd.ShowDialog() == DialogResult.OK)
            //{
            //    workingFolder = Path.GetDirectoryName(ofd.FileName) + "\\" + Path.GetFileNameWithoutExtension(ofd.FileName) + "_waza";
            //    Narc.Open(currentROM.wazaNarcPath).ExtractToFolder(workingFolder);
            //}

        }

        private void saveNarcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Packing narc...";
            if (Directory.Exists(folderPath + rom.WazaFolderPath))
            {
                Narc.FromFolder(folderPath + rom.WazaFolderPath).Save(folderPath + rom.WazaNarcPath);
                Directory.Delete(folderPath + rom.WazaFolderPath, true);
            }
            if (Directory.Exists(folderPath + rom.TextBankFolderPath))
            {
                Narc.FromFolder(folderPath + rom.TextBankFolderPath).Save(folderPath + rom.TextBankNarcPath);
                Directory.Delete(folderPath + rom.TextBankFolderPath, true);
            }
            SetEnabled(false);
            this.Text = "WE 1.0";
            lbStatus.Text = "Packed.";
        }

        private void SetEnabled(bool tf)
        {
            btnSaveRom.Enabled = tf;
            saveNarcToolStripMenuItem.Enabled = tf;
            cbxSelectedAnimFile.Visible = tf;
            tbxAnimFileContent.Visible = tf;
            btnSaveCurrent.Visible = tf;
            btnRefresh.Visible = tf;
        }
        private string GetRomId(string path)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
            {
                br.BaseStream.Seek(0xC, SeekOrigin.Begin);
                return Encoding.UTF8.GetString(br.ReadBytes(4));
            }
        }
        private void LoadAnimations()
        {
            List<string> moveAnimNames = new List<string>(Gen4TX.Text.ExtractToList(folderPath + rom.TextBankFolderPath + "\\" + $@"{rom.TextBank:D4}"));
            int fileCount = (int)Directory.GetFiles(folderPath + rom.WazaFolderPath, "*.*", SearchOption.TopDirectoryOnly).Length;
            cbxSelectedAnimFile.Items.Clear();
            for (int i = 0; i < fileCount; i++)
            {
                if (moveAnimNames.Count > i)
                {
                    cbxSelectedAnimFile.Items.Add(moveAnimNames[i] + " : " + i);
                }
                else
                {
                    cbxSelectedAnimFile.Items.Add("File : " + i);
                }
            }

            LoadAnimationDatabaseWindow(moveAnimNames);
            
            cbxSelectedAnimFile.SelectedIndex = 0;
        }
        private void LoadAnimationDatabaseWindow(List<string> names)
        {
            AnimationDatabaseWindow animationDatabaseWindow = new AnimationDatabaseWindow(names);
        }
        private void UnpackROM(string filePath)
        {
            lbStatus.Text = "Unpacking Rom";
            Process unpack = new Process();
            unpack.StartInfo.FileName = @"Data\ndstool.exe";
            unpack.StartInfo.Arguments = "-v -x " + '"' + filePath + '"' + " -9 " + '"' + folderPath + "arm9.bin" + '"' + " -7 " + '"' + folderPath + "arm7.bin" + '"' + " -y9 " + '"' + folderPath + "y9.bin" + '"' + " -y7 " + '"' + folderPath + "y7.bin" + '"' + " -d " + '"' + folderPath + "data" + '"' + " -y " + '"' + folderPath + "overlay" + '"' + " -t " + '"' + folderPath + "banner.bin" + '"' + " -h " + '"' + folderPath + "header.bin" + '"';
            Application.DoEvents();
            unpack.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            unpack.StartInfo.CreateNoWindow = true;
            unpack.Start();
            unpack.WaitForExit();

            Narc.Open(folderPath + rom.WazaNarcPath).ExtractToFolder(folderPath + rom.WazaFolderPath);
            Narc.Open(folderPath + rom.TextBankNarcPath).ExtractToFolder(folderPath + rom.TextBankFolderPath);
        }

        private void btnSaveRom_Click(object sender, EventArgs e)//Save Rom
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "nds file (*.nds)|*.nds|All files (*.*)|*.*";
            sfd.Title = "Select Save File";
            sfd.FileName = fileName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                lbStatus.Text = "Packing narc...";
                #region repack
                if (Directory.Exists(folderPath + rom.WazaFolderPath))
                {
                    Narc.FromFolder(folderPath + rom.WazaFolderPath).Save(folderPath + rom.WazaNarcPath);
                    Directory.Delete(folderPath + rom.WazaFolderPath, true);
                }
                if (Directory.Exists(folderPath + rom.TextBankFolderPath))
                {
                    Narc.FromFolder(folderPath + rom.TextBankFolderPath).Save(folderPath + rom.TextBankNarcPath);
                    Directory.Delete(folderPath + rom.TextBankFolderPath, true);
                }
                #endregion
                RepackRom(sfd.FileName);
            }
        }
        private void RepackRom(string fileName)
        {
            lbStatus.Text = "Saving ROM...";
            Process repack = new Process();
            repack.StartInfo.FileName = @"Data\ndstool.exe";
            repack.StartInfo.Arguments = "-c " + '"' + fileName + '"' + " -9 " + '"' + folderPath + "arm9.bin" + '"' + " -7 " + '"' + folderPath + "arm7.bin" + '"' + " -y9 " + '"' + folderPath + "y9.bin" + '"' + " -y7 " + '"' + folderPath + "y7.bin" + '"' + " -d " + '"' + folderPath + "data" + '"' + " -y " + '"' + folderPath + "overlay" + '"' + " -t " + '"' + folderPath + "banner.bin" + '"' + " -h " + '"' + folderPath + "header.bin" + '"';
            Application.DoEvents();
            repack.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            repack.StartInfo.CreateNoWindow = true;
            repack.Start();
            repack.WaitForExit();
            //lbStatus.Text = "Unpacking narc...";
            //#region Unpack
            //if (Directory.Exists(folderPath + rom.WazaFolderPath) == false)
            //{
            //    Narc.Open(folderPath + rom.WazaNarcPath).ExtractToFolder(folderPath + rom.WazaFolderPath);
            //}
            //if (Directory.Exists(folderPath + rom.TextBankFolderPath) == false)
            //{
            //    Narc.Open(folderPath + rom.TextBankNarcPath).ExtractToFolder(folderPath + rom.TextBankFolderPath);
            //}
            //#endregion
            lbStatus.Text = "File has been successfully saved!";
        }


        //==========================================================================================

        private void cbxSelectedAnimFile_SelectedIndexChanged(object sender, EventArgs e)//Read Data
        {
            lbStatus.Text = "Loading...";
            FileStream fileStream = File.OpenRead(folderPath + rom.WazaFolderPath + "\\" + $"{cbxSelectedAnimFile.SelectedIndex:D4}");
            ReadWE readWE = new ReadWE();
            tbxAnimFileContent.Text = readWE.GetWEData(fileStream);
            fileStream.Close();
            lbStatus.Text = "Ready";
        }

        private void btnSaveCurrent_Click(object sender, EventArgs e)//Save Data
        {
            lbStatus.Text = "Saving..";
            SaveWE saveWE = new SaveWE();
            saveWE.SaveWEData(folderPath + rom.WazaFolderPath + "\\" + $"{cbxSelectedAnimFile.SelectedIndex:D4}",tbxAnimFileContent.Text);
            lbStatus.Text = "Saved.";
        }

        private void btnRefresh_Click(object sender, EventArgs e)//Refresh
        {
            cbxSelectedAnimFile_SelectedIndexChanged(null, null);
        }


        //==========================================================================================

        private void tsmFunctionHelp_Click(object sender, EventArgs e)//Open Knownfunction Editor
        {
            KnownFunction knownFunction = new KnownFunction();
            knownFunction.Show();
        }

        private void tsmAnimList_Click(object sender, EventArgs e)
        {
            AnimList animList = new AnimList();
            animList.Show();
        } 

        private void DebugWriteAllMoveNames(List<string> names)
        {
            string path = Directory.GetCurrentDirectory() + "\\moves.txt";
            File.WriteAllLines(path, names);
            //FileStream stream = File.OpenWrite(Directory.GetCurrentDirectory() + "\\moves.txt");
            //foreach (string s in names)
            //{
            //    stream.write
            //}
        }

        //==========================================================================================
    }

    
}
