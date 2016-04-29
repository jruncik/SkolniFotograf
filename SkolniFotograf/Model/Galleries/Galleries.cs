using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galleries
{
    public class GaleriesCollection
    {
        public IList<Gallery> Galleries
        {
            get; set;
        }

        public GaleriesCollection()
        {
            Galleries = new List<Gallery>();
        }

        internal void Load(XmlDocument xmlDef)
        {
            Galleries.Clear();

            XmlNodeList galleriesNodes = xmlDef.SelectNodes("/galeries/galery");
            foreach (XmlNode galleryNode in galleriesNodes)
            {
                Gallery gallery = new Gallery();
                gallery.Load(galleryNode);

                Galleries.Add(gallery);
            }
        }
    }
}
