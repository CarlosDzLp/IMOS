using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigTed;
using Foundation;
using IMOS.Dependency;
using IMOS.iOS.Dependency;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(Progress))]
namespace IMOS.iOS.Dependency
{
    public class Progress : IProgressDialog
    {
        public void ProgressDialogHide()
        {
            BTProgressHUD.Dismiss();
        }

        public void ProgressDialogShow()
        {
            BTProgressHUD.Show("Cargando...", -1, ProgressHUD.MaskType.Black);
        }
    }
}