using SkolniFotograf.Model.Galleries;

namespace SkolniFotograf
{
    internal class ComboGaleryItem
    {
        private Gallery _gallery;

        public Gallery Gallery
        {
            get { return _gallery; }
        }

        public ComboGaleryItem(Gallery gallery)
        {
            _gallery = gallery;
        }

        public override string ToString()
        {
            return _gallery.Name;
        }
    }
}