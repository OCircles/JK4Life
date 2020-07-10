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
    public partial class Form1 : Form
    {

        // Unfortunately this is needed because JK's argument handler is dumb and doesn't know how to handle quotes
        // So -path argument becomes broken when you have a space in ur mod folder path. Needs the no-spaces shortened path
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)]
            string path,
            [MarshalAs(UnmanagedType.LPTStr)]
            StringBuilder shortPath,
            int shortPathLength
        );


        private string md5_original = "1cbc984348811f40d0d520a1d43e9106"; // Checksum of 1.0 retail, originally wanted to do MD5 check stuff but idk if needed


        // Init
        public Form1()
        {
            Properties.Settings.Default.SettingChanging += SettingChanging;
            InitializeComponent();
            this.Text = "JK4Life v" + Utility.GetReadableVersion();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // This is just for triggering SettingChangingEvent on every setting so that we don't need to populate lists and such manually
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                Properties.Settings.Default[currentProperty.Name] = Properties.Settings.Default[currentProperty.Name];
            }

            // Populate assembly patch list
            // Maybe put all this in seperate function including validation? Just gonna keep this for now
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetResourceTextFile("patches.xml"));

            PopulatePatchList(checkedListBox5, doc.DocumentElement.SelectSingleNode("/games/jk"));
            PopulatePatchList(checkedListBox6, doc.DocumentElement.SelectSingleNode("/games/mots"));

        }



        // Big important stuff here
        void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {

            Console.WriteLine(e.SettingName);

            switch(e.SettingName)
            {
                case "JK_Path":
                    textBox1.Text = (string)e.NewValue;
                    break;

                case "MotS_Path":
                    textBox2.Text = (string)e.NewValue;
                    break;

                case "JK_Mods_Path":
                    textBox3.Text = (string)e.NewValue;
                    PopulateModList(box, (string)e.NewValue);
                    break;

                case "MotS_Mods_Path":
                    textBox4.Text = (string)e.NewValue;
                    PopulateModList(checkedListBox2, (string)e.NewValue);
                    break;

            }

        }





        // Launch - Populate
        private void PopulateModList(CheckedListBox listBox, string path)
        {
            listBox.Items.Clear();

            if(Directory.Exists(path))
            {
                foreach ( var dir in Directory.GetDirectories(path) )
                {
                    // Check if subdirectories contain either .gob or .jk
                    bool isMod = false;
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        var ext = Path.GetExtension(file);
                        if (ext == ".gob" || ext == ".goo" || ext == ".jk")
                        {
                            isMod = true;
                            break;
                        }
                    }
                    if (isMod) listBox.Items.Add(Path.GetFileName(dir));
                }

            }

        }
        private void PopulatePatchList(CheckedListBox checkedListBox, XmlNode gameRoot)
        {
            checkedListBox.Items.Clear();

            if (gameRoot.ChildNodes != null)
            {
                foreach (XmlNode node in gameRoot.ChildNodes)
                {
                    checkedListBox.Items.Add(node.Attributes["name"]?.InnerText);
                }
            }
        }


        // Launch - UI
        private void button6_Click(object sender, EventArgs e)
        {
            Launch("jk");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Launch("mots");
        }


        // Launch - Events
        private void checkedListBox_PreventMultiCheck(object sender, ItemCheckEventArgs e)
        {
            // Neat way of preventing multiple checked items without looping
            // Taken from Nicolas Tyler's answer at https://stackoverflow.com/questions/10553323/checkedlistbox-allowing-only-one-item-to-be-checked

            CheckedListBox box = (CheckedListBox)sender;

            if (e.NewValue == CheckState.Checked && box.CheckedItems.Count > 0)
            {
                box.ItemCheck -= checkedListBox_PreventMultiCheck;
                box.SetItemChecked(box.CheckedIndices[0], false);
                box.ItemCheck += checkedListBox_PreventMultiCheck;
            }
        }


        // WHAT HAVE I DONE... (cleanup asap)
        private void Launch(string game)
        {
            // Get list of selected assembly patches

            List<string> patches = new List<string>();
            string target = "";
            string mod = "";

            // Also check for executables defined in properties. I'm too lazy to figure out a nicer way of doing this, using return is pretty sweet
            if (game == "jk")
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.JK_Path) || !File.Exists(Properties.Settings.Default.JK_Path))
                {
                    MessageBox.Show("Jedi Knight executable could not be located!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    BrowseForFile("Jedi Knight|*.exe", "JK_Path");

                    if (string.IsNullOrEmpty(Properties.Settings.Default.JK_Path) || !File.Exists(Properties.Settings.Default.JK_Path)) return;

                }

                foreach (string patch in checkedListBox5.CheckedItems) { patches.Add(patch); }

                target = Properties.Settings.Default.JK_Path;

                if (box.CheckedItems.Count != 0)  mod = Properties.Settings.Default.JK_Mods_Path + "\\" + box.CheckedItems[0].ToString();
            }
            else if (game == "mots")
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.MotS_Path) || !File.Exists(Properties.Settings.Default.MotS_Path))
                {
                    MessageBox.Show("Mysteries of the Sith executable could not be located!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    BrowseForFile("Mysteries of the Sith|*.exe", "MotS_Path");

                    if (string.IsNullOrEmpty(Properties.Settings.Default.MotS_Path) || !File.Exists(Properties.Settings.Default.MotS_Path)) return;

                }
                foreach (string patch in checkedListBox6.CheckedItems) { patches.Add(patch); }

                target = Properties.Settings.Default.MotS_Path;

                if (checkedListBox2.CheckedItems.Count != 0) mod = Properties.Settings.Default.MotS_Mods_Path + "\\" + checkedListBox2.CheckedItems[0].ToString();
            }


            Console.WriteLine(mod);

            // All validation is done! Apply patches from XML

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetResourceTextFile("patches.xml"));

            List<Patch> injects = new List<Patch>();

            foreach (string patchName in patches)
            {

                XmlNode patch = doc.DocumentElement.SelectSingleNode("/games/" + game + "/patch[@name='" + patchName + "']");

                foreach (XmlNode inject in patch.SelectNodes("injects/inject"))
                {

                    uint address = Convert.ToUInt32(inject.SelectSingleNode("address").InnerText, 16);
                    string instruction = inject.SelectSingleNode("instruction").InnerText;

                    instruction = Regex.Replace(instruction, @"\s+", "");

                    //Console.WriteLine(address + " " + instruction);

                    injects.Add(new Patch(address,Utility.stringToByteArrayFastest(instruction)));

                }
            }

            Console.WriteLine(target);

            string gamePath = Path.GetDirectoryName(target);
            string patched = gamePath + "\\" + Path.GetFileNameWithoutExtension(target) + "_Patched.exe";

            if (File.Exists(patched)) File.Delete(patched);

            File.Copy(target, patched);


            using (BinaryWriter b = new BinaryWriter(File.OpenWrite(patched)))
            {
                foreach (var inject in injects)
                {
                    b.BaseStream.Seek(inject.offset, SeekOrigin.Begin);
                    b.Write(inject.patch);
                }
            }


            string arguments = GetArguments();

            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(mod, shortPath, shortPath.Capacity);
            Console.WriteLine(shortPath.ToString());


            if (mod != "") arguments += " -path " + shortPath.ToString();

            Console.WriteLine(arguments);

            ProcessStartInfo startInfo = new ProcessStartInfo(patched, arguments);
            startInfo.WorkingDirectory = gamePath;
            Process.Start(startInfo);
        }


        // Launch - Utility
        private string GetArguments()
        {
            // This is kind of a dumb way of doing things, gonna replace the whole argument system later

            string s = "";

            if (checkBox1.Checked) s += " -windowgui";
            if (checkBox2.Checked) s += " -displayconfig";
            if (checkBox3.Checked) s += " -framerate";
            if (checkBox4.Checked) s += " -dev";

            return s;
        }





        // Browsy dialogs
        private void BrowseForFile(string filename, string propertyName)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = filename;
                dialog.RestoreDirectory = true;

                string exePath = Properties.Settings.Default[propertyName].ToString();

                // Will be the property path if set, closest path if path is missing, and adhere to dialog.RestoreDirectory behaviour if drive is missing altogether
                dialog.InitialDirectory = Utility.GetClosestPath(exePath);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Maybe add MD5 check here?

                    if (File.Exists(dialog.FileName))
                    {
                        Properties.Settings.Default[propertyName] = dialog.FileName;
                        Properties.Settings.Default.Save();
                    }
                }
            }


        }
        private void BrowseForModFolder(string propertyName)
        {

            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                dialog.RestoreDirectory = true;

                string modPath = Properties.Settings.Default[propertyName].ToString();

                // Will be the property path if set, closest path if path is missing, and adhere to dialog.RestoreDirectory behaviour if drive is missing altogether
                dialog.InitialDirectory = Utility.GetClosestPath(modPath);
                
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (Directory.Exists(dialog.FileName))
                    {
                        Properties.Settings.Default[propertyName] = dialog.FileName;
                        Properties.Settings.Default.Save();

                        // Console.WriteLine("Saving " + propertyName);
                    }
                }
            }
        }





       // Settings - UI
        private void button4_Click(object sender, EventArgs e)
        {
            BrowseForModFolder("JK_Mods_Path");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            BrowseForModFolder("MotS_Mods_Path");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BrowseForFile("Jedi Knight|*.exe", "JK_Path");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BrowseForFile("Mysteries of the Sith|*.exe", "MotS_Path");
        }





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
    }
}
