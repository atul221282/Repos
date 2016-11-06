using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShareSpecial.Utils.Controls;
using ShareSpecial.Droid.Custom.Control.Buttons;
using Android.Graphics.Drawables;

[assembly: ExportRendererAttribute(typeof(SuccessButton), typeof(SuccessButtonRenderer))]
namespace ShareSpecial.Droid.Custom.Control.Buttons
{
    public class SuccessButtonRenderer : ButtonRenderer
    {
        public SuccessButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> changeEvent)
        {
            base.OnElementChanged(changeEvent);

            Control.SetBackgroundColor(Color.FromHex("#43ac6a").ToAndroid());
            Control.SetTextColor(Color.FromHex("#ffffff").ToAndroid());
        }
    }
}