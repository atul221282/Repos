
using Windows.UI.Xaml.Media;

namespace ShareSpecial.UWP.Helpers
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
