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
using HtmlAgilityPack;
using System.Net;

namespace WEditor
{
    public partial class AnimationDatabaseWindow : Form
    {
        List<string> animationNames = new List<string>();
        string path;
        
        public AnimationDatabaseWindow(List<string> animationNames)
        {
            InitializeComponent();
            this.animationNames = animationNames;
            path = Directory.GetCurrentDirectory() + "\\_anim";
            if (!Directory.Exists(path))
            {
                DialogResult dr = MessageBox.Show(
                    "Animation directory not found, would you like to download all animations from bulbapedia?\n\nThis may take a while.",
                    "Missing animation directory!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );
                if (dr == DialogResult.Yes)
                {
                    Directory.CreateDirectory(path);
                    DownloadAnimationData();
                }
            }
            
        }

        private void DownloadAnimationData()
        {
            List<string> imageList = new List<string>();
            foreach (string move in animationNames)
            {

                var html = $@"https://bulbapedia.bulbagarden.net/wiki/File:{move}_IV.png";
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                

                string imageLink = "";
                foreach(var link in htmlDoc.DocumentNode.Descendants("img"))
                {
                    if (link.Attributes[0].Value.Contains("File:"))
                    {
                        imageLink = "https:" + link.Attributes[1].Value;
                        imageList.Add(imageLink);
                    }
                }
            }

            using (WebClient wb = new WebClient())
            {
                int i = 0;
                foreach (string link in imageList)
                {
                    wb.DownloadFile(link, path + "\\" + i.ToString() + ".png");
                    i++;
                }
            }

        }
    }
}
