using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace CustomIconizeFont.Droid.Helpers
{
    public static class FormsToNativeDroid
    {
        public static View ConvertFormsToNative(this Xamarin.Forms.View view, Context context, Rectangle size)
        {
            var vRenderer = Platform.CreateRendererWithContext(view, context);
            var viewGroup = vRenderer.View;
            vRenderer.Tracker.UpdateLayout();
            var layoutParams = new ViewGroup.LayoutParams((int)size.Width, (int)size.Height);
            viewGroup.LayoutParameters = layoutParams;
            view.Layout(size);
            viewGroup.Layout(0, 0, (int)view.WidthRequest, (int)view.HeightRequest);

            return viewGroup;
        }
    }
}