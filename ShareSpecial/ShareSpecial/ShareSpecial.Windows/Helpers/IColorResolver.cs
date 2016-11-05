using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.WinRT;

namespace ShareSpecial.Windows.Helpers
{
    public interface IColorResolver
    {
        string Primary { get;}
        string PrimaryHover { get;}
        string PrimaryBorder { get; }
        string PrimaryBorderHover { get; }

        SolidColorBrush GetColorViaHex(string hexCode);
    }
}
