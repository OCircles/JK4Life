using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace JK4Life
{
    public partial class GameControl : UserControl
    {

        // Argument notes so I dont forget
        // -windowgui
        // -displayconfig
        // -path <short path>
        // -framerate
        // -dev
        // -verbose <some number, 1-3 I think>

        Game game;
        Bitmap icon;


        public GameControl(Game game)
        {
            this.game = game;

            InitializeComponent();

            lbl_currentMod.Text = "";
            this.Dock = DockStyle.Fill;
            this.Visible = false;

            lbl_title.Text = game.fullName;


            PopulateModList(game.modsPath);
            PopulatePatchList();

            UpdateIcon(game.path);

        }

        private void Launch()
        {
            string path = game.path;
            string mods = game.modsPath;
            string mod = "";

            List<string> patches = new List<string>();

            if ( string.IsNullOrEmpty( path ) || !File.Exists( path ) )
            {
                MessageBox.Show( game.fullName + " executable could not be located!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                path = Form_Main.BrowseForFile( game.fullName + "|*.exe", game );

                if ( string.IsNullOrEmpty(path) ) return;

            }

            foreach (ListViewItem patch in lvw_assembly.CheckedItems)
                patches.Add(patch.SubItems[0].Text); 

            if (lvw_mods.SelectedItems.Count != 0) mod = mods + "\\" + lvw_mods.SelectedItems[0].Text;


            if (patches.Count != 0)
            {
                var a = AssemblyPatcher.ReadPatchList(game.name.ToLower(), patches, GetResourceTextFile("patches.xml"));

                var patchedExecutablePath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "_Patched.exe";

                AssemblyPatcher.PatchExecutable(a, path, patchedExecutablePath);

                path = patchedExecutablePath;
            }

            string arguments = txt_arguments.Text;

            if (mod != "") arguments += " -path " + Utility.ShortPath(mod);

            ProcessStartInfo startInfo = new ProcessStartInfo(path, arguments);
            startInfo.WorkingDirectory = Path.GetDirectoryName(path);

            try
            {
                Process.Start(startInfo);
            }
            catch (Win32Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }

        }


        #region UI

        public void UpdateIcon(string path)
        {
            if ( File.Exists(path) )
            {
                icon = Icon.ExtractAssociatedIcon(path).ToBitmap();
                pic_gameIcon.Image = icon;
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Launch();
        }

        #endregion

        #region Populate lists

        public void PopulateModList(string path)
        {

            lvw_mods.Items.Clear();

            if (Directory.Exists(path))
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    // Check if subdirectories contain either .gob or .jk
                    bool _isMod = false;
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        var ext = Path.GetExtension(file);
                        if (ext == ".gob" || ext == ".goo" || ext == ".jk")
                        {
                            _isMod = true;
                            break;
                        }
                    }
                    if ( _isMod ) lvw_mods.Items.Add(Path.GetFileName(dir));
                }

            }

        }
        public void PopulatePatchList()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetResourceTextFile("patches.xml"));

            var gameNode = doc.DocumentElement.SelectSingleNode("/games/" + game.name.ToLower());

            lvw_assembly.Items.Clear();

            if (gameNode.ChildNodes != null)
            {
                foreach (XmlNode node in gameNode.ChildNodes)
                {
                    lvw_assembly.Items.Add(node.Attributes["name"]?.InnerText);
                }
            }
        }

        #endregion

        #region Mod list drag & drop

        private void lvw_mods_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lvw_mods_DragDrop(object sender, DragEventArgs e)
        {
            if ( !string.IsNullOrEmpty(game.modsPath) && Directory.Exists(game.modsPath) )
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    FileAttributes attr = File.GetAttributes(file);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        var dest = game.modsPath + "\\" + Path.GetFileName(Path.GetDirectoryName(file + "\\"));

                        Utility.CopyDirectory(file, dest);

                        PopulateModList(game.modsPath);

                    }
                }
            }
        }

        #endregion


        // Too lazy to put this in a different class rn
        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;

            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "." + filename))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        private void lvw_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_mods.SelectedItems.Count == 0) lbl_currentMod.Text = "";
            else lbl_currentMod.Text = lvw_mods.SelectedItems[0].Text;
        }
    }
}
