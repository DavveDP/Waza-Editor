using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using APNGLib;
using HtmlAgilityPack;

namespace WEditor
{
    public partial class AnimationDatabaseWindow : Form
    {
        List<string> animationNames = new List<string>();
        Dictionary<string, APNGBox> animationDict = new Dictionary<string, APNGBox>();
        string pathDefault = Directory.GetCurrentDirectory() + "\\_anim" + "\\_Default";
        string pathDP = Directory.GetCurrentDirectory() + "\\_anim" + "\\_DP";
        string pathHGSS = Directory.GetCurrentDirectory() + "\\_anim" + "\\_HGSS";

        public AnimationDatabaseWindow(List<string> animationNames)
        {
            InitializeComponent();
            this.animationNames = animationNames;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\_anim"))
            {
                DialogResult dr = MessageBox.Show(
                    "Animation directory not found, would you like to download all animations from bulbapedia?\n\nThis may take a while.",
                    "Missing animation directory!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                if (dr == DialogResult.Yes)
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\_anim");
                    DownloadAnimationData();
                }
            }
            LoadAnimationList();
        }

        private void DownloadAnimationData()
        {
            List<string> imageList = new List<string>();
            //string HGSSExclusiveMovesPath = Directory.GetCurrentDirectory() + "\\" + "DPPt.txt";
            //List<string> HGSSExclusiveMoves = new List<string>();
            //foreach (string move in animationNames)
            //{

            //    var html = $@"https://bulbapedia.bulbagarden.net/wiki/File:{move}_PtHGSS.png";
            //    HtmlWeb web = new HtmlWeb();
            //    var htmlDoc = web.Load(html);


            //    string imageLink = "";
            //    foreach (var link in htmlDoc.DocumentNode.Descendants("img"))
            //    {
            //        if (link.Attributes[0].Value.Contains("File:"))
            //        {
            //            imageLink = "https:" + link.Attributes[1].Value;
            //            HGSSExclusiveMoves.Add(imageLink);
            //        }
            //    }
            //}
            //using (StreamWriter wr = new StreamWriter(File.OpenWrite("PtHGSS.txt")))
            //{
            //    foreach (string url in HGSSExclusiveMoves)
            //    {
            //        wr.Write("\t\t\t\"" + url + '\"' + ',' + '\n');
            //    }
            //}
            //return;

            //using (StreamWriter writer = new StreamWriter(File.OpenWrite("urls.txt")))
            //{
            //    foreach (string s in imageList)
            //    {
            //        writer.Write("\t\t\t\"" + s + '\"' + ',' + '\n');
            //    }
            //}

            using (WebClient wb = new WebClient())
            {
                int i = 0;
                foreach (string move in animationNames)
                {
                    if (AnimationDatabase.animUrlsDefault[i].Contains(move))
                    {
                        wb.DownloadFile(AnimationDatabase.animUrlsDefault[i], pathDefault + "\\" + i.ToString() + ".png");
                        i++;
                    }
                    else if (AnimationDatabase.animUrlsDP[i].Contains(move))
                    {
                        wb.DownloadFile(AnimationDatabase.animUrlsDP[i], pathDPExclusive + "\\" + i.ToString() + ".png");
                        i++;
                    }
                    else
                    {
                        wb.DownloadFile(AnimationDatabase.animUrlsDP[i], pathDPExclusive + "\\" + i.ToString() + ".png");
                        i++;
                    }
                }
                foreach (string link in AnimationDatabase.animUrlsDefault)
                {
                    wb.DownloadFile(link, path + "\\" + i.ToString() + ".png");
                    i++;
                }
            }

        }
        private void LoadAnimationList()
        {
            int i = 1;
            foreach (string file in Directory.GetFiles(path))
            {
                try
                {
                    //APNG png = new APNG();
                    //using (Stream s = File.OpenRead(file))
                    //{
                    //    png.Load(s);
                    //}
                    //APNGBox pbA = new APNGBox(png);
                    //animationDict.Add(animationNames[i], pbA);
                    lbxAnimationList.Items.Add(animationNames[i]);
                    i++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Could not locate animated images properly, click the re-download button",
                        "Image loading error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    break;
                }
            }
            lbxAnimationList.SelectedIndex = 0;
            Update();
        }

        private void lbxAnimationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var previous = flpAnimationViewer.Controls.Cast<APNGBox>();
                foreach (APNGBox box in previous)
                {
                    box.Stop();
                    box.Dispose();
                }
            }
            catch
            {

            }
            

