using ShareSpecial.Utils.Controls;
using ShareSpecial.Windows;
using ShareSpecial.Windows.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRendererAttribute(typeof(SuccessButton), typeof(SuccessButtonRenderer))]

namespace ShareSpecial.Windows
{
    public class SuccessButtonRenderer : ButtonRenderer
    {
        IButtonHelper buttonHelper;
        public SuccessButtonRenderer()
        {
            this.buttonHelper = new Helpers.ButtonHelper();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            buttonHelper.SetSuccess(Control);
        }
    }
}
