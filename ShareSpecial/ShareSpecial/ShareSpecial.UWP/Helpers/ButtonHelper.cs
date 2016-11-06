using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

namespace ShareSpecial.UWP.Helpers
{
    public class ButtonHelper : IButtonHelper
    {
        IColorResolver ColorResolver;
        public ButtonHelper()
        {
            this.ColorResolver = new ColorResolver();
        }
        public void SetPrimary(FormsButton button)
        {
            button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.PrimaryText);
            button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Primary);
            button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.PrimaryBorder);

            button.PointerMoved += (sender, eventsArgs) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                    if (control.IsPointerOver || control.IsPressed)
                    {
                        button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.PrimaryText);
                        button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.PrimaryHover);
                        button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.PrimaryBorderHover);
                    }
            };

            button.PointerExited += (sender, eventsArg) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                {
                    button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.PrimaryText);
                    button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Primary);
                    button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.PrimaryBorder);
                }
            };
        }

        public void SetDanger(FormsButton button)
        {
            button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.DangerText);
            button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Danger);
            button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.DangerBorder);

            button.PointerMoved += (sender, eventsArgs) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                    if (control.IsPointerOver || control.IsPressed)
                    {
                        button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.DangerText);
                        button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.DangerHover);
                        button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.DangerBorderHover);
                    }
            };

            button.PointerExited += (sender, eventsArg) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                {
                    button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.DangerText);
                    button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Danger);
                    button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.DangerBorder);
                }
            };
        }

        public void SetSuccess(FormsButton button)
        {
            button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.SuccessText);
            button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Success);
            button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.SuccessBorder);

            button.PointerMoved += (sender, eventsArgs) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                    if (control.IsPointerOver || control.IsPressed)
                    {
                        button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.SuccessText);
                        button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.SuccessHover);
                        button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.SuccessBorderHover);
                    }
            };

            button.PointerExited += (sender, eventsArg) =>
            {
                var control = sender as FormsButton;
                if (control != null)
                {
                    button.Foreground = ColorResolver.GetColorViaHex(ColorResolver.SuccessText);
                    button.BackgroundColor = ColorResolver.GetColorViaHex(ColorResolver.Success);
                    button.BorderBrush = ColorResolver.GetColorViaHex(ColorResolver.SuccessBorder);
                }
            };
        }
    }
}
