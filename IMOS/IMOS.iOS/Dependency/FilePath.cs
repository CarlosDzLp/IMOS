using IMOS.Dependency;
using IMOS.iOS.Dependency;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePath))]
namespace IMOS.iOS.Dependency
{
    public class FilePath : IFilePath
    {
        public string GetPath()
        {
            try
            {
                string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, "IMOS.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}