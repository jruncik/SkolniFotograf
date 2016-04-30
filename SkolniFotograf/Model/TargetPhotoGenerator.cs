using System.Collections.Generic;
using System.IO;
using System.Text;

using SkolniFotograf.Core;
using SkolniFotograf.Model.Directories;
using SkolniFotograf.Model.Galleries;

namespace SkolniFotograf.Model
{
    public class TargetPhotoGenerator
    {
        public IList<PhotoCopyInfo> PhotoCopyInfos
        {
            get { return _photoCopyInfo; }
        }

        public ICollection<string> TargetDirectories
        {
            get { return _photoTypeDirectory.Values; }
        }

        public TargetPhotoGenerator(Gallery gallery, string targetDirectory, IPhotosPaths photoPaths)
        {
            _targetDirectory = targetDirectory;
            _photoPaths = photoPaths;
            _gallery = gallery;

            _photoTypeDirectory = new Dictionary<string, string>(4);
            _photoCopyInfo = new List<PhotoCopyInfo>(128);
        }

        public void GenerateTargetPhotos()
        {
            _index = 1;

            _galeryName = NameHelpers.CreateKeyName(_gallery.Name);

            foreach (Customer customer in _gallery.Customers)
            {
                GenerateCustomerPhotos(customer);
            }
        }

        private void GenerateCustomerPhotos(Customer customer)
        {
            StringBuilder photoName = new StringBuilder();

            _galeryAndCustomerName = _galeryName + '_' + NameHelpers.CreateKeyName(customer.Name);

            foreach (PhotoType photoType in customer.PhotoTypes)
            {
                string photoTypeKeyName = NameHelpers.CreateKeyName(photoType.Name);
                string targetPhotoDirectory = GetDirectoryAccordingPhotoType(photoTypeKeyName);

                foreach (Photo photo in photoType.Photos)
                {
                    for (int i = 0; i < photo.Quantity;  ++i)
                    {
                        string textIndex = _index.ToString("0000");
                        ++_index;

                        photoName.Clear();
                        photoName.Append(targetPhotoDirectory);

                        photoName.Append('\\');
                        photoName.Append(textIndex);
                        photoName.Append('_');
                        photoName.Append(_galeryAndCustomerName);
                        photoName.Append('_');
                        photoName.Append(photoTypeKeyName);
                        photoName.Append('_');
                        photoName.Append(GeneratePhotoName(photo));

                        PhotoCopyInfo photocopyInfo = new PhotoCopyInfo();
                        photocopyInfo.DestFullFileName = photoName.ToString();
                        photocopyInfo.SrcFullFileName = _photoPaths.GetPhotoFullPath(photo.Name);

                        _photoCopyInfo.Add(photocopyInfo);
                    }
                }
            }
        }

        private string GeneratePhotoName(Photo photo)
        {
            string photoName = NameHelpers.CreateKeyName(Path.GetFileNameWithoutExtension(photo.Name));
            photoName += Path.GetExtension(photo.Name);
            return photoName;
        }

        private string GetDirectoryAccordingPhotoType(string photoTypeKeyName)
        {
            if (_photoTypeDirectory.ContainsKey(photoTypeKeyName))
            {
                return _photoTypeDirectory[photoTypeKeyName];
            }

            string photoTypeDirectoryName = _targetDirectory + @"\" + photoTypeKeyName;
            _photoTypeDirectory[photoTypeKeyName] = photoTypeDirectoryName;
            return photoTypeDirectoryName;
        }

        private string _targetDirectory;
        private readonly Gallery _gallery;
        private readonly IPhotosPaths _photoPaths;

        private IDictionary<string, string> _photoTypeDirectory;

        private int _index;

        private string _galeryName;
        private string _galeryAndCustomerName;

        private IList<PhotoCopyInfo> _photoCopyInfo;
    }
}
