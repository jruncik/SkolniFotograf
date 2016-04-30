using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SkolniFotograf
{
    public class Settings
    {
        public string GalleriesPath { get; set; }

        public string PhotoSourceDirectory { get; set; }

        public string PhotoDestinationDirectory { get; set; }

        public void Load()
        {
            if (!File.Exists("PhotoCopy.cfg"))
            {
                GalleriesPath = String.Empty;
                PhotoSourceDirectory = String.Empty;
                PhotoDestinationDirectory = String.Empty;

                return;
            }

            XmlDocument settings = new XmlDocument();
            settings.Load("PhotoCopy.cfg");

            XmlNode settingsElem = settings.SelectSingleNode("Settings");

            GalleriesPath = settingsElem.Attributes.GetNamedItem("GalleriesPath").Value;
            PhotoSourceDirectory = settingsElem.Attributes.GetNamedItem("PhotoSourceDirectory").Value;
            PhotoDestinationDirectory = settingsElem.Attributes.GetNamedItem("PhotoDestinationDirectory").Value;
        }

        public void Save()
        {
            XmlDocument settings = new XmlDocument();

            XmlElement settingsElem = (XmlElement)settings.AppendChild(settings.CreateElement("Settings"));

            settingsElem.SetAttribute("GalleriesPath", GalleriesPath);
            settingsElem.SetAttribute("PhotoSourceDirectory", PhotoSourceDirectory);
            settingsElem.SetAttribute("PhotoDestinationDirectory", PhotoDestinationDirectory);

            settings.Save("PhotoCopy.cfg");
        }

    }
}
