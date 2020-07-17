using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace JK4Life
{
    public partial class Form_Main : Form
    {


        private string md5_original = "1cbc984348811f40d0d520a1d43e9106"; // Checksum of 1.0 retail, originally wanted to do MD5 check stuff but idk if needed
        private List<Game> games;

        #region Initialize

        public Form_Main()
        {
            games = new List<Game>();
            InitializeGames();

            Properties.Settings.Default.SettingChanging += SettingChanging;

            InitializeComponent();
            this.Text = "JK4Life v" + Utility.GetReadableVersion();

            PopulateGameList();
            ChangeLaunchTab(games[0].control);

            RefreshProperties();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // I'm keeping this empty method purely out of nostalgia
        }

        private void InitializeGames()
        {
            // Maybe get data from xml/lua files instead of hardcoded? Guess this will work for the time being though

            Game JK = new Game(
                "Jedi Knight",
                "JK",
                new string[] { "JK", "JediKnight" },
                Properties.Settings.Default.JK_Path,
                Properties.Settings.Default.JK_Mods_Path,
                0x0,
                0x0 );

            Game MOTS = new Game(
                "Mysteries of the Sith",
                "MotS",
                new string[] { "JKM" },
                Properties.Settings.Default.MotS_Path,
                Properties.Settings.Default.MotS_Mods_Path,
                0x0,
                0x0);

            games.Add(JK);
            games.Add(MOTS);

        }

        private void PopulateGameList()
        {
            trv_gameList.Nodes.Clear();

            foreach (Game g in games)
            {
                TreeNode node = new TreeNode(g.fullName);
                node.Tag = g;

                trv_gameList.Nodes.Add(node);

                tab_main.TabPages[0].Controls.Add(g.control);
            }

            trv_gameList.SelectedNode = trv_gameList.Nodes[0];
        }

        private void ChangeLaunchTab(GameControl control)
        {
            tab_main.SelectTab(0);

            var page = tab_main.TabPages[0];

            page.Visible = false;

            foreach (Game g in games)
            {
                g.control.Visible = false;
            }

            control.Visible = true;

            page.Visible = true;
        }

        #endregion



        // Big important stuff here
        void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {

            // I hate this line here so much but I have to replace the entire property system later bc it turns out
            // the built in one is dumb with certain things so this gets to stay in the meantime since it works
            Game game = games.Where(i => i.name == e.SettingName.Split('_')[0]).FirstOrDefault();

            switch (e.SettingName)
            {
                case "JK_Path":
                    txt_settings_jkPath.Text = (string)e.NewValue;
                    game.control.UpdateIcon((string)e.NewValue);
                    break;

                case "MotS_Path":
                    txt_settings_motsPath.Text = (string)e.NewValue;
                    game.control.UpdateIcon((string)e.NewValue);
                    break;

                case "JK_Mods_Path":
                    txt_settings_jkMods.Text = (string)e.NewValue;
                    game.control.PopulateModList((string)e.NewValue);
                    break;

                case "MotS_Mods_Path":
                    txt_settings_motsMods.Text = (string)e.NewValue;
                    game.control.PopulateModList((string)e.NewValue);
                    break;

            }

        }





        #region Launch UI
        private void trv_gameList_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = trv_gameList.HitTest(e.X, e.Y);

            if ((info.Node != null) && (info.Node == trv_gameList.SelectedNode))
            {
                tab_main.SelectTab(0);
            }
        }
        private void trv_gameList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Game g = (Game)e.Node.Tag;

            ChangeLaunchTab(g.control);
        }
        #endregion

        #region Settings UI

        private void btn_settings_jkModsBrowse_Click(object sender, EventArgs e)
        {
            BrowseForModFolder(games.Where(i => i.name == "JK").FirstOrDefault());
        }
        private void btn_settings_motsModsBrowse_Click(object sender, EventArgs e)
        {
            BrowseForModFolder(games.Where(i => i.name == "MotS").FirstOrDefault());
        }
        private void btn_settings_jkPathBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFile("Jedi Knight|*.exe", games.Where(i => i.name == "JK").FirstOrDefault());
        }
        private void btn_settings_motsPathBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFile("Mysteries of the Sith|*.exe", games.Where(i => i.name == "MotS").FirstOrDefault());
        }
        
        #endregion

        #region Browsy dialogs

        public static string BrowseForFile(string filename, Game game)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = filename;
                dialog.RestoreDirectory = true;

                // Will be the property path if set, closest path if path is missing, and
                // adhere to dialog.RestoreDirectory behaviour if drive is missing altogether
                dialog.InitialDirectory = Utility.GetClosestPath(game.path);

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(dialog.FileName))
                    {
                        game.path = dialog.FileName;
                        Properties.Settings.Default.Save();

                        return dialog.FileName;
                    }
                }

                return null;
            }


        }
        public static string BrowseForModFolder(Game game)
        {

            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                dialog.RestoreDirectory = true;

                // Will be the property path if set, closest path if path is missing, and adhere to dialog.RestoreDirectory behaviour if drive is missing altogether
                dialog.InitialDirectory = Utility.GetClosestPath(game.modsPath);

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (Directory.Exists(dialog.FileName))
                    {

                        game.modsPath = dialog.FileName;
                        Properties.Settings.Default.Save();

                        return dialog.FileName;
                    }
                }

                return null;
            }
        }

        #endregion


        public static void RefreshProperties()
        {
            // This is just for triggering SettingChangingEvent on every setting so that we don't need to populate lists and such manually
            // Just a placeholder, shouldn't be using this in the future
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                Properties.Settings.Default[currentProperty.Name] = Properties.Settings.Default[currentProperty.Name];
            }
        }


    }
}
