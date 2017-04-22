using DynamicTheming.Enums;
using DynamicTheming.Helpers;

namespace DynamicTheming.Extensions
{
    public class OnTheme<T>
    {
        public T Default { get; set; }
        public T Light { get; set; }
        public T Dark { get; set; }
        public T Lighter { get; set; }
        public T Darker { get; set; }

        public OnTheme()
        {
            Default = default(T);
            Light = default(T);
            Dark = default(T);
            Lighter = default(T);
            Darker = default(T);
        }

        public static implicit operator T(OnTheme<T> onPlatform)
        {
            switch (Settings.Theme)
            {
                case AppTheme.Dark:
                    return onPlatform.Dark;

                case AppTheme.Light:
                    return onPlatform.Light;

                case AppTheme.Darker:
                    return onPlatform.Darker;

                case AppTheme.Lighter:
                    return onPlatform.Lighter;

                default:
                    return onPlatform.Default;
            }
        }
    }
}
