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
        #region Primary
        string Primary { get;}
        string PrimaryHover { get;}
        string PrimaryBorder { get; }
        string PrimaryBorderHover { get; }
        string PrimaryText { get; }
        #endregion

        #region Danger
        string Danger { get; }
        string DangerHover { get; }
        string DangerBorder { get; }
        string DangerBorderHover { get; }
        string DangerText { get; }
        #endregion

        #region Success
        string Success { get; }
        string SuccessHover { get; }
        string SuccessBorder { get; }
        string SuccessBorderHover { get; }
        string SuccessText { get; }
        #endregion

        SolidColorBrush GetColorViaHex(string hexCode);
    }
}
