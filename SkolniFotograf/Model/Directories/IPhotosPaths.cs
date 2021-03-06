﻿namespace SkolniFotograf.Model.Directories
{
    public interface IPhotosPaths
    {
        void AddPhoto(string photoName, string photoFullPath);
        string GetPhotoFullPath(string photoName);
    }
}