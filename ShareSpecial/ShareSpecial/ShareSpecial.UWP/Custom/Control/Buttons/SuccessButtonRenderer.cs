using ShareSpecial.Utils.Controls;
using ShareSpecial.UWP.Custom.Control.Buttons;
using ShareSpecial.UWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRendererAttribute(typeof(SuccessButton), typeof(SuccessButtonRenderer))]
namespace ShareSpecial.UWP.Custom.Control.Buttons
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
