  using System.Collections.Generic;

namespace SkolniFotograf.Model.Directories
{
    public class PhotosPaths : IPhotosPaths
    {
        public PhotosPaths()
        {
            _photosFullPaths = new Dictionary<string, string>();
        }

        public void AddPhoto(string photoName, string photoFullPath)
        {
            string photoKeyName = CreatePhotoKeyName(photoName);

            if (_photosFullPaths.ContainsKey(photoKeyName))
            {
                _photosFullPaths[photoKeyName] = photoFullPath;
                return;
            }

            _photosFullPaths.Add(photoKeyName, photoFullPath);
        }

        public static string CreatePhotoKeyName(string photoName)
        {
            string photoKeyName = photoName.Trim();
            photoKeyName = photoKeyName.Replace('.', '_');
            photoKeyName = photoKeyName.Replace('-', '_');

            return photoKeyName;
        }

        private IDictionary<string, string> _photosFullPaths;
    }
}
