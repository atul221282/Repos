using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShareSpecial.Utils.Controls;
using ShareSpecial.Droid.Custom.Control.Buttons;
using Android.Content.Res;

[assembly: ExportRendererAttribute(typeof(SuccessButton), typeof(SuccessButtonRenderer))]
namespace ShareSpecial.Droid.Custom.Control.Buttons
{
    public class SuccessButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public SuccessButtonRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> changeEvent)
        {
            base.OnElementChanged(changeEvent);

            var backgroundColor = Color.FromHex("43ac6a");

            int num = backgroundColor.ToAndroid().ToArgb();

            int num2 = backgroundColor.MultiplyAlpha(0.5).ToAndroid().ToArgb();

            Control.SupportBackgroundTintList = new ColorStateList(ColorExtensions.States, new int[] { num, num2 });

            Control.SetTextColor(Color.FromHex("#ffffff").ToAndroid());
        }
    }
}