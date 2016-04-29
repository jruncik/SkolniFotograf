using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galleries
{
    public class PhotoType
    {
        public string Name
        {
            get; set;
        }

        public IList<Photo> Photos
        {
            get; set;
        }

        public PhotoType()
        {
            Photos = new List<Photo>();
        }

        internal void Load(XmlNode photoTypeNode)
        {
            Photos.Clear();

            Name = photoTypeNode.Attributes.GetNamedItem("name").Value;

            XmlNodeList photoNodes = photoTypeNode.SelectNodes("photos/photo");
            foreach (XmlNode photoNode in photoNodes)
            {
                Photo photo= new Photo();
                photo.Load(photoNode);

                Photos.Add(photo);
            }

        }
    }
}
