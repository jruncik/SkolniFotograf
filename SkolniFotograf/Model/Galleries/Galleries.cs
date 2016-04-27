using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galeries
{
    public class GaleriesCollection
    {
        public IList<Galery> Galleries
        {
            get; set;
        }

        public GaleriesCollection()
        {
            Galleries = new List<Galery>();
        }

        internal void Load(XmlDocument xmlDef)
        {
            Galleries.Clear();

            XmlNodeList galeriesNodes = xmlDef.SelectNodes("/galeries/galery");
            foreach (XmlNode galeryNode in galeriesNodes)
            {
                Galery galery = new Galery();
                galery.Load(galeryNode);

                Galleries.Add(galery);
            }
        }
    }
}
