using SkolniFotograf.Core;
using System.Collections.Generic;
using System;

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
            string photoKeyName = NameHelpers.CreateKeyName(photoName);

            if (_photosFullPaths.ContainsKey(photoKeyName))
            {
                _photosFullPaths[photoKeyName] = photoFullPath;
                return;
            }

            _photosFullPaths.Add(photoKeyName, photoFullPath);
        }

        public string GetPhotoFullPath(string photoName)
        {
            string photoKeyName = NameHelpers.CreateKeyName(photoName);

            if (_photosFullPaths.ContainsKey(photoKeyName))
            {
                return _photosFullPaths[photoKeyName];
            }

            throw new PhotoCopyException(String.Format("Source file for '{0}' doesn't exist!", photoName));
        }

        private IDictionary<string, string> _photosFullPaths;
    }
}
