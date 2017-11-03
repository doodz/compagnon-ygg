﻿using Doods.StdFramework.Interfaces;
using System.IO;
using Windows.Storage;

namespace CompagnonYgg.UWP.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

        public string GetDownloadPath()
        {
            return ApplicationData.Current.LocalFolder.Path;
            //return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        }
    }
}