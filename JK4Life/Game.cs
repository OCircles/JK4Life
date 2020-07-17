using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JK4Life
{




    public class Game
    {

        public GameControl control;

        public string fullName;
        public string name;
        public string[] executableNames; // For monitoring/reading processes

        public uint multiplayerConnect; // Offset to check for connection status
        public uint multiplayerIP; // Offset to find MP session IP string


        // These methods seem kinda sketchy but it works
        public string path
        {
            get { return Properties.Settings.Default[name + "_Path"].ToString(); }
            set { Properties.Settings.Default[name + "_Path"] = value; Properties.Settings.Default.Save(); }
        }
        public string modsPath
        {
            get { return Properties.Settings.Default[name + "_Mods_Path"].ToString(); }
            set { Properties.Settings.Default[name + "_Mods_Path"] = value; }
        }


        public Game(string fullName, string name, string[] executableNames, string path, string modsPath, uint multiplayerConnect, uint multiplayerIP)
        {
            this.fullName = fullName;
            this.name = name;
            this.executableNames = executableNames;
            this.path = path;
            this.modsPath = modsPath;
            this.multiplayerConnect = multiplayerConnect;
            this.multiplayerIP = multiplayerIP;

            control = new GameControl(this);
        }

    }

}