            GC.Collect();
            GC.WaitForPendingFinalizers();
            flpAnimationViewer.Controls.Clear();

            APNG png = new APNG();
            using (Stream s = File.OpenRead(path + "\\" + lbxAnimationList.SelectedIndex.ToString() + ".png"))
            {
                png.Load(s);
            }
            APNGBox pbA = new APNGBox(png);
            //animationDict.Add(animationNames[i], pbA);
            flpAnimationViewer.Controls.Add(pbA);
            pbA.Start();
            //animationDict[lbxAnimationList.SelectedItem.ToString()].Start();
        }

        private void btnRedownloadDatabase_Click(object sender, EventArgs e)
        {
            DownloadAnimationData();
            Update();
        }
		public static class AnimationDatabase
		{
			public enum AnimationType
			{
				Default,
				DP_Exlusive,
				HGSS_Exlusive
			}

			public static List<string> animUrlsDefault = new List<string>()
		{
			#region static links
            "https://cdn2.bulbagarden.net/upload/e/ea/Pound_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/16/Karate_Chop_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/84/DoubleSlap_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f5/Comet_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6c/Mega_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/cd/Pay_Day_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/dc/Fire_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/99/Ice_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e4/ThunderPunch_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a9/Scratch_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e3/ViceGrip_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/64/Guillotine_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/25/Razor_Wind_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/87/Swords_Dance_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Cut_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/23/Gust_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ed/Wing_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9b/Whirlwind_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c0/Bind_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/57/Slam_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d4/Vine_Whip_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/60/Stomp_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/11/Double_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b8/Jump_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f4/Rolling_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/69/Sand-Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b4/Headbutt_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5c/Horn_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3a/Fury_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/17/Horn_Drill_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6c/Tackle_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0a/Body_Slam_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0a/Wrap_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ea/Take_Down_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9a/Thrash_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/aa/Double-Edge_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8c/Tail_Whip_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/26/Poison_Sting_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e9/Twineedle_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8b/Pin_Missile_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e9/Leer_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/40/Bite_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7c/Growl_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/13/Roar_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d4/Sing_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a1/Supersonic_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6d/SonicBoom_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/04/Disable_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c7/Acid_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/82/Ember_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ef/Flamethrower_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/ff/Mist_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b6/Water_Gun_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/09/Hydro_Pump_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9e/Surf_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ef/Ice_Beam_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bc/Blizzard_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/81/Psybeam_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2b/BubbleBeam_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c3/Aurora_Beam_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/af/Peck_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9c/Drill_Peck_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f3/Submission_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ee/Low_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/67/Counter_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/50/Seismic_Toss_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/30/Strength_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/25/Absorb_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/06/Mega_Drain_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ee/Leech_Seed_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e7/Growth_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/81/SolarBeam_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c8/PoisonPowder_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0f/Stun_Spore_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a4/Sleep_Powder_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ed/Petal_Dance_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f0/String_Shot_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b9/Dragon_Rage_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6b/Fire_Spin_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/55/ThunderShock_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/ae/Thunderbolt_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0d/Thunder_Wave_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2e/Rock_Throw_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Earthquake_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/12/Dig_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/07/Toxic_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/49/Confusion_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e1/Hypnosis_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Meditate_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7e/Quick_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/75/Rage_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/95/Teleport_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1a/Night_Shade_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/38/Mimic_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/96/Screech_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3d/Double_Team_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/30/Harden_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8c/Minimize_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/19/SmokeScreen_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Confuse_Ray_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Withdraw_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9a/Defense_Curl_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/ba/Barrier_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/93/Light_Screen_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2e/Haze_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4c/Reflect_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8b/Focus_Energy_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/83/Bide_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c6/Metronome_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b5/Mirror_Move_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e1/Selfdestruct_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ed/Egg_Bomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d0/Lick_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/15/Smog_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/33/Sludge_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/df/Bone_Club_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3a/Waterfall_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1e/Clamp_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d6/Swift_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a8/Skull_Bash_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/dc/Spike_Cannon_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Constrict_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e0/Amnesia_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9b/Kinesis_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2b/Softboiled_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Hi_Jump_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/56/Glare_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8e/Dream_Eater_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7c/Poison_Gas_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/24/Barrage_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f0/Leech_Life_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1a/Lovely_Kiss_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/13/Sky_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1c/Transform_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/11/Bubble_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/cc/Dizzy_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/81/Spore_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Flash_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d7/Psywave_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d1/Splash_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ef/Acid_Armor_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/26/Crabhammer_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/24/Explosion_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7f/Fury_Swipes_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Bonemerang_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e8/Rest_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/14/Rock_Slide_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0f/Sharpen_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e5/Conversion_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bf/Tri_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0b/Super_Fang_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/19/Slash_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3b/Substitute_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/84/Struggle_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8d/Sketch_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/53/Triple_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d8/Thief_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1e/Spider_Web_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/17/Mind_Reader_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/53/Flame_Wheel_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4f/Snore_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/ff/Flail_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a4/Conversion_2_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e1/Aeroblast_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/04/Cotton_Spore_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1a/Reversal_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Spite_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c9/Powder_Snow_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/08/Protect_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/ae/Scary_Face_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b6/Faint_Attack_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/31/Sweet_Kiss_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0c/Belly_Drum_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/ba/Sludge_Bomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4e/Mud-Slap_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Octazooka_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Spikes_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/79/Zap_Cannon_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/28/Foresight_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0b/Destiny_Bond_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/eb/Perish_Song_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c6/Icy_Wind_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/72/Detect_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3e/Bone_Rush_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f1/Lock-On_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/25/Sandstorm_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5b/Giga_Drain_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f9/Endure_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/06/Charm_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/18/Rollout_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4d/False_Swipe_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d9/Swagger_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/60/Milk_Drink_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9c/Spark_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a0/Fury_Cutter_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/24/Steel_Wing_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/08/Mean_Look_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0d/Attract_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fe/Sleep_Talk_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/63/Heal_Bell_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/27/Return_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Present_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/06/Frustration_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fc/Safeguard_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bb/Pain_Split_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/60/Magnitude_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fb/DragonBreath_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/13/Baton_Pass_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4b/Encore_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/77/Pursuit_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4d/Rapid_Spin_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/30/Sweet_Scent_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/17/Iron_Tail_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Metal_Claw_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ee/Vital_Throw_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/ab/Morning_Sun_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/55/Synthesis_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ed/Moonlight_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8e/Cross_Chop_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b6/Twister_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6f/Sunny_Day_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4b/Mirror_Coat_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c8/Psych_Up_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/72/AncientPower_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/cb/Shadow_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c1/Future_Sight_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bf/Rock_Smash_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c0/Whirlpool_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ea/Beat_Up_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/38/Fake_Out_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ee/Stockpile_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d0/Spit_Up_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6b/Swallow_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/15/Heat_Wave_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b5/Torment_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e9/Flatter_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/78/Will-O-Wisp_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a5/Memento_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/40/Facade_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c3/Focus_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/66/SmellingSalt_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/db/Follow_Me_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2b/Nature_Power_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d8/Charge_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/ac/Taunt_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/ce/Helping_Hand_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/54/Trick_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/48/Role_Play_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Wish_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f5/Assist_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8e/Ingrain_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d6/Magic_Coat_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/57/Recycle_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/34/Revenge_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Brick_Break_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7f/Yawn_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/13/Knock_Off_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Endeavor_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b3/Eruption_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2f/Skill_Swap_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f9/Imprison_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fc/Refresh_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5f/Grudge_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Snatch_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d6/Dive_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/62/Arm_Thrust_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/77/Camouflage_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0c/Tail_Glow_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b3/Luster_Purge_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2e/Mist_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/af/FeatherDance_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bc/Teeter_Dance_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bb/Blaze_Kick_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/07/Mud_Sport_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b3/Ice_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Needle_Arm_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/dd/Slack_Off_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/95/Hyper_Voice_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bf/Poison_Fang_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/02/Crush_Claw_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fe/Blast_Burn_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f5/Meteor_Mash_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d3/Astonish_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/ff/Weather_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/57/Aromatherapy_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/82/Fake_Tears_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/82/Air_Cutter_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/78/Overheat_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/df/Odor_Sleuth_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/65/Rock_Tomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Silver_Wind_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/77/Metal_Sound_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a5/GrassWhistle_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6a/Tickle_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a2/Cosmic_Power_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fe/Water_Spout_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1d/Signal_Beam_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/bd/Shadow_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8e/Extrasensory_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3f/Sand_Tomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/30/Sheer_Cold_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/60/Muddy_Water_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7a/Bullet_Seed_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f1/Aerial_Ace_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b7/Icicle_Spear_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b0/Iron_Defense_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/49/Block_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0b/Howl_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/42/Dragon_Claw_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Frenzy_Plant_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/75/Bulk_Up_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0e/Bounce_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c5/Mud_Shot_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/12/Poison_Tail_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8c/Covet_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c3/Volt_Tackle_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/65/Magical_Leaf_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6a/Water_Sport_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3f/Calm_Mind_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/d3/Leaf_Blade_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/99/Dragon_Dance_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0e/Rock_Blast_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/8a/Shock_Wave_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f1/Water_Pulse_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Doom_Desire_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9d/Roost_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/da/Gravity_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/4c/Miracle_Eye_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/ba/Wake-Up_Slap_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b9/Hammer_Arm_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b2/Gyro_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/98/Healing_Wish_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/65/Brine_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/da/Natural_Gift_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1d/Feint_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/42/Pluck_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/69/Tailwind_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/98/Acupressure_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1f/Metal_Burst_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/34/U-turn_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/99/Close_Combat_IV.png",
			"https://cdn2.bulbagarden.net/upload/b/b4/Payback_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c1/Assurance_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/43/Embargo_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c5/Fling_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Psycho_Shift_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2a/Trump_Card_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/52/Heal_Block_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/39/Wring_Out_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f4/Power_Trick_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f6/Gastro_Acid_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Lucky_Chant_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/eb/Me_First_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/17/Copycat_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a8/Power_Swap_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/ef/Guard_Swap_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/94/Punishment_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9f/Last_Resort_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0d/Worry_Seed_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fa/Sucker_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/db/Toxic_Spikes_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Heart_Swap_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/cd/Aqua_Ring_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/51/Magnet_Rise_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Flare_Blitz_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/ca/Force_Palm_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7a/Rock_Polish_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5a/Poison_Jab_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7f/Dark_Pulse_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9a/Night_Slash_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e1/Aqua_Tail_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/2f/Seed_Bomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/c2/Air_Slash_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7f/X-Scissor_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6c/Bug_Buzz_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/41/Dragon_Pulse_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/42/Dragon_Rush_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f6/Power_Gem_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/83/Drain_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/32/Vacuum_Wave_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/86/Focus_Blast_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/de/Energy_Ball_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f8/Brave_Bird_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/90/Earth_Power_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/98/Switcheroo_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Nasty_Plot_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/55/Bullet_Punch_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/db/Avalanche_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/55/Ice_Shard_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e6/Shadow_Claw_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/0c/Thunder_Fang_IV.png",
			"https://cdn2.bulbagarden.net/upload/4/49/Ice_Fang_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/ff/Fire_Fang_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6c/Shadow_Sneak_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/50/Mud_Bomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/7d/Psycho_Cut_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e7/Zen_Headbutt_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5b/Mirror_Shot_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f3/Flash_Cannon_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f9/Rock_Climb_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/18/Defog_IV.png",
			"https://cdn2.bulbagarden.net/upload/8/89/Trick_Room_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/66/Draco_Meteor_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/10/Discharge_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/5f/Lava_Plume_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/ab/Leaf_Storm_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f7/Rock_Wrecker_IV.png",
			"https://cdn2.bulbagarden.net/upload/6/6c/Cross_Poison_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/26/Gunk_Shot_IV.png",
			"https://cdn2.bulbagarden.net/upload/e/e5/Iron_Head_IV.png",
			"https://cdn2.bulbagarden.net/upload/0/06/Magnet_Bomb_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a7/Stone_Edge_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/10/Captivate_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f3/Stealth_Rock_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/35/Grass_Knot_IV.png",
			"https://cdn2.bulbagarden.net/upload/9/9a/Chatter_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/25/Judgment_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/dc/Bug_Bite_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3f/Charge_Beam_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1a/Wood_Hammer_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f7/Aqua_Jet_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a4/Attack_Order_IV.png",
			"https://cdn2.bulbagarden.net/upload/7/75/Defend_Order_IV.png",
			"https://cdn2.bulbagarden.net/upload/d/dd/Heal_Order_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/13/Head_Smash_IV.png",
			"https://cdn2.bulbagarden.net/upload/c/cc/Double_Hit_IV.png",
			"https://cdn2.bulbagarden.net/upload/a/a0/Roar_of_Time_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/fd/Lunar_Dance_IV.png",
			"https://cdn2.bulbagarden.net/upload/3/3d/Crush_Grip_IV.png",
			"https://cdn2.bulbagarden.net/upload/1/1b/Magma_Storm_IV.png",
			"https://cdn2.bulbagarden.net/upload/2/29/Seed_Flare_IV.png",
			"https://cdn2.bulbagarden.net/upload/5/54/Ominous_Wind_IV.png",
			"https://cdn2.bulbagarden.net/upload/f/f7/Shadow_Force_IV.png"
			#endregion static links
		};
			public static List<string> animUrlsHGSS = new List<string>()
		{
			#region static links
			"https://cdn2.bulbagarden.net/upload/8/8c/Fly_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/a/aa/Mega_Kick_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/1/17/Hyper_Beam_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/5/5b/Thunder_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/a/a2/Fissure_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/b5/Psychic_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/3/33/Agility_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/e/ef/Fire_Blast_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/2/2d/Hyper_Fang_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/3/34/Nightmare_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/bc/Outrage_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/bd/Sacred_Fire_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/a/a5/DynamicPunch_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/9/98/Megahorn_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/0/07/Crunch_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/6/6f/ExtremeSpeed_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/c/ca/Superpower_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/d/d4/Hydro_Cannon_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/3/37/Sky_Uppercut_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/6/6e/Psycho_Boost_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/bc/Aura_Sphere_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/2/23/Giga_Impact_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/5/5b/Power_Whip_HGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/b1/Dark_Void_HGSS.png"
			#endregion static links
		};
			public static List<string> animUrlsDPPt = new List<string>()
		{
			#region static links
			"https://cdn2.bulbagarden.net/upload/d/d4/Fly_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/7/7a/Mega_Kick_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/5/50/Hyper_Beam_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/b/b0/Thunder_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/4/44/Fissure_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/d/d2/Psychic_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/8/8a/Agility_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/8/86/Fire_Blast_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/8/8d/Hyper_Fang_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/1/10/Nightmare_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/2/2c/Outrage_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/9/9e/Sacred_Fire_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/3/39/DynamicPunch_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/4/45/Megahorn_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/f/f7/Crunch_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/f/f6/ExtremeSpeed_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/c/cc/Superpower_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/c/c5/Hydro_Cannon_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/7/70/Sky_Uppercut_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/c/cd/Psycho_Boost_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/f/f9/Aura_Sphere_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/e/e3/Giga_Impact_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/a/ac/Power_Whip_DPPt.png",
			"https://cdn2.bulbagarden.net/upload/d/d3/Dark_Void_DPPt.png"
			#endregion static links
		};
			public static List<string> animUrlsDP = new List<string>()
		{
            #region static links
			"https://cdn2.bulbagarden.net/upload/1/15/Razor_Leaf_DP.png",
			"https://cdn2.bulbagarden.net/upload/2/25/Recover_DP.png",
			"https://cdn2.bulbagarden.net/upload/8/84/Mach_Punch_DP.png",
			"https://cdn2.bulbagarden.net/upload/b/bd/Hidden_Power_DP.png",
			"https://cdn2.bulbagarden.net/upload/8/83/Rain_Dance_DP.png",
			"https://cdn2.bulbagarden.net/upload/c/ce/Uproar_DP.png",
			"https://cdn2.bulbagarden.net/upload/5/5d/Hail_DP.png",
			"https://cdn2.bulbagarden.net/upload/2/2d/Spacial_Rend_DP.png"
            #endregion static links
        };
			public static List<string> animUrlsPtHGSS = new List<string>()
		{
			#region static links
			"https://cdn2.bulbagarden.net/upload/4/49/Razor_Leaf_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/e/e4/Recover_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/1/1e/Mach_Punch_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/7/75/Hidden_Power_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/b/b7/Rain_Dance_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/f/f5/Uproar_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/1/12/Hail_PtHGSS.png",
			"https://cdn2.bulbagarden.net/upload/8/85/Spacial_Rend_PtHGSS.png"
			#endregion static links
		};

			public static string animDefaultPath = "_anim\\Default";
			public static string animHGSSPath = "_anim\\HGSS";
			public static string animDPPtPath = "_anim\\DPPt";
			public static string animDPPath = "_anim\\DP";
			public static string animPtHGSSPath = "_anim\\PtHGSS";

			public static void LoadAnimationDatabaseWindow(List<string> names)
			{
				AnimationDatabaseWindow animationDatabaseWindow = new AnimationDatabaseWindow(names);
				animationDatabaseWindow.Show();
			}

            public static string getAnimFromRomID(string Id)
            {
                switch (Id[0])
                {
					case 'I':
						animDefaultPath.con
                }
            }
        }
	}
}
