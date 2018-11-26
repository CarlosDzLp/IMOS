using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using IMOS.Dependency;
using IMOS.Droid.Dependency;
using Xamarin.Forms;

[assembly:Dependency(typeof(Progress))]
namespace IMOS.Droid.Dependency
{
    public class Progress : IProgressDialog
    {
        public void ProgressDialogHide()
        {
            AndHUD.Shared.Dismiss();
        }

        public void ProgressDialogShow()
        {
            AndHUD.Shared.Show(MainActivity.CurrentActivity, "Cargando...", -1, MaskType.Black, null, null, true, null);
        }
    }
}