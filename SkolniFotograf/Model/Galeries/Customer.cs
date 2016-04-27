using System.Collections.Generic;

namespace SkolniFotograf.Model.Galeries
{
    internal class Customer
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
    }
}
