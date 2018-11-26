using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using IMOS.Controls;
using IMOS.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]

namespace IMOS.Droid.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (CustomEditor)Element;
                if (view != null)
                {
                    // creating gradient drawable for the curved background  
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());
                    _gradientBackground.SetShape(ShapeType.Rectangle);

                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));

                    // set the background of the   
                    Control.SetBackground(_gradientBackground);
                }
                // Set padding for the internal text from border  
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }
        }
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}
