using ShareSpecial.Utils.Controls;
using ShareSpecial.Windows;
using ShareSpecial.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRendererAttribute(typeof(DangerButton), typeof(DangerButtonRenderer))]

namespace ShareSpecial.Windows
{
    public class DangerButtonRenderer : ButtonRenderer
    {
        IButtonHelper buttonHelper;
        public DangerButtonRenderer()
        {
            this.buttonHelper = new Helpers.ButtonHelper();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            buttonHelper.SetDanger(Control);
        }
    }
}
