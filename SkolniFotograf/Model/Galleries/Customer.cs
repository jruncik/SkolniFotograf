using System;
using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galleries
{
    public class Customer
    {
        public string Name
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        public IList<PhotoType> PhotoTypes
        {
            get; set;
        }

        public Customer()
        {
            PhotoTypes = new List<PhotoType>();
        }

        internal void Load(XmlNode customerNode)
        {
            PhotoTypes.Clear();

            Name = customerNode.Attributes.GetNamedItem("name").Value;
            Email = customerNode.Attributes.GetNamedItem("email").Value;
            Price = Double.Parse(customerNode.Attributes.GetNamedItem("price").Value);

            XmlNodeList photoTypesNodes = customerNode.SelectNodes("photoTypes/type");
            foreach (XmlNode photoTypeNode in photoTypesNodes)
            {
                PhotoType photoType = new PhotoType();
                photoType.Load(photoTypeNode);

                PhotoTypes.Add(photoType);
            }
        }
    }
}
