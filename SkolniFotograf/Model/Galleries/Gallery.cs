using System;
using System.Collections.Generic;
using System.Xml;

namespace SkolniFotograf.Model.Galeries
{
    public class Galery
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

        public Galery()
        {
            Customers = new List<Customer>();
        }

        internal void Load(XmlNode galeryNode)
        {
            Customers.Clear();

            Name = galeryNode.Attributes.GetNamedItem("name").Value;
            Price = Double.Parse(galeryNode.Attributes.GetNamedItem("price").Value);

            XmlNodeList custommersNodes = galeryNode.SelectNodes("orders/customer");
            foreach (XmlNode customerNode in custommersNodes)
            {
                Customer customer = new Customer();
                customer.Load(customerNode);

                Customers.Add(customer);
            }
        }
    }
}
