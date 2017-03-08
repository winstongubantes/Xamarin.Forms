using System;
using Android.OS;
using Android.Widget;
using CustomSlideOverMenu.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(NoBorderEntryEffect), "NoBorderEntryEffect")]

namespace CustomSlideOverMenu.Droid.Effects
{
    public class NoBorderEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textView = (TextView) Control;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean) // Suppose we wrote getApiLevel() helper to get the API level
                textView.SetBackground(null);
            else
#pragma warning disable 618
                textView.SetBackgroundDrawable(null);
#pragma warning restore 618
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}