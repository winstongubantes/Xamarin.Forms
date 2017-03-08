using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using CustomSlideOverMenu.Droid.Effects;
using PlatformSpecifics.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(CustomFontEffect), "FontEffect")]
namespace CustomSlideOverMenu.Droid.Effects
{
    public class CustomFontEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            SetFontName();
        }

        private void SetFontName()
        {
            if (typeof(Label) == Element.GetType())
            {
                var customFont = ((Label) Element).OnThisPlatform().IsCustomFont();
                if (customFont)
                    AwesomeUtil.CheckAndSetTypeFace((Control as TextView), ((Label) Element).FontFamily.ToLower());
            }
            else if (typeof(Xamarin.Forms.Button) == Element.GetType())
            {
                var customFont = ((Xamarin.Forms.Button) Element).OnThisPlatform().IsCustomFont();
                if (customFont)
                    AwesomeUtil.CheckAndSetTypeFace((Control as TextView), ((Xamarin.Forms.Button) Element).FontFamily.ToLower());
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "CustomFont")
            {
                SetFontName();
            }
        }

        internal static class AwesomeUtil
        {
            public static void CheckAndSetTypeFace(TextView view, string fontName)
            {
                var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, $"{fontName}.ttf");
                view.Typeface = font;
            }
        }
    }
}