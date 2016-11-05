using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.WinRT;

namespace ShareSpecial.Windows.Helpers
{
    public class ButtonHelper : IButtonHelper
    {
        IColorResolver colorResolver;
        public ButtonHelper()
        {
            this.colorResolver = new ColorResolver();
        }
        public void SetPrimary(FormsButton button)
        {
            button.Foreground = colorResolver.GetColorViaHex("#ffffff");
            button.BackgroundColor = colorResolver.GetColorViaHex("#008cba");
            button.BorderBrush = colorResolver.GetColorViaHex("#0079a1");

            button.PointerMoved += (sender, eventsArgs) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                    if (control.IsPointerOver || control.IsPressed)
                    {
                        button.BackgroundColor = colorResolver.GetColorViaHex("#006687");
                        button.BorderBrush = colorResolver.GetColorViaHex("#004b63");
                    }
            };

            button.PointerExited += (sender, eventsArg) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                {
                    button.Foreground = colorResolver.GetColorViaHex("#ffffff");
                    button.BackgroundColor = colorResolver.GetColorViaHex("#008cba");
                    button.BorderBrush = colorResolver.GetColorViaHex("#0079a1");
                }
            };
        }
    }
}
