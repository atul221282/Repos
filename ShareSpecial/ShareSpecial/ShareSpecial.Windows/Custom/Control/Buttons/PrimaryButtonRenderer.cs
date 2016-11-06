using ShareSpecial.Utils.Controls;
using ShareSpecial.Windows;
using ShareSpecial.Windows.Custom.Control.Buttons;
using ShareSpecial.Windows.Helpers;
using System;
using System.Diagnostics;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;
using Helpers = ShareSpecial.Windows.Helpers;


[assembly: ExportRendererAttribute(typeof(PrimaryButton), typeof(PrimaryButtonRenderer))]

namespace ShareSpecial.Windows.Custom.Control.Buttons
{
    public class PrimaryButtonRenderer : ButtonRenderer
    {
        IButtonHelper buttonHelper;
        public PrimaryButtonRenderer()
        {
            this.buttonHelper = new Helpers.ButtonHelper();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            buttonHelper.SetPrimary(Control);
        }
    }
}


