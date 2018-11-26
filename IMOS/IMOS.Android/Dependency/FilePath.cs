using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IMOS.Dependency;
using Xamarin.Forms;
using IMOS.Droid.Dependency;
using System.Diagnostics;

[assembly: Dependency(typeof(FilePath))]
namespace IMOS.Droid.Dependency
{
    public class FilePath : IFilePath
    {
        public string GetPath()
        {
            try
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, "IMOS.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}