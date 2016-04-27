using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galeries
{
    internal class Galeries
    {
        public IList<Galery> AllGaleries
        {
            get; set;
        }

        public Galeries()
        {
            AllGaleries = new List<Galery>();
        }

        public void Load(XmlDocument xmlDef)
        {
            AllGaleries.Clear();

            XmlNodeList galeriesNodes = xmlDef.SelectNodes("/galeries/galery");
            foreach (XmlNode galeryNode in galeriesNodes)
            {
                Galery galery = new Galery();
                galery.Load(galeryNode);

                AllGaleries.Add(galery);
            }
        }
    }
}
