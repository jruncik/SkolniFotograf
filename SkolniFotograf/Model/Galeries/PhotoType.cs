using System.Collections.Generic;

namespace SkolniFotograf.Model.Galeries
{
    internal class PhotoType
    {
        public string Name
        {
            get; set;
        }

        public IList<Photo> Photos
        {
            get; set;
        }
    }
}
