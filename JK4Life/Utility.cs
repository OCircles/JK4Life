using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JK4Life
{
    class Utility
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

        public static string ShortPath(string path)
        {
            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(path, shortPath, shortPath.Capacity);
            return shortPath.ToString();
        }
        public static string GetReadableVersion()
        {
            // Returns major + minor version of assembly (example: 1.0)
            string[] version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
            return version[0] + '.' + version[1];
        }




        public static void CopyDirectory(string strSource, string strDestination)
        {
            if (!Directory.Exists(strDestination))
            {
                Directory.CreateDirectory(strDestination);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(strSource);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo tempfile in files)
            {
                tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo tempdir in directories)
            {
                CopyDirectory(Path.Combine(strSource, tempdir.Name), Path.Combine(strDestination, tempdir.Name));
            }

        }



        public static byte[] stringToByteArrayFastest(string hex)
        {
            // From CainKellye's answer on https://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array

            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }
        public static int GetHexVal(char hex)
        {
            // From CainKellye's answer on https://stackoverflow.com/questions/321370/how-can-i-convert-a-hex-string-to-a-byte-array

            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }


        public static string GetClosestPath(string path)
        {
            // Check if directory at path exists, and if not return the closest past (just traverses down parents)
            // Returns null if the drive is gone or input is null or empty

            // Made to be used with FileDialog.InitialDirectory + FileDialog.RestoreDirectory combo; see BrowseForModFolder()

            if (!string.IsNullOrEmpty(path))
            {
                if (!Directory.Exists(Path.GetPathRoot(path)))
                {
                    return null;
                }

                string ret = path;

                while (!Directory.Exists(ret))
                {
                    DirectoryInfo info = Directory.GetParent(ret);
                    ret = info.FullName;
                }

                return ret;

            }

            return null;

        }


    }
}
