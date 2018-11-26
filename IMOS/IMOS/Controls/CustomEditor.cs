using System;
using Xamarin.Forms;

namespace IMOS.Controls
{
	public class CustomEditor : Editor
    {
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                typeof(Color), typeof(CustomEditor), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth),
                                    typeof(int), typeof(CustomEditor), 2);
        // Gets or sets BorderColor value  
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius),
                                    typeof(int), typeof(CustomEditor), 2);
        // Gets or sets BorderColor value  
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

    }
}
