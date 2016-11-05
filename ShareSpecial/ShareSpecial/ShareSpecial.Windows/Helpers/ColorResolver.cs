using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ShareSpecial.Windows.Helpers
{
    public class ColorResolver : IColorResolver
    {
        #region Primary

        public string Primary => "#008cba";
        public string PrimaryHover => "#006687";
        public string PrimaryBorder => "#0079a1";
        public string PrimaryBorderHover => "#004b63";
        public string PrimaryText => "#ffffff";

        #endregion

        #region Danger

        public string Danger => "#f04124";
        public string DangerHover => "#d32a0e";
        public string DangerBorder => "#ea2f10";
        public string DangerBorderHover => "#b1240c";
        public string DangerText => "#ffffff";

        #endregion

        #region Success

        public string Success => "#43ac6a";
        public string SuccessHover => "#358753";
        public string SuccessBorder => "#3c9a5f";
        public string SuccessBorderHover => "#2b6e44";
        public string SuccessText => "#ffffff";

        #endregion

        public SolidColorBrush GetColorViaHex(string hexCode)
        {
            string colour = hexCode;

            var color2 = ColorHelper.FromArgb(Convert.ToByte(255),
            Convert.ToByte(colour.Substring(1, 2), 16),
            Convert.ToByte(colour.Substring(3, 2), 16),
            Convert.ToByte(colour.Substring(5, 2), 16));

            return new SolidColorBrush(color2);
        }
    }
}
