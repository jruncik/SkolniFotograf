using System;
using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galleries
{
    public class Gallery
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

        public Gallery()
        {
            Customers = new List<Customer>();
        }

        internal void Load(XmlNode galleryNode)
        {
            Customers.Clear();

            Name = galleryNode.Attributes.GetNamedItem("name").Value;
            Price = Double.Parse(galleryNode.Attributes.GetNamedItem("price").Value);

            XmlNodeList custommersNodes = galleryNode.SelectNodes("orders/customer");
            foreach (XmlNode customerNode in custommersNodes)
            {
                Customer customer = new Customer();
                customer.Load(customerNode);

                Customers.Add(customer);
            }
        }
    }
}
