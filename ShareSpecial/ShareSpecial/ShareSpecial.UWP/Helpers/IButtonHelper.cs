using Xamarin.Forms.Platform.UWP;

namespace ShareSpecial.UWP.Helpers
{
    public interface IButtonHelper
    {
        /// <summary>
        /// Set bootstrap primary button effects. Creates hover over effects
        /// </summary>
        /// <param name="button">button</param>
        void SetPrimary(FormsButton button);

        /// <summary>
        /// Set bootstrap danger button effects. Creates hover over effects
        /// </summary>
        /// <param name="button">button</param>
        void SetDanger(FormsButton button);

        /// <summary>
        /// Set bootstrap success button effects. Creates hover over effects
        /// </summary>
        /// <param name="button">button</param>
        void SetSuccess(FormsButton button);
    }
}