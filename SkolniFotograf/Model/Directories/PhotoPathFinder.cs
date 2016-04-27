using System.Diagnostics;
using System.IO;

namespace SkolniFotograf.Model.Directories
{
    public class PhotoPathFinder
    {
        public PhotoPathFinder(IPhotosPaths photosPaths)
        {
            _photosPaths = photosPaths;
        }

        public void AddPhotosFromDirectory(string directory, string fileExtensionFilter)
        {
            string[] filePaths = Directory.GetFiles(directory, fileExtensionFilter, SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
            {
                _photosPaths.AddPhoto(Path.GetFileName(filePath), filePath);
            }
        }

        private readonly IPhotosPaths _photosPaths;
    }
}
