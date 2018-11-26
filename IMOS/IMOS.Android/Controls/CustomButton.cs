using Android.Content;
using Android.Widget;
using IMOS.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButton))]
namespace IMOS.Droid.Controls
{
    public class CustomButton : ButtonRenderer
    {
        public CustomButton(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) 
        { 
            base.OnElementChanged(e); 
            var button = this.Control; 
            button.SetAllCaps(false); 
        }
    }
}