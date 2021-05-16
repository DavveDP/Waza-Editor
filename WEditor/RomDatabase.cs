using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace WEditor
{
	public static class RomDatabaseHandler
	{
		public static void rebuildDatabase()
		{
			RomDatabase database = new RomDatabase();

			database.roms.Add(new Rom()
			{
				Id = "CPUE",
				FullName = "Pokémon Platinum Version",
				Region = "USA",
				WazaFolderPath = @"data\wazaeffect\wearc",
				WazaNarcPath = @"data\wazaeffect\we.arc",
				TextBankFolderPath = @"data\msgdata\pl_msg",
				TextBankNarcPath = @"data\msgdata\pl_msg.narc",
				TextBank = 647
			}) ;
				

			database.roms.Add(new Rom()
			{
				Id = "IPKE",
				FullName = "Pokémon HeartGold Version",
				Region = "USA",
				WazaFolderPath = @"data\a\0\1\0_ext",
				WazaNarcPath = @"data\a\0\1\0",
				TextBankFolderPath = @"data\a\0\2\7_ext",
				TextBankNarcPath = @"data\a\0\2\7",
				TextBank = 750
			});


            //Add new rom entries here:



            //==============================

            XmlSerializer writer = new XmlSerializer(typeof(RomDatabase));
            var path = Directory.GetCurrentDirectory() + "\\" + "RomDatabase.xml";
            FileStream file = File.Create(path);

            writer.Serialize(file, database);
            file.Close();

        }
		public static Rom GetRomFromDatabase(string Id)
        {
			string path = Directory.GetCurrentDirectory() + "\\" + "RomDatabase.xml";
			if (!File.Exists(path))
            {
				MessageBox.Show(
					"Rom Database not found! \n\nPlease restart the program and the database will be rebuilt.", 
					"Fatal Error", 
					MessageBoxButtons.OK, 
					MessageBoxIcon.Error
					);
				return null;
            }
			StreamReader databaseFile = new StreamReader(path);
			XmlSerializer serializer = new XmlSerializer(typeof(RomDatabase));
			RomDatabase database = (RomDatabase)serializer.Deserialize(databaseFile);
            
			foreach (Rom rom in database.roms)
            {
				if (rom.Id == Id)
                {
					return rom;
                }
            }
            return null;
		}
	}

	
	public class Rom
	{
		public string Id { get; set; }
		public string FullName { get; set; }
		public string Region { get; set; }
		public string WazaFolderPath { get; set; }
		public string WazaNarcPath { get; set; }
		public string TextBankFolderPath { get; set; }
		public string TextBankNarcPath { get; set; }
		public int TextBank { get; set; }
		public Bitmap icon { get; set; }

		public override string ToString()
        {
			return FullName + "\n" + "Game Code: " + "[" + Id + "]\n" + "Region: " + Region;
		}
    }

	[XmlRoot]
	public class RomDatabase
    {
		[XmlArray]
		public List<Rom> roms = new List<Rom>();
	}

}