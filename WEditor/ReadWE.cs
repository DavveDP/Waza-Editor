using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEditor
{
    class ReadWE
    {
        public ReadWE()
        {
            ;
        }

        public string GetWEData(FileStream fileStream)
        {
            StringBuilder builder = new StringBuilder();
            using(BinaryReader reader = new BinaryReader(fileStream))
            {
                int fileLength = (int)fileStream.Length;
                while(reader.BaseStream.Position != fileLength)
                {
                    (string cmdName, int argCount) cmd = GetCmd(reader.ReadInt32());
                    builder.Append(cmd.cmdName);
                    //Special Cmd
                    if(cmd.cmdName == "End")
                    {
                        builder.Append("\r\n");
                    }
                    if(cmd.cmdName == "ApplyCmd")
                    {
                        int cmdCheck = (int)reader.ReadInt32();
                        cmd.argCount = GetApplyCmdArg(cmdCheck) - 1;
                        builder.Append($" 0x{cmdCheck:x}");
                        if(cmdCheck == 0x22 || cmdCheck == 0x4b)
                        {
                            cmd.argCount = reader.ReadInt32();
                            builder.Append($" 0x{cmd.argCount:x}");
                        }
                    }
                    if(cmd.cmdName == "Cmd_37")
                    {
                        int cmdCheck = (int)reader.ReadInt32();
                        cmd.argCount = cmdCheck;
                        builder.Append($" 0x{cmdCheck:x}");
                    }
                    if(cmd.cmdName == "Cmd_4e")
                    {
                        for(int i = 0;i < 8; i++)
                        {
                            builder.Append(" 0x" + reader.ReadInt32().ToString("x"));
                        }
                        int cmdCheck = (int)reader.ReadInt32();
                        cmd.argCount = cmdCheck;
                        builder.Append($" 0x{cmdCheck:x}");
                    }
                    //ReadCmd
                    for (int j = 0; j < cmd.argCount; j++)
                    {
                        builder.Append(" 0x" + reader.ReadInt32().ToString("x"));
                    }
                    builder.Append("\r\n");
                }
            }
            return builder.ToString();
        }

        private (string cmdName,int argCount) GetCmd(int num)
        {
            return num switch
            {
                0x0 => ("Wait", 1),
                0x1 => ("Wait_Func", 0),
                //See Tail Whip
                0x2 => ("While", 1),
                //See Tail Whip
                0x3 => ("WhileEnd", 0),
                0x4 => ("End", 0),
                0x5 => ("Cmd_5", 1),
                0x6 => ("Cmd_6", 1),
                0x7 => ("Cmd_7", 1),
                0x8 => ("Cmd_8", 2),
                0x9 => ("Cmd_9", 0),
                0xA => ("Cmd_a", 1),
                0xB => ("CallEnd", 0),
                0xC => ("Cmd_c", 2),
                0xD => ("CheckTurn", 2),
                0x10 => ("ChangeBackG", 2),
                0x11 => ("ToChangeBackG", 2),
                0x12 => ("BackBackG", 2),
                0x13 => ("WaitBack", 0),
                0x14 => ("WaitBack2", 0),
                0x15 => ("SetBack", 1),
                0x16 => ("PlaySound", 2),
                0x17 => ("SetSound", 1),
                0x18 => ("SomethingSound", 5),
                0x19 => ("RepeatSound", 4),
                0x1A => ("WaitSound", 3),
                0x1F => ("Cmd_1f", 2),
                0x20 => ("Cmd_20", 1),
                0x2E => ("LoadAnim", 3),
                0x2D => ("ApplyCmd", 0),
                0x2F => ("Cmd_2f", 4),
                0x30 => ("Cmd_30", 8),
                0x31 => ("Cmd_31", 6),
                0x32 => ("WaitAnim", 0),
                0x33 => ("SetPlayAnim", 3),
                0x35 => ("Cmd_35", 1),
                0x37 => ("Cmd_37", 7),
                0x38 => ("Init", 0),
                0x39 => ("Cmd_39", 1),
                0x3A => ("Cmd_3a", 4),
                0x3B => ("Cmd_3b", 0),
                0x3C => ("Cmd_3c", 1),
                0x3E => ("ChangeCam", 2),
                0x40 => ("Cmd_40", 3),
                0x41 => ("PlayCry", 3),
                0x42 => ("StopCry", 1),
                0x43 => ("Cmd_43", 0),
                0x44 => ("Transform_44", 1),
                0x45 => ("Cmd_45", 1),
                0x47 => ("Contest_47", 1),
                0x48 => ("Cmd_48", 1),
                0x49 => ("Cmd_49", 8),
                //Surf
                0x4A => ("Cmd_4a", 2),
                //Surf
                0x4B => ("Cmd_4b", 3),
                //Surf
                0x4C => ("Cmd_4c", 2),
                //Surf
                0x4D => ("Cmd_4d", 2),
                //String Shot
                0x4E => ("Cmd_4e", 0),
                //Surf
                0x4F => ("Cmd_4f", 8),
                0x50 => ("Cmd_50", 1),
                0x51 => ("Cmd_51", 2),
                //Rollingkick : 27
                0x52 => ("Cmd_52", 3),
                //Rollingkick : 27
                0x53 => ("Cmd_53", 1),
                _ => ("Cmd_" + num.ToString("x"), 0),
            };
        }

        private int GetApplyCmdArg(int cmdCheck)
        {
            switch (cmdCheck)
            {
                case 0x0://Unused??Debug?Test? file;468-
                    return 2;
                case 0x1://Unused??Debug?Test? file;468-
                    return 2;
                case 0x2://Unused??Debug?Test? file;468-
                    return 2;
                case 0x3://Unused??Debug?Test? file;468-
                    return 2;
                case 0x4://Peck
                    return 5;
                case 0x6://Bulk Up
                    return 3;
                case 0x7://Double Team
                    return 3;
                case 0x8://Rolling kick
                    return 2;
                case 0x9://Drill peck
                    return 2;
                case 0xA://Submission
                    return 5;
                case 0xB://Future Sight
                    return 2;
                case 0xD://Growth
                    return 2;
                case 0xE://Meditate
                    return 2;
                case 0xF://Teleport
                    return 2;
                case 0x10://Flash
                    return 2;
                case 0x11://Night Shade
                    return 2;
                case 0x12://Night Shade
                    return 2;
                case 0x13://Splash
                    return 2;
                case 0x14://spite : 180
                    return 2;
                case 0x16://Minimize
                    return 3;
                case 0x17://Faint Attack
                    return 3;
                case 0x18://Earthquake
                    return 3;
                case 0x19://Charm
                    return 2;
                case 0x1A://Nightmare
                    return 3;
                case 0x1B://Flail
                    return 3;
                case 0x1C://Magnitude
                    return 3;
                case 0x1E://Vital Throw
                    return 2;
                case 0x20://Mement 262
                    return 2;
                case 0x21://Mega Punch
                    return 7;
                case 0x22://Fire Punch
                    return 8;
                case 0x23://Disable
                    return 10;
                case 0x24://file 1
                    return 7;
                case 0x26://Brave bird
                    return 8;
                case 0x29://Fake Out 252
                    return 4;
                case 0x2A://bind file20
                    return 10;
                case 0x2b://Fake Out
                    return 2;
                case 0x2C://Surf
                    return 10;
                case 0x2D://Muddy Water 330
                    return 10;
                case 0x2F://Megahorn
                    return 2;
                case 0x28://Whirlwind
                    return 4;
                case 0x30://Megahorn
                    return 2;
                case 0x31://Surf
                    return 3;
                case 0x32://Double Team
                    return 4;
                case 0x33://Extremspeed
                    return 5;
                case 0x34://bind
                    return 5;
                case 0x35://Spit up 255
                    return 7;
                case 0x39://File33 - tackle
                    return 6;
                case 0x3A://Mimic
                    return 2;
                case 0x3B://Shadow Punch
                    return 3;
                case 0x3C://TailWhip
                    return 5;
                case 0x3D://Whirlwind
                    return 4;
                case 0x3E://Whirlwind
                    return 3;
                case 0x3F://Disable
                    return 8;
                case 0x41://Supersonic
                    return 8;
                case 0x42://Pin Missoile
                    return 8;
                case 0x43://Dig
                    return 7;
                case 0x44://MegaKick
                    return 7;
                case 0x45://Transform
                    return 6;
                case 0x46://Role Play 272
                    return 3;
                case 0x48://Blast Burn 307
                    return 12;
                case 0x4a://Disable
                    return 3;
                case 0x4B://Blast Burn 307,Dark void
                    return 0;
                case 0x4c://Nightmare
                    return 3;
                case 0x4e://file 0
                    return 3;
                case 0x4f://file 0
                    return 3;
                case 0x53://Harden
                    return 4;
                default:
                    return 0;
            }

        }
    }
}
