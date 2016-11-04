using ShareSpecial.Utils.Controls;
using ShareSpecial.Windows;
using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRendererAttribute(typeof(PrimaryButton), typeof(PrimaryButtonRenderer))]

namespace ShareSpecial.Windows
{
    public class PrimaryButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.BackgroundColor = new SolidColorBrush(ColorHelper.FromArgb((byte)Convert.ToUInt32(255),
                //    (byte)Convert.ToUInt32(93),
                //    (byte)Convert.ToUInt32(173),
                //    (byte)Convert.ToUInt32(226)));

                Control.BackgroundColor = GetSolidColorBrush("#87ceeb");
                Control.Foreground = GetSolidColorBrush("#000000");
            }
        }

        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            string colour = hex;

            var color2 = ColorHelper.FromArgb(Convert.ToByte(255),
            Convert.ToByte(colour.Substring(1, 2), 16),
            Convert.ToByte(colour.Substring(3, 2), 16),
            Convert.ToByte(colour.Substring(5, 2), 16));

            return new SolidColorBrush(color2);
        }
    }
}
