using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace JK4Life
{

    class AssemblyPatcher
    {

        public static List<Patch> ReadPatchList(string gameName, List<string> patches, string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            List<Patch> injects = new List<Patch>();

            foreach (string patchName in patches)
            {

                XmlNode patch = doc.DocumentElement.SelectSingleNode("/games/" + gameName + "/patch[@name='" + patchName + "']");

                foreach (XmlNode inject in patch.SelectNodes("injects/inject"))
                {

                    uint address = Convert.ToUInt32(inject.SelectSingleNode("address").InnerText, 16);
                    string instruction = inject.SelectSingleNode("instruction").InnerText;

                    instruction = Regex.Replace(instruction, @"\s+", "");

                    injects.Add(new Patch(address, Utility.stringToByteArrayFastest(instruction)));

                }
            }

            return injects;
        }

        public static void PatchExecutable(List<Patch> patchList, string targetPath, string outputPath)
        {
            string gamePath = Path.GetDirectoryName( targetPath );

            if (File.Exists( outputPath )) File.Delete( outputPath );

            File.Copy(targetPath, outputPath);


            using (BinaryWriter b = new BinaryWriter(File.OpenWrite(outputPath)))
            {
                foreach (var inject in patchList)
                {
                    b.BaseStream.Seek(inject.offset, SeekOrigin.Begin);
                    b.Write(inject.patch);
                }
            }
        }

    }

    class Patch
    {
        public uint offset;
        public byte[] patch;

        public Patch(uint offset, byte[] patch)
        {
            this.offset = offset;
            this.patch = patch;
        }

    }
}
