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
        public string Primary => "#008cba";

        public string PrimaryHover => "#006687";

        public string PrimaryBorder => "#0079a1";

        public string PrimaryBorderHover => "#004b63";

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
