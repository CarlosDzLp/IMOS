using System;
using CoreGraphics;
using IMOS.Controls;
using IMOS.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace IMOS.iOS.Controls
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (CustomEditor)Element;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
            }
        }
    }
}
