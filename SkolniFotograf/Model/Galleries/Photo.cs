using System;
using System.Xml;

namespace SkolniFotograf.Model.Galleries
{
    public class Photo
    {
        public string Name
        {
            get; set;
        }

        public int Quantity
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        internal void Load(XmlNode photoNode)
        {
            Name = photoNode.Attributes.GetNamedItem("name").Value;
            Quantity = Int32.Parse(photoNode.Attributes.GetNamedItem("quantity").Value);
            Price = Double.Parse(photoNode.Attributes.GetNamedItem("price").Value);
        }
    }
}
