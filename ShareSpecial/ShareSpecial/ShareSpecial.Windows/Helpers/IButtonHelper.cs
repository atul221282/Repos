using Xamarin.Forms.Platform.WinRT;

namespace ShareSpecial.Windows.Helpers
{
    public interface IButtonHelper
    {
        /// <summary>
        /// Set primary button effects. Creates hover over effects
        /// </summary>
        /// <param name="button">button</param>
        void SetPrimary(FormsButton button);
    }
}