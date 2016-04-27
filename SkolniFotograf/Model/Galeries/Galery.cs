using System;
using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galeries
{
    internal class Galery
    {
        public string Name
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        public IList<Customer> Customers
        {
            get; set;
        }

        internal void Load(XmlNode galeryNode)
        {
            Name = galeryNode.Attributes.GetNamedItem("name").Value;
            Price = Double.Parse(galeryNode.Attributes.GetNamedItem("price").Value);
        }
    }
}
