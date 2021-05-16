using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WEditor
{
    class SaveWE
    {
        public SaveWE()
        {
            ;
        }

        public void SaveWEData(string fileName,string toSaveText)//Save
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.Create(fileName).Close();
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
            {
                string[] del = { "\r\n", " " };
                string[] data = toSaveText.Split(del,StringSplitOptions.RemoveEmptyEntries);
                int length = data.Length;
                for(int i = 0;i < length; i++)
                {
                    if (data[i].Contains("0x"))
                    {
                        writer.Write(int.Parse(data[i].Substring(2, data[i].Length - 2), System.Globalization.NumberStyles.HexNumber));
                    }
                    else
                    {
                        writer.Write(GetCmd(data[i]));
                    }
                }
            }
        }

        private uint GetCmd(string cmd)
        {
            switch (cmd)
            {
                case "Wait":
                    return 0x0;
                case "Wait_Func":
                    return 0x1;
                case "While":
                    return 0x2;
                case "WhileEnd":
                    return 0x3;
                case "End":
                    return 0x4;
                case "CallEnd":
                    return 0xb;
                case "CheckTurn":
                    return 0xd;
                case "ChangeBackG":
                    return 0x10;
                case "ToChangeBackG":
                    return 0x11;
                case "BackBackG":
                    return 0x12;
                case "WaitBack":
                    return 0x13;
                case "WaitBack2":
                    return 0x14;
                case "SetBack":
                    return 0x15;
                case "PlaySound":
                    return 0x16;
                case "SetSound":
                    return 0x17;
                case "SomethingSound":
                    return 0x18;
                case "RepeatSound":
                    return 0x19;
                case "WaitSound":
                    return 0x1A;
                case "LoadAnim":
                    return 0x2e;
                case "ApplyCmd":
                    return 0x2d;
                case "WaitAnim":
                    return 0x32;
                case "SetPlayAnim":
                    return 0x33;
                case "Init":
                    return 0x38;
                case "ChangeCam":
                    return 0x3E;
                case "PlayCry":
                    return 0x41;
                case "StopCry":
                    return 0x42;
                case "Transform_44":
                    return 0x44;
                case "Contest_47":
                    return 0x47;
                default:
                    break;
            }
            if (cmd.Contains("Cmd_"))
            {
                return uint.Parse(cmd.Substring(4, (cmd.Length - 4)), System.Globalization.NumberStyles.HexNumber);
            }
            return 0xFFFFFFFF;
        }
    }
}
